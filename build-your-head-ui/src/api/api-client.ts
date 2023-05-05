import axios, { AxiosInstance, AxiosResponse, CreateAxiosDefaults } from "axios";
import { Dish, Product } from "./models";

axios.defaults.baseURL = process.env.REACT_APP_API_URL;
axios.defaults.headers.post["Content-Type"] = "application/json";
axios.defaults.headers.put["Content-Type"] = "application/json";

interface AttachImageRequest {
    productId: number,
    imagePath: string,
    primary: boolean
}

export class ApiClient {

    private readonly api: AxiosInstance;

    constructor(token: string | null | undefined) {
        const config: CreateAxiosDefaults = {
            baseURL: process.env.REACT_APP_API_URL,
            headers: {
                "Authorization": `Bearer ${token}`,
                get: {
                    "Accept": "application/json"
                },
                post: {
                    "Content-Type": "application/json"
                },
                put: {
                    "Content-Type": "application/json"
                }
            }
        }
        this.api = axios.create(config);
    }

    public login = async (userName: string): Promise<string> => {
        const response = await axios.get(`/login/${userName}`);
        const token = response.data;
        return token;
    }

    public readonly Dish = {
        get: (id: number): Promise<AxiosResponse<Dish>> => this.api.get(`/dish/${id}`),
        getAll: (): Promise<AxiosResponse<Dish[]>> => this.api.get("/dish"),
        put: (dish: Dish): Promise<AxiosResponse<Dish>> => this.api.put("/dish", dish),
        post: (id: number, dish: Dish): Promise<AxiosResponse<Dish>> => this.api.post(`/dish/${id}`, dish),
        delete: (id: number): Promise<AxiosResponse> => this.api.delete(`/dish/${id}`),
    }

    public readonly Product = {
        get: (id: number): Promise<AxiosResponse<Product>> => this.api.get(`/product/${id}`),
        getAll: (): Promise<AxiosResponse<Product[]>> => this.api.get("/product"),
        put: (product: Product): Promise<AxiosResponse<Product>> => this.api.put("/product", product),
        post: (id: number, product: Product): Promise<AxiosResponse<Product>> => this.api.post(`/product/${id}`, product),
        delete: (id: number): Promise<AxiosResponse> => this.api.delete(`/product/${id}`),
        attachImage: (req: AttachImageRequest): Promise<AxiosResponse> => this.api.post(`/product/${req.productId}/image`, { imagePath: req.imagePath, primary: req.primary }),
        getPrimaryImage: (productId: number): Promise<AxiosResponse<string>> => this.api.get(`/product/${productId}/image/primary`),
    }

    public readonly Image = {
        post: (imageBase64: string): Promise<AxiosResponse<string>> => this.api.post("/image", { imageBase64 })
    }
}