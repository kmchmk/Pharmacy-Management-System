-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: localhost    Database: malithtk_pharmacy
-- ------------------------------------------------------
-- Server version	5.6.24-log

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
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `customerID` int(11) NOT NULL AUTO_INCREMENT,
  `customerName` varchar(50) DEFAULT NULL,
  `phoneNumber` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`customerID`)
) ENGINE=InnoDB AUTO_INCREMENT=146 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` (`customerID`, `customerName`, `phoneNumber`) VALUES (133,'Chanaka Maduranga','0717899366'),(134,'Milinda','0702019356'),(142,'Chanaka','0717899366'),(143,'Kasun','0717117560'),(144,'Chanaka','0717899366'),(145,'Chanka','0717899366');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(5) DEFAULT NULL,
  `productName` varchar(45) DEFAULT NULL,
  `brand` varchar(45) DEFAULT NULL,
  `rackNo` int(11) DEFAULT NULL,
  `price` decimal(8,2) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` (`id`, `code`, `productName`, `brand`, `rackNo`, `price`, `description`) VALUES (1,'900a','Acetaminophen','A & Z Pharmaceutical, Inc.',2,50.00,'the gastrointestinal tract (digestive system)'),(2,'901b','Adderall','A-S Medication Solutions, LLC',2,30.00,'For the cardiovascular system.'),(3,'902c','Alprazolam','AAIPharma',12,70.00,'the central nervous system'),(4,'903d','Amitriptyline','Abbott Laboratories',0,110.00,'pain (analgesic drugs)'),(5,'904e','Amlodipine','AbbVie Inc.',5,190.00,'musculo-skeletal disorders'),(6,'905f','Amoxicillin','Acadia Pharmaceuticals, Inc.',12,180.00,'the eye'),(7,'906g','Ativan','Accord Healthcare Inc.',0,30.00,'the ear, nose and oropharynx'),(8,'907h','Atorvastatin','Accredo Health Group, Inc.',12,40.00,'the respiratory system'),(9,'908i','Azithromycin','Acella Pharmaceuticals, LLC',2,90.00,'endocrine problems'),(10,'909j','Ciprofloxacin','Acorda Therapeutics, Inc.',15,190.00,'For the reproductive system or urinary system'),(11,'910k','Citalopram','Actavis Pharma, Inc.',1,80.00,'For contraception'),(12,'911l','Clindamycin','Actelion Pharmaceuticals US, Inc.',2,150.00,'For obstetrics and gynecology'),(13,'912m','Clonazepam','Acura Pharmaceuticals, Inc.',2,100.00,'For the skin'),(14,'913n','Codeine','Acusphere, Inc.',11,10.00,'For infections and infestations'),(15,'914o','Cyclobenzaprine','Adapt Pharma, Inc.',11,130.00,'For the immune system'),(16,'915p','Cymbalta','Adeona Pharmaceuticals, Inc.,',15,180.00,'For allergic disorders'),(17,'916q','Doxycycline','Adolor Corporation',9,130.00,'For nutrition'),(18,'917r','Gabapentin','Advance Pharmaceuticals Inc.',14,60.00,'For neoplastic disorders'),(19,'918s','Hydrochlorothiazide','Advanced Life Sciences, Inc',4,190.00,'For diagnostics'),(20,'919t','Ibuprofen','Advanced Pharmaceutical Services Inc',9,170.00,'For euthanasia'),(21,'920u','Lexapro','A & Z Pharmaceutical, Inc.',5,170.00,'the gastrointestinal tract (digestive system)'),(22,'921v','Lisinopril','A-S Medication Solutions, LLC',12,40.00,'For the cardiovascular system'),(23,'922w','Loratadine','AAIPharma',13,140.00,'the central nervous system'),(24,'923x','Lorazepam','Abbott Laboratories',1,140.00,'pain (analgesic drugs)'),(25,'924y','Losartan','AbbVie Inc.',5,170.00,'musculo-skeletal disorders'),(26,'925z','Lyrica','Acadia Pharmaceuticals, Inc.',14,60.00,'the eye'),(27,'926a','Meloxicam','Accord Healthcare Inc.',13,80.00,'the ear, nose and oropharynx'),(28,'927b','Metformin','Accredo Health Group, Inc.',0,70.00,'the respiratory system'),(29,'928c','Metoprolol','Acella Pharmaceuticals, LLC',11,60.00,'endocrine problems'),(30,'929d','Naproxen','Acorda Therapeutics, Inc.',7,150.00,'For the reproductive system or urinary system'),(31,'930e','Omeprazole','Actavis Pharma, Inc.',10,120.00,'For contraception'),(32,'931f','Oxycodone','Actelion Pharmaceuticals US, Inc.',11,70.00,'For obstetrics and gynecology'),(33,'932g','Pantoprazole','Acura Pharmaceuticals, Inc.',4,190.00,'For the skin'),(34,'933h','Prednisone','Acusphere, Inc.',7,10.00,'For infections and infestations'),(35,'934i','Tramadol','Adapt Pharma, Inc.',3,20.00,'For the immune system'),(36,'935j','Trazodone','Adeona Pharmaceuticals, Inc.,',11,70.00,'For allergic disorders'),(37,'936k','Panadol','Adolor Corporation',8,150.00,'For nutrition'),(38,'937l','Wellbutrin','Advance Pharmaceuticals Inc.',14,70.00,'For neoplastic disorders'),(39,'938m','Xanax','Advanced Life Sciences, Inc',14,70.00,'For diagnostics'),(40,'939n','Zoloft','Advanced Pharmaceutical Services Inc',0,170.00,'For euthanasia');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `routing`
--

DROP TABLE IF EXISTS `routing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `routing` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `customerID` int(11) NOT NULL,
  `medicineName` varchar(45) DEFAULT NULL,
  `how` int(11) DEFAULT NULL,
  `breakfast` int(11) DEFAULT NULL,
  `lunch` int(11) DEFAULT NULL,
  `dinner` int(11) DEFAULT NULL,
  `beforeOrAfter` int(11) DEFAULT NULL,
  `hours` int(11) DEFAULT NULL,
  `times` int(11) DEFAULT NULL,
  `time` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=224 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `routing`
--

LOCK TABLES `routing` WRITE;
/*!40000 ALTER TABLE `routing` DISABLE KEYS */;
INSERT INTO `routing` (`id`, `customerID`, `medicineName`, `how`, `breakfast`, `lunch`, `dinner`, `beforeOrAfter`, `hours`, `times`, `time`) VALUES (118,94,'asd',2,0,0,0,0,2,3,NULL),(119,95,'Panadol',2,0,0,0,0,6,4,NULL),(120,96,'panadol',2,0,0,0,0,6,5,NULL),(121,97,'Panadol',2,0,0,0,0,1,2,NULL),(122,97,'Amoxiline',2,0,0,0,0,4,6,NULL),(123,98,'sdf',1,1,1,0,1,0,10,NULL),(124,99,'sdf',1,1,0,0,0,0,3,NULL),(125,100,'jh',1,1,0,0,0,0,4,NULL),(126,101,'asdf',1,1,0,0,0,0,4,NULL),(127,102,'aaa',1,1,0,1,0,0,4,NULL),(128,103,'a',1,1,0,0,0,0,3,NULL),(129,103,'ss',1,0,1,0,0,0,3,NULL),(130,103,'sf',1,0,0,1,0,0,3,NULL),(131,103,'sdf',1,1,1,0,0,0,3,NULL),(132,103,'asdf',1,1,0,1,0,0,5,NULL),(133,104,'as',1,1,1,1,0,0,10,NULL),(134,105,'a',1,1,1,1,0,0,3,NULL),(135,106,'sadf',1,1,1,1,0,0,8,NULL),(136,107,'sdf',1,1,0,0,0,0,3,NULL),(137,107,'asdf',1,1,0,0,0,0,3,NULL),(138,108,'af',1,1,0,0,0,0,3,NULL),(139,110,'a',1,1,0,0,0,0,3,NULL),(140,111,'a',1,1,0,0,0,0,3,NULL),(141,111,'a',1,1,0,0,0,0,3,NULL),(142,112,'a',1,1,0,0,0,0,3,NULL),(143,114,'sdf',3,0,0,0,0,0,0,'2016-05-29 22:41:15'),(144,115,'sdf',1,1,0,0,0,0,7,NULL),(145,115,'sdf',3,0,0,0,0,0,0,'2016-05-29 22:42:44'),(146,115,'sdf',2,0,0,0,0,4,4,NULL),(147,119,'asd',1,1,0,0,0,0,1,NULL),(148,120,'ssa',1,1,1,1,0,0,6,NULL),(149,121,'panadol',1,1,1,1,0,0,5,NULL),(150,127,'sdf',1,1,1,1,0,0,5,NULL),(151,128,'sadf',1,1,1,1,0,0,5,NULL),(152,128,'Panadol',1,0,1,1,0,0,5,NULL),(153,129,'sadf',2,0,0,0,0,4,3,NULL),(154,130,'asdf',2,0,0,0,0,7,2,NULL),(155,131,'asdf',1,1,0,0,0,0,3,NULL),(156,132,'sadf',1,1,0,0,0,0,2,NULL),(157,133,'Panadol',1,1,1,0,0,0,4,NULL),(158,133,'Amociline',2,0,0,0,0,6,3,NULL),(159,133,'Piriton',3,0,0,0,0,0,0,'2016-06-01 21:11:12'),(160,134,'Panadol',1,1,1,1,1,0,6,NULL),(161,136,'sadf',1,1,0,0,2,0,3,NULL),(162,136,'panadol',2,0,0,0,0,4,10,NULL),(163,137,'asdf',2,0,0,0,0,2,6,NULL),(164,138,'sadf',1,1,0,0,0,0,2,NULL),(165,138,'sdf',2,0,0,0,0,5,5,NULL),(166,138,'asdf',2,0,0,0,0,3,10,NULL),(167,139,'panadol',2,0,0,0,0,6,4,NULL),(168,140,'asdfasdf',1,1,0,0,1,0,4,NULL),(169,158,'asdf',1,1,0,0,1,0,3,NULL),(170,160,'asd',1,1,0,0,0,0,4,NULL),(171,161,'panadol',2,0,0,0,0,4,4,NULL),(172,172,'asd',3,0,0,0,0,0,0,'2016-06-13 21:53:51'),(173,173,'asd',3,0,0,0,0,0,0,'2016-06-13 21:54:47'),(174,173,'asd',3,0,0,0,0,0,0,'2016-06-13 21:54:55'),(175,173,'ads',3,0,0,0,0,0,0,'2016-06-13 21:55:00'),(176,173,'asd',3,0,0,0,0,0,0,'2016-06-13 21:55:17'),(177,173,'asd',3,0,0,0,0,0,0,'2016-06-13 21:55:20'),(178,173,'asd',3,0,0,0,0,0,0,'2016-06-13 21:55:24'),(179,173,'asd',3,0,0,0,0,0,0,'2016-06-13 21:55:28'),(180,173,'asd',3,0,0,0,0,0,0,'2016-06-13 21:55:32'),(181,173,'asdsda',3,0,0,0,0,0,0,'2016-06-13 21:55:36'),(182,173,'asd',3,0,0,0,0,0,0,'2016-06-13 21:55:40'),(183,173,'asd',3,0,0,0,0,0,0,'2016-06-13 21:55:44'),(184,174,'asdf',3,0,0,0,0,0,0,'2016-06-13 21:56:51'),(185,175,'asd',3,0,0,0,0,0,0,'2016-06-13 22:06:07'),(186,175,'sdv',3,0,0,0,0,0,0,'2016-06-13 22:06:25'),(187,177,'adfadsfad',1,1,0,0,1,0,6,NULL),(188,179,'adfas',3,0,0,0,0,0,0,'2016-06-13 22:14:07'),(189,180,'Panadol',3,0,0,0,0,0,0,'2016-06-14 12:33:09'),(190,183,'asd',3,0,0,0,0,0,0,'2016-07-14 17:44:15'),(191,187,'asfs',3,0,0,0,0,0,0,'2016-07-14 18:38:39'),(192,187,'qwe',3,0,0,0,0,0,0,'2016-07-14 18:39:30'),(203,192,'456',3,0,0,0,0,0,0,'2016-07-15 00:13:00'),(205,199,'Panadol',1,1,1,1,2,0,6,NULL),(206,199,'Piriton',2,0,0,0,0,6,4,NULL),(207,200,'Panadol',3,0,0,0,0,0,0,'2016-06-15 18:23:29'),(208,201,'Panadol',3,0,0,0,0,0,0,'2016-06-15 19:01:42'),(209,8,'Panadol',3,0,0,0,0,0,0,'2016-06-15 22:41:42'),(210,134,'Panadol',1,1,1,1,2,0,6,NULL),(211,135,'Piriton',1,1,1,1,2,0,6,NULL),(212,136,'asdf',1,1,1,1,2,0,6,NULL),(213,137,'asdfsadf',1,1,1,1,2,0,6,NULL),(214,137,'asdf',3,0,0,0,0,0,0,'2016-07-16 12:57:06'),(215,138,'kftg',1,1,1,1,0,0,6,NULL),(216,139,'dhdfhd',3,0,0,0,0,0,0,'2016-08-16 13:02:43'),(217,140,'asfasf',1,1,1,1,0,0,6,NULL),(218,141,'dasdfs',2,0,0,0,0,6,6,NULL),(219,142,'Panadol',2,0,0,0,0,6,6,NULL),(220,142,'Piriton',1,1,1,1,2,0,6,NULL),(221,143,'Piriton',1,0,1,1,2,0,6,NULL),(222,143,'Amoxilin',2,0,0,0,0,4,6,NULL),(223,144,'Panadol',2,0,0,0,0,6,4,NULL);
/*!40000 ALTER TABLE `routing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(200) NOT NULL,
  `email` varchar(45) NOT NULL,
  PRIMARY KEY (`id`,`username`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`id`, `username`, `password`, `email`) VALUES (2,'chanaka','BVTXrkcJ6Jhq8joUEbG/XA==','kmchmk.13@cse.mrt.ac.lk');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `web`
--

DROP TABLE IF EXISTS `web`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `web` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `queryData` varchar(1000) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `web`
--

LOCK TABLES `web` WRITE;
/*!40000 ALTER TABLE `web` DISABLE KEYS */;
/*!40000 ALTER TABLE `web` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-16 18:15:28
