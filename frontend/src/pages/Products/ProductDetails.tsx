import { Routes } from "../../routes/Routes";
import useAxios, { Method } from "../../hooks/useAxios";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import styled from "styled-components";



const ProductDetails: React.FC = () => {
  const id = window.location.href.split("/")[4];
  const { data: product, loading, error, getData: getProduct } = useAxios();
  const { data: category, getData: getCategory } = useAxios();
  const { data: promotion, getData: getPromotion } = useAxios();
  const navigate = useNavigate();
  useEffect(() => {
    getProduct({ route: Routes.Product, method: Method.GET, id });
  }, []);
  useEffect(() => {
    if (!product) return;
    getCategory({ route: Routes.Category, method: Method.GET, id: product.categoryId });
    if(!product.promotionId) return;
    getPromotion({ route: Routes.Promotion, method: Method.GET, id: product.promotionId })
  }, [product]);

  if (loading) return <div>Loading...</div>
  if (error) return <div>Error...</div>
  if (!product) return <div>Product not found</div>
  const { name, description, image, price } = product;
  const {title}= category || {title:""};
  return (
    <DetailsContainer id={id}>
      <img className="image" src={image} alt={name} />
      <div>
        <h1>Product Details</h1>
        <h2>{category && title}/{name}</h2>
        <p>{description}</p>
        {promotion && <p>{promotion.promotionName}</p>}
        <p style={{textDecoration:promotion?"line-through":""}}>${price}</p>
        {promotion && <p style={{color:'red'}}>{`$${(price * ((100-promotion.promotionRate) / 100)).toFixed(2)}`}</p>}
        <button onClick={() => navigate("/products/edit/" + id)}>Edit</button>
        <button>Delete</button>
      </div>
    </DetailsContainer>
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
  `