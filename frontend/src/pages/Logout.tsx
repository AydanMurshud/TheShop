import HomePage from "./HomePage";

const Logout = () => {
  sessionStorage.removeItem("token");
  return <HomePage />
};
export default Logout;