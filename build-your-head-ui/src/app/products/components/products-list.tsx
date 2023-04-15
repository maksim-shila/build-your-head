import React from "react"
import { Button, ButtonGroup, Table } from "reactstrap";
import { Product } from "../../../api/models/product";

interface ProductsListProps {
    products: Product[];
    onEdit: (product: Product) => unknown,
    onDelete: (product: Product) => unknown
}

export const ProductsList: React.FC<ProductsListProps> = ({ products, onEdit, onDelete }) => {

    return (
        <div>
            {products && products.length > 0 && <Table striped>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Carbs</th>
                        <th>Proteins</th>
                        <th>Fats</th>
                        <th>Nutrition</th>
                        <th />
                    </tr>
                </thead>
                <tbody>
                    {products.map(product => (
                        <tr key={product.id}>
                            <td>{product.name}</td>
                            <td>{product.description}</td>
                            <td>{product.carbohydrates}</td>
                            <td>{product.proteins}</td>
                            <td>{product.fats}</td>
                            <td>{product.nutrition}</td>
                            <td>
                                <ButtonGroup>
                                    <Button color="warning" onClick={() => onEdit(product)}>Edit</Button>
                                    <Button color="dark" onClick={() => onDelete(product)}>Delete</Button>
                                </ButtonGroup>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>}
        </div>
    );
}