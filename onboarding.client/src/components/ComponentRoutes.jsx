import { Routes, Route } from 'react-router-dom';
import { Home } from '../pages/Home.jsx';
import { StoreTable } from './store/StoreTable';
import CustomerTable  from './customer/CustomerTable';
import AddCustomer from './customer/AddCustomer.jsx'
import AddStore from './store/AddStore.jsx';


export const ComponentRoutes = () => {
    return (
        <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/stores" element={<StoreTable />} />
            <Route path="/sales" element={<h1>Sales Details</h1>}></Route>
            <Route path="/customers" element={<CustomerTable />}> </Route>
            <Route path="/products" element={<h1>Product Details</h1>}></Route>
            <Route path="/add-store" element={<AddStore />} />
            <Route path="/add-customer" element={<AddCustomer />} />
        </Routes>
    );
};