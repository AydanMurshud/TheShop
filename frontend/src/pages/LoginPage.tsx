import { useForm } from "react-hook-form";
import styled from "styled-components";
import useAxios, { Method } from "../hooks/useAxios";
import { Routes } from "../routes/Routes";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
  const { data: token, loading, error, postData: registerUser } = useAxios();
  const navigate = useNavigate();
  const { register, handleSubmit, formState: { errors } } = useForm({
    mode: "onBlur",
    defaultValues: {
      userEmail: "",
      password: "",
    }
  });

  const onSubmit = (data: any) => {
    const { username, userEmail, password } = data;
    registerUser({ route: Routes.Login, method: Method.POST, data: { userEmail, password } })
  };
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error!</p>;
  if (token) {
    sessionStorage.setItem("token", token);
    navigate("/");
  }


  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <h1>Register</h1>
      <input {...register("userEmail")} type="email" placeholder="Email" />
      <input {...register("password")} type="password" placeholder="Password" />
      <button>Register</button>
    </Form>
  );
};
export default LoginPage;
const Form = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;
`;