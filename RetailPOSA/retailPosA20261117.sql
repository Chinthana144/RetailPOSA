CREATE DATABASE  IF NOT EXISTS `retail_pos_a` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `retail_pos_a`;
-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: localhost    Database: retail_pos_a
-- ------------------------------------------------------
-- Server version	8.0.45

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
-- Table structure for table `adjustment_detail`
--

DROP TABLE IF EXISTS `adjustment_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `adjustment_detail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `adjustment_header_id` int DEFAULT NULL,
  `inventory_id` int DEFAULT NULL,
  `product_id` int DEFAULT NULL,
  `system_qty` decimal(10,3) DEFAULT NULL,
  `physical_qty` decimal(10,3) DEFAULT NULL,
  `adjust_qty` decimal(10,3) DEFAULT NULL,
  `average_cost` decimal(10,2) DEFAULT NULL,
  `total_value` decimal(10,2) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adjustment_detail`
--

LOCK TABLES `adjustment_detail` WRITE;
/*!40000 ALTER TABLE `adjustment_detail` DISABLE KEYS */;
INSERT INTO `adjustment_detail` VALUES (1,1,3,5,11.000,10.000,-1.000,160.00,-160.00,1),(4,1,1,2,10.000,11.000,1.000,100.00,100.00,1),(7,2,1,2,12.000,10.000,-2.000,100.00,-200.00,1),(8,3,1,2,12.000,10.000,-2.000,100.00,-200.00,1);
/*!40000 ALTER TABLE `adjustment_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `adjustment_header`
--

DROP TABLE IF EXISTS `adjustment_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `adjustment_header` (
  `id` int NOT NULL AUTO_INCREMENT,
  `adjustment_no` varchar(12) DEFAULT NULL,
  `type` varchar(15) DEFAULT NULL,
  `submitted_datetime` datetime DEFAULT NULL,
  `item_count` int DEFAULT NULL,
  `purchase_price` decimal(10,2) DEFAULT NULL,
  `note` text,
  `user_id` int DEFAULT NULL,
  `status` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adjustment_header`
--

LOCK TABLES `adjustment_header` WRITE;
/*!40000 ALTER TABLE `adjustment_header` DISABLE KEYS */;
INSERT INTO `adjustment_header` VALUES (1,'ADJ_0000001','Add','2026-05-23 16:38:16',0,0.00,'add remaining stock',1,1),(2,'ADJ_0000002','Remove','2026-05-24 16:57:58',0,0.00,'Sugar Weight loss',1,1),(3,'ADJ_0000003','Remove','2026-05-25 09:28:29',1,-200.00,'remove expire',1,1);
/*!40000 ALTER TABLE `adjustment_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cart_detail`
--

DROP TABLE IF EXISTS `cart_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart_detail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cart_header_id` int DEFAULT NULL,
  `inventory_id` int DEFAULT NULL,
  `product_id` int DEFAULT NULL,
  `unit_price` decimal(10,2) DEFAULT NULL,
  `qty` decimal(10,3) DEFAULT NULL,
  `total_price` decimal(10,2) DEFAULT NULL,
  `discount` decimal(10,2) DEFAULT NULL,
  `final_price` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart_detail`
--

LOCK TABLES `cart_detail` WRITE;
/*!40000 ALTER TABLE `cart_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `cart_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cart_header`
--

DROP TABLE IF EXISTS `cart_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart_header` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cart_no` varchar(12) DEFAULT NULL,
  `user_id` varchar(45) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart_header`
--

LOCK TABLES `cart_header` WRITE;
/*!40000 ALTER TABLE `cart_header` DISABLE KEYS */;
INSERT INTO `cart_header` VALUES (22,'1','1','2026-07-02 15:24:38',1);
/*!40000 ALTER TABLE `cart_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Biscuits',1),(2,'Tea',1),(3,'Vegetables',1),(4,'Milk',1),(5,'Loose',1),(6,'Plastic',1),(7,'Soft Drinks',1);
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expense_categories`
--

DROP TABLE IF EXISTS `expense_categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `expense_categories` (
  `id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(45) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expense_categories`
--

LOCK TABLES `expense_categories` WRITE;
/*!40000 ALTER TABLE `expense_categories` DISABLE KEYS */;
INSERT INTO `expense_categories` VALUES (1,'Rent',1),(2,'Electricity',1),(3,'Water',1);
/*!40000 ALTER TABLE `expense_categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expenses`
--

DROP TABLE IF EXISTS `expenses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `expenses` (
  `id` int NOT NULL AUTO_INCREMENT,
  `datetime` datetime DEFAULT NULL,
  `category_id` int DEFAULT NULL,
  `description` varchar(120) DEFAULT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `user_id` int DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expenses`
--

LOCK TABLES `expenses` WRITE;
/*!40000 ALTER TABLE `expenses` DISABLE KEYS */;
INSERT INTO `expenses` VALUES (1,'2026-06-28 16:19:13',3,'May month water bill',130.00,1,1),(2,'2026-06-28 18:39:07',2,'May month Bill',1400.00,1,1);
/*!40000 ALTER TABLE `expenses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `general_settings`
--

DROP TABLE IF EXISTS `general_settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `general_settings` (
  `id` int NOT NULL AUTO_INCREMENT,
  `settings_key` varchar(255) DEFAULT NULL,
  `settings_value` text,
  `updated_at` datetime DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `general_settings`
--

LOCK TABLES `general_settings` WRITE;
/*!40000 ALTER TABLE `general_settings` DISABLE KEYS */;
INSERT INTO `general_settings` VALUES (1,'stock_type','FIFO','2026-06-12 17:52:25',1),(2,'report_path','C:\\Users\\ASUS\\OneDrive\\Documents\\Reports','2026-06-12 17:52:38',1),(3,'receipt_printer','X-Printer 80mm','2026-06-12 17:53:11',1),(4,'barcode_printer','X-Printer 110mm 3 in 1','2026-06-12 17:53:14',1),(5,'auto_backup','true','2026-06-12 17:53:18',1),(6,'backup_path','C:\\Users\\ASUS\\OneDrive\\Documents\\Reports','2026-06-13 08:57:33',1),(7,'backup_frequency','1','2026-06-12 17:53:44',1),(8,'negative_stock','false','2026-06-12 17:53:54',0),(9,'second_name','false','2026-06-12 17:53:56',0),(10,'danger_color','#FF8080','2026-06-12 17:56:03',1),(11,'success_color','Green','2026-06-12 17:56:01',1),(12,'primary_color','#000040','2026-06-13 08:57:48',1),(13,'secondary_color','#34324E','2026-06-13 09:21:57',1),(14,'back_color','#333076','2026-06-13 09:19:04',1),(15,'fore_color','White','2026-06-13 09:19:18',1),(16,'accent_color','#2E2EA7','2026-06-16 14:42:29',1);
/*!40000 ALTER TABLE `general_settings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grn_details`
--

DROP TABLE IF EXISTS `grn_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grn_details` (
  `id` int NOT NULL AUTO_INCREMENT,
  `grn_header_id` int NOT NULL,
  `product_id` int NOT NULL,
  `qty` decimal(10,3) DEFAULT NULL,
  `free_qty` decimal(10,3) DEFAULT NULL,
  `purchase_price` decimal(10,2) DEFAULT NULL,
  `selling_price` decimal(10,2) DEFAULT NULL,
  `discount` decimal(10,2) DEFAULT NULL,
  `final_price` decimal(10,2) DEFAULT NULL,
  `expiry_date` date DEFAULT NULL,
  `purchase_total` decimal(10,2) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grn_details`
--

LOCK TABLES `grn_details` WRITE;
/*!40000 ALTER TABLE `grn_details` DISABLE KEYS */;
INSERT INTO `grn_details` VALUES (1,1,2,10.000,0.000,100.00,120.00,0.00,120.00,'2026-07-23',1000.00,1),(3,1,1,12.000,0.000,120.00,140.00,0.00,140.00,'2026-12-25',1440.00,1),(4,1,5,12.000,0.000,160.00,200.00,0.00,200.00,'2026-12-24',1920.00,1),(6,3,6,70.000,0.000,280.00,320.00,0.00,320.00,'2026-10-14',19600.00,1),(7,2,3,20.000,2.000,250.00,320.00,20.00,300.00,'2026-08-20',5000.00,1),(9,5,10,50.000,0.000,120.00,160.00,5.00,155.00,'2027-06-16',6000.00,1),(10,4,8,100.000,5.000,220.00,250.00,10.00,240.00,'2027-08-18',22000.00,1),(13,6,9,40.000,0.000,240.00,320.00,20.00,300.00,'2026-06-23',9600.00,1),(14,6,11,30.000,0.000,150.00,220.00,20.00,200.00,'2026-06-23',4500.00,1),(15,7,8,20.000,0.000,110.00,150.00,10.00,140.00,'2026-12-24',2200.00,1);
/*!40000 ALTER TABLE `grn_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grn_header`
--

DROP TABLE IF EXISTS `grn_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grn_header` (
  `id` int NOT NULL AUTO_INCREMENT,
  `supplier_id` int DEFAULT NULL,
  `invoice_no` varchar(60) DEFAULT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_submitted` datetime DEFAULT NULL,
  `item_count` int DEFAULT NULL,
  `purchase_price` decimal(10,2) DEFAULT NULL,
  `selling_price` decimal(10,2) DEFAULT NULL,
  `status` tinyint DEFAULT NULL,
  `user_id` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grn_header`
--

LOCK TABLES `grn_header` WRITE;
/*!40000 ALTER TABLE `grn_header` DISABLE KEYS */;
INSERT INTO `grn_header` VALUES (1,3,'INV 001','2026-05-11 15:25:08','2026-05-11 15:25:08',0,0.00,0.00,2,1),(2,2,'INV 002','2026-05-11 15:25:23','2026-05-16 17:07:43',1,250.00,0.00,2,1),(3,4,'INV229091','2026-05-16 08:58:49','2026-05-16 09:00:04',1,280.00,0.00,2,1),(4,5,'INV_8878','2026-05-18 15:43:59','2026-06-19 08:50:55',1,220.00,0.00,2,1),(5,3,'IV_99897','2026-06-16 14:57:57','2026-06-16 15:00:53',1,120.00,0.00,2,1),(6,5,'INV_0323','2026-06-23 08:50:51','2026-06-23 09:05:35',2,390.00,0.00,2,1),(7,5,'INV_02932','2026-06-23 09:15:40','2026-06-23 09:15:40',0,0.00,0.00,1,1);
/*!40000 ALTER TABLE `grn_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory` (
  `id` int NOT NULL AUTO_INCREMENT,
  `grn_header_id` int DEFAULT NULL,
  `product_id` int DEFAULT NULL,
  `initial_qty` decimal(10,3) DEFAULT NULL,
  `current_qty` decimal(10,3) DEFAULT NULL,
  `purchase_price` decimal(10,2) DEFAULT NULL,
  `selling_price` decimal(10,2) DEFAULT NULL,
  `discount` decimal(10,2) DEFAULT NULL,
  `final_price` decimal(10,2) DEFAULT NULL,
  `purchase_total` decimal(10,2) DEFAULT NULL,
  `expiry_date` date DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (1,1,2,10.000,0.000,100.00,120.00,0.00,120.00,1000.00,'2026-07-23',1),(2,1,1,12.000,11.000,120.00,140.00,0.00,140.00,1440.00,'2026-12-25',1),(3,1,5,12.000,0.000,160.00,200.00,0.00,200.00,1920.00,'2026-12-24',1),(4,3,6,70.000,62.500,280.00,320.00,0.00,320.00,19600.00,'2026-10-14',1),(5,2,3,22.000,21.000,250.00,320.00,20.00,300.00,5000.00,'2026-08-20',1),(6,1,2,10.000,5.000,0.00,120.00,0.00,130.00,0.00,'2026-07-23',1),(7,1,5,9.000,7.000,0.00,200.00,0.00,210.00,0.00,'2026-12-24',1),(8,5,10,50.000,47.000,120.00,160.00,5.00,155.00,6000.00,'2027-06-16',1),(9,4,8,105.000,103.000,220.00,250.00,10.00,240.00,22000.00,'2027-08-18',1),(10,6,9,40.000,39.000,240.00,320.00,20.00,300.00,9600.00,'2026-06-23',1),(11,6,11,30.000,29.000,150.00,220.00,20.00,200.00,4500.00,'2026-06-23',1);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice_details`
--

DROP TABLE IF EXISTS `invoice_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice_details` (
  `id` int NOT NULL AUTO_INCREMENT,
  `invoice_id` int DEFAULT NULL,
  `inventory_id` int DEFAULT NULL,
  `product_id` int DEFAULT NULL,
  `unit_price` decimal(10,2) DEFAULT NULL,
  `qty` decimal(10,3) DEFAULT NULL,
  `selling_price` decimal(10,2) DEFAULT NULL,
  `discount` decimal(10,2) DEFAULT NULL,
  `final_price` decimal(10,2) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice_details`
--

LOCK TABLES `invoice_details` WRITE;
/*!40000 ALTER TABLE `invoice_details` DISABLE KEYS */;
INSERT INTO `invoice_details` VALUES (1,1,3,5,200.00,2.000,400.00,0.00,400.00,1),(2,1,5,3,320.00,2.000,640.00,80.00,560.00,1),(3,1,4,6,320.00,2.000,640.00,0.00,640.00,1),(4,2,3,5,200.00,2.000,400.00,0.00,400.00,1),(5,3,1,2,120.00,1.000,120.00,0.00,120.00,1),(6,3,3,5,200.00,1.000,200.00,0.00,200.00,1),(7,4,2,1,140.00,1.000,140.00,0.00,140.00,1),(8,5,3,5,200.00,1.000,200.00,0.00,200.00,1),(9,6,4,6,320.00,1.000,320.00,0.00,320.00,1),(10,6,6,2,120.00,1.000,120.00,0.00,120.00,1),(11,7,6,2,120.00,1.000,120.00,0.00,120.00,1),(12,8,7,5,200.00,1.000,200.00,0.00,200.00,1),(13,9,5,3,320.00,1.000,320.00,20.00,300.00,1),(14,1,6,2,120.00,1.000,120.00,0.00,120.00,1),(15,2,5,3,320.00,1.000,320.00,20.00,300.00,1),(16,3,6,2,120.00,1.000,120.00,0.00,120.00,1),(17,4,7,5,200.00,1.000,200.00,0.00,200.00,1),(18,5,4,6,320.00,2.000,640.00,0.00,640.00,1),(19,6,4,6,320.00,2.500,800.00,0.00,800.00,1),(20,7,4,6,320.00,1.000,320.00,0.00,320.00,1),(21,8,6,2,120.00,1.000,120.00,0.00,120.00,1),(22,8,8,10,160.00,2.000,320.00,10.00,310.00,1),(23,9,4,6,320.00,1.000,320.00,0.00,320.00,1),(24,10,10,9,320.00,1.000,320.00,20.00,300.00,1),(25,11,9,8,250.00,1.000,250.00,10.00,240.00,1),(26,12,8,10,160.00,1.000,160.00,5.00,155.00,1),(27,13,11,11,220.00,1.000,220.00,20.00,200.00,1),(28,14,9,8,250.00,1.000,250.00,10.00,240.00,1);
/*!40000 ALTER TABLE `invoice_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice_header`
--

DROP TABLE IF EXISTS `invoice_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice_header` (
  `id` int NOT NULL AUTO_INCREMENT,
  `invoice_date` date DEFAULT NULL,
  `issued_datetime` datetime DEFAULT NULL,
  `invoice_no` varchar(20) DEFAULT NULL,
  `item_count` int DEFAULT NULL,
  `total` decimal(10,2) DEFAULT NULL,
  `discounts` decimal(10,2) DEFAULT NULL,
  `return_amount` decimal(10,2) DEFAULT NULL,
  `sub_total` decimal(10,2) DEFAULT NULL,
  `paymethod_id` int DEFAULT NULL,
  `paid_amount` decimal(10,2) DEFAULT NULL,
  `balance` decimal(10,2) DEFAULT NULL,
  `user_id` int DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice_header`
--

LOCK TABLES `invoice_header` WRITE;
/*!40000 ALTER TABLE `invoice_header` DISABLE KEYS */;
INSERT INTO `invoice_header` VALUES (1,'2026-06-01','2026-06-15 17:26:14','INV_0000001',1,120.00,0.00,0.00,120.00,1,200.00,80.00,1,2),(2,'2026-06-02','2026-06-15 17:55:18','INV_0000002',1,320.00,20.00,0.00,300.00,1,300.00,0.00,1,2),(3,'2026-06-03','2026-06-15 17:55:29','INV_0000003',1,120.00,0.00,0.00,120.00,1,120.00,0.00,1,2),(4,'2026-06-04','2026-06-15 17:55:38','INV_0000004',1,200.00,0.00,0.00,200.00,1,200.00,0.00,1,2),(5,'2026-06-15','2026-06-15 17:55:56','INV_0000005',1,640.00,0.00,0.00,640.00,1,640.00,0.00,1,2),(6,'2026-06-15','2026-06-15 18:16:39','INV_0000006',1,800.00,0.00,0.00,800.00,1,800.00,0.00,1,2),(7,'2026-06-16','2026-06-16 09:23:43','INV_0000007',1,320.00,0.00,0.00,320.00,1,320.00,0.00,1,2),(8,'2026-06-16','2026-06-16 15:01:37','INV_0000008',2,440.00,10.00,0.00,430.00,1,500.00,70.00,1,2),(9,'2026-06-19','2026-06-19 08:38:24','INV_0000009',1,320.00,0.00,0.00,320.00,1,500.00,180.00,1,2),(10,'2026-06-23','2026-06-23 09:07:02','INV_0000010',1,320.00,20.00,0.00,300.00,1,300.00,0.00,1,2),(11,'2026-06-23','2026-06-23 09:17:14','INV_0000011',1,250.00,10.00,0.00,240.00,1,300.00,60.00,1,2),(12,'2026-06-27','2026-06-27 08:49:03','INV_0000012',1,160.00,5.00,0.00,155.00,1,200.00,45.00,1,2),(13,'2026-06-29','2026-06-29 08:43:30','INV_0000013',1,220.00,20.00,0.00,200.00,1,200.00,0.00,1,2),(14,'2026-07-02','2026-07-02 15:20:56','INV_0000014',1,250.00,10.00,0.00,240.00,1,300.00,60.00,1,2);
/*!40000 ALTER TABLE `invoice_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pages`
--

DROP TABLE IF EXISTS `pages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pages` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pages`
--

LOCK TABLES `pages` WRITE;
/*!40000 ALTER TABLE `pages` DISABLE KEYS */;
INSERT INTO `pages` VALUES (1,'Dashboard',1),(2,'Profile',1),(3,'Categories',1),(4,'Products',1),(5,'Suppliers',1),(6,'GRN',1),(7,'Inventory',1),(8,'Adjustment',1),(9,'Price Change',1),(10,'POS',1),(11,'Invoices',1),(12,'Return',1),(13,'Reports',1),(14,'Settings',1),(15,'Users',1),(16,'Admin Panel',1),(17,'Expenses',1);
/*!40000 ALTER TABLE `pages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paymethods`
--

DROP TABLE IF EXISTS `paymethods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paymethods` (
  `id` int NOT NULL AUTO_INCREMENT,
  `paymethod` varchar(45) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paymethods`
--

LOCK TABLES `paymethods` WRITE;
/*!40000 ALTER TABLE `paymethods` DISABLE KEYS */;
INSERT INTO `paymethods` VALUES (1,'Cash',1),(2,'Card',1),(3,'Credit',1),(4,'Bank Transfer',0);
/*!40000 ALTER TABLE `paymethods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `price_change_detail`
--

DROP TABLE IF EXISTS `price_change_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `price_change_detail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `price_change_header_id` int DEFAULT NULL,
  `inventory_id` int DEFAULT NULL,
  `product_id` int DEFAULT NULL,
  `qty` decimal(10,3) DEFAULT NULL,
  `old_price` decimal(10,2) DEFAULT NULL,
  `selling_price` decimal(10,2) DEFAULT NULL,
  `discount` decimal(10,2) DEFAULT NULL,
  `new_price` decimal(10,2) DEFAULT NULL,
  `total_price` decimal(10,2) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `price_change_detail`
--

LOCK TABLES `price_change_detail` WRITE;
/*!40000 ALTER TABLE `price_change_detail` DISABLE KEYS */;
INSERT INTO `price_change_detail` VALUES (1,1,1,2,10.000,120.00,120.00,0.00,130.00,1300.00,1),(2,1,3,5,9.000,200.00,200.00,0.00,210.00,1890.00,1);
/*!40000 ALTER TABLE `price_change_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `price_change_header`
--

DROP TABLE IF EXISTS `price_change_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `price_change_header` (
  `id` int NOT NULL AUTO_INCREMENT,
  `price_change_no` varchar(12) DEFAULT NULL,
  `note` text,
  `submitted_datetime` datetime DEFAULT NULL,
  `item_count` int DEFAULT NULL,
  `total_price` decimal(10,2) DEFAULT NULL,
  `user_id` int DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `price_change_header`
--

LOCK TABLES `price_change_header` WRITE;
/*!40000 ALTER TABLE `price_change_header` DISABLE KEYS */;
INSERT INTO `price_change_header` VALUES (1,'PCH_0000001','Price increase for buiscuit items','2026-06-02 18:58:34',2,3190.00,1,1);
/*!40000 ALTER TABLE `price_change_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `id` int NOT NULL AUTO_INCREMENT,
  `category_id` int DEFAULT NULL,
  `barcode` varchar(45) DEFAULT NULL,
  `name` varchar(90) DEFAULT NULL,
  `second_name` varchar(90) DEFAULT NULL,
  `is_weighted` tinyint(1) DEFAULT NULL,
  `has_expiry` tinyint(1) DEFAULT NULL,
  `minimum_stock` int DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,1,'2736483','Munchee Lemon Puff 280g','Munchee Lemon Puff 280g',0,1,20,1),(2,1,'346762','Maliban Ginger 100g','Maliban Ginger 100g',0,1,0,1),(3,4,'44878282','Hiland Milk 100ml','Hiland Milk 100ml',0,1,0,1),(4,2,'2876834','Nestle Coffee 100g','Nestle Coffee 100g',0,1,0,1),(5,1,'9987876656','Little Lion Cake 230g','Little Lion Cake 230g',0,1,0,1),(6,5,'1001','White Suger Loose','සුදු සීනි ',1,1,0,1),(7,5,'2001','White Flour','තිරිගු පිටි ',1,1,0,1),(8,2,'2263776845','Ceylon Tea 100g','Ceylon Tea 100g',0,1,0,1),(9,6,'38378372','Plastic Bascket lg','Plastic Bascket lg',0,0,0,1),(10,7,'987876656','Coca Cola 330ml','Coca Cola 330ml',0,1,20,1),(11,6,'73568476','Plastic cup small','Plastic cup small',0,0,0,1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_permissions`
--

DROP TABLE IF EXISTS `role_permissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role_permissions` (
  `id` int NOT NULL AUTO_INCREMENT,
  `role_id` int NOT NULL,
  `page_id` int DEFAULT NULL,
  `view` tinyint(1) DEFAULT NULL,
  `add` tinyint(1) DEFAULT NULL,
  `edit` tinyint(1) DEFAULT NULL,
  `remove` tinyint(1) DEFAULT NULL,
  `print` tinyint(1) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role_permissions`
--

LOCK TABLES `role_permissions` WRITE;
/*!40000 ALTER TABLE `role_permissions` DISABLE KEYS */;
INSERT INTO `role_permissions` VALUES (1,1,1,1,1,0,0,0,1),(2,5,1,1,1,1,0,0,1),(3,4,3,1,0,0,0,0,1),(4,1,3,1,1,1,0,0,1),(5,1,2,1,1,1,1,1,1),(6,2,1,1,1,0,0,0,1),(7,1,4,1,1,1,0,0,1),(8,1,16,1,1,1,1,1,1),(9,2,2,1,1,1,1,0,1),(10,3,1,1,0,0,0,0,1),(11,3,2,1,1,1,1,0,1),(12,3,3,1,1,1,0,0,1),(13,3,4,1,1,1,0,0,1),(14,6,2,1,1,1,1,0,1),(15,6,10,1,1,1,0,0,1),(16,7,2,1,1,1,1,0,1),(17,7,10,1,1,1,0,0,1),(18,5,4,1,1,1,0,0,1),(19,5,3,1,1,1,0,0,1),(20,5,5,1,1,1,0,0,1),(21,5,6,1,1,0,0,0,1),(22,5,7,1,0,0,0,0,1),(23,5,8,1,1,1,0,0,1),(24,6,3,1,1,1,0,0,1),(25,6,4,1,1,1,0,0,1);
/*!40000 ALTER TABLE `role_permissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Admin'),(4,'Assistant Manger'),(9,'Fired'),(8,'Intern'),(7,'Junior Cashier'),(3,'Manager'),(2,'Owner'),(6,'Senior Cashier'),(5,'Store Keeper');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sale_return_detail`
--

DROP TABLE IF EXISTS `sale_return_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sale_return_detail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `sale_return_header_id` int DEFAULT NULL,
  `inventory_id` int DEFAULT NULL,
  `invoice_detail_id` int DEFAULT NULL,
  `product_id` int DEFAULT NULL,
  `unit_price` decimal(10,2) DEFAULT NULL,
  `qty` decimal(10,3) DEFAULT NULL,
  `selling_price` decimal(10,2) DEFAULT NULL,
  `discount` decimal(10,2) DEFAULT NULL,
  `final_price` decimal(10,2) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sale_return_detail`
--

LOCK TABLES `sale_return_detail` WRITE;
/*!40000 ALTER TABLE `sale_return_detail` DISABLE KEYS */;
INSERT INTO `sale_return_detail` VALUES (1,1,5,2,3,280.00,1.000,280.00,0.00,280.00,1);
/*!40000 ALTER TABLE `sale_return_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sale_return_header`
--

DROP TABLE IF EXISTS `sale_return_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sale_return_header` (
  `id` int NOT NULL AUTO_INCREMENT,
  `sale_return_no` varchar(12) DEFAULT NULL,
  `invoice_id` int DEFAULT NULL,
  `submitted_datetime` datetime DEFAULT NULL,
  `return_type` varchar(30) DEFAULT NULL,
  `reason` text,
  `item_count` decimal(10,2) DEFAULT NULL,
  `return_total` decimal(10,2) DEFAULT NULL,
  `user_id` int DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sale_return_header`
--

LOCK TABLES `sale_return_header` WRITE;
/*!40000 ALTER TABLE `sale_return_header` DISABLE KEYS */;
INSERT INTO `sale_return_header` VALUES (1,'RTN_0000001',2,'2026-06-04 15:34:51','Return to Stock','return exchange',1.00,280.00,1,1);
/*!40000 ALTER TABLE `sale_return_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shop`
--

DROP TABLE IF EXISTS `shop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shop` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `address` varchar(120) DEFAULT NULL,
  `phone` varchar(12) DEFAULT NULL,
  `shop_logo` varchar(255) DEFAULT NULL,
  `receipt_logo` varchar(255) DEFAULT NULL,
  `invoice_prefix` varchar(3) DEFAULT NULL,
  `currency` varchar(3) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shop`
--

LOCK TABLES `shop` WRITE;
/*!40000 ALTER TABLE `shop` DISABLE KEYS */;
INSERT INTO `shop` VALUES (1,'Fancy Mahal','No123, somewhere.','0712345678','C:\\Users\\ASUS\\source\\repos\\RetailPOSA\\RetailPOSA\\bin\\Debug\\Logos\\Fancy_Mahal.png','C:\\Users\\ASUS\\source\\repos\\RetailPOSA\\RetailPOSA\\bin\\Debug\\Logos\\receipt_Fancy_Mahal.png','INV','Rs',1);
/*!40000 ALTER TABLE `shop` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `company_name` varchar(45) DEFAULT NULL,
  `supplier_name` varchar(60) DEFAULT NULL,
  `contact_no` varchar(12) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'Munchee','Piyadasa','0765461833',1),(2,'Maliban','Ramesh Kumara','0716752788',1),(3,'CocaCola','K.M.N Rathnasiri','0775245341',1),(4,'Suger Coop','siyathu','0776753635',1),(5,'Ceylon Tea','N A Sumanadasa','0769893744',1);
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `role_id` int NOT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,1,'Chinthana','bluecat4'),(2,2,'Bempi Appu',''),(3,4,'Siyathu','123'),(4,5,'Danish','123'),(5,6,'Siriyalatha','123');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-17  4:46:29
