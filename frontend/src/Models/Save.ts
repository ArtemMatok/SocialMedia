import { PostGetDto } from "./Post";

export type SaveGetDto = {
    saveId:number;
    userId:number;
    postId:number;
    post:PostGetDto;
}