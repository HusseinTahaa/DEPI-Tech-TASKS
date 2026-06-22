

create table authors (
    author_id   int identity  primary key,
    name        varchar(150) not null
);




create table books (
    book_id     int identity primary key,
    title       varchar(200) not null,
    author_id   int not null,
    category_id int not null,
    price       decimal(10,2) not null,
    stock       int not null default 0,
    is_active   bit not null default 1,
    constraint fk_books_author   foreign key (author_id)   references authors(author_id),
    constraint fk_books_category foreign key (category_id) references categories(category_id),
    constraint chk_books_price_positive check (price > 0),
    constraint chk_books_stock_nonneg   check (stock >= 0)
);


create table customers (
    customer_id int identity primary key,
    name        varchar(150) not null,
    email       varchar(150) not null unique,
    city        varchar(100)
);

create table orders (
    order_id    int identity primary key,
    customer_id int not null,
    order_date  date not null,
    constraint fk_orders_customer foreign key (customer_id) references customers(customer_id)
);


create table order_items (
    order_id    int not null,
    book_id     int not null,
    quantity    int not null,
    unit_price  decimal(10,2) not null,
    primary key (order_id, book_id),
    constraint fk_items_order foreign key (order_id) references orders(order_id) on delete cascade,
    constraint fk_items_book  foreign key (book_id)  references books(book_id)  on delete no action,
    constraint chk_items_qty_positive   check (quantity > 0),
    constraint chk_items_price_positive check (unit_price > 0)
);



insert into authors (name) values
('george orwell'),
('j.k. rowling'),
('agatha christie'),
('isaac asimov'),
('yuval noah harari'),
('robert c. martin'),
('frank herbert');

insert into categories (name) values
('fiction'),
('fantasy'),
('mystery'),
('science fiction'),
('non-fiction'),
('technology'),
('history');

insert into books (title, author_id, category_id, price, stock, is_active) values
('1984',                          1, 1, 12.99, 40, 1),
('animal farm',                   1, 1,  9.99,  3, 1),
('harry potter and the sorcerer''s stone', 2, 2, 15.99, 25, 1),
('harry potter and the chamber of secrets',2, 2, 15.99, 18, 1),
('harry potter and the prisoner of azkaban',2,2, 16.99, 12, 1),
('murder on the orient express',  3, 3, 11.50,  2, 1),
('the abc murders',               3, 3, 10.50, 30, 1),
('and then there were none',      3, 3, 13.25,  5, 1),
('foundation',                    4, 4, 14.00, 22, 1),
('i, robot',                      4, 4, 13.50,  0, 1),
('sapiens',                       5, 5, 18.00, 17, 1),
('homo deus',                     5, 5, 17.50,  9, 1),
('clean code',                    6, 6, 32.00, 14, 1),
('the clean coder',               6, 6, 28.00,  4, 1),
('dune',                          7, 4, 19.99, 28, 1),
('dune messiah',                  7, 4, 16.00,  1, 1),
('children of dune',              7, 4, 16.50,  6, 1),
('god emperor of dune',           7, 4, 17.00, 10, 1),
('old out-of-print pamphlet',     1, 7,  5.00,  0, 0);

insert into customers (name, email, city) values
('aisha mansour',    'aisha.mansour@example.com',  'cairo'),
('omar khaled',      'omar.khaled@example.com',    'cairo'),
('lina sami',        'lina.sami@example.com',      'giza'),
('youssef adel',     'youssef.adel@example.com',   'cairo'),
('mona farouk',      'mona.farouk@example.com',    'alexandria'),
('karim tarek',      'karim.tarek@example.com',    'giza'),
('nour hassan',      'nour.hassan@example.com',    'cairo'),
('hana mostafa',     'hana.mostafa@example.com',   'luxor'),
('sara ibrahim',     'sara.ibrahim@example.com',   'alexandria'),
('tamer ezz',        'tamer.ezz@example.com',      'cairo');

insert into orders (customer_id, order_date) values
(1, '2025-01-15'),
(2, '2025-01-20'),
(1, '2025-02-03'),
(3, '2025-02-10'),
(4, '2025-02-18'),
(5, '2025-03-01'),
(2, '2025-03-05'),
(6, '2025-03-12'),
(1, '2025-04-02'),
(7, '2025-04-15'),
(8, '2025-04-20'),
(3, '2025-05-01'),
(9, '2025-05-10'),
(5, '2025-05-22'),
(4, '2025-06-01');


insert into order_items (order_id, book_id, quantity, unit_price) values
(1,  1, 1, 11.99),  
(1,  3, 1, 15.99),
(2,  6, 1, 11.50),
(2,  7, 2, 10.50),
(3,  1, 2, 12.99),
(3,  9, 1, 14.00),
(4,  3, 1, 15.99),
(4,  4, 1, 15.99),
(4,  5, 1, 16.99),
(5,  11,1, 18.00),
(6,  13,1, 32.00),
(6,  15,1, 19.99),
(7,  1, 3, 12.99),
(7,  2, 1,  9.99),
(8,  16,1, 16.00),
(9,  3, 2, 15.99),
(10, 8, 1, 13.25),
(10, 6, 1, 11.50),
(11, 12,1, 17.50),
(12, 1, 1, 12.99),
(12, 9, 2, 14.00),
(13, 3, 1, 15.99),
(13, 14,1, 28.00),
(14, 1, 4, 12.99),
(14, 17,1, 16.50),
(15, 3, 1, 15.99),
(15, 1, 1, 12.99);


-- =====================================================================
-- task 3: all books sorted by price, highest to lowest
-- =====================================================================
select book_id, title, price
from books
order by price desc;


-- =====================================================================
-- task 4: book titles in uppercase, author names in lowercase
-- =====================================================================
select
    upper(b.title)   as title_upper,
    lower(a.name)    as author_lower
from books b
join authors a on a.author_id = b.author_id;


-- =====================================================================
-- task 5: every book with its category and its author
-- =====================================================================
select
    b.title,
    c.name as category,
    a.name as author
from books b
join categories c on c.category_id = b.category_id
join authors a    on a.author_id   = b.author_id
order by b.title;


-- =====================================================================
-- task 6: every customer with the number of purchases they have made

-- =====================================================================
select
    cu.customer_id,
    cu.name,
    count(o.order_id) as purchase_count
from customers cu
left join orders o on o.customer_id = cu.customer_id
group by cu.customer_id, cu.name
order by purchase_count desc, cu.name;


-- =====================================================================
-- task 7: top 5 best-selling books (by total quantity sold)
-- =====================================================================
select top(5)
    b.book_id,
    b.title,
    sum(oi.quantity) as total_sold
from order_items oi
join books b on b.book_id = oi.book_id
group by b.book_id, b.title
order by total_sold desc



-- =====================================================================
-- task 8: city with the highest number of customers
-- =====================================================================
select top(1)
    city,
    count(*) as customer_count
from customers
group by city
order by customer_count desc

-- =====================================================================
-- task 9: categories that have more than 5 books
-- =====================================================================
select
    c.name as category,
    count(b.book_id) as book_count
from categories c
join books b on b.category_id = c.category_id
group by c.category_id, c.name
having count(b.book_id) > 5;


-- =====================================================================
-- task 10: books that cost more than the average book price
-- =====================================================================
select
    title,
    price
from books
where price > (select avg(price) from books)
order by price desc;


-- =====================================================================
-- task 11: customers who have never made a purchase
-- =====================================================================
select
    cu.customer_id,
    cu.name,
    cu.email
from customers cu
left join orders o on o.customer_id = cu.customer_id
where o.order_id is null;


-- =====================================================================
-- task 12: total revenue for each month

-- =====================================================================
select
    format(o.order_date, '%y-%m') as month,
    sum(oi.quantity * oi.unit_price)   as total_revenue
from orders o
join order_items oi on oi.order_id = o.order_id
group by format(o.order_date, '%y-%m')
order by month;


-- =====================================================================
-- task 13: view combining book title, category, author, and price
-- =====================================================================
create view book_catalog as
select
    b.book_id,
    b.title,
    c.name  as category,
    a.name  as author,
    b.price
from books b
join categories c on c.category_id = b.category_id
join authors a    on a.author_id   = b.author_id
where b.is_active = 1;   

-- example usage:
 select * from book_catalog order by category, title;



--- =====================================================================
-- task 14: stored procedure - all purchases of a given customer + totals
-- =====================================================================



create procedure get_customer_purchases (
    @p_customer_id int
)
as
begin
  
    select
        o.order_id,
        o.order_date,
        b.title,
        oi.quantity,
        oi.unit_price,
        (oi.quantity * oi.unit_price) as line_total
    from orders o
    join order_items oi on oi.order_id = o.order_id
    join books b        on b.book_id   = oi.book_id
    where o.customer_id = @p_customer_id
    order by o.order_date;

    -- summary: grand total spent by this customer
    select
        o.customer_id,
        count(distinct o.order_id)            as total_orders,
        sum(oi.quantity * oi.unit_price)      as total_spent
    from orders o
    join order_items oi on oi.order_id = o.order_id
    where o.customer_id = @p_customer_id
    group by o.customer_id;
end 




exec get_customer_purchases @p_customer_id = 1;

   