import React, { useState, useEffect } from 'react';
import { Table, Spin, notification, Button, Modal, Input, Form } from 'antd';
import { EditOutlined, DeleteOutlined } from '@ant-design/icons';
import handleAPI from '../../../apis/handleAPI';
import { formatDate } from '../../../utils/formatDate';

const Restaurant = () => {
    const [restaurants, setRestaurants] = useState([]);
    const [loading, setLoading] = useState(false);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [isEditMode, setIsEditMode] = useState(false);
    const [selectedRestaurant, setSelectedRestaurant] = useState(null);
    const [newRestaurant, setNewRestaurant] = useState({
        name: '',
        description: '',
        phone: '',
        address: ''
    });
    const [form] = Form.useForm();
    const [isProcessing, setIsProcessing] = useState(false);

    useEffect(() => {
        const fetchRestaurants = async () => {
            setLoading(true);
            try {
                const response = await handleAPI(
                    'http://localhost:5011/api/Restaurant',
                    null,
                    'get'
                );
                setRestaurants(response);
                notification.success({
                    message: 'Restaurants Loaded Successfully',
                    description:
                        'The restaurants have been successfully fetched.',
                    placement: 'topRight',
                    duration: 2
                });
            } catch (error) {
                notification.error({
                    message: 'Error Fetching Restaurants',
                    description:
                        'There was an error while fetching the restaurants.',
                    placement: 'topRight',
                    duration: 2
                });
            } finally {
                setLoading(false);
            }
        };

        fetchRestaurants();
    }, []);

    const handleEdit = async record => {
        setSelectedRestaurant(record);
        console.log(record);
        try {
            // Gửi PUT request với toàn bộ dữ liệu nhà hàng cần cập nhật
            const response = await handleAPI(
                `http://localhost:5011/api/Restaurant/Id?id=${record.id}`,
                {
                    name: record.name,
                    description: record.description,
                    phone: record.phone,
                    address: record.address
                },
                'put' // Sử dụng PUT thay vì GET
            );

            if (response) {
                form.setFieldsValue({
                    name: response.name,
                    description: response.description,
                    phone: response.phone,
                    address: response.address
                });
                setIsEditMode(true);
                setIsModalVisible(true);
            }
        } catch (error) {
            notification.error({
                message: 'Error Fetching Restaurant Data',
                description:
                    'There was an error while fetching restaurant data.',
                placement: 'topRight',
                duration: 2
            });
        }
    };

    const handleCreate = async () => {
        if (isProcessing) return;
        setIsProcessing(true);
        try {
            const response = await handleAPI(
                'http://localhost:5011/api/Restaurant',
                newRestaurant,
                'post'
            );

            // Thêm nhà hàng mới vào danh sách mà không cần reload trang
            setRestaurants(prevRestaurants => [...prevRestaurants, response]);
            setIsModalVisible(false);
            notification.success({
                message: 'Restaurant Created',
                description: 'New restaurant has been created successfully.',
                placement: 'topRight',
                duration: 2
            });
        } catch (error) {
            notification.error({
                message: 'Error Creating Restaurant',
                description:
                    'There was an error while creating the restaurant.',
                placement: 'topRight',
                duration: 2
            });
        } finally {
            setIsProcessing(false);
        }
    };

    const handleSave = async () => {
        if (isProcessing) return;
        setIsProcessing(true);
        try {
            const response = await handleAPI(
                `http://localhost:5011/api/Restaurant/Id?id=${selectedRestaurant.id}`,
                newRestaurant,
                'put'
            );

            // Cập nhật nhà hàng đã chỉnh sửa trong danh sách
            setRestaurants(prevRestaurants =>
                prevRestaurants.map(restaurant =>
                    restaurant.id === selectedRestaurant.id
                        ? response
                        : restaurant
                )
            );
            setIsModalVisible(false);
            setIsEditMode(false);
            notification.success({
                message: 'Restaurant Updated',
                description: 'Restaurant has been updated successfully.',
                placement: 'topRight',
                duration: 2
            });
        } catch (error) {
            notification.error({
                message: 'Error Updating Restaurant',
                description:
                    'There was an error while updating the restaurant.',
                placement: 'topRight',
                duration: 2
            });
        } finally {
            setIsProcessing(false);
        }
    };

    const handleDelete = async record => {
        try {
            Modal.confirm({
                title: `Are you sure you want to delete with ${record.name} restaurant?`,
                onOk: async () => {
                    try {
                        // Gửi request DELETE đến backend để soft delete
                        await handleAPI(
                            `http://localhost:5011/api/Restaurant/Id?id=${record.id}`,
                            null,
                            'delete'
                        );

                        // Cập nhật lại trạng thái để loại bỏ nhà hàng đã xóa khỏi UI
                        setRestaurants(prevRestaurants =>
                            prevRestaurants.filter(
                                restaurant => restaurant.id !== record.id
                            )
                        );

                        notification.success({
                            message: 'Restaurant Deleted',
                            description:
                                'Restaurant has been soft deleted successfully.',
                            placement: 'topRight',
                            duration: 2
                        });
                    } catch (error) {
                        notification.error({
                            message: 'Error Deleting Restaurant',
                            description:
                                'There was an error while deleting the restaurant.',
                            placement: 'topRight',
                            duration: 2
                        });
                    }
                }
            });
        } catch (error) {
            notification.error({
                message: 'Error Deleting Restaurant',
                description:
                    'There was an error while deleting the restaurant.',
                placement: 'topRight',
                duration: 2
            });
        }
    };

    const handleCancel = () => {
        setNewRestaurant({ name: '', description: '', phone: '', address: '' });
        setIsModalVisible(false);
        setIsEditMode(false);
        form.resetFields();
    };

    const handleInputChange = e => {
        const { name, value } = e.target;
        setNewRestaurant(prev => ({
            ...prev,
            [name]: value
        }));
    };

    const openCreateModal = () => {
        setNewRestaurant({ name: '', description: '', phone: '', address: '' });
        form.resetFields();
        setIsEditMode(false);
        setIsModalVisible(true);
    };

    const columns = [
        { title: 'Name', dataIndex: 'name', key: 'name' },
        { title: 'Description', dataIndex: 'description', key: 'description' },
        { title: 'Phone', dataIndex: 'phone', key: 'phone' },
        { title: 'Address', dataIndex: 'address', key: 'address' },
        {
            title: 'Created',
            dataIndex: 'created',
            key: 'created',
            render: text => formatDate(text)
        },
        {
            title: 'Updated',
            dataIndex: 'updated',
            key: 'updated',
            render: text => formatDate(text)
        },
        {
            title: 'Action',
            key: 'action',
            render: (_, record) => (
                <div>
                    <Button
                        icon={<EditOutlined style={{ color: '#FFD700' }} />}
                        onClick={() => handleEdit(record)}
                        style={{ marginRight: 10 }}
                    />
                    <Button
                        icon={<DeleteOutlined />}
                        danger
                        onClick={() => handleDelete(record)}
                    />
                </div>
            )
        }
    ];

    return (
        <div>
            <h1>Restaurants</h1>
            <div
                style={{
                    display: 'flex',
                    justifyContent: 'flex-end',
                    marginBottom: 16
                }}
            >
                <Button type='primary' onClick={openCreateModal}>
                    Create Restaurant
                </Button>
            </div>
            {loading ? (
                <Spin size='large' />
            ) : (
                <Table
                    dataSource={restaurants}
                    columns={columns}
                    rowKey='id'
                    pagination={{ pageSize: 5 }}
                />
            )}

            <Modal
                title={isEditMode ? 'Edit Restaurant' : 'Create New Restaurant'}
                visible={isModalVisible}
                onCancel={handleCancel}
                footer={null}
            >
                <Form
                    form={form}
                    layout='vertical'
                    onFinish={isEditMode ? handleSave : handleCreate}
                >
                    <Form.Item
                        label='Name'
                        name='name'
                        rules={[
                            { required: true, message: 'Please enter a name' }
                        ]}
                    >
                        <Input
                            name='name'
                            value={newRestaurant.name}
                            onChange={handleInputChange}
                            placeholder='Enter name'
                        />
                    </Form.Item>
                    <Form.Item label='Description' name='description'>
                        <Input
                            name='description'
                            value={newRestaurant.description}
                            onChange={handleInputChange}
                            placeholder='Enter description'
                        />
                    </Form.Item>
                    <Form.Item label='Phone' name='phone'>
                        <Input
                            name='phone'
                            value={newRestaurant.phone}
                            onChange={handleInputChange}
                            placeholder='Enter phone'
                        />
                    </Form.Item>
                    <Form.Item label='Address' name='address'>
                        <Input
                            name='address'
                            value={newRestaurant.address}
                            onChange={handleInputChange}
                            placeholder='Enter address'
                        />
                    </Form.Item>
                    <div style={{ textAlign: 'right' }}>
                        <Button
                            onClick={handleCancel}
                            style={{ marginRight: 8 }}
                        >
                            Cancel
                        </Button>
                        <Button
                            type='primary'
                            htmlType='submit'
                            disabled={isProcessing}
                        >
                            {isEditMode ? 'Save' : 'Create'}
                        </Button>
                    </div>
                </Form>
            </Modal>
        </div>
    );
};

export default Restaurant;
