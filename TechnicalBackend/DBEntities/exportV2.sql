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
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(250) NOT NULL,
  `email` varchar(250) NOT NULL,
  `telephone` varchar(50) NOT NULL,
  `address1` varchar(250) NOT NULL,
  `address2` varchar(250) DEFAULT NULL,
  `address3` varchar(250) DEFAULT NULL,
  `postcode` int(11) NOT NULL,
  `city` varchar(100) NOT NULL,
  `lastUpdate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- Dumping data for table technicaltest.ttdeveloper: ~1 rows (approximately)
DELETE FROM `ttdeveloper`;
INSERT INTO `ttdeveloper` (`id`, `name`, `email`, `telephone`, `address1`, `address2`, `address3`, `postcode`, `city`, `lastUpdate`) VALUES
	(1, 'Azizi Fahmi', 'azizi@gmail.com', '+60173159286', 'No 22A, Jalan Ecohill 9/1M', '', '', 43500, 'Semenyih', '2024-06-19 08:21:21'),
	(2, 'Azizi Fahmi', 'azizi@gmail.com', '+60173159286', 'No 22A, Jalan Ecohill 9/1M', '', '', 43500, 'Semenyih', '2024-06-19 08:21:21'),
	(4, 'Fahmi', 'fahmi@gmail.com', '+60173159286', 'No 22A, Jalan Ecohill 9/1M', '', '', 43500, 'Semenyih', '2024-06-19 08:21:21');

-- Dumping structure for table technicaltest.ttdeveloperhobbies
CREATE TABLE IF NOT EXISTS `ttdeveloperhobbies` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ttdeveloper_id` int(11) NOT NULL DEFAULT 0,
  `hobby` varchar(250) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `FK__ttdeveloper` (`ttdeveloper_id`),
  CONSTRAINT `FK__ttdeveloper` FOREIGN KEY (`ttdeveloper_id`) REFERENCES `ttdeveloper` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- Dumping data for table technicaltest.ttdeveloperhobbies: ~1 rows (approximately)
DELETE FROM `ttdeveloperhobbies`;
INSERT INTO `ttdeveloperhobbies` (`id`, `ttdeveloper_id`, `hobby`) VALUES
	(1, 1, 'Watching ZZZ'),
	(2, 2, 'Watching'),
	(4, 4, 'Sleeping');

-- Dumping structure for table technicaltest.ttdeveloperskills
CREATE TABLE IF NOT EXISTS `ttdeveloperskills` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ttdeveloper_id` int(11) NOT NULL DEFAULT 0,
  `skill` varchar(250) NOT NULL DEFAULT '0',
  `year_of_experience` int(11) NOT NULL DEFAULT 0,
  `level` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `FK__ttdeveloper_1` (`ttdeveloper_id`),
  CONSTRAINT `FK__ttdeveloper_1` FOREIGN KEY (`ttdeveloper_id`) REFERENCES `ttdeveloper` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- Dumping data for table technicaltest.ttdeveloperskills: ~0 rows (approximately)
DELETE FROM `ttdeveloperskills`;
INSERT INTO `ttdeveloperskills` (`id`, `ttdeveloper_id`, `skill`, `year_of_experience`, `level`) VALUES
	(1, 2, 'Malay', 0, 3),
	(2, 2, 'English', 0, 3),
	(4, 4, 'Walking', 0, 3);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
