import { useTitle } from "./hooks/use-title";

export const Home: React.FC = () => {

    useTitle("Build Your Head");

    return (
        <div>What a wonderful world</div>
    );
}