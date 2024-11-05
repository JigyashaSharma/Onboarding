import './App.css';
import { NavMenu } from './components/navmenu/NavMenu.jsx';
import { ComponentRoutes } from './components/ComponentRoutes';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {

    return (
        <div className="app-layout">

            <NavMenu />
            <div className="main-content">
                <ComponentRoutes />
            </div>

        </div>
    );
}

export default App;