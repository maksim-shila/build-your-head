import { Navigate, Route, Routes } from "react-router";
import { BrowserRouter } from "react-router-dom";
import { GlobalContextProvider } from "./app/context/GlobalContext";
import { LoginPage } from "./app/pages/login/LoginPage";
import { Home } from "./home";
import { Loader } from "./hooks/loader";

export const App = () => {
  return (
    <Loader>
      <GlobalContextProvider>
        <div id="app" className="container mt-5">

          <BrowserRouter>
            <Routes>
              <Route path="/" Component={Home} />
              <Route path="/login" Component={LoginPage} />

              <Route path="*" element={<Navigate to="/" />} />
            </Routes>
          </BrowserRouter>

        </div>
      </GlobalContextProvider >
    </Loader>
  );
}