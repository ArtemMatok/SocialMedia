import { LoginDto, RegisterDto, UserProfileToken } from "@/Models/AppUser";
import axios from "axios";
import { toast } from "react-toastify"

const api = "http://localhost:5146/api/Account/"

export const register = async (name:string,userName:string, email:string, password:string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "Register",{name, userName, email, password})
        return data.data;
    } catch (error) {
        toast.error(error as string);
    }
}

export const login = async(userName:string, password:string) =>{
    try {
        const data = await axios.post<UserProfileToken>(api + "Login", {userName, password});

        return data.data;
    } catch (error) {
        toast.error(error as string);
    }
}