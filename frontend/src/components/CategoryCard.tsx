import styled from "styled-components";
import ICategoryCard from "../interfaces/ICategoryCard"
import { useNavigate } from "react-router-dom";

const CategoryCard: React.FC<ICategoryCard> = ({ id, image, products, title }) => {
  const navigate = useNavigate();
  return (
    <Card onClick={() => navigate(`/products?category=${id}`)} key={id} >
      <img className="image" src={image} alt={title} />
      <small>has {products.length} products</small>
      <h5>{title}</h5>
    </Card>
  )
}
export default CategoryCard;

const Card = styled.div`
width: 150px;
height: 150px;
border: 1px solid black;
box-shadow: 1px 1px 10px black;
border-radius: 10px;
margin: 10px;
padding: 10px;
display: flex;
flex-direction: column;
justify-content: space-between;
align-items: center;
.image{
  width: 80px;
  height: 80px;
  border-radius: solid 5px red;
}
`