import React, { useState } from "react";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Textarea } from "../ui/textarea";
import FileUploader from "../ui/shared/FileUploader";
import { PostGetDto } from "@/Models/Post";
import { PostValidation } from "@/lib/validation";
import { createPost } from "@/Services/PostService";
import { useAuth } from "@/Context/useAuth";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";

type Props = {
  post?: PostGetDto;
};

const PostForm = ({ post }: Props) => {
  const navigate = useNavigate();
  const { userFull } = useAuth();
  const [isLoading, setIsLoading] = useState(false); // стан завантаження

  const form = useForm<z.infer<typeof PostValidation>>({
    resolver: zodResolver(PostValidation),
    defaultValues: {
      caption: post ? post?.postCaption : "",
      file: [],
      location: post ? post?.location : "",
      tags: post ? post?.tags.join(",") : "",
    },
  });

  const onSubmit = async (values: z.infer<typeof PostValidation>) => {
    setIsLoading(true); 
    try {
      const tagsArray = values.tags ? values.tags.split(",") : [];
      const data = await createPost({
        postCaption: values.caption,
        image: values.file,
        location: values.location,
        tags: tagsArray,
        userId: userFull?.id!,
      });
      if (data) {
        toast.success("Post was created");
        navigate("/");
      }
    } catch (error) {
      toast.error("Failed to create post");
    } finally {
      setIsLoading(false); 
    }
  };

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="flex flex-col gap-9 w-full max-w-5xl"
      >
        <FormField
          control={form.control}
          name="caption"
          render={({ field }) => (
            <FormItem>
              <FormLabel className="shad-form_label">Caption</FormLabel>
              <FormControl>
                <Textarea
                  className="shad-textarea custom-scrollbar"
                  {...field}
                />
              </FormControl>
              <FormMessage className="shad-form_message" />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="file"
          render={({ field }) => (
            <FormItem>
              <FormLabel className="shad-form_label">Add Photos</FormLabel>
              <FormControl>
                <FileUploader
                  fileChange={field.onChange}
                  mediaUrl={post ? post.image : ""}
                />
              </FormControl>
              <FormMessage className="shad-form_message" />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="location"
          render={({ field }) => (
            <FormItem>
              <FormLabel className="shad-form_label">Add Location</FormLabel>
              <FormControl>
                <Input {...field} type="text" className="shad-input"></Input>
              </FormControl>
              <FormMessage className="shad-form_message" />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="tags"
          render={({ field }) => (
            <FormItem>
              <FormLabel className="shad-form_label">
                Add Tags (separated by comma ",")
              </FormLabel>
              <FormControl>
                <Input
                  type="text"
                  className="shad-input"
                  placeholder="Art, Expression, Learn"
                  {...field}
                ></Input>
              </FormControl>
              <FormMessage className="shad-form_message" />
            </FormItem>
          )}
        />
        <div className="flex gap-4 items-center justify-end">
          <Button
            type="button"
            onClick={() => navigate(-1)}
            className="shad-button_dark_4"
          >
            Cancel
          </Button>
          <Button
            type="submit"
            className="shad-button_primary whitespace-nowrap"
            disabled={isLoading} // блокуємо кнопку під час завантаження
          >
            {isLoading ? "Loading..." : "Submit"} {/* показуємо індикатор завантаження */}
          </Button>
        </div>
      </form>
    </Form>
  );
};

export default PostForm;
