-- MySQL dump 10.13  Distrib 5.5.21, for Win32 (x86)
--
-- Host: localhost    Database: fryzjer
-- ------------------------------------------------------
-- Server version	5.5.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `clients`
--

DROP DATABASE IF EXISTS `fryzjer`;
CREATE DATABASE `fryzjer`;
USE `fryzjer`;

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clients` (
  `id_c` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` char(15) COLLATE utf8_unicode_ci NOT NULL,
  `surname` char(32) COLLATE utf8_unicode_ci NOT NULL,
  `phone_number` char(9) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id_c`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,'Jan','Kowalski','458329965'),(2,'Maria','Nowakowska','698594798'),(3,'Krystyna','Krystynowicz','682234672'),(4,'Karolina','Woźniak','696639629'),(5,'Karolina','Prusakowska','692319538'),(6,'Krzysztof','Grzesica','673598329'),(7,'Jakub','Wadas','679564298'),(8,'Marylka','Rodowicz','632987462'),(9,'Ryszard','Zklanu','666333999'),(10,'Kamil','Baranowski','592234456'),(11,'Hubert','Borkowski','599086674'),(12,'Anita','Kowalczyk','192834756'),(13,'Kinga','Jakubowska','987789675'),(14,'Otylia','Jaworska','923645837'),(15,'Lidia','Mazurek','332758493'),(16,'Oksana','Przybylska','993645211'),(17,'Olimpia','Kamińska','647382976'),(18,'Regina','Chmielewska','432397463'),(19,'Korneliusz','Kamiński','400875543'),(20,'Regina','Chmielewska','432397463'),(21,'Kasia','Januszewska','333222567'),(22,'Janusz','Januszewski','223222567'),(23,'Andrzej','Kowalski','398473001'),(24,'Maria','Zaleska','444555777');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = cp852 */ ;
/*!50003 SET character_set_results = cp852 */ ;
/*!50003 SET collation_connection  = cp852_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 trigger correct before insert on clients for each row 
begin
set new.name=concat(upper(substr(new.name,1,1)),
lower(substr(new.name,2)));
set new.surname=concat(upper(substr(new.surname,1,1)),
lower(substr(new.surname,2)));
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `disposable_products`
--

DROP TABLE IF EXISTS `disposable_products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `disposable_products` (
  `id_dp` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` char(32) COLLATE utf8_unicode_ci NOT NULL,
  `quantity` int(10) unsigned NOT NULL,
  `price` double unsigned NOT NULL,
  PRIMARY KEY (`id_dp`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disposable_products`
--

LOCK TABLES `disposable_products` WRITE;
/*!40000 ALTER TABLE `disposable_products` DISABLE KEYS */;
INSERT INTO `disposable_products` VALUES (1,'rękawiczki',198,1),(2,'peleryny',199,1),(3,'ręczniki papierowe',48,3);
/*!40000 ALTER TABLE `disposable_products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dproductvisit`
--

DROP TABLE IF EXISTS `dproductvisit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dproductvisit` (
  `id_dp` int(10) unsigned NOT NULL,
  `id_v` int(10) unsigned NOT NULL,
  `quantity` int(11) NOT NULL,
  KEY `id_v` (`id_v`),
  KEY `id_dp` (`id_dp`),
  CONSTRAINT `dproductvisit_ibfk_1` FOREIGN KEY (`id_v`) REFERENCES `visits` (`id_v`),
  CONSTRAINT `dproductvisit_ibfk_2` FOREIGN KEY (`id_dp`) REFERENCES `disposable_products` (`id_dp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dproductvisit`
--

LOCK TABLES `dproductvisit` WRITE;
/*!40000 ALTER TABLE `dproductvisit` DISABLE KEYS */;
INSERT INTO `dproductvisit` VALUES (3,1,2),(2,1,1),(1,1,2);
/*!40000 ALTER TABLE `dproductvisit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products` (
  `id_p` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` char(32) COLLATE utf8_unicode_ci NOT NULL,
  `quantity_item` int(10) unsigned NOT NULL,
  `ml` int(10) unsigned NOT NULL,
  `capacity` int(10) unsigned NOT NULL,
  `price` double unsigned NOT NULL,
  PRIMARY KEY (`id_p`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'szampon SLS',10,395,400,20),(2,'szampon łagodny',10,400,400,25),(3,'szampon kolor',8,150,150,27),(4,'odżywka proteinowa',12,250,250,50),(5,'odżywka humektantowa',12,250,250,45),(6,'odżywka emolientowa',12,248,250,55),(7,'żel stylizujący',8,150,150,70),(8,'pianka stylizujący',8,150,150,65),(9,'jedwab',8,50,50,55),(10,'lakier spray',5,150,150,60),(11,'wosk',5,70,70,55),(12,'utleniacz',7,200,200,120),(13,'kolor000',7,50,50,100),(14,'kolor000',7,50,50,100),(15,'kolor001',7,50,50,100),(16,'kolor002',7,30,50,100),(17,'kolor003',7,50,50,100),(18,'kolor004',7,50,50,100),(19,'kolor005',7,50,50,100),(20,'kolor006',7,50,50,100),(21,'kolor007',7,50,50,100),(22,'kolor008',7,50,50,100),(23,'kolor009',7,50,50,100),(24,'kolor010',7,50,50,100),(25,'kolor011',7,50,50,100),(26,'kolor012',7,50,50,100),(27,'kolor013',7,50,50,100),(28,'kolor014',7,50,50,100),(29,'kolor015',7,50,50,100),(30,'kolor016',7,50,50,100),(31,'kolor017',7,50,50,100),(32,'kolor018',7,50,50,100),(33,'kolor019',7,50,50,100),(34,'kolor020',7,50,50,100),(35,'kolor021',7,50,50,100),(36,'kolor022',7,50,50,100),(37,'kolor023',7,50,50,100),(38,'kolor024',7,50,50,100),(39,'kolor025',7,50,50,100),(40,'keratyna',4,250,250,350),(41,'serum',8,60,60,100),(42,'rozjaśniacz',10,200,200,70),(43,'spray termoochronny',12,250,250,65),(44,'cement termiczny',5,150,150,120);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productvisit`
--

DROP TABLE IF EXISTS `productvisit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productvisit` (
  `id_p` int(10) unsigned NOT NULL,
  `id_v` int(10) unsigned NOT NULL,
  `quantity` int(11) NOT NULL,
  KEY `id_v` (`id_v`),
  KEY `id_p` (`id_p`),
  CONSTRAINT `productvisit_ibfk_1` FOREIGN KEY (`id_v`) REFERENCES `visits` (`id_v`),
  CONSTRAINT `productvisit_ibfk_2` FOREIGN KEY (`id_p`) REFERENCES `products` (`id_p`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productvisit`
--

LOCK TABLES `productvisit` WRITE;
/*!40000 ALTER TABLE `productvisit` DISABLE KEYS */;
INSERT INTO `productvisit` VALUES (1,1,5),(6,1,2),(16,1,20);
/*!40000 ALTER TABLE `productvisit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `services` (
  `id_s` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` char(32) COLLATE utf8_unicode_ci NOT NULL,
  `price` double unsigned NOT NULL,
  PRIMARY KEY (`id_s`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services` VALUES (1,'strzyżenie męskie',50),(2,'strzyżenie damskie',100),(3,'koloryzacja',170),(4,'rozjaśnianie',110),(5,'modelowanie',70),(6,'refleks',60),(7,'mycie',50),(8,'upięcie',90),(9,'pielęgnacja',50);
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicevisit`
--

DROP TABLE IF EXISTS `servicevisit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `servicevisit` (
  `id_s` int(10) unsigned NOT NULL,
  `id_v` int(10) unsigned NOT NULL,
  KEY `id_v` (`id_v`),
  KEY `id_s` (`id_s`),
  CONSTRAINT `servicevisit_ibfk_1` FOREIGN KEY (`id_v`) REFERENCES `visits` (`id_v`),
  CONSTRAINT `servicevisit_ibfk_2` FOREIGN KEY (`id_s`) REFERENCES `services` (`id_s`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicevisit`
--

LOCK TABLES `servicevisit` WRITE;
/*!40000 ALTER TABLE `servicevisit` DISABLE KEYS */;
INSERT INTO `servicevisit` VALUES (2,1),(3,1);
/*!40000 ALTER TABLE `servicevisit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visits`
--

DROP TABLE IF EXISTS `visits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `visits` (
  `id_v` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_c` int(10) unsigned NOT NULL,
  `date` date NOT NULL,
  `price` double unsigned NOT NULL,
  PRIMARY KEY (`id_v`),
  KEY `client_fk` (`id_c`),
  CONSTRAINT `client_fk` FOREIGN KEY (`id_c`) REFERENCES `clients` (`id_c`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visits`
--

LOCK TABLES `visits` WRITE;
/*!40000 ALTER TABLE `visits` DISABLE KEYS */;
INSERT INTO `visits` VALUES (1,24,'2020-07-05',279);
/*!40000 ALTER TABLE `visits` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-07-06  0:12:00
