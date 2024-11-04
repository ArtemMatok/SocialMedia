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