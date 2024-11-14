import axios from 'axios';

// Đặt baseURL cho tất cả các yêu cầu API
const baseURL = 'http://localhost:5011';

// Tạo một instance của Axios
const axiosClient = axios.create({
    baseURL: baseURL, // base URL mặc định
    timeout: 5000, // Thời gian chờ của request
    headers: {
        'Content-Type': 'application/json' // Đặt header mặc định là JSON
    }
});

// Interceptor xử lý trước khi gửi request
axiosClient.interceptors.request.use(
    config => {
        // Không có token nên không cần thêm Authorization header
        return config;
    },
    error => Promise.reject(error)
);

// Interceptor xử lý phản hồi
axiosClient.interceptors.response.use(
    response => response.data, // Trả về dữ liệu khi thành công
    error => {
        // Xử lý lỗi từ server (nếu có)
        if (error.response) {
            if (error.response.status === 404) {
                console.error('API không tồn tại.');
            } else if (error.response.status >= 500) {
                console.error('Lỗi từ phía server. Vui lòng thử lại sau.');
            }
        } else if (error.request) {
            console.error('Không có phản hồi từ server.');
        } else {
            console.error('Lỗi khi thiết lập request:', error.message);
        }
        return Promise.reject(error);
    }
);

export default axiosClient;
