import { LogoutOutlined, SearchOutlined } from '@ant-design/icons';
import { Button, Col, Input, Layout, Menu, Row } from 'antd';
import React from 'react';

const { Header, Content, Sider } = Layout;
const { SubMenu } = Menu;

const Navbar = () => {
    return (
        <Header style={{ padding: 0, background: '#fff' }}>
            {/* bổ sung logo ở đây
            https://marketplace.canva.com/EAGHzuEFphw/1/0/1600w/canva-black-and-white-minimalist-circle-restaurant-food-logo-W6O-O70WDwA.jpg */}

            <Row
                justify='space-between'
                align='stretch'
                style={{
                    paddingTop: 20,
                    paddingBottom: 20,
                    paddingLeft: 40,
                    paddingRight: 40
                }}
            >
                <Col>
                    <div>
                        <img
                            src='https://marketplace.canva.com/EAGHzuEFphw/1/0/1600w/canva-black-and-white-minimalist-circle-restaurant-food-logo-W6O-O70WDwA.jpg'
                            width={40}
                            height={40}
                        />
                    </div>
                </Col>
                <Col>
                    <Row align={'middle'}>
                        <Input
                            placeholder='Tìm kiếm'
                            prefix={<SearchOutlined />}
                            style={{ width: 200, marginRight: 50 }}
                        />
                        <Button icon={<LogoutOutlined />} type='primary'>
                            Logout
                        </Button>
                    </Row>
                </Col>
            </Row>
        </Header>
    );
};

export default Navbar;
