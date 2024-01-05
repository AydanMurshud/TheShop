import styled from "styled-components";
import SearchBar from "./SearchBar";
import { useContext, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../context/Context";

const Header = () => {
  const token = useContext(AuthContext);
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
        {!token ? <div>
          <Button><a href="/auth/register">Register</a></Button>
          <Button><a href="/auth/login">Login</a></Button>
        </div>
          :
          <div>
            <p>HI, user</p>
            <Button><a href="/auth/logout">Log out</a></Button>
          </div>}
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
    font-size: 28px;
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
      font-size: 14px;
      text-decoration: none;
      color: #000000;
    }
  }
`;
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