import { PostGetDto } from "@/Models/Post"
import { useEffect, useState } from "react";

export const usePost = () => {
    const[posts,setPosts] = useState<PostGetDto>();
    
    useEffect(()=>{
        const posts = async() => {
            
        }
    })
}