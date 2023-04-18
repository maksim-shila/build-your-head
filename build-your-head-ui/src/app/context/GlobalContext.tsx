import React from "react";
import { ApiClient } from "../../api/api-client";
import Cookies from "js-cookie";
import { useLoader } from "../../hooks/loader";
import { dateNowPlus } from "../../utils/date";

type User = {
    name: string;
    token: string;
}

interface IGlobalContext {
    $api: ApiClient;
    $user: User | null;
    login: (userName: string) => unknown;
    logout: () => unknown;
}

const DEFAULT_CLIENT = new ApiClient(null);

export const GlobalContext = React.createContext<IGlobalContext>({
    $api: DEFAULT_CLIENT,
    $user: null,
    login: () => { },
    logout: () => { }
});

interface GlobalContextProviderProps {
    children: React.ReactNode
}

const TOKEN_EXPIRATION_MIN = 2;

export const GlobalContextProvider: React.FC<GlobalContextProviderProps> = ({ children }) => {

    const [isReady, setIsReady] = React.useState(false);
    const [user, setUser] = React.useState<User | null>(null);
    const [apiClient, setApiClient] = React.useState<ApiClient>(DEFAULT_CLIENT);

    React.useEffect(() => {
        setUserFromCookies();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    const setUserFromCookies = useLoader(async () => {
        setIsReady(false);
        const userName = Cookies.get("user_name");
        const token = Cookies.get("token");
        if (userName && token) {
            setUser({ name: userName, token: token });
            setApiClient(new ApiClient(token));
        }
        setIsReady(true);
    });

    const login = async (userName: string) => {
        const token = await apiClient.login(userName);

        const expires = dateNowPlus({ minutes: TOKEN_EXPIRATION_MIN });
        Cookies.set("user_name", userName, { expires: expires });
        Cookies.set("token", token, { expires: expires });

        setUser({ name: userName, token: token });
        setApiClient(new ApiClient(token));
    }

    const logout = () => {
        Cookies.remove("user_name");
        Cookies.remove("token");
        setUser(null);
        setApiClient(new ApiClient(null));
    }

    return (
        <GlobalContext.Provider value={{
            $api: apiClient,
            $user: user,
            login: login,
            logout: logout
        }}>
            {isReady && children}
        </GlobalContext.Provider>
    )
}