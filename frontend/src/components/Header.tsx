import styled from "styled-components";
import SearchBar from "./SearchBar";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

const Header = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const navigate = useNavigate();
  const onChange = (e: any) => {
    setSearchTerm(e.target.value);
  }
  const handleSearch = (e: any) => {
    searchTerm && navigate("/products?search=" + searchTerm)
  }
  useEffect(() => { }, [searchTerm])
  return (
    <HeaderContainer>
      <div style={{ width: "80%", display: "flex", flexWrap: 'wrap', alignItems: 'center' }}>
        <div className="logo"><a href="/">The<span className="span">Shop</span></a></div>
        <div className="nav">
          <a href="/">Home</a>
          <a href="/products">Products</a>
          <a href="/categories">Categories</a>
        </div>
        <div>
          <SearchBar
            searchTerm={searchTerm}
            onChange={onChange}
            handleSearch={handleSearch}
          />
        </div>
      </div>

    </HeaderContainer>);
};
export default Header;
const HeaderContainer = styled.div`
  width: 100%;
  height: fit-content;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #f1f1f1;
  box-shadow: 1px 1px 10px black;
  .logo{
    font-size: 40px;
    font-weight: bold;
    a{
      text-decoration: none;
      color: #000000;
    }
    .span{
      color: #3d3def;
    }
  }
  .nav{
    display: flex;
    justify-content: center;
    a{
      margin: 0 20px;
      font-size: 20px;
      text-decoration: none;
      color: #000000;
    }
  }
`;