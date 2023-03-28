import axios, { AxiosResponse } from "axios";

axios.defaults.baseURL = process.env.REACT_APP_API_URL;

interface Product {
    id: number
}

class ApiClient {
    public readonly Product = {
        get: async (id: number): Promise<AxiosResponse<Product>> => axios.get(`/product?id=${id}`)
    }
}

const $api = new ApiClient();
export default $api;