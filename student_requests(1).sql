-- phpMyAdmin SQL Dump
-- version 3.4.6
-- http://www.phpmyadmin.net
--
-- Хост: localhost:3306
-- Время создания: Апр 29 2021 г., 14:21
-- Версия сервера: 5.6.27
-- Версия PHP: 5.5.20-pl0-gentoo




/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `student_requests`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Catalog`
--

CREATE TABLE Catalog (
  Id_clothes int NOT NULL,
  Name varchar(256) NOT NULL,
  Article int NOT NULL,
  Size varchar(256) NOT NULL,
  Attribute varchar(1) NOT NULL,
)  ;

--
-- Дамп данных таблицы `Catalog`
--

INSERT INTO Catalog ('Id_clothes', 'Name', 'Article', 'Size', 'Attribute') VALUES
(1, 'костюм (халат) для защиты от общих производственных загрязнений ', 122336, 'S', 'М'),
(2, 'костюм (халат) для защиты от общих производственных загрязнений', 211236, 'S', 'Ж'),
(3, 'костюм (халат) для защиты от общих производственных загрязнений', 322136, 'M', 'М'),
(4, 'костюм (халат) для защиты от общих производственных загрязнений', 431236, 'M', 'Ж'),
(5, 'Перчатки с полимерным покрытием ', 748596, 'M', 'Ж'),
(6, 'Перчатки с полимерным покрытием', 326598, 'M', 'М'),
(7, 'Перчатки с полимерным покрытием', 525258, 'L', 'Ж'),
(8, 'Перчатки с полимерным покрытием', 215986, 'L', 'М'),
(9, 'Жилет утепленный ', 857496, 'S', 'Ж'),
(10, 'Жилет утепленный', 968574, 'S', 'М'),
(11, 'полуботинки кожанные ', 635241, '39', 'Ж'),
(12, 'полуботинки кожанные ', 526341, '39', 'М'),
(13, 'полуботинки кожанные ', 415263, '42', 'Ж'),
(14, 'полуботинки кожанные ', 326541, '42', 'М'),
(15, 'наушники противошумные ', 451278, 'М', 'Ж'),
(16, 'наушники противошумные ', 986532, 'М', 'М'),
(17, 'сапоги резиновые', 984532, '40', 'Ж'),
(18, 'сапоги резиновые', 789852, '40', 'М'),
(19, 'сапоги резиновые', 829371, '43', 'Ж'),
(20, 'сапоги резиновые', 791346, '43', 'М'),
(21, 'Куртка на утепляющей прокладке ', 917364, 'М', 'Ж'),
(22, 'Куртка на утепляющей прокладке ', 497631, 'М', 'М'),
(23, 'Куртка на утепляющей прокладке ', 927282, 'L', 'Ж'),
(24, 'Куртка на утепляющей прокладке ', 917181, 'L', 'М'),
(25, 'перчатки резиновые ', 854565, 'М', 'Ж'),
(26, 'перчатки резиновые ', 191713, 'М', 'М'),
(27, 'перчатки резиновые ', 292723, 'L', 'Ж'),
(28, 'перчатки резиновые ', 373934, 'L', 'М'),
(29, 'Сапоги утепленные ', 676169, '42', 'Ж'),
(30, 'Сапоги утепленные ', 494643, '42', 'М');

-- --------------------------------------------------------

--
-- Структура таблицы `Divisions`
--

CREATE TABLE Divisions (
  Id_division int NOT NULL,
  code varchar(256) NOT NULL,
  Name varchar(256) NOT NULL,
  Id_chief int DEFAULT NULL,
  phone int NOT NULL,
  Description varchar(256) NOT NULL,
) ;

--
-- Дамп данных таблицы `Divisions`
--

INSERT INTO Divisions ('Id_division', 'code', 'Name', 'Id_chief', 'phone', 'Description') VALUES
(1, '000100', 'Механический цех', 1, 2599876, 'занимаются изготовлением механических деталей '),
(2, '000200', 'Инструментальный цех', 2, 2595653, 'занимаются изготовлением инструментов '),
(3, '000300', 'Транспортный цех', 3, 2599636, 'занимается транспортировкой '),
(4, '000400', 'Опытный цех', 4, 2598754, 'занимается производством материалов в единичных колличествах '),
(5, '000500', 'Сварочный цех ', 5, 2598512, 'занимается свариванием деталей '),
(6, '000600', 'Отдел кадров ', 6, 2593217, 'занимается набором персонала '),
(7, '000700', 'Финансовый отдел', 7, 2597852, 'занимаются учетом и ведением финансов '),
(8, '000800', 'Технологический отедл ', 8, 2595421, 'занимается проектированием'),
(9, '000900', 'Отдел главного металлурга ', 9, 2592154, 'занимается выпуском конкуретноспособной продукции '),
(10, '000110', 'Информационнй отдел', 10, 2596532, 'занимается аналитической и оперативной работой');

-- --------------------------------------------------------

--
-- Структура таблицы `Orders`
--

CREATE TABLE Orders (
  Id_order int NOT NULL,
  Name varchar(256) NOT NULL,
  Description varchar(256) NOT NULL,
  Id_clothes int NOT NULL,
  Count int NOT NULL,
  Id_user int NOT NULL,
  DateTime datetime NOT NULL,
  Status varchar(256) NOT NULL,
) ;

--
-- Дамп данных таблицы `Orders`
--

INSERT INTO Orders ('Id_order', 'Name', 'Description', 'Id_clothes', 'Count', 'Id_user', 'DateTime', 'Status') VALUES
(1, 'костюм (халат) для защиты от общих производственных загрязнений', 'требуется срочно', 1, 1, 1, '2021-04-15 00:00:00', 'В ожидании'),
(2, 'Перчатки с полимерным покрытием', 'доставте', 6, 2, 2, '2021-04-17 00:00:00', 'Одобрено'),
(3, 'Жилет утепленный', 'доставте', 3, 2, 3, '2021-04-18 00:00:00', 'Отказано');

-- --------------------------------------------------------

--
-- Структура таблицы `Posts`
--

CREATE TABLE Posts (
  Id_post int NOT NULL,
  Name varchar(256) NOT NULL,
) ;

--
-- Дамп данных таблицы `Posts`
--

INSERT INTO Posts ('Id_post', 'Name') VALUES
(1, 'Начальник механического цеха'),
(2, 'Зам начальника механического цеха'),
(3, 'Начальник инструментального цеха'),
(4, 'Зам начальника инструментального цеха'),
(5, 'Начальник транспортного цеха'),
(6, 'Зам начальника транспортного цеха'),
(7, 'Начальник опытного цеха'),
(8, 'зам начальника опытного цеха'),
(9, 'Начальник сварочного цеха'),
(10, 'Зам начальника сварочного цеха'),
(11, 'Начальник отдела кадров'),
(12, 'Зам начальника отдела кадров '),
(13, 'Начальник финансового отдела '),
(14, 'Зам начальника финансового отдела'),
(15, 'Начальник технологического отдела'),
(16, 'Зам начальника технологического отдела'),
(17, 'Главный металлург '),
(18, 'Зам главы металлурга '),
(19, 'Начальник информационного отдела'),
(20, 'Зам начальника информационного отедла ');

-- --------------------------------------------------------

--
-- Структура таблицы `Users`
--

CREATE TABLE Users (
  Id_users int NOT NULL,
  Fio varchar(256) NOT NULL,
  login varchar(256) NOT NULL,
  Password varchar(256) NOT NULL,
  Id_division int NOT NULL,
  Id_post varchar(256) NOT NULL,
  phone int NOT NULL,
) ;

--
-- Дамп данных таблицы `Users`
--

INSERT INTO Users ('Id_users', 'Fio', 'login', 'Password', 'Id_division', 'Id_post', 'phone') VALUES
(1, 'Вилявина Наталья Генадьевна ', 'Vialivna', '123', 1, '1', 89562321),
(2, 'Жуин Михаил Юрьевич', 'Zuin', '124', 1, '2', 89562154),
(3, 'Князев Иван Витальевич', 'Knezev', '125', 2, '3', 89747454),
(4, 'Хорева Юлия Дмитриевна', 'Horeva', '126', 2, '4', 89545120),
(5, 'Солнцева Наталья Генадьевна', 'Solncheva', '127', 3, '5', 89525257),
(6, 'Морозова Татьяна Юрьевна', 'Morozova', '128', 3, '6', 89545474),
(7, 'Пономарев Иван Савельевич', 'Ponamarev', '129', 4, '7', 89636274),
(8, 'Семенова Ева Константиновна', 'Semenova', '130', 4, '8', 89023674),
(9, 'Жуков Александр Ильич', 'Zykov', '131', 5, '9', 89032141),
(10, 'Зуева Арина Макаровна', 'Zyeva', '132', 5, '10', 89401232),
(11, 'Федорова Таисия Антоновна', 'Fedorovna', '133', 6, '11', 89966965),
(12, 'Ильинская Виктория Глебовна', 'Ilinskai', '134', 6, '12', 89522521),
(13, 'Овчинников Егор Арсентьевич', 'Ovchinnikov', '135', 7, '13', 8984586),
(14, 'Кузнецов Артём Богданович', 'Kyznecov', '136', 7, '14', 89748590),
(15, 'Костин Михаил Никитич', 'Kostin', '137', 8, '15', 89744551),
(16, 'Платонов Григорий Иванович', 'Platonov', '138', 8, '16', 89656232),
(17, 'Рогов Денис Дмитриевич', 'Rogov', '139', 9, '17', 89545253),
(18, 'Агеев Даниил Андреевич', 'Ageev', '140', 9, '18', 89656218),
(19, 'Калашников Иван Ярославович', 'Kalashnikov', '141', 10, '19', 89032149),
(20, 'Уткина Екатерина Степановна', 'Ytkina', '999', 10, '20', 89020105);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
