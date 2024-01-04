import styled from "styled-components";
import IProductCard from "../../interfaces/IProductCard";
import ProductCard from "../../components/ProductCard";
import useAxios, { Method } from "../../hooks/useAxios";
import { Routes } from "../../routes/Routes";
import { useSearchParams } from "react-router-dom";
import { useEffect } from "react";

export interface IProductsPageProps {
  search?: string;
  categoryId?: string;
}
const ProductsPage: React.FC<IProductsPageProps> = () => {
  const [searchParams] = useSearchParams()
  const categoryId = searchParams.get('category')
  const search = searchParams.get('search')

  let query: string;
  if (categoryId && search) {
    query = `?category=${categoryId}&search=${search}`;
  } else if (categoryId && !search) {
    query = `?category=${categoryId}`;
  } else if (!categoryId && search) {
    query = `?search=${search}`;
  } else { query = ``; }

  const { data: products, loading, error, getData: getProducts } = useAxios();

  useEffect(() => {
    getProducts({ route: Routes.Product, method: Method.GET, query });
  }, [query]);
  if (loading) return <div>Loading...</div>
  if (error) return <div>Error...</div>
  if (products && products.length < 1) return <div>No products found</div>

  return (
    <ProductContainer>
      {products && products.map((product: IProductCard) => (
        <ProductCard key={product.id} {...product} />
      ))

      }
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