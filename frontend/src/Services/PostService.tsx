import { PostCreateDto, PostGetDto } from "@/Models/Post";
import axios from "axios";
import { toast } from "react-toastify";
import { ZodError } from "zod";

const api = "http://localhost:5146/api/Post/";


export const createPost = async(post:PostCreateDto) => {
    try {
        const data = await axios.post<boolean>(api + "CreatePost", {PostCaption:post.postCaption, Image:post.image, Location:post.location, Tags:post.tags, UserId:post.userId});
        if(data){
            return data.data;
        }
    } catch (error:any) {
        console.log("createPost error:",error);
    }
}

export const getPosts = async() => {
    try {
        const data = await axios.get<PostGetDto>(api + "GetPosts");
        if(data){
            return data.data;
        }
    } catch (error) {
        console.log("getPosts:",error);
    }
}