import styled from "styled-components";
import useAxios, { Method } from "../../hooks/useAxios";
import ICategoryCard from "../../interfaces/ICategoryCard";
import { Routes } from "../../routes/Routes";
import { useContext, useEffect } from "react";
import { set, useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../context/Context";

const CreateProduct = () => {
  const { data: categories, loading, error, getData: getCategories } = useAxios();
  const { data: promotions, getData: getPromotions } = useAxios();
  const { postData: createProduct } = useAxios();
  const token = useContext(AuthContext);
  const navigate = useNavigate();
  const { register, handleSubmit, formState: { errors }, formState: { isValid }, } = useForm({
    mode: "onChange",
    defaultValues: {
      name: "",
      description: "",
      price: "",
      image: "",
      categoryId: "",
      promotionId: "",
    },
  });
  useEffect(() => {
    getCategories({ route: Routes.Category, method: Method.GET });
    getPromotions({ route: Routes.Promotion, method: Method.GET });
  }, []);
  const onSubmit = (data: any) => {
    if (data.promotionId === "") {
      data.promotionId = null;
    }
    createProduct({
      route: Routes.Product,
      method: Method.POST,
      token,
      data: data,
    });
    setTimeout(() => {
      navigate("/products");
    }, 1000);
  }
  if (loading) return <div>Loading...</div>;
  if (error) return <div>ERROR</div>;
  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <h1>Create Product</h1>
      <label>
        Product Name
        <input {...register("name")} type="text" />
      </label>
      <label>
        Product Description
        <textarea {...register("description")} />
      </label>
      <label>
        Product Price
        <input {...register("price")} type="number" />
      </label>
      <label>
        Product Image
        <input {...register("image")} type="text" />
      </label>
      <select {...register("categoryId")}>
        <option disabled selected defaultValue="">Select Category</option>
        {categories?.map((category: ICategoryCard) => (
          <option key={category.id} value={category.id}>
            {category.title}
          </option>
        ))}
      </select>
      <select {...register("promotionId")}>
        <option disabled selected defaultValue="">Select Promotion</option>
        <option value="">None</option>
        {promotions?.map((promotion: any) => (
          <option key={promotion.id} value={promotion.id}>
            {promotion.promotionName}
          </option>
        ))}
      </select>
      <button>Create Product</button>
    </Form>
  );
};
export default CreateProduct;
const Form = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;
`;