create database saledb;
using saledb;

CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    full_name VARCHAR(100),
    role VARCHAR(20) CHECK (role IN ('customer', 'staff', 'admin')) DEFAULT 'customer',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);  

CREATE TABLE sessions (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(), -- sessionid
    user_id INT REFERENCES users(id) ON DELETE CASCADE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    expires_at TIMESTAMP NOT NULL,
    is_active BOOLEAN DEFAULT TRUE
);

CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    price NUMERIC(12,2) NOT NULL,
    stock INT NOT NULL DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    user_id INT REFERENCES users(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE order_items (
    id SERIAL PRIMARY KEY,
    order_id INT REFERENCES orders(id) ON DELETE CASCADE,
    product_id INT REFERENCES products(id),
    quantity INT NOT NULL CHECK (quantity > 0),
    price NUMERIC(12,2) NOT NULL
);

INSERT INTO users (username, password_hash, email, full_name, role)
VALUES
-- ('alice', '123456', 'alice@example.com', 'Alice Nguyen', 'customer'),
-- ('bob',   '123456', 'bob@example.com',   'Bob Tran',   'staff'),
-- ('admin', '123456', 'admin@example.com', 'System Admin', 'admin');
('sang', '123456', 'sang@gmail.com', 'sang', 'admin'),
('customer', '123456', 'khach@gmail.com', 'customer', 'customer');
('seller', '123456', 'seller@gmail.com', 'seller', 'seller');


INSERT INTO products (name, description, price, stock)
VALUES
('iPhone 15', 'Apple smartphone 256GB', 29990000, 10),
('Samsung Galaxy S24', 'Samsung flagship 256GB', 25990000, 15),
('MacBook Air M2', 'Apple laptop M2 13 inch', 32990000, 5),
('Logitech Mouse', 'Wireless mouse', 499000, 100);

INSERT INTO orders (user_id)
VALUES
(1)

INSERT INTO order_items (order_id, product_id, quantity, price)
VALUES
(1, 1, 1, 29990000), -- iPhone
(1, 4, 1,   499000), -- Mouse
(2, 3, 1, 32990000); -- MacBook