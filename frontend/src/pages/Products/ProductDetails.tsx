import { Routes } from "../../routes/Routes";
import useAxios, { Method } from "../../hooks/useAxios";


const ProductDetails: React.FC = () => {
  const currentURL = window.location.href;
  const linkId = currentURL.split("/")[4];
  const { data: product, loading, error } = useAxios({ method: Method.GET, route: Routes.Product, id: linkId })
  if (loading) return <div>Loading...</div>
  if (error) return <div>Error...</div>
  if(product)
  return (
    <div id={linkId}>
      <h1>Product Details</h1>
      <h2>{product.name}</h2>
      <p>{product.description}</p>
      <img src={product.image} alt={product.name} />
      <p>{product.price}</p>
      <p>{product.categoryId}</p>
      <p>{product.promotionId}</p>
    </div>
  );
};
export default ProductDetails;