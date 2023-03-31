import { Home } from "./home";
import { Loader } from "./hooks/loader";

export const App = () => {
  return (
    <Loader>
      <div id="app" className="container mt-5">
        <Home />
      </div>
    </Loader>
  );
}