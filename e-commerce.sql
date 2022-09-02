-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Set 02, 2022 alle 16:02
-- Versione del server: 10.4.24-MariaDB
-- Versione PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `e-commerce`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `cart`
--

CREATE TABLE `cart` (
  `CARTID` int(11) NOT NULL,
  `USERID` int(11) NOT NULL,
  `PRODUCTID` int(11) NOT NULL,
  `QUANTITY` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `cart`
--

INSERT INTO `cart` (`CARTID`, `USERID`, `PRODUCTID`, `QUANTITY`) VALUES
(1, 6, 1, 2),
(2, 7, 2, 2),
(3, 7, 1, 1),
(5, 7, 13, 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `smartphone`
--

CREATE TABLE `smartphone` (
  `ID` int(11) NOT NULL,
  `MARCA` varchar(255) NOT NULL,
  `MODELLO` varchar(255) NOT NULL,
  `PROCESSORE` varchar(255) NOT NULL,
  `MEMORIA` int(11) NOT NULL,
  `BATTERIA` int(11) NOT NULL,
  `RAM` int(11) NOT NULL,
  `OS` varchar(255) NOT NULL,
  `FOTOCAMERA` double NOT NULL,
  `DISPLAY` double NOT NULL,
  `SIM` int(11) NOT NULL,
  `PREZZO` decimal(10,0) NOT NULL,
  `QUANTITA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `smartphone`
--

INSERT INTO `smartphone` (`ID`, `MARCA`, `MODELLO`, `PROCESSORE`, `MEMORIA`, `BATTERIA`, `RAM`, `OS`, `FOTOCAMERA`, `DISPLAY`, `SIM`, `PREZZO`, `QUANTITA`) VALUES
(1, 'Samsung', 'Galaxy Z Flip 4', '1x 3.19 GHz Cortex-X2 + 3x 2.75 GHz Cortex-A710 + 4x 1.80 GHz Cortex-A510\r\nSnapdragon 8 Plus Gen 1 Qualcomm SM8475', 512, 3700, 8, 'Android 12 Samsung One UI 4.1', 12, 6.7, 2, '873', 25),
(2, 'Samsung', 'Galaxy S22', '1x 2.99 GHz Cortex X2 + 3x 2.49 GHz Cortex A710 + 4x 1.78GHz Cortex A510\r\nSAMSUNG Exynos 2200', 256, 3700, 8, 'Android 12 Samsung One UI 4.1', 50, 6.1, 2, '619', 18),
(3, 'Xiaomi', '12 Lite', '1x 2.4 GHz Kryo 670 Prime + 3x 2.2 GHz Kryo 670 Gold + 4x 1.9 GHz Kryo 670 Silver\r\nSnapdragon 778G Qualcomm SM7325', 128, 4300, 6, 'Android 12 MIUI 13', 108, 6.55, 2, '357', 25),
(4, 'Samsung', 'Galaxy A53', '2x 2.4 GHz Cortex-A78 + 6x 2.0 GHz Cortex-A55\r\nSAMSUNG Exynos 1280', 256, 5000, 6, 'Android 12 Samsung One UI 4.0', 64, 6.5, 2, '319', 30),
(5, 'Xiaomi', 'Mi Note 10 Lite', '2x 2.2 GHz Kyro 470 Gold + 6x 1.8 GHz Kyro 470 Silver\r\nSnapdragon 730G Qualcomm SDM730G', 128, 5260, 6, 'Android 10 MIUI 11', 64, 6.47, 2, '333', 35),
(6, 'Samsung', 'Galaxy A41', '2x 2.0 GHz Cortex-A75 + 6x 1.7 GHz Cortex-A55\r\nHelio P65 MediaTek MT6768\r\n', 64, 3500, 4, 'Android 10 Samsung One UI 2.0', 48, 6.1, 2, '312', 14),
(7, 'Samsung', 'Galaxy A13', '4x 2.0 GHz Cortex-A55 + 4x 2.0 GHz Cortex-A55\r\nSAMSUNG Exynos 850', 32, 5000, 3, 'Android 12 Samsung One UI 4.1', 50, 6.6, 2, '140', 18),
(8, 'Motorola', 'Moto E32', '2x 1.6 GHz Cortex-A75 + 6x 1.6 GHz Cortex-A55\r\nT606 Unisoc', 64, 5000, 4, 'Android 11', 16, 6.5, 2, '119', 13),
(9, 'Redmi', '10C', '4x 2.4 GHz Kryo 265 Gold + 4x 1.9 GHz Kryo 265 Silver\r\nSnapdragon 680 4G Qualcomm SM6225', 64, 5000, 4, 'Android 11 MIUI 13', 50, 6.71, 2, '124', 8),
(10, 'Redmi', 'Note 11', '4x 2.4 GHz Kryo 265 Gold + 4x 1.9 GHz Kryo 265 Silver\r\nSnapdragon 680 4G Qualcomm SM6225\r\n', 128, 5000, 4, 'Android 11 MIUI 13', 50, 6.43, 2, '159', 5),
(11, 'Honor', 'Magic 4 Lite', '2x 2.2 GHz Kryo 660 Gold + 6x 1.7 GHz Kryo 660 Silver\r\nSnapdragon 695 Qualcomm SM6375', 128, 4800, 6, 'Android 11 Magic UI 4.2', 48, 6.81, 2, '239', 7),
(12, 'Oppo', 'A94 5G', '2x 2.4 GHz Cortex-A76 + 6x 2.0 GHz Cortex-A55\r\nDimensity 800U MediaTek MT6853', 128, 4310, 8, 'Android 11 ColorOS 11.1', 48, 6.43, 2, '215', 8),
(13, 'Apple', 'iPhone 13', '2x 3.22 GHz Avalanche + 4x 1.82 GHz Blizzard\r\nApple A15 Bionic', 512, 3700, 4, 'iOS 15', 12, 6.1, 2, '799', 30),
(14, 'Apple', 'iPhone 12 Pro Max', '2x 2.65 GHz Firestorm + 4x 1.8 GHz Icestorm\r\nApple A14 Bionic', 512, 3687, 6, 'iOS 14', 12, 6.7, 2, '1150', 20),
(15, 'Apple', 'iPhone 11 Pro Max', '2x 2.65 GHz Lightning + 4x 1.8 GHz Thunder\r\nApple A13 Bionic', 512, 3969, 4, 'iOS 13\r\n', 12, 6.5, 1, '849', 10),
(16, 'Apple', 'iPhone XR', '2x Vortex + 4x Tempest\r\nApple A12 Bionic', 256, 2942, 3, 'iOS 12\r\n', 12, 6.1, 1, '297', 20),
(17, 'Apple', 'iPhone SE', '2x 3.22 GHz Avalanche + 4x 1.82 GHz Blizzard\r\nApple A15 Bionic', 256, 2987, 4, 'iOS 15\r\n', 12, 4.7, 2, '312', 30),
(18, 'Apple', 'iPhone 13 Mini', '2x 3.22 GHz Avalanche + 4x 1.82 GHz Blizzard\r\nApple A15 Bionic', 512, 2406, 4, 'iOS 15\r\n', 12, 5.42, 2, '663', 20),
(19, 'Apple', 'iPhone 12 Mini\r\n', '2x 2.65 GHz Firestorm + 4x 1.8 GHz Icestorm\r\nApple A14 Bionic', 256, 2227, 4, 'iOS 14', 12, 5.4, 1, '447', 14),
(20, 'Xiaomi', '11T Pro\r\n', '1x 2.84 GHz Kryo 680 + 3x 2.42 GHz Kryo 680 + 4x 1.80 GHz Kryo 680\r\nSnapdragon 888 Qualcomm SM8350', 256, 5000, 8, 'Android 11 MIUI 12.5\r\n', 108, 6.67, 2, '378', 5),
(21, 'Samsung \r\n', 'Galaxy A52s', '1x 2.4 GHz Kryo 670 Prime + 3x 2.2 GHz Kryo 670 Gold + 4x 1.9 GHz Kryo 670 Silver\r\nSnapdragon 778G Qualcomm SM7325\r\n', 128, 4500, 6, 'Android 11 Samsung One UI 3.1\r\n', 64, 6.5, 2, '312', 20),
(22, 'Samsung \r\n', 'Galaxy A33', '2x 2.4 GHz Cortex-A78 + 6x 2.0 GHz Cortex-A55\r\nSAMSUNG Exynos 1280', 128, 5000, 6, 'Android 12 Samsung One UI 4.1\r\n', 48, 6.4, 2, '239', 20),
(23, 'Xiaomi', 'Poco X4 GT', '4x 2.85 GHz Cortex-A78 + 4x 2.0 GHz Cortex-A55\r\nDimensity 8100 MediaTek', 256, 5000, 8, 'Android 12 MIUI 13\r\n', 64, 6.6, 2, '299', 9),
(24, 'Xiaomi', 'Poco X3', '4x 2.85 GHz Cortex-A78 + 4x 2.0 GHz Cortex-A55\r\nDimensity 8100 MediaTek', 128, 5160, 6, 'Android 10 MIUI 12\r\n', 64, 6.67, 2, '276', 10),
(25, 'Realme', '9', '4x 2.4 GHz Kryo 265 Gold + 4x 1.9 GHz Kryo 265 Silver\r\nSnapdragon 680 4G Qualcomm SM6225', 128, 5000, 6, 'Android 12 Realme UI 3.0\r\n', 108, 6.4, 2, '220', 15),
(26, 'Samsung', 'Galaxy Z Fold 4\r\n', '1x 3.19 GHz Cortex-X2 + 3x 2.75 GHz Cortex-A710 + 4x 1.80 GHz Cortex-A510\r\nSnapdragon 8 Plus Gen 1 Qualcomm SM8475', 512, 4400, 12, 'Android 12 Samsung One UI 4.1\r\n', 50, 7.6, 2, '1348', 9),
(27, 'Samsung', 'Galaxy Z Fold 3\r\n', '1x 2.84 GHz Kryo 680 + 3x 2.42 GHz Kryo 680 + 4x 1.80 GHz Kryo 680\r\nSnapdragon 888 Qualcomm SM8350', 512, 4400, 12, 'Android 11 Samsung One UI 3.1.1\r\n', 12, 7.6, 2, '1136', 7),
(28, 'Samsung', 'Galaxy S22 Ultra\r\n', '1x 2.99 GHz Cortex X2 + 3x 2.49 GHz Cortex A710 + 4x 1.78GHz Cortex A510\r\nSAMSUNG Exynos 2200', 128, 5000, 8, 'Android 12 Samsung One UI 4.1\r\n', 108, 6.8, 2, '899', 9),
(29, 'Samsung', 'Galaxy S10\r\n', '2x 2.7 GHz Exynos M4 + 2x 2.3 GHz Cortex-A75+ 4x 1.9 GHz Cortex-A55\r\nSAMSUNG Exynos 9820', 512, 3400, 8, 'Android 9 Pie\r\n', 12, 6.1, 2, '431', 20),
(30, 'Samsung', 'Galaxy S9\r\n', '4x 2.8 GHz M3 Mongoose + 4x 1.7 GHz Cortex-A55\r\n9810 SAMSUNG Exynos 9', 64, 3000, 4, 'Android 8.0 Grace UX Oreo\r\n', 12, 5.8, 2, '319', 9),
(31, 'Apple', 'iPhone 11\r\n', '2x 2.65 GHz Lightning + 4x 1.8 GHz Thunder\r\nApple A13 Bionic', 512, 3110, 4, 'iOS 13\r\n', 12, 6.1, 1, '468', 20),
(32, 'Apple', 'iPhone 13 Pro\r\n', '2x 3.22 GHz Avalanche + 4x 1.82 GHz Blizzard\r\nApple A15 Bionic', 128, 3095, 6, 'iOS 15\r\n', 12, 6.1, 2, '999', 9),
(33, 'Apple', 'iPhone 7\r\n', 'Quad-core\r\nApple A10 Fusion', 256, 1960, 2, 'iOS 10\r\n', 12, 4.7, 1, '194', 10),
(34, 'Apple', 'iPhone XS Max\r\n', '2x Vortex + 4x Tempest\r\nApple A12 Bionic', 512, 3174, 4, 'iOS 12\r\n', 12, 6.5, 1, '375', 10),
(35, 'Huawei', 'Nova 10\r\n', '4x 2.4 GHz Kryo 670 + 4x 1.8 GHz Kryo 670\r\nSnapdragon 778G 4G Qualcomm SM7325', 256, 4000, 8, 'HarmonyOS 2.0\r\n', 50, 6.67, 2, '598', 5),
(36, 'Huawei', 'Enjoy 50 Pro\r\n', '4x 2.4 GHz Kryo 265 Gold + 4x 1.9 GHz Kryo 265 Silver\r\nSnapdragon 680 4G Qualcomm SM6225', 256, 5000, 8, 'HarmonyOS 2.0\r\n', 50, 6.7, 2, '357', 10),
(37, 'Realme', 'GT Neo 3', '4x 2.85 GHz Cortex-A78 + 4x 2.0 GHz Cortex-A55\r\nDimensity 8100 MediaTek\r\n', 256, 5000, 8, 'Android 12 Realme UI 3.0\r\n', 50, 6.7, 2, '520', 20),
(38, 'Oppo', 'Reno 8 Lite', '2x 2.2 GHz Kryo 660 Gold + 6x 1.7 GHz Kryo 660 Silver\r\nSnapdragon 695 Qualcomm SM6375', 128, 4500, 8, 'Android 11 ColorOS 12\r\n', 64, 6.43, 2, '350', 15),
(39, 'Motorola', 'Moto G42\r\n', '4x 2.4 GHz Kryo 265 Gold + 4x 1.9 GHz Kryo 265 Silver\r\nSnapdragon 680 4G Qualcomm SM6225\r\n', 128, 5000, 4, 'Android 12\r\n', 50, 6.4, 2, '223', 15),
(40, 'Samsung', 'Galaxy M53', '2x 2.4 GHz Cortex-A78 + 6x 2.0 GHz Cortex-A55\r\nDimensity 900 MediaTek MT6877', 128, 5000, 6, 'Android 12 One UI 4.1\r\n', 108, 6.7, 2, '349', 15);

-- --------------------------------------------------------

--
-- Struttura della tabella `utenti`
--

CREATE TABLE `utenti` (
  `ID` int(11) NOT NULL,
  `USER` varchar(255) NOT NULL,
  `EMAIL` varchar(255) NOT NULL,
  `PASSWORD` varchar(255) NOT NULL,
  `ADMIN` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `utenti`
--

INSERT INTO `utenti` (`ID`, `USER`, `EMAIL`, `PASSWORD`, `ADMIN`) VALUES
(1, 'admin', 'admin@admin.com', 'testtest', 1),
(2, 'user', 'user@user.com', 'testtest', 0),
(6, 'oliviero', 'oliviero@gmail.com', 'olivierotosini', 0),
(7, 'francesca', 'fraste@gmail.com', 'frastefraste', 0);

-- --------------------------------------------------------

--
-- Struttura della tabella `vendite`
--

CREATE TABLE `vendite` (
  `SALEID` int(11) NOT NULL,
  `USERID` int(11) NOT NULL,
  `PRODUCTID` int(11) NOT NULL,
  `QUANTITY` int(11) NOT NULL,
  `DATE` datetime NOT NULL,
  `ADDRESS` varchar(255) NOT NULL,
  `CREDITCARD` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`CARTID`),
  ADD KEY `FK_USERID` (`USERID`),
  ADD KEY `FK_PRODUCTID` (`PRODUCTID`);

--
-- Indici per le tabelle `smartphone`
--
ALTER TABLE `smartphone`
  ADD PRIMARY KEY (`ID`);

--
-- Indici per le tabelle `utenti`
--
ALTER TABLE `utenti`
  ADD PRIMARY KEY (`ID`);

--
-- Indici per le tabelle `vendite`
--
ALTER TABLE `vendite`
  ADD PRIMARY KEY (`SALEID`),
  ADD KEY `FK_USERID` (`USERID`),
  ADD KEY `FK_PRODUCTID` (`PRODUCTID`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `cart`
--
ALTER TABLE `cart`
  MODIFY `CARTID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT per la tabella `smartphone`
--
ALTER TABLE `smartphone`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT per la tabella `utenti`
--
ALTER TABLE `utenti`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `vendite`
--
ALTER TABLE `vendite`
  MODIFY `SALEID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `FK_PRODUCTID2` FOREIGN KEY (`PRODUCTID`) REFERENCES `smartphone` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_USERID2` FOREIGN KEY (`USERID`) REFERENCES `utenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `vendite`
--
ALTER TABLE `vendite`
  ADD CONSTRAINT `FK_PRODUCTID` FOREIGN KEY (`PRODUCTID`) REFERENCES `smartphone` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_USERID` FOREIGN KEY (`USERID`) REFERENCES `utenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
