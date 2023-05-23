import React from "react";
import { Recipe } from "../../../api/models";
import { useLoader } from "../../../hooks/loader";
import { GlobalContext } from "../../context/global-context";
import { useParams } from "react-router-dom";

interface Props {
}

type Params = {
    recipeId: string
}

export const RecipePage: React.FC<Props> = () => {

    const { recipeId } = useParams<Params>();
    const { $api } = React.useContext(GlobalContext);
    const [recipe, setRecipe] = React.useState<Recipe | null>(null);

    React.useEffect(() => {
        (async () => {
            document.title = "Loading...";
            const recipe = await fetchRecipe(Number(recipeId));
            if (recipe != null) {
                document.title = `Recipe: ${recipe.name}`;
            }
        })();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [recipeId]);

    const fetchRecipe = useLoader(async (id: number): Promise<Recipe | null> => {
        const request = $api.Recipe.get(id);
        const response = await request.invoke();
        const recipe = response.data;
        if (!response.success || recipe == null) {
            return null;
        }
        setRecipe(recipe);
        return recipe;
    });

    return (
        <React.Fragment>
            {recipe &&
                <div>
                    <div>{recipe.name}</div>
                    <div>{recipe.description}</div>
                </div>
            }
        </React.Fragment>
    )
}