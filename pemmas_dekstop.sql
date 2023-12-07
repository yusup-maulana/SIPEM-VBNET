-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 20, 2018 at 05:02 PM
-- Server version: 10.1.13-MariaDB
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pemmas_dekstop`
--

-- --------------------------------------------------------

--
-- Table structure for table `agenda`
--

CREATE TABLE `agenda` (
  `id_agenda` int(11) NOT NULL,
  `tgl_dibagikan` date NOT NULL,
  `data_agenda` longtext NOT NULL,
  `ket` longtext NOT NULL,
  `data_absen` longtext NOT NULL,
  `anggaran` int(11) NOT NULL,
  `id_kas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `anggaran`
--

CREATE TABLE `anggaran` (
  `id_anggaran` int(11) NOT NULL,
  `id_kas` int(11) NOT NULL,
  `ket` longtext NOT NULL,
  `anggaran` int(11) NOT NULL,
  `tgl` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `kas_pemmas`
--

CREATE TABLE `kas_pemmas` (
  `id_kas` int(11) NOT NULL,
  `ket` longtext NOT NULL,
  `dana` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kas_pemmas`
--

INSERT INTO `kas_pemmas` (`id_kas`, `ket`, `dana`) VALUES
(1, 'Anggaran Bulanan untuk pkk', 141000),
(2, 'Anggaran Tahunan Pemberdayaan Masyarakat', 46600),
(3, 'Musyawarah LANSIA', 60000);

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `user` varchar(20) NOT NULL,
  `pass` varchar(20) NOT NULL,
  `nama_instansi` varchar(20) NOT NULL,
  `akses` varchar(35) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `nik` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`user`, `pass`, `nama_instansi`, `akses`, `nama`, `nik`) VALUES
('andir', '123123', 'Bandung Kulon', 'Kecamatan', 'Eren', '123456456546'),
('campaka', '123123', 'Campaka', 'Kelurahan', 'Mikasa', '456445454544'),
('caringin', '123123', 'Caringin', 'Kelurahan', 'Reiss Rod', '1111111111111'),
('ckaler', '123123', 'Cigondewah Kaler', 'Kelurahan', 'Armin', '875678645455'),
('ckidul', '123123', 'Cigondewah Kidul', 'Kelurahan', 'Berthold', '456876868686'),
('dunguscariang', '123123', 'Dunguscariang', 'Kelurahan', 'Levi', '454454545454'),
('gempolsari', '123123', 'Gempolsari', 'Kelurahan', 'Ackerman', '456787867868');

-- --------------------------------------------------------

--
-- Table structure for table `notulen_gambar`
--

CREATE TABLE `notulen_gambar` (
  `id_notulen_gambar` int(11) NOT NULL,
  `id_proposal` int(11) NOT NULL,
  `gambar` varchar(100) NOT NULL,
  `tgl` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `proposal`
--

CREATE TABLE `proposal` (
  `id_proposal` int(11) NOT NULL,
  `namakegiatan` varchar(200) NOT NULL,
  `tgl_acara` date NOT NULL,
  `tgl_kirim` date NOT NULL,
  `tgl_acc` date NOT NULL,
  `ket` longtext NOT NULL,
  `kelurahan` varchar(30) NOT NULL,
  `data_proposal` varchar(100) NOT NULL,
  `status_proposal` varchar(15) NOT NULL,
  `data_notulen` varchar(100) NOT NULL,
  `status_notulen` varchar(15) NOT NULL,
  `tgl_notulen` date NOT NULL,
  `status_gambar` varchar(15) NOT NULL,
  `nama_petugas` varchar(50) NOT NULL,
  `anggaran_diajukan` int(11) NOT NULL,
  `anggaran_diterima` int(11) NOT NULL,
  `id_kas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `agenda`
--
ALTER TABLE `agenda`
  ADD PRIMARY KEY (`id_agenda`);

--
-- Indexes for table `anggaran`
--
ALTER TABLE `anggaran`
  ADD PRIMARY KEY (`id_anggaran`);

--
-- Indexes for table `kas_pemmas`
--
ALTER TABLE `kas_pemmas`
  ADD PRIMARY KEY (`id_kas`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`user`);

--
-- Indexes for table `notulen_gambar`
--
ALTER TABLE `notulen_gambar`
  ADD PRIMARY KEY (`id_notulen_gambar`);

--
-- Indexes for table `proposal`
--
ALTER TABLE `proposal`
  ADD PRIMARY KEY (`id_proposal`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `agenda`
--
ALTER TABLE `agenda`
  MODIFY `id_agenda` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `anggaran`
--
ALTER TABLE `anggaran`
  MODIFY `id_anggaran` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;
--
-- AUTO_INCREMENT for table `kas_pemmas`
--
ALTER TABLE `kas_pemmas`
  MODIFY `id_kas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `notulen_gambar`
--
ALTER TABLE `notulen_gambar`
  MODIFY `id_notulen_gambar` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=285;
--
-- AUTO_INCREMENT for table `proposal`
--
ALTER TABLE `proposal`
  MODIFY `id_proposal` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
