import React, { FormEvent } from "react";
import { DishFormData } from "../models/dish-form-data";
import { DishForm } from "./dish-form";
import { Dish } from "../../../../api/models";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

const defaultData: DishFormData = {
    name: "",
    description: ""
}

interface Props {
    isOpen: boolean,
    toggle: () => unknown,
    dish: Dish | null,
    onSubmit: (dish: DishFormData) => unknown
}

export const DishViewModal: React.FC<Props> = ({ isOpen, toggle, dish, onSubmit }) => {

    const isEdit = dish !== null;

    const [data, setData] = React.useState<DishFormData>(defaultData);

    React.useEffect(() => {
        if (!isOpen) {
            return;
        }

        (async () => {
            const data: DishFormData = {
                name: dish?.name ?? defaultData.name,
                description: dish?.description ?? defaultData.description
            }
            setData(data);
        })();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [isOpen, dish])

    const handleSubmit = (e: FormEvent) => {
        e.preventDefault();
        onSubmit(data);
    }

    return (
        <Modal id="dishModal" isOpen={isOpen} toggle={toggle} size="lg">
            <ModalHeader toggle={toggle}>{isEdit ? "Edit Dish" : "Add Dish"}</ModalHeader>
            <ModalBody>
                <DishForm data={data} onChange={setData} />
            </ModalBody>
            <ModalFooter>
                <Button className="btn-success mt-4" onClick={handleSubmit}>{isEdit ? "Update" : "Add"}</Button>
            </ModalFooter>
        </Modal>)
}