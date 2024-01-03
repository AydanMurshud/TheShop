import styled from "styled-components";
import useAxios, { Method } from "../hooks/useAxios";
import { Routes } from "../routes/Routes";
import ProductCard from "../components/ProductCard";
import IProductCard from "../Interfaces/IProductCard";
import CategoryCard from "../components/CategoryCard";
import ICategoryCard from "../Interfaces/ICategoryCard";

const HomePage: React.FC = () => {
  const { data: products, loading, error } = useAxios({ method: Method.GET, route: Routes.Product })
  const { data: categories } = useAxios({ method: Method.GET, route: Routes.Category })
  if (loading) return <div>Loading...</div>
  if (error) return <div>Error...</div>
  return (
    <CatalogContainer>
      <CategoryContainer>
        {categories?.map((category: ICategoryCard) => (
          <CategoryCard key={category.id} {...category} />
        ))}
      </CategoryContainer>
      <ProductContainer>
        {products?.map((product: IProductCard) => (
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