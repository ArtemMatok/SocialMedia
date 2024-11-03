import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { Button } from "../button";
import { useAuth } from "@/Context/useAuth";

type Props = {};

const Topbar = (props: Props) => {
  const { logout, userFull } = useAuth();

  useEffect(() => {
    console.log("userFull:", userFull);
  }, []);

  return (
    <section className="topbar">
      <div className="flex-between py-4 px-5">
        <Link to={"/"} className="flex gap-3 items-center">
          <img src="/assets/images/logo3.png" width={50} height={75} alt="" />
        </Link>

        <div className="flex gap-4">
          <Button
            variant={"ghost"}
            className="shad-button_ghost"
            onClick={logout}
          >
            <img src="/assets/icons/logout.svg" alt="logout"></img>
          </Button>
          <Link to={`/profile/${userFull?.id}`}>
            <img
              src={userFull?.image}
              alt="profile"
              className="h-8 w-8 rounded-full"
            />
          </Link>
        </div>
      </div>
    </section>
  );
};

export default Topbar;
