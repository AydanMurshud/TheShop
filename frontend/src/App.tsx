import { Route, Routes } from "react-router-dom";
import ProductsPage from "./pages/Products/ProductsPage";
import HomePage from "./pages/HomePage";
import ProductDetails from "./pages/Products/ProductDetails";
import CategoriesPage from "./pages/Categories/CategoriesPage";

function App() {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/products" element={<ProductsPage />} />
      <Route path="/products/:id" element={<ProductDetails/>} />
      <Route path="/category" element={<CategoriesPage/>} />
    </Routes>
  );
}

export default App;
