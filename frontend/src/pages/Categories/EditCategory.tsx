import { useNavigate } from "react-router-dom";
import useAxios, { Method } from "../../hooks/useAxios";
import { Routes } from "../../routes/Routes";
import { useEffect } from "react";
import styled from "styled-components";
import { set, useForm } from "react-hook-form";

const EditCategory = () => {
  const id = window.location.href.split('/')[5].toLowerCase();
  const { putData: updateCategory, getData: getCategory, data: category, loading, error } = useAxios();
  const navigate = useNavigate();
  const { register, handleSubmit, formState: { errors }, formState: { isValid }, } = useForm({
    mode: "onChange",
    values: {
      title: category?.title,
      image: category?.image,
    },
  });
  const onSubmit = (data: any) => {
    updateCategory({
      route: Routes.Category,
      method: Method.PUT,
      id,
      data: JSON.stringify(data),
    });
    setTimeout(() => {
      navigate("/categories");
    }, 500);
  }
  useEffect(() => {
    getCategory({ route: Routes.Category, method: Method.GET, id });
  }, [id]);
  if (loading) return <div>Loading...</div>;
  if (error) return <div>ERROR</div>;
  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <h1>Create Category</h1>
      <label>
        Category Name
        <input {...register("title")} type="text" />
      </label>
      <label>
        Category Image
        <input {...register("image")} type="text" />
      </label>
      <button>Create Category</button>
    </Form>
  );
};
export default EditCategory;
const Form = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;
`;