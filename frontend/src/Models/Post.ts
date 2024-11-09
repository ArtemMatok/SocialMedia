import { UserLikeDto } from "./AppUser";

export type PostGetDto = {
    postId:number;
    postCaption:string;
    tags:string[];
    image:string;
    location:string;
    userId:string;
    likes:UserLikeDto[]
}

export type PostLikeDto = {
    postId:number;
}

export type PostCreateDto = {
    postCaption:string;
    image:string[];
    location:string;
    tags:string[];
    userId:string;
}