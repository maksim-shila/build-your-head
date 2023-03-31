import { Table } from "reactstrap";
import { Product } from "../api/api-client";

interface ProductsListProps {
    products: Product[]
}

export const ProductsList = (props: ProductsListProps) => {

    const { products } = { ...props };

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
                    </tr>
                </thead>
                <tbody>
                    {products.map(p => (
                        <tr key={p.id}>
                            <td>{p.name}</td>
                            <td>{p.description}</td>
                            <td>{p.carbohydrates}</td>
                            <td>{p.proteins}</td>
                            <td>{p.fats}</td>
                            <td>{p.nutrition}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>}
        </div>
    );
}