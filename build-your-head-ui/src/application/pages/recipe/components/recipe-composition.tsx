import React from "react";
import { Recipe } from "../../../../api/models";
import { Button } from "reactstrap";
import { GlobalContext } from "../../../context/global-context";
import { AddProductsModal } from "./add-products-modal";

interface Props {
    recipe: Recipe
}

export const RecipeComposition: React.FC<Props> = ({ recipe }) => {

    const { $api } = React.useContext(GlobalContext);

    const [isAddProductsDialogShown, setIsAddProductsDialogShown] = React.useState(false);

    const handleAddProductClick = () => {
        setIsAddProductsDialogShown(true)
    }

    return (
        <React.Fragment>
            <h2>Composition</h2>
            <Button onClick={handleAddProductClick}>Add Product</Button>
            <AddProductsModal
                isOpen={isAddProductsDialogShown}
                toggle={() => setIsAddProductsDialogShown(prev => !prev)}
            />
        </React.Fragment>
    )
}