import React from "react";
import { Dish } from "../../../api/models";
import { useLoader } from "../../../hooks/loader";
import { GlobalContext } from "../../context/global-context";
import { useParams } from "react-router-dom";

interface Props {

}

type Params = {
    dishId: string
}

export const DishPage: React.FC<Props> = () => {

    const { dishId } = useParams<Params>();
    const { $api } = React.useContext(GlobalContext);
    const [dish, setDish] = React.useState<Dish | null>(null);

    React.useEffect(() => {
        (async () => {
            document.title = "Loading...";
            const dish = await fetchDish(Number(dishId));
            document.title = `Dish: ${dish.name}`;
        })();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [dishId]);

    const fetchDish = useLoader(async (id: number): Promise<Dish> => {
        const response = await $api.Dish.get(id);
        const data = response.data;
        setDish(data);
        return data;
    });

    return (
        <React.Fragment>
            {dish &&
                <div>
                    <div>{dish.name}</div>
                    <div>{dish.description}</div>
                </div>
            }
        </React.Fragment>
    )
}