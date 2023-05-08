import { ApiCall, ApiClientBase } from "./core"
import { AttachImageRequest, Dish, Product } from "./models"

export interface IApiClient {
    login: (userName: string) => ApiCall<string>,
    Dish: {
        get: (id: number) => ApiCall<Dish>,
        getAll: () => ApiCall<Dish[]>,
        put: (dish: Dish) => ApiCall<Dish>,
        post: (id: number, dish: Dish) => ApiCall<Dish>,
        delete: (id: number) => ApiCall<string>
    },
    Product: {
        get: (id: number) => ApiCall<Product>,
        getAll: () => ApiCall<Product[]>,
        put: (product: Product) => ApiCall<Product>,
        post: (id: number, product: Product) => ApiCall<Product>,
        delete: (id: number) => ApiCall<string>,
        attachImage: (request: AttachImageRequest) => ApiCall<string>,
        getPrimaryImage: (productId: number) => ApiCall<string>
    },
    Image: {
        post: (imageBase64: string) => ApiCall<string>
    }
}

export class ApiClient extends ApiClientBase implements IApiClient {

    public login = (userName: string) => this.get<string>(`/login/${userName}`);

    public Dish = {
        get: (id: number) => this.get<Dish>(`/dish/${id}`),
        getAll: () => this.get<Dish[]>("/dish"),
        put: (dish: Dish) => this.put<Dish>("/dish", dish),
        post: (id: number, dish: Dish) => this.post<Dish>(`/dish/${id}`, dish),
        delete: (id: number) => this.delete<string>(`/dish/${id}`),
    }

    public Product = {
        get: (id: number) => this.get<Product>(`/product/${id}`),
        getAll: () => this.get<Product[]>("/product"),
        put: (product: Product) => this.put<Product>("/product", product),
        post: (id: number, product: Product) => this.post<Product>(`/product/${id}`, product),
        delete: (id: number) => this.delete<string>(`/product/${id}`),
        attachImage: (request: AttachImageRequest) => {
            const url = `/product/${request.productId}/image`;
            const body = { imagePath: request.imagePath, primary: request.primary };
            return this.post<string>(url, body);
        },
        getPrimaryImage: (productId: number) => this.get<string>(`/product/${productId}/image/primary`)
    }

    public Image = {
        post: (imageBase64: string) => this.post<string>("/image", { imageBase64 })
    }
}

