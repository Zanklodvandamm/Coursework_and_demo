-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: tradedb
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `manufacturer`
--

DROP TABLE IF EXISTS `manufacturer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manufacturer` (
  `id_manufacturer` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id_manufacturer`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacturer`
--

LOCK TABLES `manufacturer` WRITE;
/*!40000 ALTER TABLE `manufacturer` DISABLE KEYS */;
INSERT INTO `manufacturer` VALUES (1,'GardenPlast'),(2,'Santino'),(3,'InGreen'),(4,'Gloria Garden'),(5,'Цветочный сад');
/*!40000 ALTER TABLE `manufacturer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `id_order` int NOT NULL AUTO_INCREMENT,
  `product_in_order` varchar(500) NOT NULL,
  `date_order` date NOT NULL,
  `date_delivery` date NOT NULL,
  `id_order_point` int NOT NULL,
  `id_user` int NOT NULL,
  `code` int NOT NULL,
  `id_status` int NOT NULL,
  PRIMARY KEY (`id_order`),
  KEY `fk_order_point_order_idx` (`id_order_point`),
  KEY `fk_user_order_idx` (`id_user`),
  KEY `fk_order_status_order_idx` (`id_status`),
  CONSTRAINT `fk_order_point_order` FOREIGN KEY (`id_order_point`) REFERENCES `order_point` (`id_order_point`),
  CONSTRAINT `fk_order_status_order` FOREIGN KEY (`id_status`) REFERENCES `order_status` (`id_order_status`),
  CONSTRAINT `fk_user_order` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,'D325D4, 3, S432T5, 3','2016-05-20','2022-05-20',11,7,902,1),(2,'F325D4, 1, G432G6, 1','2016-05-20','2022-05-20',2,8,903,1),(3,'H542F5, 5, C346F5, 1','2019-05-20','2025-05-20',11,9,904,1),(4,'G643F4, 5, J326V5, 5','2019-05-20','2025-05-20',2,10,905,1);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_point`
--

DROP TABLE IF EXISTS `order_point`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_point` (
  `id_order_point` int NOT NULL AUTO_INCREMENT,
  `post_index` int NOT NULL,
  `city` varchar(100) NOT NULL,
  `street` varchar(100) NOT NULL,
  `house` varchar(100) NOT NULL,
  PRIMARY KEY (`id_order_point`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_point`
--

LOCK TABLES `order_point` WRITE;
/*!40000 ALTER TABLE `order_point` DISABLE KEYS */;
INSERT INTO `order_point` VALUES (1,344288,'г.Лесной','ул.Чехова','1'),(2,614164,'г.Лесной',' ул.Степная','30'),(3,394242,'г.Лесной','ул.Коммунистическая','43'),(4,660540,'г.Лесной','ул.Солнечная','25'),(5,125837,'г.Лесной','ул.Шоссейная','40'),(6,125703,'г.Лесной','ул.Партизанская','49'),(7,625283,'г.Лесной','ул.Победы','46'),(8,614611,'г.Лесной','ул.Молодежная','50'),(9,454311,'г.Лесной','ул.Новая','19'),(10,660007,'г.Лесной','ул.Октябрьская','19'),(11,603036,'г.Лесной','ул.Садовая','4'),(12,450983,'г.Лесной','ул.Комсомольская','26'),(13,394782,'г.Лесной','ул.Чехова','3'),(14,603002,'г.Лесной','ул.Дзержинского','28'),(15,450558,'г.Лесной','ул.Набережная','30'),(16,394060,'г.Лесной','ул.Фрунзе','43'),(17,410661,'г.Лесной','ул.Школьная','50'),(18,625590,'г.Лесной','ул.Коммунистическая','20'),(19,625683,'г.Лесной','ул.8Марта','34'),(20,400562,'г.Лесной','ул.Зеленая','32'),(21,614510,'г.Лесной','ул.Маяковского','47'),(22,410542,'г.Лесной','ул.Светлая','46'),(23,620839,'г.Лесной','ул.Цветочная','8'),(24,443890,'г.Лесной','ул.Коммунистическая','1'),(25,603379,'г.Лесной','ул.Спортивная','46'),(26,603721,'г.Лесной','ул.Гоголя','41'),(27,410172,'г.Лесной','ул.Северная','13'),(28,420151,'г.Лесной','ул.Вишневая','32'),(29,125061,'г.Лесной','ул.Подгорная','8'),(30,630370,'г.Лесной','ул.Шоссейная','24'),(31,614753,'г.Лесной','ул.Полевая','35'),(32,426030,'г.Лесной','ул.Маяковского','44'),(33,450375,'г.Лесной','ул.Клубная','44'),(34,625560,'г.Лесной','ул.Некрасова','12'),(35,630201,'г.Лесной','ул.Комсомольская','17'),(36,190949,'г.Лесной','ул.Мичурина','26');
/*!40000 ALTER TABLE `order_point` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_status`
--

DROP TABLE IF EXISTS `order_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_status` (
  `id_order_status` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id_order_status`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_status`
--

LOCK TABLES `order_status` WRITE;
/*!40000 ALTER TABLE `order_status` DISABLE KEYS */;
INSERT INTO `order_status` VALUES (1,'Новый'),(2,'Завершен');
/*!40000 ALTER TABLE `order_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `id_product` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `position` varchar(45) NOT NULL,
  `cost` int NOT NULL,
  `max_discount` int NOT NULL,
  `id_manufacturer` int NOT NULL,
  `id_supplier` int NOT NULL,
  `id_product_category` int NOT NULL,
  `current_discount` int NOT NULL,
  `quantity` int NOT NULL,
  `description` varchar(500) NOT NULL,
  `image` varchar(100) NOT NULL,
  PRIMARY KEY (`id_product`),
  KEY `fk_manufacturer_product_idx` (`id_manufacturer`),
  KEY `fk_supplier_product_idx` (`id_supplier`),
  KEY `fk_product_category_product_idx` (`id_product_category`),
  CONSTRAINT `fk_manufacturer_product` FOREIGN KEY (`id_manufacturer`) REFERENCES `manufacturer` (`id_manufacturer`),
  CONSTRAINT `fk_product_category_product` FOREIGN KEY (`id_product_category`) REFERENCES `product_category` (`id_product_category`),
  CONSTRAINT `fk_supplier_product` FOREIGN KEY (`id_supplier`) REFERENCES `supplier` (`id_supplier`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('12','12','шт.',12,12,1,1,1,12,12,'efsrgthyerjhyrjyr',''),('124SSWW','1','шт.',0,1,1,1,1,1,1,'1','1'),('A357H6','Цветок в горшке','шт.',222,15,3,1,3,3,2,'Суккулент микс 5х15см',''),('B653G6','Цветок в горшке','шт.',171,30,5,2,3,2,9,'Пуансеттия микс 13 см',''),('C346F5','Цветок в горшкe','шт.',177,15,2,1,3,5,4,'Хамедорея Бридбл 9х35 см','C346F5.jpg'),('C638J8','Цветок в горшке','шт.',222,10,4,1,3,2,15,'Многолетнее растение Пуансеттия микс',''),('D325D4','Горшок','шт.',292,10,2,2,1,2,12,'Горшок Santino с автополивом Arte-dea 14.7 x 17 см бледно-зеленый','D325D4.jpg'),('F256G6','Цветок в горшке','шт.',577,30,3,2,3,3,2,'Орхидея Фаленопсис промо ø12 h40 - 55 см','F256G6.jpg'),('F325D4','Горшок с поддоном','шт.',984,5,4,1,1,4,3,'Gloria Garden Горшок с поддоном Гербера br59951 (Набор)','F325D4.jpg'),('F537H7','Цветок в горшке','шт.',277,5,5,2,3,3,6,'Многолетнее растение Пуансеттия микс Айс Пунш h20см',''),('G432G6','Букет','шт.',910,6,5,1,2,3,3,'Букет из 9 красных роз длиной 50 см в крафте','G432G6.jpg'),('G543F5','Цветок в горшке','шт.',533,15,4,2,3,3,6,'Замиокулькас 12х30 см',''),('G632H6','Цветок в горшке','шт.',390,6,2,2,3,2,8,'Цикламен 15х35 см',''),('G634F5','Цветок в горшке','шт.',111,5,5,2,3,2,15,'Пуансеттия Промо красная 10х30 см',''),('G643F4','Цветок в горшке','шт.',455,10,2,1,3,3,24,'Орхидея Фаленопсис микс 1 стебель ø12 h50 см',''),('G643F5','Цветок в горшке','шт.',355,10,1,2,3,5,1,'Фиттония микс 8х10 см',''),('G689G5','Цветок в горшке','шт.',145,15,1,2,3,4,3,'Драцена маргината 11х50 см',''),('G843H5','Кашпо','шт.',335,15,1,2,1,3,9,'Кашпо «Орхидея», 1,6 л, 14 х 14 см','G843H5.jpg'),('H346F5','Цветок в горшке','шт.',133,6,3,1,3,3,5,'Каланхое микс h11см',''),('H436H7','Цветок в горшке','шт.',298,10,5,1,3,4,23,'Пуансеттия, 15х35см',''),('H475R5','Цветок в горшке','шт.',398,5,3,1,3,3,12,'Орхидея Фаленопсис микро h20см',''),('H542F5','Искусственные цветы','шт.',400,10,5,2,2,2,5,'Искусственные цветы подсолнух/Искусственные цветы для декора','H542F5.jpg'),('J326V5','Цветок в горшке','шт.',211,5,1,1,3,4,4,'Плант микс 9х25 см',''),('J532V5','Цветок в горшке','шт.',185,15,5,2,3,2,6,'Пуансеттия, 30х12 см','J532V5.jpg'),('J632F6','Цветок в горшке','шт.',288,5,1,1,3,3,6,'Спатифиллиум Чопин 9х35 см',''),('J735J7','Цветок в горшке','шт.',262,15,5,1,3,3,4,'Пуансеттия микс 15 см',''),('K532T5','Цветок в горшке','шт.',111,30,2,1,3,5,7,'Кактус грузони шаровидный микс 5х8 см',''),('L732G6','Цветок в горшке','шт.',150,5,5,2,3,4,9,'Каланхое \"Каландива\" микс',''),('M642E5','Цветок в горшке','шт.',111,10,3,1,3,5,2,'Кактус микс 5х10 см',''),('R635F5','Цветок в горшке','шт.',188,6,5,1,3,3,7,'Кактус мамиллярия 5х14 см',''),('S432T5','Кашпо','шт.',309,5,3,1,1,3,15,'Кашпо InGreen Фиджи ING1555, 5 л, 23х20.8 см шоколадный','S432T5.jpg'),('А112Т4','Кашпо','шт.',300,30,1,1,1,5,6,'Кашпо GardenPlast Лаванда 14 х 26 см фиолетовый','А112Т4.jpg');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_category`
--

DROP TABLE IF EXISTS `product_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_category` (
  `id_product_category` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id_product_category`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_category`
--

LOCK TABLES `product_category` WRITE;
/*!40000 ALTER TABLE `product_category` DISABLE KEYS */;
INSERT INTO `product_category` VALUES (1,'Горшки'),(2,'Букеты'),(3,'В горшке');
/*!40000 ALTER TABLE `product_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id_role` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Администратор'),(2,'Менеджер'),(3,'Клиент');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplier` (
  `id_supplier` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id_supplier`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'Цветовик'),(2,'Мир цветов');
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `surname` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `patronimyc` varchar(100) NOT NULL,
  `login` varchar(200) NOT NULL,
  `password` varchar(200) NOT NULL,
  `role` int NOT NULL,
  PRIMARY KEY (`id_user`),
  KEY `fk_role_user_idx` (`role`),
  CONSTRAINT `fk_role_user` FOREIGN KEY (`role`) REFERENCES `role` (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Калачева','Валерия','Даниловна','zpv1r94d5ous@gmail.com','2L6KZG',1),(2,'Макарова','Вероника','Евгеньевна','9eln76uth4iz@mail.com','uzWC67',1),(3,'Михайлова','Василиса','Ярославовна','60f2ix5d4zbu@tutanota.com','8ntwUp',1),(4,'Горшков','Марк','Матвеевич','ridvnptec8ym@yahoo.com','YOyhfR',2),(5,'Смирнов','Данила','Артёмович','dt3ifc1qz4kw@mail.com','RSbvHv',2),(6,'Зимин','Михаил','Филиппович','co30fa4np6se@mail.com','rwVDh9',2),(7,'Николаев','Даниил','Денисович','arucwkyzls62@outlook.com','LdNyos',3),(8,'Сазонов','Руслан','Германович','nmxos1diph5e@tutanota.com','gynQMT',3),(9,'Одинцов','Серафим','Артёмович','xbvi3ktjde7c@yahoo.com','AtnDjr',3),(10,'Степанов','Михаил','Артёмович','lqgbwpmrc3do@tutanota.com','JlFRCZ',3);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-10 13:54:34
