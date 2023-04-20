import styles from "./app.module.css";
import { Navigate, Route, Routes } from "react-router";
import { BrowserRouter } from "react-router-dom";
import { NavBar } from "./application/common/navbar";
import { GlobalContextProvider } from "./application/context/GlobalContext";
import { LoginPage } from "./application/pages/login/LoginPage";
import { Home } from "./home";
import { Loader } from "./hooks/loader";
import { ProductsPage } from "./application/pages/products/products-page";

export const App = () => {
  return (
    <Loader>
      <GlobalContextProvider>
        <NavBar />
        <div id="app" className={`${styles.appContainer} container`}>
          <BrowserRouter>
            <Routes>
              <Route path="/" Component={Home} />
              <Route path="/products" Component={ProductsPage} />
              <Route path="/login" Component={LoginPage} />
              <Route path="*" element={<Navigate to="/" />} />
            </Routes>
          </BrowserRouter>
        </div>
      </GlobalContextProvider >
    </Loader>
  );
}