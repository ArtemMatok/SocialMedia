import { UserProfile, UserProfileToken } from "@/Models/AppUser";
import { login, register } from "@/Services/AuthService";
import axios from "axios";
import React from "react";
import { createContext, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

type UserContextType = {
  loading:boolean,
  user: UserProfile | null;
  token: string | null;
  registerUser: (
    name: string,
    userName: string,
    email: string,
    password: string
  ) => void;
  loginUser: (userName: string, password: string) => void;
  logout: () => void;
  isLoggedIn: () => boolean;
};

type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
  const navigate = useNavigate();
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<UserProfile | null>(null);
  const [isReady, setIsReady] = useState<boolean>(false);
  const[loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    const user = localStorage.getItem("user");
    const token = localStorage.getItem("token");

    if (token && user) {
      setUser(JSON.parse(user));
      setToken(token);
      axios.defaults.headers.common["Authorization"] = "Bearer " + token;
    }
    setIsReady(true);
  }, []);

  const registerUser = async (
    name: string,
    userName: string,
    email: string,
    password: string
  ) => {
    try {
      setLoading(true);
      const data = await register(name, userName, email, password);
      if (data) {
        localStorage.setItem("token", data.token);
        const userObj = {
          userName: data.userName,
          email: data.email,
        };
        localStorage.setItem("user", JSON.stringify(userObj));
        setToken(data.token!);
        setUser(userObj!);
        toast.success("Register Success!");
        setLoading(false);
        navigate("/");
        
      }else{
        setLoading(false);
      }
    } catch (error) {
      console.log("Register error:",error);
    }
  };

  const loginUser = async (userName: string, password: string) => {
    try {
      setLoading(true);
      const data = await login(userName, password);
      if (data) {
        localStorage.setItem("token", data.token);
        const userObj = {
          userName: data.userName,
          email: data.email,
        };
        localStorage.setItem("user", JSON.stringify(userObj));
        setToken(data.token!);
        setUser(userObj!);
        toast.success("Login Success!");
        setLoading(false);
        navigate("/");
      }else{
        setLoading(false);
      }
    } catch (error) {
      console.log("Login error:",error);
    }
  };

  const isLoggedIn = () => {
    return !!user;
  };

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    setUser(null);
    setToken("");
    navigate("/");
  };

  return (
    <UserContext.Provider
      value={{ loginUser, user, token, logout, isLoggedIn, registerUser, loading }}
    >
      {isReady ? children : null}
    </UserContext.Provider>
  );
};


export const useAuth = () => React.useContext(UserContext);