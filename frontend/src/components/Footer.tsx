import styled from "styled-components";

const Footer = () => {
  return (
    <FooterContainer>
      <div style={{ width: "80%" }}>
        <div className="logo"><a href="/">The<span className="span">Shop</span></a></div>
        <p>© 2024 TheShop. All Rights Reserved | Design by <a href="https://www.linkedin.com/in/aydan-murshud-969ba322b/">Aydan Murshud</a></p>
      </div>
    </FooterContainer>
  );
};
export default Footer;
const FooterContainer = styled.div`
  width: 100%; 
  position: fixed;
  bottom: 0;
  height: 100px;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #f1f1f1;
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
  `;