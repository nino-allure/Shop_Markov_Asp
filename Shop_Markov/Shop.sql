-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 21 2026 г., 12:08
-- Версия сервера: 5.7.39-log
-- Версия PHP: 8.0.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `Shop`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Categories`
--

CREATE TABLE `Categories` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Description` text COLLATE utf8mb4_unicode_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Categories`
--

INSERT INTO `Categories` (`Id`, `Name`, `Description`) VALUES
(1, 'Электроника', 'Смартфоны, ноутбуки, планшеты и другая электроника'),
(2, 'Одежда', 'Мужская, женская и детская одежда'),
(3, 'Дом и сад', 'Товары для дома, сада и интерьера'),
(4, 'Спорт', 'Спортивный инвентарь и оборудование'),
(5, 'Книги', 'Художественная литература, учебники и журналы'),
(6, 'Игрушки', 'Детские игрушки и развивающие игры'),
(7, 'Красота и здоровье', 'Косметика, парфюмерия и средства гигиены'),
(8, 'Автотовары', 'Аксессуары и запчасти для автомобилей');

-- --------------------------------------------------------

--
-- Структура таблицы `Items`
--

CREATE TABLE `Items` (
  `Id` int(11) NOT NULL,
  `Name` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Description` text COLLATE utf8mb4_unicode_ci,
  `Img` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Price` decimal(10,2) NOT NULL,
  `CategoryId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Items`
--

INSERT INTO `Items` (`Id`, `Name`, `Description`, `Img`, `Price`, `CategoryId`) VALUES
(1, 'Смартфон Apple iPhone 15 Pro', '256GB, титановый корпус, 48MP камера', '/images/iphone15pro.jpg', '999.99', 1),
(2, 'Ноутбук ASUS ROG Strix G16', 'Intel Core i9, 32GB RAM, 1TB SSD, RTX 4080', '/images/asus_rog.jpg', '1999.99', 1),
(3, 'Планшет Samsung Galaxy Tab S9', '11\" AMOLED, 256GB, S Pen в комплекте', '/images/galaxy_tab.jpg', '799.99', 1),
(4, 'Наушники Sony WH-1000XM5', 'Беспроводные, активное шумоподавление', '/images/sony_headphones.jpg', '349.99', 1),
(5, 'Футболка хлопковая', 'Классический крой, 100% хлопок, различные цвета', '/images/tshirt.jpg', '29.99', 2),
(6, 'Джинсы мужские', 'Слим фит, темно-синий, размеры 28-40', '/images/jeans.jpg', '79.99', 2),
(7, 'Пуховик зимний', 'Водоотталкивающая ткань, наполнитель 80/20', '/images/jacket.jpg', '199.99', 2),
(8, 'Кроссовки Nike Air Max', 'Легкие, дышащие, амортизация', '/images/nike_airmax.jpg', '129.99', 2),
(9, 'Набор посуды', '24 предмета, нержавеющая сталь', '/images/cookware.jpg', '149.99', 3),
(10, 'Постельное белье', 'Сатин, 2-спальный комплект', '/images/bedding.jpg', '59.99', 3),
(11, 'Садовая мебель', 'Набор стул+стол, алюминиевый каркас', '/images/garden_furniture.jpg', '299.99', 3),
(12, 'Робот-пылесос', 'Лазерная навигация, функция влажной уборки', '/images/robot_vacuum.jpg', '399.99', 3),
(13, 'Беговая дорожка', 'Электрическая, 12 программ, макс. нагрузка 120кг', '/images/treadmill.jpg', '599.99', 4),
(14, 'Велосипед горный', 'Алюминиевая рама, 24 скорости', '/images/bike.jpg', '449.99', 4),
(15, 'Гантели разборные', 'Набор 20кг, с регулировкой веса', '/images/dumbbells.jpg', '89.99', 4),
(16, 'Фитнес-браслет', 'Шагомер, пульсометр, мониторинг сна', '/images/fitness_band.jpg', '49.99', 4),
(17, 'Война и мир', 'Лев Толстой, классическое издание', '/images/war_and_peace.jpg', '19.99', 5),
(18, 'Преступление и наказание', 'Федор Достоевский, подарочное издание', '/images/crime_punishment.jpg', '15.99', 5),
(19, 'Современная веб-разработка', 'Учебник по современным технологиям', '/images/web_dev.jpg', '49.99', 5),
(20, 'LEGO Technic', 'Автомобиль, 1500 деталей', '/images/lego.jpg', '89.99', 6),
(21, 'Мягкая игрушка Медведь', 'Высота 50см, гипоаллергенный материал', '/images/teddy_bear.jpg', '34.99', 6),
(22, 'Конструктор магнитный', '100 деталей, развивающий набор', '/images/magnetic_blocks.jpg', '44.99', 6),
(23, 'Парфюмерный набор', '3 аромата по 50мл, подарочная упаковка', '/images/perfume.jpg', '79.99', 7),
(24, 'Маска для волос', 'Восстанавливающая, 300мл', '/images/hair_mask.jpg', '24.99', 7),
(25, 'Массажер для спины', 'Электрический, с подогревом', '/images/massager.jpg', '89.99', 7),
(26, 'Автомобильный видеорегистратор', '4K, ночная съемка, GPS', '/images/dashcam.jpg', '129.99', 8),
(27, 'Чехлы для сидений', 'Универсальные, дышащие', '/images/seat_covers.jpg', '89.99', 8),
(28, 'Набор инструментов', '100 предметов, в кейсе', '/images/tool_set.jpg', '149.99', 8);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Categories`
--
ALTER TABLE `Categories`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `idx_categories_name` (`Name`);

--
-- Индексы таблицы `Items`
--
ALTER TABLE `Items`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `idx_items_name` (`Name`),
  ADD KEY `idx_items_category` (`CategoryId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Categories`
--
ALTER TABLE `Categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `Items`
--
ALTER TABLE `Items`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Items`
--
ALTER TABLE `Items`
  ADD CONSTRAINT `items_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
