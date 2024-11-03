import { Route, Routes } from "react-router-dom";
import "./global.css";
import SignInForm from "./_auth/Forms/SignInForm";
import SingUpForm from "./_auth/Forms/SingUpForm";
import AuthLayout from "./_auth/AuthLayout";
import RootLayout from "./_root/RootLayout";
import { ToastContainer } from "react-toastify";
import { UserProvider } from "./Context/useAuth";
import ProtectedRoute from "./Router/Protected";
import{AllUsers,CreatePost, EditPost, Explore, Home, PostDetails, Profile, Saved, UpdateProfile} from './_root/Pages'
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
            <Route path="/explore" element={<Explore />}/>
            <Route path="/saved" element={<Saved />}/>
            <Route path="/all-users" element={<AllUsers />}/>
            <Route path="/create-post" element={<CreatePost />}/>
            <Route path="/update-post/:postId" element={<EditPost />}/>
            <Route path="/post/:postId" element={<PostDetails />}/>
            <Route path="/profile/:userId" element={<Profile />}/>
            <Route path="/update-profile/:userId" element={<UpdateProfile />}/>
          </Route>
        </Routes>
        <ToastContainer></ToastContainer>
      </main>
    </UserProvider>
  );
}

export default App;
