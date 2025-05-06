// src/App.tsx
import React, { Suspense } from 'react';
const Login = React.lazy(() => import('authentication-app/Login'));

function App() {
  return (
<Suspense fallback={<div>Loading...</div>}>
  <Login />
</Suspense>
  );
}
export default App;
