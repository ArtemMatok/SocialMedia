import { PostGetDto, PostLikeDto } from "./Post";
import { SaveGetDto } from "./Save";

export type RegisterDto = {
    name:string;
    userName:string;
    email:string;
    password:string;
}

export type LoginDto = {
    userName:string;
    password:string;
}

export type UserProfileToken = {
  
    userName:string;
    email:string;
    token:string;
}

export type UserProfile = {
   
    userName:string;
    email:string;
}

export type UserLikeDto = {
    id:string;
    userName:string;
    image:string;
} 

export type UserFullDto = {
    id:string;
    email:string;
    name:string;
    userName:string;
    image:string;
    posts:PostGetDto[];
    likedPosts:PostLikeDto[];
    saves:SaveGetDto[];
}