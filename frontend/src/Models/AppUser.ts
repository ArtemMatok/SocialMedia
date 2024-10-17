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