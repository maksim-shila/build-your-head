import axios, { AxiosResponse } from "axios";

axios.defaults.baseURL = process.env.REACT_APP_API_URL;
axios.defaults.headers.post["Content-Type"] = "application/json";
axios.defaults.headers.put["Content-Type"] = "application/json";

interface Product {
    name: string,
    description: string,
    proteins: number,
    carbohydrates: number,
    fats: number,
    nutrition: number
}

class ApiClient {
    public readonly Product = {
        get: async (id: number): Promise<AxiosResponse<Product>> => axios.get(`/product?id=${id}`),
        put: async (product: Product) => axios.put('/product', product)
    }
}

const $api = new ApiClient();
export default $api;