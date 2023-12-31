import { useForm } from "react-hook-form";
import styled from "styled-components";
import useAxios, { Method } from "../hooks/useAxios";
import { Routes } from "../routes/Routes";

const RegisterPage = () => {
  const { data: token, loading, error, postData: registerUser } = useAxios();
  const { register, handleSubmit, formState: { errors } } = useForm({
    mode: "onBlur",
    defaultValues: {
      username: "",
      userEmail: "",
      password: "",
      confirmPassword: ""
    }
  });

  const onSubmit = (data: any) => {
    const { username, userEmail, password } = data;
    registerUser({ route: Routes.Register, method: Method.POST, data: { username, userEmail, password } })
  };
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error!</p>;
  if (token) {
    sessionStorage.setItem("token", token);
  }


  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <h1>Register</h1>
      <input {...register("username")} type="text" placeholder="Username" />
      <input {...register("userEmail")} type="email" placeholder="Email" />
      <input {...register("password")} type="password" placeholder="Password" />
      <input {...register("confirmPassword")} type="password" placeholder="Confirm Password" />
      <button>Register</button>
    </Form>
  );
};
export default RegisterPage;
const Form = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;
`;