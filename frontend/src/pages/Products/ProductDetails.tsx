import { Routes } from "../../routes/Routes";
import useAxios, { Method } from "../../hooks/useAxios";
import { useContext, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import styled from "styled-components";
import { AuthContext } from "../../context/Context";



const ProductDetails: React.FC = () => {
  const id = window.location.href.split("/")[4];
  const token = useContext(AuthContext);
  const { data: product, loading, error, getData: getProduct, deleteData: deleteProduct } = useAxios();
  const { data: category, getData: getCategory } = useAxios();
  const { data: promotion, getData: getPromotion } = useAxios();
  const navigate = useNavigate();
  useEffect(() => {
    getProduct({ route: Routes.Product, method: Method.GET, id });
  }, []);
  useEffect(() => {
    if (!product) return;
    getCategory({ route: Routes.Category, method: Method.GET, id: product.categoryId });
    if (!product.promotionId) return;
    getPromotion({ route: Routes.Promotion, method: Method.GET, id: product.promotionId })
  }, [product]);

  if (loading) return <div>Loading...</div>
  if (error) return <div>Error...</div>
  if (!product) return <div>Product not found</div>
  const { name, description, image, price } = product;
  const { title } = category || { title: "" };
  return (
    <DetailsContainer id={id}>
      <img className="image" src={image} alt={name} />
      <div>
        <h1>Product Details</h1>
        <h2>{category && title}/{name}</h2>
        <p>{description}</p>
        {promotion && <p style={{ fontSize:"20px",fontWeight: 'bold' }}>{`${promotion.promotionName} ${promotion.promotionRate}% off`}</p>}
        {promotion && <p style={{ color: "red" }}>{`You save $${(price * (promotion.promotionRate / 100)).toFixed(2)}`}</p>}
        <p style={{ textDecoration: promotion ? "line-through" : "", color: 'red',fontSize:"20px" }}>${price}</p>
        {promotion && <p style={{ fontWeight: 'bold',fontSize:"36px" }}>{`$${(price * ((100 - promotion.promotionRate) / 100)).toFixed(2)}`}</p>}


        {token && <div>
          <Button onClick={(e: any) => { e.stopPropagation(); navigate("/products/edit/" + id) }}>Edit</Button>
          <Button className="dlt" onClick={(e: any) => {
            e.stopPropagation();
            deleteProduct({ route: Routes.Product, method: Method.DELETE, id, token, data: product })
            navigate("/products");
          }}>Delete</Button>
        </div>}
      </div>
    </DetailsContainer >
  );
};
export default ProductDetails;
const DetailsContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  .image{
    width: 300px;
    height: 300px;
  }
  button.dlt{
    background-color: red;
  }
  `
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