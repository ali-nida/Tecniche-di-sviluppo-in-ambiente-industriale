-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Ago 29, 2022 alle 16:41
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
(4, 'a', 'a', 'a', 1, 1, 1, 'a', 1, 1, 1, '1', 1);

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
(1, 'admin', 'admin@admin.com', 'testtest', 1, '', ''),
(2, 'user', 'user@user.com', 'testtest', 0, '', '');

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT per la tabella `utenti`
--
ALTER TABLE `utenti`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

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
