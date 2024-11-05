import axios from "axios";

const StoreEndpoint = "/api/store";

const storeApiServices = {
    async fetchStores(pageNumber = 1, pageSize = 10) {
        try {
            const url = `${StoreEndpoint}?pageNumber=${pageNumber}&pageSize=${pageSize}`;
            const response = await fetch(url);
            if (!response.ok) {
                throw new Error(`Http Error! status: ${response.status}`);
            }
            const data = await response.json();
            return data;
        } catch (error) {
            console.error("fetch store failed!! ", error);
            throw error;
        }
        
    },

    //Task2: Using axios
    async CreateStore(newStore) {
        /*const response = await fetch(
            StoreEndpoint, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newStore)
        });*/
        try {
            const response = await axios.post(StoreEndpoint, newStore);
            return response.data;
        } catch (error) {
            console.error("create store failed!! ", error);
            throw error;
        }
        
    }
}

export default storeApiServices;
