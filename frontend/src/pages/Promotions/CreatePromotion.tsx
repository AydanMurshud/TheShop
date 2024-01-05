import { useForm } from "react-hook-form";
import styled from "styled-components";
import useAxios, { Method } from "../../hooks/useAxios";
import { Routes } from "../../routes/Routes";
import { useNavigate } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "../../context/Context";

const CreatePromotion = () => {
  const token = useContext(AuthContext);
  const { postData: createPromotion } = useAxios();
  const navigate = useNavigate();
  const { register, handleSubmit, formState: { errors }, formState: { isValid }, } = useForm({
    mode: "onChange",
    defaultValues: {
      promotionName: "",
      promotionRate: 0
    }
  });
  const onSubmit = (data: any) => {
    data.products = [];
    createPromotion({
      route: Routes.Promotion,
      method: Method.POST,
      token,
      data: data,
    });
  }
  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <h1>Create Promotion</h1>
      <label>
        Promotion Name
        <input {...register("promotionName")} type="text" />
      </label>
      <label>
        Promotion Rate
        <input {...register("promotionRate")} type="number" />%
      </label>
      <Button type="submit">Create Promotion</Button>
    </Form>
  )
}

export default CreatePromotion
const Form = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;
`;
const Button = styled.button`
margin-left: 8px;
padding: 4px 8px;
background-color: #007bff;
color: #fff;
a{
  color: #fff;
  text-decoration: none;
}
border: none;
border-radius: 4px;
cursor: pointer;
`;