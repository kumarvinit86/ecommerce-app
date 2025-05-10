import ReactDOM from "react-dom/client";
import { Suspense, useState } from "react";
import React from "react";
import "./index.css";
const Login = React.lazy(() => import("authentication_app/Login"));
const App = () => {
  return <div>
 <Suspense fallback={<div className="text-3xl mx-auto max-w-6xl">Loading...</div>}>
  <Login />
 </Suspense>
  </div>
};

const root = ReactDOM.createRoot(document.getElementById("app") as HTMLElement);

root.render(<App />);

export default App