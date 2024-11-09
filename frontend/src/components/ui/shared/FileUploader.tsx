import React, { useCallback, useState } from "react";
import { FileWithPath, useDropzone } from "react-dropzone";
import { Button } from "../button";
import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation } from "swiper/modules"; // Import Swiper's navigation module
import "swiper/css"; // Import Swiper styles
import "swiper/css/navigation"; // Import navigation styles

type Props = {
  fileChange: (giles: string[]) => void;
  mediaUrl: string;
};

const FileUploader = ({ fileChange, mediaUrl }: Props) => {
  const [fileUrls, setFileUrls] = useState<string[]>(mediaUrl ? [mediaUrl] : []);
  const [files, setFiles] = useState<File[]>([]);

  const onDrop = useCallback(
    (acceptedFiles: FileWithPath[]) => {
      const newFileUrls = acceptedFiles.map((file) => URL.createObjectURL(file));
      setFiles(acceptedFiles);
      fileChange(newFileUrls);

      
      setFileUrls(newFileUrls);
    },
    [fileChange]
  );

  const { getInputProps, open } = useDropzone({
    onDrop,
    accept: {
      "image/*": [".png", ".jpeg", ".jpg", ".svg"],
    },
    noClick: true,
    noKeyboard: true,
  });

  const onRemovePhoto = () => {
    setFiles([]);
    setFileUrls([]);
  };

  return (
    <div className="flex flex-center flex-col bg-dark-3 rounded-xl">
      <input {...getInputProps()} className="hidden" />
      {fileUrls.length > 0 ? (
        <>
          <div className="flex flex-1 justify-center w-full p5 lg:p-10">
            {fileUrls.length === 1 ? (
              <img src={fileUrls[0]} alt="image" className="w-full h-full object-cover" />
            ) : (
              <Swiper
                spaceBetween={10}
                slidesPerView={1}

                modules={[Navigation]}
                className="w-full h-full"
                style={{ width: "400px", height: "300px" }} // Set fixed dimensions
              >
                {fileUrls.map((url, index) => (
                  <SwiperSlide key={index}>
                    <img src={url} alt={`slide-${index}`} className="w-full h-full object-contain" />
                  </SwiperSlide>
                ))}
              </Swiper>
            )}
          </div>
          <p className="file_uploader-label cursor-pointer" onClick={onRemovePhoto}>Remove photo</p>
        </>
      ) : (
        <div className="file_uploader-box">
          <img
            src="/assets/icons/file-upload.svg"
            width={96}
            height={77}
            alt="upload"
          />
          <h3 className="base-medium text-light-2 mb-2 mt-6">
            Drag photo here
          </h3>
          <p className="text-light-4 small-regular mb-6">SVG, PNG, JPG</p>

          <Button onClick={open} className="shad-button_dark_4">
            Select from computer
          </Button>
        </div>
      )}
    </div>
  );
};

export default FileUploader;
