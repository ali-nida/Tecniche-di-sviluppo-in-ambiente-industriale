-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Set 01, 2022 alle 10:28
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
(13, 'Apple', 'Iphone 13', '2x 3.22 GHz Avalanche + 4x 1.82 GHz Blizzard\r\nApple A15 Bionic', 512, 3700, 4, 'iOS 15', 12, 6.1, 2, '799', 30),
(14, 'Apple', 'Iphone 12 Pro Max', '2x 2.65 GHz Firestorm + 4x 1.8 GHz Icestorm\r\nApple A14 Bionic', 512, 3687, 6, 'iOS 14', 12, 6.7, 2, '1150', 20);

-- --------------------------------------------------------

--
-- Struttura della tabella `utenti`
--

CREATE TABLE `utenti` (
  `ID` int(11) NOT NULL,
  `USER` varchar(255) NOT NULL,
  `EMAIL` varchar(255) NOT NULL,
  `PASSWORD` varchar(255) NOT NULL,
  `ADMIN` tinyint(1) NOT NULL,
  `PAYMENT_METHOD` varchar(255) NOT NULL,
  `INDIRIZZO` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `utenti`
--

INSERT INTO `utenti` (`ID`, `USER`, `EMAIL`, `PASSWORD`, `ADMIN`, `PAYMENT_METHOD`, `INDIRIZZO`) VALUES
(1, 'a', 'a', 'a', 1, '', ''),
(2, 'b', 'b', 'b', 0, '', ''),
(3, 'd', 'd', 'd', 0, '', ''),
(4, 'nida', 'nida.3@uhyuy', 'UHASJ', 0, '', ''),
(5, 'nidaa', 'nida@gmail.com', 'nida@gmail.com', 0, '', '');

-- --------------------------------------------------------

--
-- Struttura della tabella `vendite`
--

CREATE TABLE `vendite` (
  `ID_VENDITA` int(11) NOT NULL,
  `ACQUIRENTE` int(11) NOT NULL,
  `DATA` datetime NOT NULL,
  `QUANTITA` int(11) NOT NULL,
  `PRODOTTO` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`CARTID`),
  ADD KEY `PRODUCTID` (`PRODUCTID`) USING BTREE,
  ADD KEY `USERID` (`USERID`) USING BTREE;

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
  ADD PRIMARY KEY (`ID_VENDITA`),
  ADD KEY `ACQUIRENTE` (`ACQUIRENTE`),
  ADD KEY `PRODOTTO` (`PRODOTTO`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `cart`
--
ALTER TABLE `cart`
  MODIFY `CARTID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `smartphone`
--
ALTER TABLE `smartphone`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT per la tabella `utenti`
--
ALTER TABLE `utenti`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT per la tabella `vendite`
--
ALTER TABLE `vendite`
  MODIFY `ID_VENDITA` int(11) NOT NULL AUTO_INCREMENT;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `PRODUCTID` FOREIGN KEY (`PRODUCTID`) REFERENCES `smartphone` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `USERID` FOREIGN KEY (`USERID`) REFERENCES `utenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `vendite`
--
ALTER TABLE `vendite`
  ADD CONSTRAINT `ACQUIRENTE` FOREIGN KEY (`ACQUIRENTE`) REFERENCES `utenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `PRODOTTO` FOREIGN KEY (`PRODOTTO`) REFERENCES `smartphone` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
