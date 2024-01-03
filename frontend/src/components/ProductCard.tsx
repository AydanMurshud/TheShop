
import styled from "styled-components";
import IProductCard from "../Interfaces/IProductCard";
import { Link, Navigate, useNavigate } from "react-router-dom";


const ProductCard: React.FC<IProductCard> = ({id,name,description,image,price,promotionId,updatedAt,categoryId,createdAt}) => {
  const navigate = useNavigate();
  const onClick = (e: React.MouseEvent<HTMLDivElement>) => {
    const id = e.currentTarget.id;
    navigate(`/products/${id}`,{state: {id,name,description,image,price,promotionId,updatedAt,categoryId,createdAt}});
  }

 return(
 <Card onClick={onClick} id={id} key={id}>
    <h2>{name}</h2>
    <p>{description}</p>
    <img src={image} alt={name}/>
    <p>{price}</p>
    <p>{promotionId}</p>
    <p>{categoryId}</p>
 </Card>
 )
}
export default ProductCard;
const Card = styled.div`
  width: 300px;
  height: 500px;
  border: 1px solid black;
  box-shadow: 1px 1px 20px black;
  border-radius: 10px;
  margin: 10px;
  padding: 10px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
  `