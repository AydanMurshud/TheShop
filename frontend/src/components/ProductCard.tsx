
import styled from "styled-components";
import IProductCard from "../interfaces/IProductCard";
import { Link, Navigate, useNavigate } from "react-router-dom";
import useAxios, { Method } from "../hooks/useAxios";
import { useContext, useEffect } from "react";
import { Routes } from "../routes/Routes";
import { AuthContext } from "../context/Context";


const ProductCard: React.FC<IProductCard> = ({ id, name, description, image, price, promotionId, updatedAt, categoryId, createdAt }) => {
  const navigate = useNavigate();
  const token = useContext(AuthContext);
  const { data: promotion, loading, error, getData: getPromotion, deleteData: deleteProduct } = useAxios();
  const onClick = (e: React.MouseEvent<HTMLDivElement>) => {
    const id = e.currentTarget.id;
    navigate(`/products/${id}`);
  }
  useEffect(() => {
    if (promotionId) {
      getPromotion({ route: Routes.Promotion, method: Method.GET, id: promotionId });
    }
  }, [promotionId])

  if (loading) return <p>Loading...</p>
  if (error) return <p>Error!</p>
  return (
    <Card onClick={onClick} id={id} key={id}>
      <img className="image" src={image} alt={name} />
      <div className="text">
        <h5>{name}</h5>
        <p>{description}</p>
        {promotion && <p>{`${promotion.promotionName} ${promotion.promotionRate}% off`}</p>}
        <p style={{ textDecoration: promotion ? "line-through" : "" }}>${price}</p>
        {promotion && <p style={{ color: 'red' }}>{`$${(price * ((100 - promotion.promotionRate) / 100)).toFixed(2)}`}</p>}
      </div>
      {token && <div>
        <Button onClick={(e: any) => { e.stopPropagation(); navigate("/products/edit/" + id) }}>Edit</Button>
        <Button onClick={(e: any) => {
          e.stopPropagation();
          deleteProduct({ route: Routes.Product, method: Method.DELETE, id, token, data: { id, name, description, image, price, promotionId, updatedAt, categoryId, createdAt } })
          navigate("/products");
        }}>Delete</Button>
      </div>}
    </Card>
  )
}
export default ProductCard;
const Card = styled.div`
  width: 250px;
  height: 350px;
  border: 1px solid black;
  box-shadow: 1px 1px 20px black;
  border-radius: 10px;
  margin: 10px;
  padding: 10px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
  .text{
    font-size: 14px;
    width: 100%;
    height: 60%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    h5,p{
      margin: 0;
      padding: 0;
    
    }
  }
  .image{
    width: 150px;
    height: 170px;
  }
  `
const Button = styled.button`
  margin-left: 8px;
  padding: 4px 8px;
  background-color: #007bff;
  a{
    color: #fff;
    text-decoration: none;
  }
  border: none;
  border-radius: 4px;
  cursor: pointer;
`;