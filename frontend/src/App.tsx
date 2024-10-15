import {Route, Routes} from "react-router-dom"
import "./global.css";
import SignInForm from "./_auth/Forms/SignInForm";
import { Home } from "./_root/Pages";
import SingUpForm from "./_auth/Forms/SingUpForm";


function App() {
  return(
    <main className="flex h-screen">
      <Routes>
        <Route path="/sign-in" element={<SignInForm />}/>
        <Route path="/sign-up" element={<SingUpForm />}/>

        <Route index element={<Home />}/>
      </Routes>
    </main>
  )
}

export default App;
