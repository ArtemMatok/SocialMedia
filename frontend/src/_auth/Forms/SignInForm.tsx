import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import React from "react";
import { useForm } from "react-hook-form";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { SignInValidation, SignupValidation } from "@/lib/validation";
import Loader from "@/components/ui/shared/Loader";
import { Link } from "react-router-dom";
import { useAuth } from "@/Context/useAuth";

type Props = {};

const SingInForm = (props: Props) => {
  const { loginUser, loading } = useAuth();

  const form = useForm<z.infer<typeof SignInValidation>>({
    resolver: zodResolver(SignInValidation),
    defaultValues: {
      userName: "",
      password: "",
    },
  });

  const onSubmit = async (values: z.infer<typeof SignInValidation>) => {
    const newUser = await loginUser(values.userName, values.password);

    console.log(newUser);
  };
  return (
    <div>
      <Form {...form}>
        <div className="sm:w-420 flex center flex-col">
          <div className="flex justify-center items-center mr-[25px]">
            <img
              className="h-[100px] w-[100px]"
              src="/assets/images/logo3.png"
              alt="logo"
            />
          </div>

          <h2 className="h3-bold md:h2-bold pt-5 sm:pt-12">
            Create a new account
          </h2>
          <p className="text-light-3 small-medium md:base-regular mt-2">
            To use Monix enter your account details
          </p>

          <form
            onSubmit={form.handleSubmit(onSubmit)}
            className="flex flex-col gap-5 w-full mt-4"
          >
            <FormField
              control={form.control}
              name="userName"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>User Name</FormLabel>
                  <FormControl>
                    <Input type="text" className="shad-input" {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            <FormField
              control={form.control}
              name="password"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Password</FormLabel>
                  <FormControl>
                    <Input type="password" className="shad-input" {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <Button type="submit" className="shad-button_primary">
              {loading ? (
                <div className="flex-center gap-2">
                  <Loader />
                  Loading
                </div>
              ) : (
                "Sign Up"
              )}
            </Button>

            <p className="text-small-regular text-light-2 text-center mt-2">
             Don`t have an account ?
              <Link
                to={"/sign-up"}
                className="text-primary-500 text-small-semibold ml-1"
              >
                Register
              </Link>
            </p>
          </form>
        </div>
      </Form>
    </div>
  );
};

export default SingInForm;
