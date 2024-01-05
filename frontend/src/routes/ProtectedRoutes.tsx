import { useContext } from "react";
import {  Navigate, Outlet } from "react-router-dom"
import { AuthContext } from "../context/Context";

const ProtectedRoute = () => {
  const token = useContext(AuthContext);

  if (token) {
    return <Outlet />
  }
  return <Navigate to="/" />

};

export default ProtectedRoute;