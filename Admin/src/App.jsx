// import React, { useState } from 'react';
// import { Button } from 'antd';
// import handleAPI from '../apis/handleAPI';

// const App = () => {
//     const [loading, setLoading] = useState(false);
//     const [responseData, setResponseData] = useState(null);

//     const handleApiCall = async () => {
//         setLoading(true); // Đánh dấu bắt đầu gọi API

//         try {
//             const response = await handleAPI(
//                 'http://localhost:5011/api/Role',
//                 null,
//                 'get'
//             ); // Sử dụng handleAPI thay vì axios trực tiếp
//             setResponseData(response); // Lưu kết quả vào state
//             console.log('API response:', response); // In ra kết quả trả về
//         } catch (error) {
//             console.error('Error calling API:', error);
//         } finally {
//             setLoading(false); // Đánh dấu kết thúc gọi API
//         }
//     };

//     return (
//         <div>
//             <Button
//                 type='primary'
//                 loading={loading} // Hiển thị trạng thái loading
//                 onClick={handleApiCall}
//             >
//                 Call API
//             </Button>
//             {responseData && (
//                 <div>
//                     <h3>Response:</h3>
//                     <pre>{JSON.stringify(responseData, null, 2)}</pre>
//                 </div>
//             )}
//         </div>
//     );
// };

// export default App;

import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Layout } from 'antd';
import Navbar from './components/Navbar';
import Sidebar from './components/Sidebar';
import { Category, Location, Role, Status, Unit } from './pages';

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
                                <Route path='/role' element={Role} />
                                <Route path='/status' element={Status} />
                                <Route path='/location' element={Location} />
                                <Route path='/unit' element={Unit} />
                                <Route path='/category' element={Category} />
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
