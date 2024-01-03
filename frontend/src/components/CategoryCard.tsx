import styled from "styled-components";
import ICategoryCard from "../Interfaces/ICategoryCard"

const CategoryCard:React.FC<ICategoryCard> =({id,image,products,title})=>{
  return(
    <Card key={id} >
      <img src={image} alt={title}/>
      <h2>{title}</h2>
      <small>{products.length}</small>
    </Card>
  )
} 
export default CategoryCard;

const Card = styled.div`
width: 150px;
height: 150px;
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