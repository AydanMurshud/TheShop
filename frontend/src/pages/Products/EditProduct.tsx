import { useForm } from "react-hook-form";
import styled from "styled-components";
import useAxios, { Method } from "../../hooks/useAxios";
import { Routes } from "../../routes/Routes";
import ICategoryCard from "../../interfaces/ICategoryCard";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";


const EditProduct: React.FC = () => {
  const id = window.location.href.split("/")[5].toLowerCase();

  const { putData: updateProduct, getData: getProduct, data: product, loading, error } = useAxios();
  const { data: categories, getData: getCategories } = useAxios();
  const { data: promotions, getData: getPromotions } = useAxios();

  const navigate = useNavigate();

  const { register, handleSubmit, formState: { errors }, formState: { isValid }, } = useForm({
    mode: "onChange",
    values: {
      name: product?.name,
      description: product?.description,
      price: product?.price,
      image: product?.image,
      categoryId: product?.categoryId,
      promotionId: product?.promotionId,
    },
  });
  const onSubmit = (data: any) => {
    if (data.promotionId === "") {
      data.promotionId = null;
    }
    updateProduct({
      route: Routes.Product,
      method: Method.PUT,
      id,
      data: JSON.stringify(data),
    });
    navigate("/products");
  }

  useEffect(() => {
    getProduct({ route: Routes.Product, method: Method.GET, id });
    getCategories({ route: Routes.Category, method: Method.GET });
    getPromotions({ route: Routes.Promotion, method: Method.GET });
  }, [id]);
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
      <button>Edit Product</button>
    </Form>
  );
}
export default EditProduct;
const Form = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;
`;