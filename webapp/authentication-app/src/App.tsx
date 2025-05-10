import React from "react";
import ReactDOM from "react-dom/client";
import Login from "./components/auth/Login";
import "./index.css";

const App = () => (
  <Login />
  
);

const root = ReactDOM.createRoot(document.getElementById("app") as HTMLElement);

root.render(<App />);