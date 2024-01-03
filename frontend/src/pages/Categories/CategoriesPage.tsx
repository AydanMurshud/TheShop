import styled from "styled-components";
import useAxios, { Method } from "../../hooks/useAxios";
import { Routes } from "../../routes/Routes";
import CategoryCard from "../../components/CategoryCard";
import { useSearchParams } from "react-router-dom";

const CategoriesPage = () => {
  const [searchParams] = useSearchParams();
  const search = searchParams.get('search');
  let query = search ? `?search=${search}` : ``;
  
  const { data: categories, loading, error } = useAxios({ method: Method.GET, route: Routes.Category, query });

  if (loading) return <div>Loading...</div>
  if (error) return <div>Error...</div>
  return (
    <CategoryContainer>
      {categories && categories.map((category: any) => (
        <CategoryCard key={category.id} {...category} />
      ))}
    </CategoryContainer>
  );
};
export default CategoriesPage;
const CategoryContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  `