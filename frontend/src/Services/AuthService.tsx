import { LoginDto, RegisterDto, UserFullDto, UserProfileToken } from "@/Models/AppUser";
import axios from "axios";
import { toast } from "react-toastify";

const api = "http://localhost:5146/api/Account/";

export const register = async (
  name: string,
  userName: string,
  email: string,
  password: string
) => {
  try {
    const data = await axios.post<UserProfileToken>(api + "Register", {
      name,
      userName,
      email,
      password,
    });
    return data.data;
  } catch (error: any) {
    if (error.response) {
      toast.error(`${error.response ? error.response.data :  error.response}`);
    } else {
    
      toast.error("Something went wrong...");
    }
  }
};

export const login = async (userName: string, password: string) => {
    try {
      const response = await axios.post<UserProfileToken>(api + "Login", {
        userName,
        password,
      });
  
      if (response.status === 200) {
        return response.data;
      }
    } catch (error: any) {
      if (error.response) {
        // Axios спіймав помилкову відповідь від сервера
        toast.error(`${error.response.data} `);
      } else {
        // Обробка інших помилок, не пов'язаних з відповіддю сервера
        toast.error(error.message);
      }
    }
  };
  
export const getUserByUserName = async(userName:string) => {
  try {
    const data = await axios.get<UserFullDto>(api + `GetUserByUserName/${userName}`)
    if(data){
      return data.data;
    }
  } catch (error:any) {
    console.log("getUserByUserName error:",error.response.data)
  }
}