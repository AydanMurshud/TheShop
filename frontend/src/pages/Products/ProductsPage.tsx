import styled from "styled-components";
import IProductCard from "../../Interfaces/IProductCard";
import ProductCard from "../../components/ProductCard";
import useAxios, { Method } from "../../hooks/useAxios";
import { Routes } from "../../routes/Routes";
import { useSearchParams } from "react-router-dom";

export interface IProductsPageProps {
  search?: string;
  categoryId?: string;
}
const ProductsPage: React.FC<IProductsPageProps> = () => {
  const [searchParams] = useSearchParams()
  const categoryId = searchParams.get('categoryId')
  const search = searchParams.get('search')

  let query;
  if (categoryId && search) {
    query = `?categoryId=${categoryId}&search=${search}`;
  } else if (categoryId && !search) {
    query = `?categoryId=${categoryId}`;
  } else if (!categoryId && search) {
    query = `?search=${search}`;
  } else { query = ``; }

  const { data: products, loading, error } = useAxios({ method: Method.GET, route: Routes.Product, query })

  if (loading) return <div>Loading...</div>
  if (error) return <div>Error...</div>
  return (
    <ProductContainer>
      {products && products.map((product: IProductCard) => (
        <ProductCard key={product.id} {...product} />
      ))}
    </ProductContainer>
  );
};
export default ProductsPage;
const ProductContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  `