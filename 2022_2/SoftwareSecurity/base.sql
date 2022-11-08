DROP TABLE IF EXISTS `Information`;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Information` (
  `word` char(50) DEFAULT NULL,
  `description` char(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table ``
--
LOCK TABLES `Information` WRITE;
/*!40000 ALTER TABLE `Information` DISABLE KEYS */;
INSERT INTO `Information` VALUES ('Apple','red and sweet fruit'),('Korea University','University in Anam');
/*!40000 ALTER TABLE `Information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Users` (
  `id` char(100) DEFAULT NULL,
  `password` char(100) DEFAULT NULL,
  `phone` char(15) DEFAULT NULL,
  `super` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES ('super','super','000-0000-0000', 1),('man','qwerty','111-1111-1111', 0),('woman','asdfgh','222-2222-2222', 0);
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

/*Database name: Wiki, root password: 1111*/