import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Layout } from 'antd';
import Navbar from './components/Navbar';
import Sidebar from './components/Sidebar';
import {
    Category,
    Item,
    Location,
    Role,
    Staff,
    Status,
    Table,
    Unit
} from './pages';

const { Content } = Layout;

const App = () => {
    return (
        <Router>
            <Layout style={{ minHeight: '100vh' }}>
                <Navbar />
                <Layout>
                    <Sidebar />
                    <Layout style={{ padding: '0 24px 24px' }}>
                        <Content
                            style={{
                                padding: 24,
                                margin: 0,
                                minHeight: 280
                            }}
                        >
                            <Routes>
                                <Route path='/' element={<h1>Home</h1>} />
                                <Route path='/role' element={<Role />} />
                                <Route path='/status' element={<Status />} />
                                <Route
                                    path='/location'
                                    element={<Location />}
                                />
                                <Route path='/unit' element={<Unit />} />
                                <Route
                                    path='/category'
                                    element={<Category />}
                                />
                                <Route path='/staff' element={<Staff />} />
                                <Route path='/table' element={<Table />} />
                                <Route path='/item' element={<Item />} />
                                {/* Add more routes here */}
                            </Routes>
                        </Content>
                    </Layout>
                </Layout>
            </Layout>
        </Router>
    );
};

export default App;
