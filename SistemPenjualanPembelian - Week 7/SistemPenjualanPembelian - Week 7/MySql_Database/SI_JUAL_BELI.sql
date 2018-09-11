-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 16, 2017 at 04:09 AM
-- Server version: 5.6.24
-- PHP Version: 5.6.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `si_jual_beli`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE IF NOT EXISTS `barang` (
  `KodeBarang` char(5) NOT NULL,
  `Nama` varchar(45) DEFAULT NULL,
  `HargaJual` int(11) DEFAULT NULL,
  `Stok` smallint(6) DEFAULT NULL,
  `KodeKategori` char(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`KodeBarang`, `Nama`, `HargaJual`, `Stok`, `KodeKategori`) VALUES
('10001', 'Green Tea Sachet', 10000, 50, '01'),
('10002', 'Orange Squash', 5000, 100, '01'),
('10003', 'Soda Kaleng', 4000, 20, '01'),
('20001', 'Bumbu Ayam Kalasan Royku', 15000, 120, '02'),
('20002', 'Kaldu Ayam Magic', 30000, 25, '02'),
('30001', 'T-Shirt Pelangi Lengan Pendek', 80000, 5, '03'),
('30002', 'T-Shirt Bola Lengan Panjang', 125000, 15, '03'),
('40001', 'Susu UHT Sapiku', 45000, 15, '04'),
('40002', 'Keju Cheddar Healthy Choice', 67000, 55, '04'),
('40003', 'Keju Cheddar Kejuku', 7500, 20, '04');

-- --------------------------------------------------------

--
-- Table structure for table `kategori`
--

CREATE TABLE IF NOT EXISTS `kategori` (
  `KodeKategori` char(2) NOT NULL,
  `Nama` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `kategori`
--

INSERT INTO `kategori` (`KodeKategori`, `Nama`) VALUES
('01', 'Minuman'),
('02', 'Bumbu'),
('03', 'Fashion'),
('04', 'Susu dan Olahan'),
('05', 'Daging');

-- --------------------------------------------------------

--
-- Table structure for table `notabeli`
--

CREATE TABLE IF NOT EXISTS `notabeli` (
  `NoNota` char(11) NOT NULL,
  `Tanggal` datetime DEFAULT NULL,
  `KodeSupplier` int(11) NOT NULL,
  `KodePegawai` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `notabeli`
--

INSERT INTO `notabeli` (`NoNota`, `Tanggal`, `KodeSupplier`, `KodePegawai`) VALUES
('20170725001', '2017-07-25 16:40:21', 2, 4),
('20170725002', '2017-07-25 16:40:49', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `notabelidetil`
--

CREATE TABLE IF NOT EXISTS `notabelidetil` (
  `NoNota` char(11) NOT NULL,
  `KodeBarang` char(5) NOT NULL,
  `Harga` int(11) DEFAULT NULL,
  `Jumlah` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `notabelidetil`
--

INSERT INTO `notabelidetil` (`NoNota`, `KodeBarang`, `Harga`, `Jumlah`) VALUES
('20170725001', '10001', 5000, 72),
('20170725001', '10002', 2000, 100),
('20170725002', '30001', 45000, 48),
('20170725002', '30002', 60000, 24);

-- --------------------------------------------------------

--
-- Table structure for table `notajual`
--

CREATE TABLE IF NOT EXISTS `notajual` (
  `NoNota` char(11) NOT NULL,
  `Tanggal` datetime DEFAULT NULL,
  `KodePelanggan` int(11) NOT NULL,
  `KodePegawai` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `notajual`
--

INSERT INTO `notajual` (`NoNota`, `Tanggal`, `KodePelanggan`, `KodePegawai`) VALUES
('20170801001', '2017-08-01 16:36:22', 1, 1),
('20170801002', '2017-08-01 16:36:53', 2, 4);

-- --------------------------------------------------------

--
-- Table structure for table `notajualdetil`
--

CREATE TABLE IF NOT EXISTS `notajualdetil` (
  `NoNota` char(11) NOT NULL,
  `KodeBarang` char(5) NOT NULL,
  `Harga` int(11) DEFAULT NULL,
  `Jumlah` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `notajualdetil`
--

INSERT INTO `notajualdetil` (`NoNota`, `KodeBarang`, `Harga`, `Jumlah`) VALUES
('20170801001', '10001', 10000, 2),
('20170801001', '20002', 30000, 1),
('20170801002', '10001', 10000, 3),
('20170801002', '30002', 125000, 1),
('20170801002', '40001', 42000, 2);

-- --------------------------------------------------------

--
-- Table structure for table `pegawai`
--

CREATE TABLE IF NOT EXISTS `pegawai` (
  `KodePegawai` int(11) NOT NULL,
  `Nama` varchar(45) DEFAULT NULL,
  `TglLahir` date DEFAULT NULL,
  `Alamat` varchar(100) DEFAULT NULL,
  `KodeAtasan` int(11) DEFAULT NULL,
  `Gaji` bigint(20) DEFAULT NULL,
  `Username` varchar(8) NOT NULL,
  `Password` varchar(8) NOT NULL,
  `Jabatan` varchar(10) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pegawai`
--

INSERT INTO `pegawai` (`KodePegawai`, `Nama`, `TglLahir`, `Alamat`, `KodeAtasan`, `Gaji`, `Username`, `Password`, `Jabatan`) VALUES
(1, 'Nancy', '2017-08-16', 'Tenggilis Mejoyo AA-10', 2, 5000000, 'nancy', '123', 'kasir'),
(2, 'Andrew', '1977-03-09', 'Raya Darmo 129', NULL, 10000000, 'andrew', 'andrew', 'admin'),
(3, 'Janet', '1987-02-20', 'Darmo Permai Utara X/12', 2, 4000000, 'janet', 'abc', 'kasir'),
(4, 'Margaret', '1984-11-20', 'Raya Kendangsari 200', 2, 4000000, '', '', ''),
(5, 'Steven', '1967-03-07', 'Raya Tenggilis 44', 1, 3000000, '', '', ''),
(6, 'Michael', '1988-07-12', 'Sidosermo Indah Blok A No 12', 1, 3000000, '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `pelanggan`
--

CREATE TABLE IF NOT EXISTS `pelanggan` (
  `KodePelanggan` int(11) NOT NULL,
  `Nama` varchar(50) DEFAULT NULL,
  `Alamat` varchar(100) DEFAULT NULL,
  `Telepon` varchar(45) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pelanggan`
--

INSERT INTO `pelanggan` (`KodePelanggan`, `Nama`, `Alamat`, `Telepon`) VALUES
(1, 'Pelanggan Umum', '-', '-'),
(2, 'Ana Maria TR', 'Darmo 333', '(085) 83423234'),
(3, 'Anton Mario', 'Raya Diponegoro 123', '(031) 75638234'),
(4, 'PT Around the World', 'Raya Kendangsari 12A', '(031) 34243434'),
(5, 'PT Bahagia Selalu', 'Bukit Darmo Boulevard 124A', '(031) 232344323'),
(6, 'UD Maju Sejati', 'Raya Lontar 34', '(031) 23324422');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE IF NOT EXISTS `supplier` (
  `KodeSupplier` int(11) NOT NULL,
  `Nama` varchar(30) DEFAULT NULL,
  `Alamat` varchar(100) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`KodeSupplier`, `Nama`, `Alamat`) VALUES
(1, 'New Orleans Company', 'P.O. Box 78934'),
(2, 'Cooperativa the Spain', 'MH. Thamrin 55'),
(3, 'UD. Subur Selalu', 'Raya Jemursari 123'),
(4, 'Leka Trading', '22 Jump Street');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`KodeBarang`), ADD KEY `fk_Produk_Kategori1_idx` (`KodeKategori`);

--
-- Indexes for table `kategori`
--
ALTER TABLE `kategori`
  ADD PRIMARY KEY (`KodeKategori`);

--
-- Indexes for table `notabeli`
--
ALTER TABLE `notabeli`
  ADD PRIMARY KEY (`NoNota`), ADD KEY `fk_NotaBeli_Pemasok1_idx` (`KodeSupplier`), ADD KEY `fk_NotaBeli_Pegawai1_idx` (`KodePegawai`);

--
-- Indexes for table `notabelidetil`
--
ALTER TABLE `notabelidetil`
  ADD PRIMARY KEY (`NoNota`,`KodeBarang`), ADD KEY `fk_NotaBeli_has_Produk_Produk1_idx` (`KodeBarang`), ADD KEY `fk_NotaBeli_has_Produk_NotaBeli1_idx` (`NoNota`);

--
-- Indexes for table `notajual`
--
ALTER TABLE `notajual`
  ADD PRIMARY KEY (`NoNota`), ADD KEY `fk_NotaJual_Pelanggan1_idx` (`KodePelanggan`), ADD KEY `fk_NotaJual_Pegawai1_idx` (`KodePegawai`);

--
-- Indexes for table `notajualdetil`
--
ALTER TABLE `notajualdetil`
  ADD PRIMARY KEY (`NoNota`,`KodeBarang`), ADD KEY `fk_NotaJual_has_Produk_Produk1_idx` (`KodeBarang`), ADD KEY `fk_NotaJual_has_Produk_NotaJual_idx` (`NoNota`);

--
-- Indexes for table `pegawai`
--
ALTER TABLE `pegawai`
  ADD PRIMARY KEY (`KodePegawai`), ADD KEY `FK_Pegawai_Atasan` (`KodeAtasan`);

--
-- Indexes for table `pelanggan`
--
ALTER TABLE `pelanggan`
  ADD PRIMARY KEY (`KodePelanggan`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`KodeSupplier`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pegawai`
--
ALTER TABLE `pegawai`
  MODIFY `KodePegawai` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `pelanggan`
--
ALTER TABLE `pelanggan`
  MODIFY `KodePelanggan` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `KodeSupplier` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `barang`
--
ALTER TABLE `barang`
ADD CONSTRAINT `FK_Barang_Kategori` FOREIGN KEY (`KodeKategori`) REFERENCES `kategori` (`KodeKategori`);

--
-- Constraints for table `notabeli`
--
ALTER TABLE `notabeli`
ADD CONSTRAINT `FK_NotaBeli_Pegawai` FOREIGN KEY (`KodePegawai`) REFERENCES `pegawai` (`KodePegawai`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `FK_NotaBeli_Supplier` FOREIGN KEY (`KodeSupplier`) REFERENCES `supplier` (`KodeSupplier`);

--
-- Constraints for table `notabelidetil`
--
ALTER TABLE `notabelidetil`
ADD CONSTRAINT `FK_notabelidetil_KodeBarang` FOREIGN KEY (`KodeBarang`) REFERENCES `barang` (`KodeBarang`),
ADD CONSTRAINT `FK_notabelidetil_NoNota` FOREIGN KEY (`NoNota`) REFERENCES `notabeli` (`NoNota`);

--
-- Constraints for table `notajual`
--
ALTER TABLE `notajual`
ADD CONSTRAINT `FK_NotaJual_Pegawai` FOREIGN KEY (`KodePegawai`) REFERENCES `pegawai` (`KodePegawai`),
ADD CONSTRAINT `FK_NotaJual_Pelanggan` FOREIGN KEY (`KodePelanggan`) REFERENCES `pelanggan` (`KodePelanggan`);

--
-- Constraints for table `notajualdetil`
--
ALTER TABLE `notajualdetil`
ADD CONSTRAINT `FK_notajualdetil_KodeBarang` FOREIGN KEY (`KodeBarang`) REFERENCES `barang` (`KodeBarang`),
ADD CONSTRAINT `FK_notajualdetil_NoNota` FOREIGN KEY (`NoNota`) REFERENCES `notajual` (`NoNota`);

--
-- Constraints for table `pegawai`
--
ALTER TABLE `pegawai`
ADD CONSTRAINT `FK_Pegawai_Atasan` FOREIGN KEY (`KodeAtasan`) REFERENCES `pegawai` (`KodePegawai`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
