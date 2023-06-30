-- phpMyAdmin SQL Dump
-- version 5.1.4
-- https://www.phpmyadmin.net/
--
-- Host: mysql-nokijoto.alwaysdata.net
-- Generation Time: Jun 30, 2023 at 02:30 PM
-- Server version: 10.6.11-MariaDB
-- PHP Version: 7.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `nokijoto_projekt`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`nokijoto`@`%` PROCEDURE `POMELO_AFTER_ADD_PRIMARY_KEY` (IN `SCHEMA_NAME_ARGUMENT` VARCHAR(255), IN `TABLE_NAME_ARGUMENT` VARCHAR(255), IN `COLUMN_NAME_ARGUMENT` VARCHAR(255))   BEGIN
	DECLARE HAS_AUTO_INCREMENT_ID INT(11);
	DECLARE PRIMARY_KEY_COLUMN_NAME VARCHAR(255);
	DECLARE PRIMARY_KEY_TYPE VARCHAR(255);
	DECLARE SQL_EXP VARCHAR(1000);
	SELECT COUNT(*)
		INTO HAS_AUTO_INCREMENT_ID
		FROM `information_schema`.`COLUMNS`
		WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
			AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
			AND `COLUMN_NAME` = COLUMN_NAME_ARGUMENT
			AND `COLUMN_TYPE` LIKE '%int%'
			AND `COLUMN_KEY` = 'PRI';
	IF HAS_AUTO_INCREMENT_ID THEN
		SELECT `COLUMN_TYPE`
			INTO PRIMARY_KEY_TYPE
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_NAME` = COLUMN_NAME_ARGUMENT
				AND `COLUMN_TYPE` LIKE '%int%'
				AND `COLUMN_KEY` = 'PRI';
		SELECT `COLUMN_NAME`
			INTO PRIMARY_KEY_COLUMN_NAME
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_NAME` = COLUMN_NAME_ARGUMENT
				AND `COLUMN_TYPE` LIKE '%int%'
				AND `COLUMN_KEY` = 'PRI';
		SET SQL_EXP = CONCAT('ALTER TABLE `', (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA())), '`.`', TABLE_NAME_ARGUMENT, '` MODIFY COLUMN `', PRIMARY_KEY_COLUMN_NAME, '` ', PRIMARY_KEY_TYPE, ' NOT NULL AUTO_INCREMENT;');
		SET @SQL_EXP = SQL_EXP;
		PREPARE SQL_EXP_EXECUTE FROM @SQL_EXP;
		EXECUTE SQL_EXP_EXECUTE;
		DEALLOCATE PREPARE SQL_EXP_EXECUTE;
	END IF;
END$$

CREATE DEFINER=`nokijoto`@`%` PROCEDURE `POMELO_BEFORE_DROP_PRIMARY_KEY` (IN `SCHEMA_NAME_ARGUMENT` VARCHAR(255), IN `TABLE_NAME_ARGUMENT` VARCHAR(255))   BEGIN
	DECLARE HAS_AUTO_INCREMENT_ID TINYINT(1);
	DECLARE PRIMARY_KEY_COLUMN_NAME VARCHAR(255);
	DECLARE PRIMARY_KEY_TYPE VARCHAR(255);
	DECLARE SQL_EXP VARCHAR(1000);
	SELECT COUNT(*)
		INTO HAS_AUTO_INCREMENT_ID
		FROM `information_schema`.`COLUMNS`
		WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
			AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
			AND `Extra` = 'auto_increment'
			AND `COLUMN_KEY` = 'PRI'
			LIMIT 1;
	IF HAS_AUTO_INCREMENT_ID THEN
		SELECT `COLUMN_TYPE`
			INTO PRIMARY_KEY_TYPE
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_KEY` = 'PRI'
			LIMIT 1;
		SELECT `COLUMN_NAME`
			INTO PRIMARY_KEY_COLUMN_NAME
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_KEY` = 'PRI'
			LIMIT 1;
		SET SQL_EXP = CONCAT('ALTER TABLE `', (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA())), '`.`', TABLE_NAME_ARGUMENT, '` MODIFY COLUMN `', PRIMARY_KEY_COLUMN_NAME, '` ', PRIMARY_KEY_TYPE, ' NOT NULL;');
		SET @SQL_EXP = SQL_EXP;
		PREPARE SQL_EXP_EXECUTE FROM @SQL_EXP;
		EXECUTE SQL_EXP_EXECUTE;
		DEALLOCATE PREPARE SQL_EXP_EXECUTE;
	END IF;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoleClaims`
--

CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoles`
--

CREATE TABLE `AspNetRoles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `AspNetRoles`
--

INSERT INTO `AspNetRoles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('1', 'Admin', 'ADMIN', '1'),
('2', 'User', 'USER', '2');

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserClaims`
--

CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserLogins`
--

CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserRoles`
--

CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUsers`
--

CREATE TABLE `AspNetUsers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `AspNetUsers`
--

INSERT INTO `AspNetUsers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('1880c5cc-1f0a-4ebf-82f2-05f79f68c630', 'rafalwatroba@rw.pl', 'RAFALWATROBA@RW.PL', 'rafalwatroba@rw.pl', 'RAFALWATROBA@RW.PL', 1, 'AQAAAAIAAYagAAAAELA3rMKyoLyQRXIssEPNB4NqBEudlLuMbFymRbnkvV1jkueOeWjPWlY/0MnONRItVw==', 'CRHLWGTU3YYQAHMLV5KLBC6NJP3XAIS2', 'a1e57971-f624-4447-bd29-2127761f0953', NULL, 0, 0, NULL, 1, 0),
('1f4ffcc0-e98b-440a-b19f-2b441836bff3', 'test@test.pl', 'TEST@TEST.PL', 'test@test.pl', 'TEST@TEST.PL', 1, 'AQAAAAIAAYagAAAAEBXHBkYpwD5ftZ0jpvRFNOAOysTaTLLbEHHzitOInetcmYHZ6L8+v/bPLXSgyY8vFQ==', 'H5ZSNMOGRJNLDJ5AZW5AVDSEXASGY7M7', '2cdc6cbc-09f4-4313-a9ff-809739b3f8da', NULL, 0, 0, NULL, 1, 0),
('3082cf38-2e3a-4e3c-8435-c0278ad3277a', 'admin@admin.pl', 'ADMIN@ADMIN.PL', 'admin@admin.pl', 'ADMIN@ADMIN.PL', 1, 'AQAAAAIAAYagAAAAEA36LIQxiOOa8zPOd+ZVdz22zfo6r5Af4NLRKVMwiplHP4IdJghF9g5qr01gsL9+kQ==', 'NZWI5VBEJWJ6NVS63QYNKNODTSE3HJPD', '04708013-b2d2-42b0-af64-91830660b140', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserTokens`
--

CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE `authors` (
  `AuthorId` int(11) NOT NULL,
  `author_uuid` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `birth_date` varchar(50) NOT NULL,
  `description` varchar(500) NOT NULL,
  `imageUrl` varchar(1000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`AuthorId`, `author_uuid`, `first_name`, `last_name`, `birth_date`, `description`, `imageUrl`) VALUES
(1, 'fcb25860-0c68-11ee-9cd0-52540054c9cd', 'Robert', 'Makłowicz', '2000', 'Młody Bóg', 'https://upload.wikimedia.org/wikipedia/commons/thumb/4/48/Robert_Maklowicz_2014_%28cropped%29.jpg/161px-Robert_Maklowicz_2014_%28cropped%29.jpg'),
(2, '04da3878-14ec-11ee-9cd0-52540054c9cd', 'Jarosław', 'Grzędowicz', '2023-06-30', 'Polski pisaż! Nawet Fajny', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Jaros%C5%82aw_Grz%C4%99dowicz_2014.JPG/185px-Jaros%C5%82aw_Grz%C4%99dowicz_2014.JPG'),
(8, '8d03c5ba-14ec-11ee-9cd0-52540054c9cd', 'Aneta ', 'Jadowska', '1981-08-14', 'Polska pisarka fantasy, doktor nauk humanistycznych w zakresie literaturoznawstwa Uniwersytetu Mikołaja Kopernika w Toruniu. Autorka m.in. serii wydawniczych o Dorze Wilk, Nikicie i Witkacym oraz trylogii kryminalnej Garstki z Ustki. Od 2016 roku związana z Wydawnictwem SQN.', 'https://upload.wikimedia.org/wikipedia/commons/thumb/c/ca/Aneta_Jadowska.jpg/160px-Aneta_Jadowska.jpg'),
(9, 'cbae9e22-14ec-11ee-9cd0-52540054c9cd', 'Holly', 'Black', '1971-11-10', 'Amerykańska pisarka, najbardziej znana dzięki cyklowi powieści dla dzieci Kroniki Spiderwick, którą stworzyła wraz z pisarzem i ilustratorem Tonym DiTerlizzi oraz trylogii dla młodzieży pod tytułem Nowoczesna baśń.', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Holly_Black_Author_Photo_2020.jpg/180px-Holly_Black_Author_Photo_2020.jpg'),
(10, 'ed5d510f-14ec-11ee-9cd0-52540054c9cd', 'Robert Cecil ', 'Martin ', '1952-12-05', 'Amerykański programista i autor wielu książek dotyczących inżynierii oprogramowania. Zwany w środowisku programistów jako „wujek Bob”. Zaproponował szeroko przyjęty mnemonik na pięć podstawowych założeń programowania obiektowego – SOLID', 'https://upload.wikimedia.org/wikipedia/commons/thumb/2/27/Robert_C._Martin_surrounded_by_computers.jpg/240px-Robert_C._Martin_surrounded_by_computers.jpg'),
(11, '14bee77a-14ed-11ee-9cd0-52540054c9cd', 'Andrzej ', 'Sapkowski', '1948-06-21', 'Polski pisarz fantasy, z wykształcenia ekonomista. Twórca postaci wiedźmina. Jest najczęściej po Stanisławie Lemie tłumaczonym polskim autorem fantastyki.', 'https://upload.wikimedia.org/wikipedia/commons/thumb/7/76/Andrzej_Sapkowski_-_Lucca_Comics_and_Games_2015_2.JPG/171px-Andrzej_Sapkowski_-_Lucca_Comics_and_Games_2015_2.JPG'),
(12, '31c6ec19-58f1-4089-b5a0-47c981ae5780', 'Andrzej', 'Pilipiuk', '1974-03-20', 'Polski pisarz fantastyczny i publicysta, laureat nagrody literackiej im. Janusza A. Zajdla za rok 2002. Z wykształcenia archeolog.', 'https://upload.wikimedia.org/wikipedia/commons/thumb/5/50/Andrzej_Pilipiuk-Polcon2006.jpg/177px-Andrzej_Pilipiuk-Polcon2006.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `book_id` int(11) NOT NULL,
  `book_uuid` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `title` varchar(100) NOT NULL,
  `total_pages` int(11) NOT NULL,
  `rating` int(11) NOT NULL,
  `isbn` varchar(30) NOT NULL,
  `published_date` varchar(50) NOT NULL,
  `description` varchar(500) NOT NULL,
  `imageUrl` varchar(1000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`book_id`, `book_uuid`, `title`, `total_pages`, `rating`, `isbn`, `published_date`, `description`, `imageUrl`) VALUES
(1, 'd20280c3-0c68-11ee-9cd0-52540054c9cd', 'Ostanie Życzenie', 332, 36, '9788375780', '2023-06-28', 'Potężny wiedźmin wyrusza odnaleźć swoją przybraną córkę. Podczas podróży będzie musiał zmierzyć się z groźnymi przciwnikami, takimi jak: uzależnienie od gwinta, te baby, widły.', 'https://s.lubimyczytac.pl/upload/books/240000/240310/490965-352x500.jpg'),
(2, 'df4c7885-0c68-11ee-9cd0-52540054c9cd', 'Ostanie Życzenie', 332, 999, ' 9788375780', '2023-06-14', 'Potężny wiedźmin wyrusza odnaleźć swoją przybraną córkę. Podczas podróży będzie musiał zmierzyć się z groźnymi przciwnikami, takimi jak: \r\nuzależnienie od gwinta, te baby, widły.', 'https://gaming.komputronik.pl/wp-content/uploads/2022/06/wiedzmin-4-premiera.jpg'),
(3, 'e3cc5b2b-0c68-11ee-9cd0-52540054c9cd', 'Czysty Kod', 23, 3, '2342345242', '2023-06-28', ' tym, ile problemów sprawia niedbale napisany kod, wie każdy programista. Nie wszyscy jednak wiedzą, jak napisać ten świetny, \"czysty\" kod i czym właściwie powinien się on charakteryzować. Co więcej - jak odróżnić dobry kod od złego? Odpowiedź na te pytania oraz sposoby tworzenia czystego, czytelnego kodu znajdziesz właśnie w tej książce. Podręcznik jest obowiązkową pozycją dla każdego, kto chce poznać techniki rzetelnego i efektywnego programowania.', 'https://s.lubimyczytac.pl/upload/books/83000/83492/352x500.jpg'),
(4, 'e37c1a6c-9301-402d-8cf6-f1928705ec7e', 'Pan Lodowego Ogrodu', 660, 8, '97883796449', '2023-06-18', 'Księga pierwsza kultowego cyklu, która w jednym roku zgarnęła Zajdla, Nautilusa, Sfinksa i Śląkfę.\r\n \r\nVuko Drakkainen samotnie rusza na poszukiwanie zaginionej ekspedycji naukowej, badającej człekopodobną cywilizację planety Midgaard. Misja: odesłać na Ziemię lub zlikwidować i zatrzeć ślady. Pod ża', 'https://ecsmedia.pl/cdn-cgi/image/format=webp,width=500,height=500,/c/pan-lodowego-ogrodu-tom-1-b-iext122295508.jpg'),
(5, 'e37c1a6c-9301-402d-8cf6-f1928705ec7e', 'Pan Lodoweg Ogrodu Tom 2', 625, 8, '97883796449', '2023-06-18', 'Mówią, że zimna mgła żyje. Inni uważają, że to oddech bogów albo brama zaświatów. \r\nMidgaard. Planeta, gdzie nas, ludzi, postrzega się jako istoty o rybich oczach. Gdzie trwa wojna bogów, a samozwańczy demiurgowie hodują okrucieństwo kwitnące w mroku zła. Gdzie więdną najnowsze ziemskie technologie,', 'https://ecsmedia.pl/cdn-cgi/image/format=webp,width=500,height=500,/c/pan-lodowego-ogrodu-tom-2-b-iext125042887.jpg'),
(6, 'f00365dd-b5ad-4b43-bba0-05316069f452', 'Pan Lodoweg Ogrodu Tom 3', 484, 8, ' 9788379646', '2009-11-27', 'Władza… Wystarczyło zaledwie czworo obdarzonych jej pełnią Ziemian, by z planety Midgaard uczynić istne piekło.\r\n\r\nVuko Drakkainen podąża śladami ich przerażającego szaleństwa. Z misją: zlikwidować! Odesłać na Ziemię, lub pogrzebać na bagnach. Problem w tym, że oni stali się… Bogami.\r\nFilar, cesarsk', 'https://ecsmedia.pl/cdn-cgi/image/format=webp,width=500,height=500,/c/pan-lodowego-ogrodu-tom-3-b-iext127969289.jpg'),
(14, 'c1f62171-14ed-11ee-9cd0-52540054c9cd', 'Krew elfów', 340, 8, ' 9788375780', '1994-06-01', 'powieść fantasy autorstwa Andrzeja Sapkowskiego, pierwszy raz wydana w 1994 roku. Jest pierwszą z pięciu części sagi o wiedźminie tego autora. W 2009 zdobyła David Gemmell Awards for Fantasy', 'https://s.lubimyczytac.pl/upload/books/240000/240512/490973-352x500.jpg'),
(15, '265c3bf0-ff88-46e4-beb2-203f04372fe4', 'CK kuchnia', 247, 7, '8324001034', '2023-06-29', 'Książka przepisów kulinarnych polecanych przez Roberta Makłowicza! Niezwyczajna, zaprawiona opowieściami mrożącymi krew w żyłach i nieodparcie dowcipnymi', 'https://s.lubimyczytac.pl/upload/books/82000/82804/352x500.jpg'),
(16, '24512e17-b54b-47a7-b6ac-cf83a516c36a', 'Pani Jeziora', 596, 8, '9788375780697', '2023-06-07', 'Andrzej Sapkowski, arcymistrz światowej fantasy, zaprasza do swojego Neverlandu i przedstawia uwielbianą przez czytelników i wychwalaną przez krytykę wiedźmińską sagę!\nCiri wpatruje się w wypukły relief\nprzedstawiający ogromnego łuskowatego węża.\nGad, zwinąwszy się w kształt ósemki,\nwgryzł się zębiskami we własny ogon.\nTo pradawny wąż Uroboros.', 'https://s.lubimyczytac.pl/upload/books/240000/240527/490982-352x500.jpg'),
(17, '25985ccb-51ea-40d2-af1b-27b3f4a418ba', 'Kroniki Jakuba Wędrowycza', 562, 999, '9788375745092', '2011-01-01', 'Polscy autorzy raczej unikają tematyki polskiej a nawet scenografii kraju ojczystego. Jeśli już postanowią napisać utwór fantastyczny którego akcja rozgrywa się w Polsce, to po pierwszej próbie z ulgą odskakują od niewygodnego tematu.', 'https://s.lubimyczytac.pl/upload/books/5000/5049/352x500.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `book_authors`
--

CREATE TABLE `book_authors` (
  `book_id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `book_shelfs`
--

CREATE TABLE `book_shelfs` (
  `shelf_id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `book_shelfs`
--

INSERT INTO `book_shelfs` (`shelf_id`, `book_id`) VALUES
(17, 1),
(13, 2),
(15, 2),
(18, 2),
(20, 2),
(15, 3),
(17, 3);

-- --------------------------------------------------------

--
-- Table structure for table `DeviceCodes`
--

CREATE TABLE `DeviceCodes` (
  `UserCode` varchar(200) NOT NULL,
  `DeviceCode` varchar(200) NOT NULL,
  `SubjectId` varchar(200) DEFAULT NULL,
  `SessionId` varchar(100) DEFAULT NULL,
  `ClientId` varchar(200) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `Expiration` datetime(6) NOT NULL,
  `Data` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Keys`
--

CREATE TABLE `Keys` (
  `Id` varchar(255) NOT NULL,
  `Version` int(11) NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Use` varchar(255) DEFAULT NULL,
  `Algorithm` varchar(100) NOT NULL,
  `IsX509Certificate` tinyint(1) NOT NULL,
  `DataProtected` tinyint(1) NOT NULL,
  `Data` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Keys`
--

INSERT INTO `Keys` (`Id`, `Version`, `Created`, `Use`, `Algorithm`, `IsX509Certificate`, `DataProtected`, `Data`) VALUES
('13A985334E76B153E176C139F2FB2A09', 1, '2023-06-28 19:22:37.755733', 'signing', 'RS256', 0, 1, 'CfDJ8FeXr7YO-l1AmdphnrE6XUZjSRkzy5mjgqzSUQJLNMKwkXNmljs2a2fQxsc7NJ5zcsqbu600B3Z2L05Pxft_A4OBawYLkRr6K841CmRiZN-f-G2MItrSt4UtVNCXphXAvQ9yHcafLAnrC9TZW6lbOqsZdMErQy4l1vsr8zGaAP2qTn3fNLOkeed_l6xaeWmVTQfDG5-3s86j6J-38UwriDDZ940lPrpsrT4EnD5uaV2QFp_0CCuvhb-z6LidPWxdL2SPF2M5s6dWoMofiKHO7WdalSwDqsKQYNa_UeE8mrX95h7AunK-zpgb9JhoYgyF8pPCXJ0ji12_TOkQ42cbtgjS9eSh0mDECq9M1K54dTISRFlcz8VXbBOQwteABJGFms52Q6L51BxXIOBoPLiFJ2sC5ureSXlGvuhafwVSNr8LE-U6wzazs3NEnBVIGhtV-rkSrZUhBLRQ6FjeYZbOYSUOQu3Q79grWVtstiTE9LafJmq56CfLXaf1C-z4lyOL6_CVLVE9eO8PzRuyxEX8XX5pJb2hzeADLC7xU-RVSr-Sp2Ywvv4EH93s6HHEoki_3FacdKjW4IUa4KilFQ1z1NWl4YT4FvOkuDq7JFWYy7VXoIgR_R3FvK8jHT5clZwRE1Kd24TQ97CGh7_I3SF-PE6f1YUfnzLmfsAEs4Xk3_ZTH-oWFvN54V5E9_bIcjrt4ZbE46S7JXKwswnniw6y9dQxy2bFElr9BJUoFCP8MQsFhXzeAJkDnWYjXP5T7u_kWJTFMwX0orE47j52nmYrFnyacDGXb1tUNWgBcCB0nZiPQgveCB9NcoT7xZ1e4jeZYChuPivVeYbtCFz2DXPVFbjtkm-A2prwaFClOLlZPY8Mfc1wYhMNQl14tiCCuAZNX0NTCwVpg-9PhZR452J1wFM4EgouAQlx981b77GqRvKVHb5HCQ76jgTqrXNQqdlq4C9Hd5eBe73T1h6DDDx2VCyyTgu6zkzgmYABdCcNh28o0hg6VwEvnE1305Bo1_-NfrTl4c1rVbkUeNkYLjhMaSgtYGHrK1eFgHOz7mMrADUcBV3w6efs8RAf2LBJd2SJhyAE2bCDevi1r8csDF_Ysn1UypP4_YN_RDOvgwMBFg8E5vjysaGShzPyGR8d_tQK8pwkMoB5kTNf9uufacP-7nwBKpA5rlhg_A7nWKJBgX6QNyUbHdJvHt1MmXc8e-WijNL-fzSZ3XbDdtRwrItjwrokdjJ1gpZGnsi34m6JDj00IhZlaTc1jJbMdTR1RsKHX38SFvtn0Nd-EpfsZv8oXYIy0CtqOimLqeKq28oIC5m40wqd5eGQy-VlIgsa-99L8vMxx1qw_aaSkg6Ut5boWpptW9PRGuNrHjJLdVaxUKFz8gSjHCt-3UGesMjKLEOQ1Rzl8kaJwH5ueGdVO7ehoAGCpvazVl-grRo40OmnjoCyyHo7B-Z2cnbqBNEfWJjuD1CeycdAGXpJ7O0krwmrei7ww-K8gj74_lJfk2LiI6xqQWOx0mJ7WBGaG8CPlsvYy4EFHCK3TdJxB-fr06dRkt0J8Wn-NpXnd6b5hOzXxhjAkUkPEFn5oNgPVFZfO-fthZwtir6yVHN9LxzJMl5MQpepHAfyuC8zktVQHjUXbd8fSwininA4jnC0Ysr16_cD-f5QrTr9WRslwibd81yuy_HlU8JSGRRJeP-VTDYtVfeTyh4UgP9J43_HSX-IIJbp-jvecpd0DQmmxG5XfsypM-NaDKjQAnMnRurNK19VuJ8FnYXBfoIoLQevqpm5UkY27KpFpsxBPa8jsWpnc8SaLOWJh7Qi6SLpJuQpuY_O5AYrOukqbxdn7BvRwX9Uc0ckeoIV-twN8C5Y5taJSokAsmjZItDKnladZ1HRcMkRaNu5gDg516GxzPlRFEz3QFMF0ShPdQuSLsfg17p3IOcboRGcBcE8Zh_xJG2Y-qiR4kckRKFFKKgyZdvsjaNtoqgyC2B-17Y1H-qMq44CMzo-37EQMG7P1Q3Y1NlFmC2l4zShEDcC-GrGmq4mfsongS3Of2OdDL3R46aT89zeFEKcYR_QjYvLmG3mJzlB_b36JHQPCH7bbfujSbYWUZBZV2mVql7N4Rv-UGV9CRARc_Y0NVwJoH3Ys0mVuHYCApHdFZ4-ZpaguhpGjqZAzhjDOgqbqOZfktNhkyPtMWA4MLxrVryL-EPqr2oxPqMb_U3m4exn3YZKVD-suSDI_l3pERRtK8PNa2ZhSOCWwNqyYUl-Xu99i5il-oNqie1o0e9oyPPMtPhCek57vuagbCvLhHmLNP5OL1GcvZZ1R9oWiHsapnKCJePSe7j2uIMX5iit2S3sqmyTovdoMHk5GUvpH_u8_Id7adz1UO6AyxHluPbQ5o-IsheIcHitYdVNb63Jzxu3OdmeuwugQ0rqe7LwzdXcpQiWpK9sSZN4c6jvCOQ-4NJ6PJc6Rm5H2_pFncgixjHj'),
('2FD2DB3179702F4BAF6DF5984822F104', 1, '2023-06-29 06:08:18.137943', 'signing', 'RS256', 0, 1, 'CfDJ8JiNzdMNt6tCjVuqQJGM9fszc8GuDXkrjhuW2ZMKpFBhQDEZCA34NAFckEtx-LJ18nZYsyckcBsrl-9psMIaDQ0R94GVeBvLj9Y9cU1gsln38V5c9QBykVGw7apZV1VeZrfZQYdhQquB0Oc9AojPbL-ioXqO5i02l1zNNd9zgY3DWM5k8oaPHNcBBSOStr8d3w21esyj38fjYCENPLYCd9LSCLfr25aDR6RG2qop4QTjDh6sVWuAJIc_Qd8Twkp3fneM8oRd0iuR37SRtEcxEcoSHZl01Tyy9anvm9Q0rmXWJ4bya6ZNOh7mEUPLvF3ExFONgqY8RJgNnSmX91lDeOVlowZioitxLBHS0GReAd7qOqwnpjZFWQVyYN78poFhBR8c5BuEiOKr0a5zqGYt_GaduRkHDkHOgEqiVp4HYTV9hRwpSoRkjrILILvtNNbuupQUevHwz9heHZcHfn-qMm6QUeJmVKXjplUO0tVnLkhYbiNRxfsmsy3NiHZ19O3CUXSBWfOvSDr07BwMy6BswCfYcUUVVp40nfmp13LE0zv8KsrwEJzvN38Eh3VxXrt0vxc6bNZ8CHoVDEplfXV3DCGkGhGd3idygPj8lmHWErrBDsarMooWgajkgs7FuKxebkLHyvnK1GYTa4hCwbseR1SocnqBGvPlRRUAc6zP1eCWlTJYERdG_NT3oWlK5JQ_-NKFIsCaJXsJtOgCTRsQnh80FvU6m3QRZ6ihTGF46UHzwIMvEcWo5nWayuOroJwDicbsezwaV75kmZAh2wPpQS5ZG0_cjolI-bg53wbVdHrV1OmN7ugIuFqstVa88V357e7nqZkL6IzgUiJ2xzq788y7-TBOhee_rl_6oPJta54WxR2uWsbsyAWfyeJoU9tnyjwiJTWDeHraDew1h4ohjVrh_rFGXS93eJa3giMW9NxnJ8tEtF8r2I1gKtqtaGSNpZizraFIC36HmnROXhlVop-42JngwO6ZwCv3uJ0TNmJhZQbRNgsLzAVKJT5eoR06TTdkSo3gRZscoKKpxaI-p8c3T_mYr1E279pO0t3t6ydtl1uqJG62xnUWc59nXsC3CfIvbix4thk00ksbmGAHC0RncDdDDtpJe4_S19ywh9Fc5EupeGE14qAYX2wT6SKea3wrQ5dF16CxfDhsoG0yJhza2uDEVVugteZs9lL9tkeZRBTddNX6DNwjrQOMaru5hiS16AtzRECmDrPrxCfN2_HqEGtqdWqniHzxRi6QTcZgI9x7GbD6lodb8NRPG8PdeyGwY-F3pJItQpFeRHuU5kQpiTS-4UlbmxKQmKwXbyDKAxvuKk2D-xh4IrQOZYBSEV-CLxIVbXJI3trJ-Bn26d8p-CHNTgXPST2jdAY73sa5mZVGK4NKyQW5R5NiK9z21iiu9Ki48RX3IeAFcLJcgk40sZzP7R4-oejL3DhPFa1SyL3NTg-tc4zA7M-bG6J9RpjqABVjsS5q0er-9sLTaryFA-db6UzDPTEG-0RpZoRUqYnHRM-SuQfPEOJGyWnf3ivL46UpoHpazpk9ZCouqTgzoPKPigcpyW3Jbhbxar2O0lWTRQXl90lYzIVhSIaBYSOPR5zbkuEkU1_oZya0e81ULamTZBTmDoZv1knO9S-PqUj_8wZ6fuHEWbmIkKIhO9VKZXvw_x_pQHJ37GfXvtMm9i0R6dVcghmpvo6H_7M8dQBzdh2_Ny0kPwPIEfLM_I3MW4F5KJtQisl0wgG-XPGYOl3HQOfW0hzaLJfAQ2b7eZ2pdFgGv_fqWXbG1Io6VSBnYMYTGQv59KFzcT_YCQIOFKmFQuzZ2TFG57zrDVUyIsvG5-eRMaSlyX7MlIQ3xcoUDEV8K2AAPq5IgA19tAxn9T3WITW0OcbuBQo4YxSXbqCJERJAkteDApjAeHyWEAgtA1jY2lu4F54MdxajFhoR2qkNkrrXrHnDozzmoOXx6U-66G8TkMXIT4xXHBQRjDp04iuKymzhd9w_9JecW6aZtQWkWcQ7SNb9h8ucWwWYC22F8pYPLGT0Zwp8xPdtwx3Ujm-pLNU6s1WkHfK7Q400VXRa2_xe2HcO6FHm-7fiXwphgvktAWbf3Wm7Oug5cMozNxnAdjNLa1AEDvUbNl8vvh7WNZVzl9S_ZqGK7_evY4_-MRzyNrMy5VRfev0DKTFYh2IXn--OpJvoYoOXQrUIPT4agqwumgN-ftYQWoePwZQGNxs-AMYAF0LzodVWjSgAfRFA3VYuzDO01rqEBfqbqQhoBEjYPy5xTqFzSgC3rA22_DjHQUQaKIEYGzlGIXIpzop3PkTv29V-sag0Nb-GdBedxL6G5ZvuH84OBHTUtyvOD9Z-PZxSa89GTaBYOWseUftn18pnlbfF4U8RtEVi9O5B09F4o1hM6O59n96G2R0Qm7l2CdCcR7Sa2c68MJiJur3DRzQXG7VTcYgfLOASspCHuGP7alG2oe7CT2yk');

-- --------------------------------------------------------

--
-- Table structure for table `PersistedGrants`
--

CREATE TABLE `PersistedGrants` (
  `Key` varchar(200) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `SubjectId` varchar(200) DEFAULT NULL,
  `SessionId` varchar(100) DEFAULT NULL,
  `ClientId` varchar(200) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `Expiration` datetime(6) DEFAULT NULL,
  `ConsumedTime` datetime(6) DEFAULT NULL,
  `Data` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `shelfs`
--

CREATE TABLE `shelfs` (
  `shelf_id` int(11) NOT NULL,
  `shelf_uuid` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `shelf_name` varchar(50) NOT NULL,
  `created_by_un` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `shelfs`
--

INSERT INTO `shelfs` (`shelf_id`, `shelf_uuid`, `shelf_name`, `created_by_un`) VALUES
(1, '8d8e32fa-15ea-11ee-9cd0-52540054c9cd', 'test', 'test'),
(10, '0faf4a6a-07e5-4a31-b124-30e5ac1cf673', 'asdasdfgf', 'admin@admin.pl'),
(11, '74905449-4d0c-4089-92dc-832fb0a98d5c', 'ELO', 'admin@admin.pl'),
(12, 'c74d346f-9930-4a9a-b71a-6fa50ed19917', 'asgagf', 'admin@admin.pl'),
(13, 'a041bb8c-6692-439a-b8cb-561bbfd9bec1', 'Rafalkurczeczytodziala', 'admin@admin.pl'),
(14, 'cacb8a23-51bb-4f4b-9f13-58a7645fe907', 'ocholeraRafaltodziala', 'admin@admin.pl'),
(15, 'fcde683a-9718-4c84-b13b-4c960c2c9846', 'ajaja', 'test@test.pl'),
(17, '161c220f-1c83-4196-ae4a-5f3d47b64f7f', 'asdfsdfasfasdf', 'test@test.pl'),
(18, '81cdd37f-b6c3-41fe-b8db-c803cec4e4fc', 'TestowaPolka', 'test@test.pl'),
(19, '4cd90859-81fd-49fc-8448-af3a7c452706', 'ELO', 'test@test.pl'),
(20, '55b1708d-9ec3-4015-876c-245383f32dec', 'PolkaWstydu', 'rafalwatroba@rw.pl');

-- --------------------------------------------------------

--
-- Table structure for table `userShelfs`
--

CREATE TABLE `userShelfs` (
  `shelf_id` int(11) NOT NULL,
  `profile_un` varchar(255) NOT NULL,
  `ProfileId` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20230628191401_DatabaseUpdate7', '7.0.5'),
('20230630075831_TablesUpdate8', '7.0.5'),
('20230630103610_TablesUpdate11', '7.0.5');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetRoles`
--
ALTER TABLE `AspNetRoles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetUsers`
--
ALTER TABLE `AspNetUsers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`AuthorId`);

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`book_id`);

--
-- Indexes for table `book_authors`
--
ALTER TABLE `book_authors`
  ADD PRIMARY KEY (`author_id`,`book_id`),
  ADD KEY `author_id` (`author_id`),
  ADD KEY `book_id` (`book_id`);

--
-- Indexes for table `book_shelfs`
--
ALTER TABLE `book_shelfs`
  ADD PRIMARY KEY (`book_id`,`shelf_id`),
  ADD KEY `shelf_id` (`shelf_id`),
  ADD KEY `book_id1` (`book_id`);

--
-- Indexes for table `DeviceCodes`
--
ALTER TABLE `DeviceCodes`
  ADD PRIMARY KEY (`UserCode`),
  ADD UNIQUE KEY `IX_DeviceCodes_DeviceCode` (`DeviceCode`),
  ADD KEY `IX_DeviceCodes_Expiration` (`Expiration`);

--
-- Indexes for table `Keys`
--
ALTER TABLE `Keys`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Keys_Use` (`Use`);

--
-- Indexes for table `PersistedGrants`
--
ALTER TABLE `PersistedGrants`
  ADD PRIMARY KEY (`Key`),
  ADD KEY `IX_PersistedGrants_ConsumedTime` (`ConsumedTime`),
  ADD KEY `IX_PersistedGrants_Expiration` (`Expiration`),
  ADD KEY `IX_PersistedGrants_SubjectId_ClientId_Type` (`SubjectId`,`ClientId`,`Type`),
  ADD KEY `IX_PersistedGrants_SubjectId_SessionId_Type` (`SubjectId`,`SessionId`,`Type`);

--
-- Indexes for table `shelfs`
--
ALTER TABLE `shelfs`
  ADD PRIMARY KEY (`shelf_id`);

--
-- Indexes for table `userShelfs`
--
ALTER TABLE `userShelfs`
  ADD PRIMARY KEY (`profile_un`,`shelf_id`),
  ADD KEY `profile_un` (`ProfileId`),
  ADD KEY `shelf_id1` (`shelf_id`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `authors`
--
ALTER TABLE `authors`
  MODIFY `AuthorId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `shelfs`
--
ALTER TABLE `shelfs`
  MODIFY `shelf_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `book_authors`
--
ALTER TABLE `book_authors`
  ADD CONSTRAINT `FK_BookAuthors_Authors` FOREIGN KEY (`author_id`) REFERENCES `authors` (`AuthorId`),
  ADD CONSTRAINT `FK_BookAuthors_Books` FOREIGN KEY (`book_id`) REFERENCES `books` (`book_id`);

--
-- Constraints for table `book_shelfs`
--
ALTER TABLE `book_shelfs`
  ADD CONSTRAINT `FK_BookShelfs_Books` FOREIGN KEY (`book_id`) REFERENCES `books` (`book_id`),
  ADD CONSTRAINT `FK_BookShelfs_Shelfs` FOREIGN KEY (`shelf_id`) REFERENCES `shelfs` (`shelf_id`);

--
-- Constraints for table `userShelfs`
--
ALTER TABLE `userShelfs`
  ADD CONSTRAINT `FK_UserShelfs_Profile` FOREIGN KEY (`profile_un`) REFERENCES `AspNetUsers` (`Id`),
  ADD CONSTRAINT `FK_UserShelfs_Shelfs` FOREIGN KEY (`shelf_id`) REFERENCES `shelfs` (`shelf_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
