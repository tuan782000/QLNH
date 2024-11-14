import {
    AppstoreAddOutlined,
    HomeOutlined,
    UserOutlined
} from '@ant-design/icons';
import { Layout, Menu } from 'antd';
import React, { useState } from 'react';
import { Link } from 'react-router-dom';

const { Header, Content, Sider } = Layout;
const { SubMenu } = Menu;

const Sidebar = () => {
    const [collapsed, setCollapsed] = useState(false);
    return (
        <Sider
            width={200}
            className='site-layout-background'
            collapsible
            collapsed={collapsed}
            onCollapse={value => setCollapsed(value)}
        >
            <Menu
                mode='inline'
                defaultSelectedKeys={['1']}
                style={{ height: '100%', borderRight: 0 }}
            >
                <Menu.Item key='1' icon={<HomeOutlined />}>
                    <Link to='/'>Home</Link>
                </Menu.Item>
                <Menu.Item key='2' icon={<UserOutlined />}>
                    <Link to='/role'>Quyền</Link>
                </Menu.Item>
                <Menu.Item key='3' icon={<AppstoreAddOutlined />}>
                    <Link to='/status'>Trạng Thái</Link>
                </Menu.Item>
                <Menu.Item key='4' icon={<AppstoreAddOutlined />}>
                    <Link to='/location'>Khu vực</Link>
                </Menu.Item>
                <Menu.Item key='5' icon={<AppstoreAddOutlined />}>
                    <Link to='/unit'>Đơn vị</Link>
                </Menu.Item>
                <Menu.Item key='6' icon={<AppstoreAddOutlined />}>
                    <Link to='/category'>Thể loại</Link>
                </Menu.Item>
                <Menu.Item key='7' icon={<UserOutlined />}>
                    <Link to='/staff'>Nhân sự</Link>
                </Menu.Item>
                <Menu.Item key='8' icon={<AppstoreAddOutlined />}>
                    <Link to='/table'>Bàn ăn</Link>
                </Menu.Item>
                <Menu.Item key='9' icon={<AppstoreAddOutlined />}>
                    <Link to='/item'>Thức ăn</Link>
                </Menu.Item>
                <Menu.Item key='10' icon={<AppstoreAddOutlined />}>
                    <Link to='/restaurant'>Nhà hàng</Link>
                </Menu.Item>
            </Menu>
        </Sider>
    );
};

export default Sidebar;
