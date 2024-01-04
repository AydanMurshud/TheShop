import { Route, Routes, useNavigate } from "react-router-dom";
import ProductsPage from "./pages/Products/ProductsPage";
import HomePage from "./pages/HomePage";
import ProductDetails from "./pages/Products/ProductDetails";
import CategoriesPage from "./pages/Categories/CategoriesPage";
import CreateProduct from "./pages/Products/CreateProduct";
import EditProduct from "./pages/Products/EditProduct";
import CreateCategory from "./pages/Categories/CreateCategory";
import EditCategory from "./pages/Categories/EditCategory";
import Header from "./components/Header";
import Footer from "./components/Footer";
import SearchBar from "./components/SearchBar";
import { FormEvent, useEffect, useState } from "react";

function App() {
  return (
    <>
      <Header />
      <div style={{ width: "100%", height: "80vh",paddingBottom:"200px" }}>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/products" element={<ProductsPage />} />
          <Route path="/products/create" element={<CreateProduct />} />
          <Route path="/products/edit/:id" element={<EditProduct />} />
          <Route path="/products/:id" element={<ProductDetails />} />
          <Route path="/categories" element={<CategoriesPage />} />
          <Route path="/categories/create" element={<CreateCategory />} />
          <Route path="/categories/Edit/:id" element={<EditCategory />} />
        </Routes>
      </div>
      <Footer />
    </>

  );
}

export default App;
