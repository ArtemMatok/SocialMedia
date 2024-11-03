import { sidebarLinks } from "@/constants";
import { useAuth } from "@/Context/useAuth";
import React from "react";
import { Link, NavLink, useLocation } from "react-router-dom";
import { Button } from "../button";

type Props = {};

const LeftSidebar = (props: Props) => {
  const { userFull, logout } = useAuth();
  const { pathname } = useLocation();

  return (
    <nav className="leftsidebar">
      <div className="flex flex-col gap-5">
        <Link to={"/"} className="flex gap-3 items-center">
          <img src="/assets/images/logo3.png" width={60} height={85} alt="" />
          <h1>MONIX</h1>
        </Link>

        <Link
          to={`/profile/${userFull?.id}`}
          className="flex gap-2 items-center"
        >
          <img
            src={userFull?.image || "/assets/icons/profile-placeholdder.svg"}
            alt="profile"
            className="h-14 w-14 rounded-full"
          />
          <div className="flex flex-col">
            <p className="boy-bold">{userFull?.name}</p>
            <p className="smal;-regular text-light-3">@{userFull?.userName}</p>
          </div>
        </Link>

        <ul className="flex flex-col gap-6">
          {sidebarLinks.map((link) => {
            const isActive = pathname === link.route;

            return (
              <li
                key={link.label}
                className={`leftsidebar-link ${
                  isActive && "bg-primary-500"
                } group`}
              >
                <NavLink
                  to={link.route}
                  className="flex gap-4 items-center p-4"
                >
                  <img
                    src={link.imgURL}
                    alt={link.label}
                    className={`group-hover:invert-white ${
                      isActive && "invert-white"
                    }`}
                  />
                  {link.label}
                </NavLink>
              </li>
            );
          })}
        </ul>
      </div>

      <Button variant={"ghost"} className="shad-button_ghost " onClick={logout}>
        <img src="/assets/icons/logout.svg" alt="logout"></img>
        <p className="small-medium lg:base-medium">Logout</p>
      </Button>
    </nav>
  );
};

export default LeftSidebar;
