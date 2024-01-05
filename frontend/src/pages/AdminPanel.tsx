import styled from "styled-components";

const AdminPanel = () => {
  return (
    <div>
      <Button><a href="/products/create">Add product</a></Button>
      <Button><a href="/categories/create">Add category</a></Button>
      <Button><a href="/promotions/create">Add promotion</a></Button>
    </div>
  );
};
export default AdminPanel;
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