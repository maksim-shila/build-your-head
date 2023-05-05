import { Button, ButtonGroup, Col, Row, Table } from "reactstrap";
import { Dish } from "../../../../api/models";

interface Props {
    dishes: Dish[],
    onEdit: (dish: Dish) => unknown,
    onDelete: (dish: Dish) => unknown
}

export const DishesList: React.FC<Props> = ({ dishes, onEdit, onDelete }) => {
    return (
        <div>
            {dishes && dishes.length > 0 &&
                <Table striped className="products-table">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Description</th>
                            <th />
                        </tr>
                    </thead>
                    <tbody>
                        {dishes.map(dish => (
                            <tr key={dish.id}>
                                <td className="cell-name">{dish.name}</td>
                                <td className="cell-description">{dish.description}</td>
                                <td>
                                    <ButtonGroup>
                                        <Button color="warning" onClick={() => onEdit(dish)}>Edit</Button>
                                        <Button color="dark" onClick={() => onDelete(dish)}>Delete</Button>
                                    </ButtonGroup>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>}
        </div>
    );
}