-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 16, 2017 at 08:06 PM
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
('B0001', 'Green Tea Sachet', 10000, 50, '01'),
('B0002', 'Orange Squash', 5000, 100, '01'),
('B0003', 'T-Shirt Pelangi Lengan Pendek', 80000, 5, '03'),
('B0004', 'Bumbu Ayam Kalasan Royku', 15000, 120, '02'),
('B0005', 'Kaldu Ayam Magic', 30000, 25, '02'),
('B0006', 'Keju Cheddar Healthy Choice', 67000, 55, '04');

-- --------------------------------------------------------

--
-- Table structure for table `jabatan`
--

CREATE TABLE IF NOT EXISTS `jabatan` (
  `IdJabatan` char(2) NOT NULL,
  `Nama` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `jabatan`
--

INSERT INTO `jabatan` (`IdJabatan`, `Nama`) VALUES
('J1', 'Pegawai Pembelian'),
('J2', 'Kasir'),
('J3', 'Manajer');

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
('02', 'Bumbu Dapur'),
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

-- --------------------------------------------------------

--
-- Table structure for table `pegawai`
--

CREATE TABLE IF NOT EXISTS `pegawai` (
  `KodePegawai` int(11) NOT NULL,
  `Nama` varchar(45) DEFAULT NULL,
  `TglLahir` date DEFAULT NULL,
  `Alamat` varchar(100) DEFAULT NULL,
  `Gaji` bigint(20) DEFAULT NULL,
  `Username` varchar(8) DEFAULT NULL,
  `Password` varchar(8) DEFAULT NULL,
  `IdJabatan` char(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pegawai`
--

INSERT INTO `pegawai` (`KodePegawai`, `Nama`, `TglLahir`, `Alamat`, `Gaji`, `Username`, `Password`, `IdJabatan`) VALUES
(1, 'Nancy', '2017-08-16', 'Tenggilis Mejoyo AA-10', 5000000, 'nancy', 'abc', 'J2'),
(2, 'Andrew', '1977-03-09', 'Raya Darmo 129', 10000000, 'andrew', '1234', 'J3'),
(3, 'Janet', '1987-02-20', 'Darmo Permai Utara X/12', 4000000, 'janet', 'janet123', 'J2'),
(4, 'Margaret', '1984-11-20', 'Raya Kendangsari 200', 4000000, 'margaret', 'margaret', 'J2'),
(5, 'Steven', '1967-03-07', 'Raya Tenggilis 44', 3000000, 'steve', 'steve123', 'J1'),
(6, 'Michael', '1988-07-12', 'Sidosermo Indah Blok A No 12', 3000000, 'michael', '123', 'J1');

-- --------------------------------------------------------

--
-- Table structure for table `pelanggan`
--

CREATE TABLE IF NOT EXISTS `pelanggan` (
  `KodePelanggan` int(11) NOT NULL,
  `Nama` varchar(50) DEFAULT NULL,
  `Alamat` varchar(100) DEFAULT NULL,
  `Telepon` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
-- Indexes for table `jabatan`
--
ALTER TABLE `jabatan`
  ADD PRIMARY KEY (`IdJabatan`);

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
  ADD PRIMARY KEY (`KodePegawai`), ADD KEY `fk_Pegawai_Jabatan1_idx` (`IdJabatan`);

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
-- Constraints for dumped tables
--

--
-- Constraints for table `barang`
--
ALTER TABLE `barang`
ADD CONSTRAINT `fk_Produk_Kategori1` FOREIGN KEY (`KodeKategori`) REFERENCES `kategori` (`KodeKategori`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `notabeli`
--
ALTER TABLE `notabeli`
ADD CONSTRAINT `fk_NotaBeli_Pegawai1` FOREIGN KEY (`KodePegawai`) REFERENCES `pegawai` (`KodePegawai`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_NotaBeli_Pemasok1` FOREIGN KEY (`KodeSupplier`) REFERENCES `supplier` (`KodeSupplier`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `notabelidetil`
--
ALTER TABLE `notabelidetil`
ADD CONSTRAINT `fk_NotaBeli_has_Produk_NotaBeli1` FOREIGN KEY (`NoNota`) REFERENCES `notabeli` (`NoNota`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_NotaBeli_has_Produk_Produk1` FOREIGN KEY (`KodeBarang`) REFERENCES `barang` (`KodeBarang`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `notajual`
--
ALTER TABLE `notajual`
ADD CONSTRAINT `fk_NotaJual_Pegawai1` FOREIGN KEY (`KodePegawai`) REFERENCES `pegawai` (`KodePegawai`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_NotaJual_Pelanggan1` FOREIGN KEY (`KodePelanggan`) REFERENCES `pelanggan` (`KodePelanggan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `notajualdetil`
--
ALTER TABLE `notajualdetil`
ADD CONSTRAINT `fk_NotaJual_has_Produk_NotaJual` FOREIGN KEY (`NoNota`) REFERENCES `notajual` (`NoNota`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_NotaJual_has_Produk_Produk1` FOREIGN KEY (`KodeBarang`) REFERENCES `barang` (`KodeBarang`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pegawai`
--
ALTER TABLE `pegawai`
ADD CONSTRAINT `fk_Pegawai_Jabatan1` FOREIGN KEY (`IdJabatan`) REFERENCES `jabatan` (`IdJabatan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
