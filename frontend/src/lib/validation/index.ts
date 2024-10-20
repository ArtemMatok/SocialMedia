import * as z from "zod";

export const SignupValidation = z.object({
  name: z.string().min(2, { message: "Too short" }),
  userName: z.string().min(2, { message: "Too short" }),
  email: z.string().email(),
  password: z
    .string()
    .min(8, { message: "Password must be at least 8 characters." }),
});

export const SignInValidation = z.object({
  userName: z.string().min(2, { message: "Too short" }),
  password: z
    .string()
    .min(8, { message: "Password must be at least 8 characters." }),
});
