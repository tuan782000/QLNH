import {
    AppstoreAddOutlined,
    HomeOutlined,
    UserOutlined
} from '@ant-design/icons';
import { Layout, Menu } from 'antd';
import React, { useState } from 'react';

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
                    Nhà hàng
                </Menu.Item>
                <Menu.Item key='2' icon={<UserOutlined />}>
                    Quyền
                </Menu.Item>
                <Menu.Item key='3' icon={<AppstoreAddOutlined />}>
                    Tình Trạng
                </Menu.Item>
                <Menu.Item key='4' icon={<AppstoreAddOutlined />}>
                    Khu vực
                </Menu.Item>
                <Menu.Item key='5' icon={<AppstoreAddOutlined />}>
                    Đơn vị
                </Menu.Item>
                <Menu.Item key='6' icon={<AppstoreAddOutlined />}>
                    Thể loại
                </Menu.Item>
                <Menu.Item key='7' icon={<UserOutlined />}>
                    Nhân sự
                </Menu.Item>
                <Menu.Item key='8' icon={<AppstoreAddOutlined />}>
                    Bàn ăn
                </Menu.Item>
                <Menu.Item key='9' icon={<AppstoreAddOutlined />}>
                    Thức ăn
                </Menu.Item>
            </Menu>
        </Sider>
    );
};

export default Sidebar;
