import React from "react";
import { Button } from "reactstrap";
import { DishesList } from "./components/dishes-list";
import { DishViewModal } from "./components/dish-view-modal";
import { DishFormData } from "./models/dish-form-data";
import { GlobalContext } from "../../context/global-context";
import { useLoader } from "../../../hooks/loader";
import { Dish } from "../../../api/models";
import { useNavigate } from "react-router-dom";

export const DishesPage: React.FC = () => {

    const { $api } = React.useContext(GlobalContext);
    const navigate = useNavigate();

    const [dishes, setDishes] = React.useState<Dish[]>([]);
    const [activeDish, setActiveDish] = React.useState<Dish | null>(null);
    const [isDishViewModalOpen, setIsDishViewModalOpen] = React.useState(false);

    React.useEffect(() => {
        document.title = "Dishes";
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

    const handleSubmit = useLoader(async (data: DishFormData) => {
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
        if (isEdit) {
            setActiveDish(null);
            setIsDishViewModalOpen(false);
            await fetchDishes();
        } else {
            navigate(`/dish/${dishId}`);
        }
    })

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