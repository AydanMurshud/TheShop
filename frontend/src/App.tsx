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
import { FormEvent, useContext, useEffect, useState } from "react";
import RegisterPage from "./pages/RegisterPage";
import { AuthContext } from "./context/Context";
import ProtectedRoute from "./routes/ProtectedRoutes";
import LoginPage from "./pages/LoginPage";
import Logout from "./pages/Logout";
import CreatePromotion from "./pages/Promotions/CreatePromotion";
import AdminPanel from "./pages/AdminPanel";

function App() {
  const [token, setToken] = useState(useContext(AuthContext));
  useEffect(() => {
  }, [token])
  return (
    <div style={{ width: "100%", height: "fit-content" }}>
      <Header />
      <div style={{ width: "100%", height: "80vh", paddingBottom: "200px" }}>
        <Routes>
          <Route element={<ProtectedRoute />}>
            <Route path="/products/create" element={<CreateProduct />} />
            <Route path="/products/edit/:id" element={<EditProduct />} />
            <Route path="/categories/create" element={<CreateCategory />} />
            <Route path="/categories/Edit/:id" element={<EditCategory />} />
            <Route path="/admin" element={<AdminPanel />} />
            <Route path="/promotions/create" element={<CreatePromotion />} />
          </Route>
          <Route path="/" element={<HomePage />} />
          <Route path="/auth/register" element={<RegisterPage />} />
          <Route path="/auth/login" element={<LoginPage />} />
          <Route path="/auth/logout" element={<Logout />} />
          <Route path="/products" element={<ProductsPage />} />
          <Route path="/products/:id" element={<ProductDetails />} />
          <Route path="/categories" element={<CategoriesPage />} />
        </Routes>
      </div>
      <Footer />
    </div>
  );
}

export default App;
