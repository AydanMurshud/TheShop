import { useNavigate } from "react-router-dom";
import styled from "styled-components";
import useAxios, { Method } from "../../hooks/useAxios";
import { useForm } from "react-hook-form";
import { Routes } from "../../routes/Routes";

const CreateCategory = () => {
  const navigate = useNavigate();
  const { postData: createCategory } = useAxios();
  const { register, handleSubmit, formState: { errors } } = useForm({
    mode: "onChange",
    defaultValues: {
      title: "",
      image: "",
    },
  });
  const onSubmit = async (data: any) => {
    createCategory({
      route: Routes.Category,
      method: Method.POST,
      data: JSON.stringify(data),
    });
    navigate("/categories");
  };
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
  )
}
export default CreateCategory
const Form = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;
`;