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

class ApiClient {
    public readonly Product = {
        get: (id: number): Promise<AxiosResponse<Product>> => axios.get(`/product/${id}`),
        getAll: (): Promise<AxiosResponse<Product[]>> => axios.get("/product"),
        put: (product: Product): Promise<AxiosResponse<Product>> => axios.put("/product", product),
        delete: (id: number): Promise<AxiosResponse> => axios.delete(`/product/${id}`),
        attachImage: (productId: number, imageId: string, primary = false) => axios.post(`/product/${productId}/image`, { imageId, primary })
    }

    public readonly Image = {
        post: (image: File): Promise<AxiosResponse<string>> => {
            const formData = new FormData();
            formData.append("image", image)
            return axios.post("/image", formData, { headers: { "Content-Type": "multipart/form-data" } })
        }
    }
}

const $api = new ApiClient();
export default $api;