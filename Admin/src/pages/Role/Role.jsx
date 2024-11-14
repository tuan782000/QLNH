// import React, { useState, useEffect } from 'react';
// import { Table, Spin, notification, Button, Modal, Input, Form } from 'antd';
// import { EditOutlined, DeleteOutlined } from '@ant-design/icons';
// import handleAPI from '../../../apis/handleAPI';

// const Role = () => {
//     const [roles, setRoles] = useState([]);
//     const [loading, setLoading] = useState(false);
//     const [isModalVisible, setIsModalVisible] = useState(false);
//     const [isEditMode, setIsEditMode] = useState(false);
//     const [selectedRole, setSelectedRole] = useState(null);
//     const [newRole, setNewRole] = useState({ name: '', description: '' });
//     const [form] = Form.useForm(); // Khai báo form sử dụng hook useForm

//     const [isProcessing, setIsProcessing] = useState(false); // Biến trạng thái để ngăn nhấp liên tục

//     useEffect(() => {
//         // Fetch roles khi component mount
//         const fetchRoles = async () => {
//             setLoading(true);
//             try {
//                 const response = await handleAPI(
//                     'http://localhost:5011/api/Role',
//                     null,
//                     'get'
//                 );
//                 setRoles(response);
//                 notification.success({
//                     message: 'Roles Loaded Successfully',
//                     description: 'The roles have been successfully fetched.',
//                     placement: 'topRight',
//                     duration: 2
//                 });
//             } catch (error) {
//                 notification.error({
//                     message: 'Error Fetching Roles',
//                     description: 'There was an error while fetching the roles.',
//                     placement: 'topRight',
//                     duration: 2
//                 });
//             } finally {
//                 setLoading(false);
//             }
//         };

//         fetchRoles();
//     }, []);

//     const handleEdit = async record => {
//         // console.log(record.id);
//         setSelectedRole(record);

//         try {
//             // Fetch role details từ API khi chỉnh sửa
//             const response = await handleAPI(
//                 `http://localhost:5011/api/Role/Id?id=${record.id}`,
//                 null,
//                 'get'
//             );
//             // console.log(response.name, response.description);
//             // setNewRole({
//             //     name: response.name,
//             //     description: response.description
//             // });
//             form.setFieldsValue({
//                 // Đồng bộ dữ liệu từ API vào form
//                 name: response.name,
//                 description: response.description
//             });
//             setIsEditMode(true);
//             setIsModalVisible(true);
//         } catch (error) {
//             notification.error({
//                 message: 'Error Fetching Role Data',
//                 description: 'There was an error while fetching role data.',
//                 placement: 'topRight',
//                 duration: 2
//             });
//         }
//     };

//     const handleCreate = async () => {
//         if (isProcessing) return; // Ngăn không cho nhấp nhiều lần
//         setIsProcessing(true);
//         try {
//             // Sử dụng setTimeout để mô phỏng API call với độ trễ 5 giây
//             setTimeout(() => {
//                 console.log('Tạo thành công');
//                 setIsProcessing(false); // Đặt lại isProcessing ở đây, sau khi kết thúc xử lý
//                 setIsModalVisible(false);
//                 notification.success({
//                     message: 'Role Created',
//                     description: 'New role has been created successfully.',
//                     placement: 'topRight',
//                     duration: 2
//                 });
//             }, 5000);
//         } catch (error) {
//             notification.error({
//                 message: 'Error Creating Role',
//                 description: 'There was an error while creating the role.',
//                 placement: 'topRight',
//                 duration: 2
//             });
//             setIsProcessing(false); // Đặt lại ở đây trong trường hợp lỗi
//         }
//     };

//     const handleSave = async () => {
//         if (isProcessing) return; // Ngăn không cho nhấp nhiều lần
//         setIsProcessing(true);
//         try {
//             // call api

//             // Logic lưu dữ liệu chỉnh sửa

//             setTimeout(() => {
//                 console.log('Sửa thành công');
//                 setIsModalVisible(false);
//                 setIsEditMode(false);
//                 notification.success({
//                     message: 'Role Updated',
//                     description: 'Role has been updated successfully.',
//                     placement: 'topRight',
//                     duration: 2
//                 });
//             }, 5000);
//         } catch (error) {
//             notification.error({
//                 message: 'Error Updating Role',
//                 description: 'There was an error while updating the role.',
//                 placement: 'topRight',
//                 duration: 2
//             });
//             setIsProcessing(false); // Đặt lại ở đây trong trường hợp lỗi
//         }
//     };

//     const handleCancel = () => {
//         setNewRole({ name: '', description: '' }); // Reset the newRole state
//         setIsModalVisible(false);
//         setIsEditMode(false);
//         form.resetFields(); // Reset form khi đóng modal
//     };

//     const handleInputChange = e => {
//         const { name, value } = e.target;
//         setNewRole(prevRole => ({
//             ...prevRole,
//             [name]: value
//         }));
//     };

//     const openCreateModal = () => {
//         setNewRole({ name: '', description: '' }); // Reset the newRole state
//         form.resetFields(); // Xóa sạch dữ liệu trong form
//         setIsEditMode(false); // Đảm bảo là chế độ tạo mới
//         setIsModalVisible(true);
//     };

//     // Handle Delete Action with confirmation modal
//     const handleDelete = record => {
//         if (isProcessing) return; // Ngăn không cho nhấp nhiều lần
//         Modal.confirm({
//             title: 'Are you sure you want to delete this role?',
//             content: `Role: ${record.name}`,
//             onOk: async () => {
//                 try {
//                     // Proceed with the deletion API call
//                     // await handleAPI(
//                     //     `http://localhost:5011/api/Role/${record.id}`,
//                     //     null,
//                     //     'delete'
//                     // );
//                     // Update the roles state after deletion
//                     setRoles(roles.filter(role => role.id !== record.id));
//                     notification.success({
//                         message: 'Role Deleted Successfully',
//                         description: `Role ${record.name} has been deleted.`,
//                         placement: 'topRight',
//                         duration: 2
//                     });
//                 } catch (error) {
//                     notification.error({
//                         message: 'Error Deleting Role',
//                         description:
//                             'There was an error while deleting the role.',
//                         placement: 'topRight',
//                         duration: 2
//                     });
//                 } finally {
//                     setIsProcessing(false); // Hoàn tất xử lý
//                 }
//             },
//             onCancel() {
//                 console.log('Delete action canceled');
//             }
//         });
//     };

//     const columns = [
//         {
//             title: 'Role Name',
//             dataIndex: 'name',
//             key: 'name'
//         },
//         {
//             title: 'Description',
//             dataIndex: 'description',
//             key: 'description'
//         },
//         {
//             title: 'Action',
//             key: 'action',
//             render: (_, record) => (
//                 <div>
//                     <Button
//                         icon={<EditOutlined style={{ color: '#FFD700' }} />}
//                         onClick={() => handleEdit(record)}
//                         style={{ marginRight: 10 }}
//                     />
//                     <Button
//                         icon={<DeleteOutlined />}
//                         danger
//                         onClick={() => handleDelete(record)}
//                     />
//                 </div>
//             )
//         }
//     ];

//     return (
//         <div>
//             <h1>Roles</h1>
//             <div
//                 style={{
//                     display: 'flex',
//                     justifyContent: 'flex-end',
//                     marginBottom: 16
//                 }}
//             >
//                 <Button type='primary' onClick={openCreateModal}>
//                     Create Role
//                 </Button>
//             </div>
//             {loading ? (
//                 <Spin size='large' />
//             ) : (
//                 <Table dataSource={roles} columns={columns} rowKey='id' />
//             )}

//             <Modal
//                 title={isEditMode ? 'Edit Role' : 'Create New Role'}
//                 visible={isModalVisible}
//                 onCancel={handleCancel}
//                 footer={null}
//             >
//                 <Form
//                     form={form} // Truyền form vào Form component
//                     layout='vertical'
//                     onFinish={isEditMode ? handleSave : handleCreate}
//                     initialValues={newRole} // Khởi tạo dữ liệu từ newRole khi mở modal
//                 >
//                     <Form.Item
//                         label='Role Name'
//                         name='name'
//                         rules={[
//                             {
//                                 required: true,
//                                 message: 'Please enter a role name'
//                             },
//                             {
//                                 min: 3,
//                                 message:
//                                     'Role name must be at least 3 characters'
//                             }
//                         ]}
//                     >
//                         <Input
//                             name='name'
//                             value={newRole.name}
//                             onChange={handleInputChange}
//                             placeholder='Enter role name'
//                         />
//                     </Form.Item>
//                     <Form.Item label='Description' name='description'>
//                         <Input
//                             name='description'
//                             value={newRole.description}
//                             onChange={handleInputChange}
//                             placeholder='Enter role description'
//                         />
//                     </Form.Item>
//                     <div style={{ textAlign: 'right' }}>
//                         <Button
//                             onClick={handleCancel}
//                             style={{ marginRight: 8 }}
//                         >
//                             Cancel
//                         </Button>
//                         <Button
//                             type='primary'
//                             htmlType='submit'
//                             disabled={isProcessing}
//                         >
//                             {isEditMode ? 'Save' : 'Create'}
//                         </Button>
//                     </div>
//                 </Form>
//             </Modal>
//         </div>
//     );
// };

// export default Role;

import React, { useState, useEffect } from 'react';
import { Table, Spin, notification, Button, Modal, Input, Form } from 'antd';
import { EditOutlined, DeleteOutlined } from '@ant-design/icons';
import handleAPI from '../../../apis/handleAPI';
import { formatDate } from '../../../utils/formatDate';

const Role = () => {
    const [roles, setRoles] = useState([]);
    const [loading, setLoading] = useState(false);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [isEditMode, setIsEditMode] = useState(false);
    const [selectedRole, setSelectedRole] = useState(null);
    const [newRole, setNewRole] = useState({ name: '', description: '' });
    const [form] = Form.useForm();
    const [isProcessing, setIsProcessing] = useState(false);

    useEffect(() => {
        const fetchRoles = async () => {
            setLoading(true);
            try {
                const response = await handleAPI(
                    'http://localhost:5011/api/Role',
                    null,
                    'get'
                );
                setRoles(response);
                notification.success({
                    message: 'Roles Loaded Successfully',
                    description: 'Roles have been successfully fetched.',
                    placement: 'topRight',
                    duration: 2
                });
            } catch (error) {
                notification.error({
                    message: 'Error Fetching Roles',
                    description: 'There was an error fetching roles.',
                    placement: 'topRight',
                    duration: 2
                });
            } finally {
                setLoading(false);
            }
        };
        fetchRoles();
    }, []);

    const handleEdit = async record => {
        setSelectedRole(record);
        form.setFieldsValue({
            name: record.name,
            description: record.description
        });
        setIsEditMode(true);
        setIsModalVisible(true);
    };

    const handleCreate = async () => {
        if (isProcessing) return;
        setIsProcessing(true);
        try {
            const response = await handleAPI(
                'http://localhost:5011/api/Role',
                newRole,
                'post'
            );
            setRoles(prevRoles => [...prevRoles, response]);
            setIsModalVisible(false);
            notification.success({
                message: 'Role Created',
                description: 'New role created successfully.',
                placement: 'topRight',
                duration: 2
            });
        } catch (error) {
            notification.error({
                message: 'Error Creating Role',
                description: 'Error creating the role.',
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
                `http://localhost:5011/api/Role/Id?id=${selectedRole.id}`,
                newRole,
                'put'
            );
            setRoles(prevRoles =>
                prevRoles.map(role =>
                    role.id === selectedRole.id ? response : role
                )
            );
            setIsModalVisible(false);
            setIsEditMode(false);
            notification.success({
                message: 'Role Updated',
                description: 'Role updated successfully.',
                placement: 'topRight',
                duration: 2
            });
        } catch (error) {
            notification.error({
                message: 'Error Updating Role',
                description: 'Error updating the role.',
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
                title: `Are you sure you want to delete the role ${record.name}?`,
                onOk: async () => {
                    try {
                        await handleAPI(
                            `http://localhost:5011/api/Role/Id?id=${record.id}`,
                            null,
                            'delete'
                        );
                        setRoles(prevRoles =>
                            prevRoles.filter(role => role.id !== record.id)
                        );
                        notification.success({
                            message: 'Role Deleted',
                            description: 'Role deleted successfully.',
                            placement: 'topRight',
                            duration: 2
                        });
                    } catch (error) {
                        notification.error({
                            message: 'Error Deleting Role',
                            description: 'Error deleting the role.',
                            placement: 'topRight',
                            duration: 2
                        });
                    }
                }
            });
        } catch (error) {
            notification.error({
                message: 'Error Deleting Role',
                description: 'Error deleting the role.',
                placement: 'topRight',
                duration: 2
            });
        }
    };

    const handleCancel = () => {
        setNewRole({ name: '', description: '' });
        setIsModalVisible(false);
        setIsEditMode(false);
        form.resetFields();
    };

    const handleInputChange = e => {
        const { name, value } = e.target;
        setNewRole(prev => ({ ...prev, [name]: value }));
    };

    const openCreateModal = () => {
        setNewRole({ name: '', description: '' });
        form.resetFields();
        setIsEditMode(false);
        setIsModalVisible(true);
    };

    const columns = [
        { title: 'Name', dataIndex: 'name', key: 'name' },
        { title: 'Description', dataIndex: 'description', key: 'description' },
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
            <h1>Roles</h1>
            <div
                style={{
                    display: 'flex',
                    justifyContent: 'flex-end',
                    marginBottom: 16
                }}
            >
                <Button type='primary' onClick={openCreateModal}>
                    Create Role
                </Button>
            </div>
            {loading ? (
                <Spin size='large' />
            ) : (
                <Table
                    dataSource={roles}
                    columns={columns}
                    rowKey='id'
                    pagination={{ pageSize: 5 }}
                />
            )}
            <Modal
                title={isEditMode ? 'Edit Role' : 'Create New Role'}
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
                            value={newRole.name}
                            onChange={handleInputChange}
                            placeholder='Enter role name'
                        />
                    </Form.Item>
                    <Form.Item label='Description' name='description'>
                        <Input
                            name='description'
                            value={newRole.description}
                            onChange={handleInputChange}
                            placeholder='Enter description'
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

export default Role;
