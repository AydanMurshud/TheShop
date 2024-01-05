import styled from "styled-components";
import useAxios, { Method } from "../hooks/useAxios";
import { Routes } from "../routes/Routes";
import ProductCard from "../components/ProductCard";
import IProductCard from "../interfaces/IProductCard";
import CategoryCard from "../components/CategoryCard";
import ICategoryCard from "../interfaces/ICategoryCard";
import { useEffect } from "react";

const HomePage: React.FC = () => {
  const { data: products, loading, error, getData: getProducts } = useAxios()
  const { data: categories, getData: getCategories } = useAxios()
  useEffect(() => {
    getProducts({ route: Routes.Product, method: Method.GET });
    getCategories({ route: Routes.Category, method: Method.GET });
  }, []);
  if (loading) return <div>Loading...</div>
  if (error) return <div>Error...</div>
  return (
    <CatalogContainer>
      <CategoryContainer>
        {categories?.slice(0, 3).map((category: ICategoryCard) => (
          <CategoryCard key={category.id} {...category} />
        ))}
      </CategoryContainer>
      <ProductContainer>
        {products?.slice(0,10).map((product: IProductCard) => (
          <ProductCard key={product.id} {...product} />
        ))}
      </ProductContainer>
    </CatalogContainer>
  );
}
export default HomePage;
const CatalogContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  `
const CategoryContainer = styled.div`
  width: 100%;
  height: fit-content;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  `
const ProductContainer = styled.div`
  width: 100%;
  height: fit-content;
  display: flex;
  flex-wrap: wrap;
  `  