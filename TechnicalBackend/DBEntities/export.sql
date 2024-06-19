-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               11.4.0-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table technicaltest.ttdeveloper
CREATE TABLE IF NOT EXISTS `ttdeveloper` (
  `id` uuid NOT NULL,
  `name` varchar(250) NOT NULL DEFAULT '',
  `email` varchar(250) NOT NULL DEFAULT '',
  `telephone` varchar(15) NOT NULL DEFAULT '',
  `address1` varchar(250) NOT NULL DEFAULT '',
  `address2` varchar(250) DEFAULT '',
  `address3` varchar(250) DEFAULT '',
  `postcode` int(11) NOT NULL DEFAULT 0,
  `city` varchar(50) NOT NULL DEFAULT '',
  `lastUpdate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- Dumping data for table technicaltest.ttdeveloper: ~1 rows (approximately)
DELETE FROM `ttdeveloper`;
INSERT INTO `ttdeveloper` (`id`, `name`, `email`, `telephone`, `address1`, `address2`, `address3`, `postcode`, `city`, `lastUpdate`) VALUES
	('08dc9024-c903-48a7-8aa4-1cd69eb7909c', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 05:31:03'),
	('08dc9025-9d9d-43e6-8232-21ea1f8a7456', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:03:45'),
	('08dc9025-7522-4007-84f1-21ec30ed011f', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:02:35'),
	('08dc9026-44a9-437f-8790-23abe2e86f67', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:08:37'),
	('08dc9029-c89c-4e65-886b-3b70ef5a6d8b', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:33:48'),
	('08dc902a-1275-40b0-8501-40f74d2c1969', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:35:09'),
	('08dc902a-811b-4d98-846a-48aab1ea6fad', 'azizi', 'fahmi@mat.com', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:37:32'),
	('08dc9021-0a9f-49ab-81ee-6e2971fa1b95', 'Azizi Fahmi', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 05:31:03'),
	('08dc9026-b7d7-4cb1-8b9a-95b2d36acaf5', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:11:37'),
	('08dc9029-fb26-4e30-84de-96788c5af20a', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:35:09'),
	('08dc902a-511d-447a-8689-bb438cd8f8ed', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:37:32'),
	('08dc9028-a536-4337-84d7-c35a7e4ab423', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:25:31'),
	('08dc9027-d408-4e79-86bf-ec4c3c968174', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:19:40'),
	('08dc9027-5774-4118-86de-f6fda0f34253', 'string', 'string', 'string', 'string', 'string', 'string', 0, 'string', '2024-06-19 06:16:13');

-- Dumping structure for table technicaltest.ttdeveloperhobbies
CREATE TABLE IF NOT EXISTS `ttdeveloperhobbies` (
  `id` uuid NOT NULL,
  `ttdeveloper_id` uuid NOT NULL,
  `hobby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_ttdeveloperhobbies_ttdeveloper` (`ttdeveloper_id`),
  CONSTRAINT `FK_ttdeveloperhobbies_ttdeveloper` FOREIGN KEY (`ttdeveloper_id`) REFERENCES `ttdeveloper` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- Dumping data for table technicaltest.ttdeveloperhobbies: ~6 rows (approximately)
DELETE FROM `ttdeveloperhobbies`;
INSERT INTO `ttdeveloperhobbies` (`id`, `ttdeveloper_id`, `hobby`) VALUES
	('08dc9026-44e0-4ede-830a-405824f8c8fc', '08dc9026-44a9-437f-8790-23abe2e86f67', 'string'),
	('08dc9026-b826-48dd-8f9a-632ee0ceb0ed', '08dc9026-b7d7-4cb1-8b9a-95b2d36acaf5', 'string'),
	('08dc9025-a76d-4734-8d07-6a151df5bfd0', '08dc9025-9d9d-43e6-8232-21ea1f8a7456', 'string'),
	('08dc9029-c8bc-4c51-8b74-7b7433e4a33c', '08dc9029-c89c-4e65-886b-3b70ef5a6d8b', 'string'),
	('08dc9029-ffc2-45dc-83e8-80c5237ec85a', '08dc9029-fb26-4e30-84de-96788c5af20a', 'string'),
	('08dc902a-818a-4dcc-8ece-830f5be69d05', '08dc902a-811b-4d98-846a-48aab1ea6fad', 'melepaking'),
	('08dc9025-7554-4aec-8a5c-ee4d079643ae', '08dc9025-7522-4007-84f1-21ec30ed011f', 'string'),
	('08dc902a-17cd-4891-89d0-f3838fa585ab', '08dc902a-1275-40b0-8501-40f74d2c1969', 'string'),
	('08dc902a-5234-4704-8347-f4e879c07613', '08dc902a-511d-447a-8689-bb438cd8f8ed', 'string'),
	('08dc9028-ae2b-45ac-8680-fa6e742561a6', '08dc9028-a536-4337-84d7-c35a7e4ab423', 'string');

-- Dumping structure for table technicaltest.ttdeveloperskills
CREATE TABLE IF NOT EXISTS `ttdeveloperskills` (
  `id` uuid NOT NULL,
  `ttdeveloper_id` uuid NOT NULL,
  `skill` text NOT NULL,
  `level` int(11) NOT NULL DEFAULT 0,
  `year_of_exp` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `FK_ttdeveloperskills_ttdeveloper` (`ttdeveloper_id`),
  CONSTRAINT `FK_ttdeveloperskills_ttdeveloper` FOREIGN KEY (`ttdeveloper_id`) REFERENCES `ttdeveloper` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- Dumping data for table technicaltest.ttdeveloperskills: ~1 rows (approximately)
DELETE FROM `ttdeveloperskills`;
INSERT INTO `ttdeveloperskills` (`id`, `ttdeveloper_id`, `skill`, `level`, `year_of_exp`) VALUES
	('08dc902a-5241-47dd-8b76-2936c4887c24', '08dc902a-511d-447a-8689-bb438cd8f8ed', 'string', 0, 0),
	('08dc902a-8192-4671-8c32-8b4d59cc1516', '08dc902a-811b-4d98-846a-48aab1ea6fad', 'string', 0, 0);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
