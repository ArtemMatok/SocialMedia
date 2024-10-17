import { Route, Routes } from "react-router-dom";
import "./global.css";
import SignInForm from "./_auth/Forms/SignInForm";
import { Home } from "./_root/Pages";
import SingUpForm from "./_auth/Forms/SingUpForm";
import AuthLayout from "./_auth/AuthLayout";
import RootLayout from "./_root/RootLayout";
import { ToastContainer } from "react-toastify";
import { UserProvider } from "./Context/useAuth";
import ProtectedRoute from "./Router/Protected";
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return (
    <UserProvider>
      <main className="flex h-screen">
        <Routes>
          <Route element={<AuthLayout />}>
            <Route path="/sign-in" element={<SignInForm />} />
            <Route path="/sign-up" element={<SingUpForm />} />
          </Route>

          <Route element={<RootLayout />}>
            <Route
              index
              path="/"
              element={
                <ProtectedRoute>
                  <Home />
                </ProtectedRoute>
              }
            />
          </Route>
        </Routes>
        <ToastContainer></ToastContainer>
      </main>
    </UserProvider>
  );
}

export default App;
