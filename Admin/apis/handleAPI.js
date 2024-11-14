import axiosClient from './axiosClinet.js';

const handleAPI = async (url, data, method) => {
    return await axiosClient(url, {
        method: method ?? 'get',
        data
    });
};
export default handleAPI;
