import axios, { AxiosResponse } from "axios";

axios.defaults.baseURL = process.env.REACT_APP_API_URL;
axios.defaults.headers.post["Content-Type"] = "application/json";
axios.defaults.headers.put["Content-Type"] = "application/json";

export interface Product {
    id?: number,
    name: string,
    description: string,
    proteins: number,
    carbohydrates: number,
    fats: number,
    nutrition: number
}

interface AttachImageRequest {
    productId: number,
    imagePath: string,
    primary: boolean
}

class ApiClient {
    public readonly Product = {
        get: (id: number): Promise<AxiosResponse<Product>> => axios.get(`/product/${id}`),
        getAll: (): Promise<AxiosResponse<Product[]>> => axios.get("/product"),
        put: (product: Product): Promise<AxiosResponse<Product>> => axios.put("/product", product),
        post: (id: number, product: Product): Promise<AxiosResponse<Product>> => axios.post(`/product/${id}`, product),
        delete: (id: number): Promise<AxiosResponse> => axios.delete(`/product/${id}`),
        attachImage: (req: AttachImageRequest): Promise<AxiosResponse> => axios.post(`/product/${req.productId}/image`, { imagePath: req.imagePath, primary: req.primary }),
        getPrimaryImage: (productId: number): Promise<AxiosResponse<string>> => axios.get(`/product/${productId}/image/primary`)
    }

    public readonly Image = {
        post: (imageBase64: string): Promise<AxiosResponse<string>> => axios.post("/image", imageBase64)
    }
}

const $api = new ApiClient();
export default $api;