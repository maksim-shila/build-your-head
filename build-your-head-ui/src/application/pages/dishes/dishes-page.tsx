import React from "react";
import { useTitle } from "../../../hooks/use-title";
import { Button } from "reactstrap";
import { DishesList } from "./components/dishes-list";
import { DishViewModal } from "./components/dish-view-modal";
import { DishFormData } from "./models/dish-form-data";
import { GlobalContext } from "../../context/global-context";
import { useLoader } from "../../../hooks/loader";
import { Dish } from "../../../api/models";

export const DishesPage: React.FC = () => {

    useTitle("Dishes");

    const { $api } = React.useContext(GlobalContext);

    const [dishes, setDishes] = React.useState<Dish[]>([]);
    const [activeDish, setActiveDish] = React.useState<Dish | null>(null);
    const [isDishViewModalOpen, setIsDishViewModalOpen] = React.useState(false);

    React.useEffect(() => {
        fetchDishes();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    const fetchDishes = useLoader(async (): Promise<void> => {
        const response = await $api.Dish.getAll();
        setDishes(response.data);
    })

    const toggleDishViewModal = () => setIsDishViewModalOpen(c => !c);

    const showDishViewModal = (dish: Dish | null) => {
        setActiveDish(dish);
        setIsDishViewModalOpen(true);
    }

    const handleSubmit = async (data: DishFormData) => {
        const isEdit = activeDish !== null;
        if (isEdit && !activeDish.id) {
            console.error("Edited dish hasn't id");
            return;
        }

        const { ...dish } = data;
        const response = await (isEdit ? $api.Dish.post(activeDish.id!, dish) : $api.Dish.put(dish));
        const dishId = response.data?.id;
        if (!dishId) {
            console.error(`Failed to ${isEdit ? "update" : "create"} dish`);
            return;
        }

        setActiveDish(null);
        setIsDishViewModalOpen(false);
        await fetchDishes();
    }

    const deleteDish = async (dish: Dish) => {
        if (!dish.id) {
            console.error("Couldn't delete dish without id");
            return;
        }
        await $api.Dish.delete(dish.id);
        await fetchDishes();
    }

    return (
        <React.Fragment>
            <Button onClick={() => showDishViewModal(null)}>Add Dish</Button>
            <DishesList
                dishes={dishes}
                onEdit={showDishViewModal}
                onDelete={deleteDish}
            />
            <DishViewModal
                isOpen={isDishViewModalOpen}
                toggle={toggleDishViewModal}
                dish={activeDish}
                onSubmit={handleSubmit}
            />
        </React.Fragment>
    )
}