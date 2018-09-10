-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 22-12-2017 a las 00:14:46
-- Versión del servidor: 10.1.28-MariaDB
-- Versión de PHP: 7.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `db_igeographic`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `amigos`
--

CREATE TABLE `amigos` (
  `idAmigos` int(11) NOT NULL,
  `Usuarios_idUsuarios` int(11) NOT NULL,
  `Usuarios_idUsuarios1` int(11) NOT NULL,
  `A_pendiente` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aparicion`
--

CREATE TABLE `aparicion` (
  `idAparicion` int(11) NOT NULL,
  `Partida_idPartida` int(11) NOT NULL,
  `Partida_Torneo_idTorneo` int(11) NOT NULL,
  `Partida_Torneo_Usuarios_idUsuarios` int(11) NOT NULL,
  `Partida_Usuarios_idUsuarios` int(11) NOT NULL,
  `Ciudad_idCiudad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ciudad`
--

CREATE TABLE `ciudad` (
  `idCiudad` int(11) NOT NULL,
  `Continente_idContinente` int(11) NOT NULL,
  `I_nombre` varchar(45) DEFAULT NULL,
  `I_path` varchar(45) DEFAULT NULL,
  `latitud` varchar(45) DEFAULT NULL,
  `longitud` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ciudad`
--

INSERT INTO `ciudad` (`idCiudad`, `Continente_idContinente`, `I_nombre`, `I_path`, `latitud`, `longitud`) VALUES
(101, 1, 'Madrid', NULL, '48.857595', '2.348432');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `continente`
--

CREATE TABLE `continente` (
  `idContinente` int(11) NOT NULL,
  `C_nombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `continente`
--

INSERT INTO `continente` (`idContinente`, `C_nombre`) VALUES
(1, 'Europa'),
(2, 'Asia'),
(3, 'África'),
(4, 'América Central'),
(5, 'América del Norte'),
(6, 'América del Sur'),
(7, 'Oceanía');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `fotos`
--

CREATE TABLE `fotos` (
  `idfotos` int(11) NOT NULL,
  `urlFotos` varchar(200) DEFAULT NULL,
  `Dificultad` int(11) NOT NULL,
  `Ciudad_Continente_idContinente` int(11) NOT NULL,
  `latitud` double DEFAULT NULL,
  `longitud` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `fotos`
--

INSERT INTO `fotos` (`idfotos`, `urlFotos`, `Dificultad`, `Ciudad_Continente_idContinente`, `latitud`, `longitud`) VALUES
(1, 'http://localhost/igeographic/Europa/Madrid/Imagen1.jpg', 1, 1, 40.420216, -3.704335),
(2, 'http://localhost/igeographic/Europa/Madrid/Imagen2.jpg', 1, 1, 40.419223, -3.693271),
(3, 'http://localhost/igeographic/Europa/Madrid/Imagen3.jpg', 1, 1, 40.416867, -3.703194),
(4, 'http://localhost/igeographic/Europa/Madrid/Imagen4.jpg', 2, 1, 40.42405869094252, -3.7166267900047387),
(5, 'http://localhost/igeographic/Europa/Londres/Imagen1.jpg', 1, 1, 51.500809, -0.120092),
(6, 'http://localhost/igeographic/Europa/Londres/Imagen2.jpg', 1, 1, 51.500029, -0.124481),
(7, 'http://localhost/igeographic/Europa/Londres/Imagen3.jpg', 3, 1, 51.555902599383955, -0.17658128346693047),
(8, 'http://localhost/igeographic/Europa/Londres/Imagen4.jpg', 3, 1, 51.479382953346125, -0.13804233002474575),
(9, 'http://localhost/igeographic/Europa/Paris/Imagen1.jpg', 1, 1, 48.858543, 2.294073),
(10, 'http://localhost/igeographic/Europa/Paris/Imagen2.jpg', 2, 1, 48.860540515673826, 2.3377512883605505),
(11, 'http://localhost/igeographic/Europa/Paris/Imagen3.jpg', 3, 1, 48.85304232475187, 2.350384897622689),
(12, 'http://localhost/igeographic/Europa/Paris/Imagen4.jpg', 2, 1, 48.8530423247519, 2.350384897622689),
(13, 'http://localhost/igeographic/Europa/Lisboa/Imagen1.jpg', 3, 1, 38.714638, -9.14063),
(14, 'http://localhost/igeographic/Europa/Lisboa/Imagen2.jpg', 2, 1, 38.712129, -9.123721),
(15, 'http://localhost/igeographic/Europa/Lisboa/Imagen3.jpg', 3, 1, 38.711133, -9.131864),
(16, 'http://localhost/igeographic/Europa/Lisboa/Imagen4.jpg', 3, 1, 38.6935973, -9.205711500000007),
(17, 'http://localhost/igeographic/Europa/Roma/Imagen1.jpg', 1, 1, 41.889587, 12.491952),
(18, 'http://localhost/igeographic/Europa/Roma/Imagen2.jpg', 2, 1, 41.909930300000006, 12.497408299999961),
(19, 'http://localhost/igeographic/Europa/Roma/Imagen3.jpg', 2, 1, 41.901510057089155, 12.466652850366586),
(20, 'http://localhost/igeographic/Europa/Roma/Imagen2.jpg', 1, 1, 41.9009325, 12.48331299),
(21, 'http://localhost/igeographic/Europa/Berlin/Imagen1.jpg', 2, 1, 52.505809, 13.436003),
(22, 'http://localhost/igeographic/Europa/Berlin/Imagen2.jpg', 3, 1, 52.517378, 13.367025),
(23, 'http://localhost/igeographic/Asia/Malasia/Imagen1.jpg', 2, 2, 3.13851116272114, 101.68698949),
(24, 'http://localhost/igeographic/Asia/Malasia/Imagen2.jpg', 3, 2, 4.47939187747496, 101.42773842851568),
(25, 'http://localhost/igeographic/Asia/Malasia/Imagen3.jpg', 2, 2, 1.3434057727950663, 103.83909426072694),
(26, 'http://localhost/igeographic/Asia/Japon/Imagen1.jpg', 1, 2, 35.714220654555824, 139.79699057612686),
(27, 'http://localhost/igeographic/Asia/Japon/Imagen2.jpg', 1, 2, 34.99485390272491, 135.78504361779096),
(28, 'http://localhost/igeographic/Asia/Tailandia/Imagen1.jpg', 2, 2, 15.867683392249175, 100.99561295184276),
(29, 'http://localhost/igeographic/Asia/Tailandia/Imagen2.jpg', 3, 2, 18.77176722935581, 98.95647725000003),
(30, 'http://localhost/igeographic/Asia/Tailandia/Imagen3.jpg', 2, 2, 13.756330899, 100.5017651),
(31, 'http://localhost/igeographic/Asia/China/Imagen1.jpg', 1, 2, 40.44444626215918, 116.58138805021508),
(32, 'http://localhost/igeographic/Asia/China/Imagen2.jpg', 1, 2, 29.86547720886891, 110.64297729140617),
(33, 'http://localhost/igeographic/Asia/China/Imagen3.jpg', 2, 2, 39.905147024653076, 116.42472946474618),
(34, 'http://localhost/igeographic/Asia/CoreaDelSur/Imagen1.jpg', 3, 2, 37.5781672799778, 126.97578036176299),
(35, 'http://localhost/igeographic/Asia/CoreaDelSur/Imagen2.jpg', 3, 2, 37.79210019858116, 127.5250697312133),
(36, 'http://localhost/igeographic/Asia/CoreaDelSur/Imagen3.jpg', 1, 2, 37.56398371981698, 126.974086299),
(37, 'http://localhost/igeographic/Asia/CoreaDelSur/Imagen4.jpg', 3, 2, 38.175023922419435, 128.4846808217843),
(38, 'http://localhost/igeographic/Africa/Marruecos/Imagen1.jpg', 2, 3, 31.62360461782709, -7.993601),
(39, 'http://localhost/igeographic/Africa/Marruecos/Imagen2.jpg', 3, 3, 31.6217408, -7.981552599),
(40, 'http://localhost/igeographic/Africa/Marruecos/Imagen3.jpg', 3, 3, 33.96924424950715, -6.857262799),
(41, 'http://localhost/igeographic/Africa/Marruecos/Imagen4.jpg', 2, 3, 30.93552454011197, -6.9325893499),
(42, 'http://localhost/igeographic/Africa/Egipto/Imagen1.jpg', 1, 3, 22.336477691, 31.624833404754668),
(43, 'http://localhost/igeographic/Africa/Egipto/Imagen2.jpg', 1, 3, 29.847491345122044, 31.21879605557251),
(44, 'http://localhost/igeographic/Africa/Egipto/Imagen3.jpg', 1, 3, 27.18176678793723, 31.20390004720457),
(45, 'http://localhost/igeographic/Africa/Egipto/Imagen4.jpg', 1, 3, 30.0478468, 31.2336493),
(46, 'http://localhost/igeographic/Africa/Egipto/Imagen5.jpg', 1, 3, 22.3372319, 31.625799),
(47, 'http://localhost/igeographic/Africa/Tunez/Imagen1.jpg', 3, 3, 36.8093387, 10.1342615),
(48, 'http://localhost/igeographic/Africa/Tunez/Imagen2.jpg', 2, 3, 36.7972866, 10.1712416),
(49, 'http://localhost/igeographic/Africa/Tunez/Imagen3.jpg', 3, 3, 36.8542451, 10.3348631),
(50, 'http://localhost/igeographic/Africa/CostaDeMarfil/Imagen1.jpg', 2, 3, 6.8112673, -5.296421),
(51, 'http://localhost/igeographic/Africa/Tunez/Imagen2.jpg', 3, 3, 5.3331223, -4.0203807),
(52, 'http://localhost/igeographic/Africa/Madagascar/Imagen1.jpg', 2, 3, -18.989440999674063, 46.86765005),
(53, 'http://localhost/igeographic/Oceania/NuevaGuinea/Imagen1.jpg', 2, 7, -3.8741026675190913, 144.51519015),
(54, 'http://localhost/igeographic/Oceania/NuevaGuinea/Imagen2.jpg', 3, 7, -5.1667, 150.5),
(55, 'http://localhost/igeographic/Oceania/NuevaZelanda/Imagen1.jpg', 3, 7, -40.934681, 172.9699665),
(56, 'http://localhost/igeographic/Oceania/NuevaZelanda/Imagen2.jpg', 2, 7, -36.8484437, 174.7600023),
(57, 'http://localhost/igeographic/Oceania/NuevaZelanda/Imagen3.jpg', 1, 7, -37.8573593, 175.675299),
(58, 'http://localhost/igeographic/Oceania/NuevaZelanda/Imagen4.jpg', 2, 7, -38.2392568, 174.9975291),
(59, 'http://localhost/igeographic/Oceania/Australia/Imagen1.jpg', 1, 7, -33.8567799, 151.213108),
(60, 'http://localhost/igeographic/Oceania/Australia/Imagen2.jpg', 1, 7, -38.6620973, 143.102903),
(61, 'http://localhost/igeographic/Oceania/Australia/Imagen3.jpg', 1, 7, -33.8523018, 151.2085984),
(62, 'http://localhost/igeographic/Oceania/Australia/Imagen4.jpg', 2, 7, -33.8748755, 151.1987113),
(63, 'http://localhost/igeographic/Oceania/Australia/Imagen5.jpg', 2, 7, -33.8641814, 151.2143821),
(64, 'http://localhost/igeographic/Oceania/Australia/Imagen6.jpg', 2, 7, -31.960906, 115.8300042),
(65, 'http://localhost/igeographic/Oceania/Australia/Imagen7.jpg', 1, 7, -37.9701541, 144.492683),
(66, 'http://localhost/igeographic/Oceania/Australia/Imagen8.jpg', 1, 7, -16.4399178, 139.0524887),
(67, 'http://localhost/igeographic/Oceania/Samoa/Imagen1.jpg', 3, 7, -13.8380738, -171.7855737),
(68, 'http://localhost/igeographic/Oceania/Samoa/Imagen2.jpg', 3, 7, -13.9201117, -172.0288275),
(69, 'http://localhost/igeographic/Oceania/Australia/Imagen3.jpg', 3, 7, -13.8012566, -172.5266147),
(70, 'http://localhost/igeographic/AmericaCentral/Bahamas/Imagen1.jpg', 1, 4, 25.0835162, -77.3264306),
(71, 'http://localhost/igeographic/AmericaCentral/Bahamas/Imagen2.jpg', 3, 4, 25.0736001, -77.3407087),
(72, 'http://localhost/igeographic/AmericaCentral/Cuba/Imagen1.jpg', 1, 4, 23.1507559, -82.3602545),
(73, 'http://localhost/igeographic/AmericaCentral/Cuba/Imagen2.jpg', 3, 4, 23.1416453, -82.3588209),
(74, 'http://localhost/igeographic/AmericaCentral/Cuba/Imagen3.jpg', 2, 4, 23.1354067, -82.3611941),
(75, 'http://localhost/igeographic/AmericaCentral/Cuba/Imagen4.jpg', 2, 4, 22.4026726, -79.9815611),
(76, 'http://localhost/igeographic/AmericaCentral/Panama/Imagen1.jpg', 2, 4, 9.144374, -80.0087188),
(77, 'http://localhost/igeographic/AmericaCentral/Panama/Imagen2.jpg', 3, 4, 9.0310994, -79.6371517),
(78, 'http://localhost/igeographic/AmericaCentral/Mexico/Imagen1.jpg', 3, 4, 20.2145431, -87.4314335),
(79, 'http://localhost/igeographic/AmericaCentral/Mexico/Imagen2.jpg', 1, 4, 19.6922779, -98.8456922),
(80, 'http://localhost/igeographic/AmericaCentral/Mexico/Imagen3.jpg', 1, 4, 20.6829909, -88.5708378),
(81, 'http://localhost/igeographic/AmericaCentral/Mexico/Imagen4.jpg', 2, 4, 19.4270231, -99.1686937),
(82, 'http://localhost/igeographic/AmericaCentral/Mexico/Imagen5.jpg', 3, 4, 19.4406976, -99.2068888),
(83, 'http://localhost/igeographic/AmericaCentral/Mexico/Imagen6.jpg', 2, 4, 20.4930305, -87.7264178),
(84, 'http://localhost/igeographic/AmericaCentral/Mexico/Imagen7.jpg', 1, 4, 19.055914, -98.3029939),
(85, 'http://localhost/igeographic/AmericaDelNorte/Canada/Imagen1.jpg', 3, 5, 49.3428609, -123.1171131),
(86, 'http://localhost/igeographic/AmericaDelNorte/Canada/Imagen2.jpg', 2, 5, 43.6425662, -79.3892455),
(87, 'http://localhost/igeographic/AmericaDelNorte/Canada/Imagen3.jpg', 2, 5, 43.6677097, -79.3969658),
(88, 'http://localhost/igeographic/AmericaDelNorte/Canada/Imagen4.jpg', 2, 5, 46.811978, -71.2071987),
(89, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen1.jpg', 1, 5, 37.8199286, -122.4804438),
(90, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen2.jpg', 1, 5, 40.6892494, -74.0466891),
(91, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen3.jpg', 1, 5, 40.7484405, -73.9878531),
(92, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen4.jpg', 3, 5, 38.7261205, -109.7315942),
(93, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen5.jpg', 1, 5, 28.417663, -81.5834007),
(94, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen6.jpg', 3, 5, 37.573297, -112.3184),
(95, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen7.jpg', 1, 5, 34.1019216, -118.3399057),
(96, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen8.jpg', 2, 5, 36.1246737, -115.4551954),
(97, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen9.jpg', 2, 5, 43.0828162, -79.0763516),
(98, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen10.jpg', 3, 5, 32.6702295, -117.2371717),
(99, 'http://localhost/igeographic/AmericaDelNorte/EstadosUnidos/Imagen11.jpg', 3, 5, 25.7823907, -80.2994994),
(100, 'http://localhost/igeographic/AmericaDelSur/Venezuela/Imagen1.jpg', 1, 6, 5.9689135, -62.5376132),
(101, 'http://localhost/igeographic/AmericaDelSur/Venezuela/Imagen2.jpg', 2, 6, 10.5131932, -66.9147957),
(102, 'http://localhost/igeographic/AmericaDelSur/Argentina/Imagen1.jpg', 1, 6, -25.6950947, -54.4389574),
(103, 'http://localhost/igeographic/AmericaDelSur/Argentina/Imagen2.jpg', 3, 6, -34.6375871, -58.379205),
(104, 'http://localhost/igeographic/AmericaDelSur/Argentina/Imagen3.jpg', 2, 6, -34.6080556, -58.3724665),
(105, 'http://localhost/igeographic/AmericaDelSur/Argentina/Imagen4.jpg', 3, 6, -34.5995735, -58.3857785),
(106, 'http://localhost/igeographic/AmericaDelSur/Argentina/Imagen5.jpg', 1, 6, -34.6037389, -58.3837591),
(107, 'http://localhost/igeographic/AmericaDelSur/Argentina/Imagen6.jpg', 3, 6, -34.6075694, -58.3754461),
(108, 'http://localhost/igeographic/AmericaDelSur/Brasil/Imagen1.jpg', 1, 6, -22.951916, -43.2126759),
(109, 'http://localhost/igeographic/AmericaDelSur/Brasil/Imagen2.jpg', 2, 6, -22.9121089, -43.2323445),
(110, 'http://localhost/igeographic/AmericaDelSur/Brasil/Imagen3.jpg', 3, 6, -23.5342666, -46.6361388),
(111, 'http://localhost/igeographic/AmericaDelSur/Peru/Imagen1.jpg', 1, 6, -13.1631412, -72.5471516),
(112, 'http://localhost/igeographic/AmericaDelSur/Peru/Imagen2.jpg', 2, 6, -13.5096866, -71.9841851),
(113, 'http://localhost/igeographic/AmericaDelSur/Peru/Imagen3.jpg', 2, 6, -13.4832941, -71.9643833),
(114, 'http://localhost/igeographic/AmericaDelSur/Peru/Imagen4.jpg', 3, 6, -12.0448456, -77.0319752);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `partida`
--

CREATE TABLE `partida` (
  `idPartida` int(11) NOT NULL,
  `Torneo_idTorneo` int(11) NOT NULL,
  `Torneo_Usuarios_idUsuarios` int(11) NOT NULL,
  `Usuarios_idUsuarios` int(11) NOT NULL,
  `Continente_idContinente` int(11) NOT NULL,
  `P_fecha` datetime DEFAULT NULL,
  `P_puntuacion` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `partida`
--

INSERT INTO `partida` (`idPartida`, `Torneo_idTorneo`, `Torneo_Usuarios_idUsuarios`, `Usuarios_idUsuarios`, `Continente_idContinente`, `P_fecha`, `P_puntuacion`) VALUES
(1, 0, 0, 2, 0, '2017-11-16 23:54:55', 48278),
(2, 0, 0, 2, 0, '2017-11-19 17:38:14', 19582),
(3, 0, 0, 2, 0, '2017-11-19 17:39:44', 248539),
(4, 0, 0, 2, 0, '2017-11-19 17:44:55', 250378),
(5, 0, 0, 2, 0, '2017-11-19 17:45:52', 253513),
(6, 0, 0, 2, 0, '2017-11-19 17:49:23', 241339),
(7, 0, 0, 2, 0, '2017-11-19 17:49:36', 235992),
(8, 0, 0, 2, 0, '2017-11-19 17:49:54', 264911),
(9, 0, 0, 4, 0, '2017-11-19 20:08:43', 31406),
(10, 0, 0, 2, 0, '2017-11-28 17:38:52', 51020),
(11, 0, 0, 2, 0, '2017-11-28 22:51:15', 24498),
(12, 0, 0, 2, 2, '2017-12-20 14:45:33', 614407),
(13, 0, 0, 2, 1, '2017-12-20 14:45:54', 239955),
(14, 0, 0, 2, 3, '2017-12-20 14:46:03', 202002);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `smf_members`
--

CREATE TABLE `smf_members` (
  `id_member` mediumint(8) UNSIGNED NOT NULL,
  `member_name` varchar(80) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `date_registered` int(10) UNSIGNED NOT NULL DEFAULT '0',
  `last_login` int(10) UNSIGNED NOT NULL DEFAULT '0',
  `passwd` varchar(64) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `email_address` varchar(255) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `gender` tinyint(4) UNSIGNED NOT NULL DEFAULT '0',
  `birthdate` date NOT NULL DEFAULT '0001-01-01',
  `validation_code` varchar(10) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `active` int(11) DEFAULT NULL,
  `number_updates` int(11) DEFAULT NULL,
  `continent` varchar(50) COLLATE utf8_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `smf_members`
--

INSERT INTO `smf_members` (`id_member`, `member_name`, `date_registered`, `last_login`, `passwd`, `email_address`, `gender`, `birthdate`, `validation_code`, `active`, `number_updates`, `continent`) VALUES
(1, 'iGeographic', 1509968367, 1510063687, '0e353c902612ff398abca261e013dd0c3c85aa04', 'luiskar009@gmail.com', 0, '0001-01-01', '', NULL, NULL, NULL),
(2, 'luiskar', 1510063751, 1510063752, '7287a5dda8d02124dfad8651bf16d1dd0f5d3412', 'lc.navas@alumnos.upm.es', 0, '0001-01-01', '', NULL, NULL, NULL),
(4, 'usuario', 1511121165, 1511121165, '28df2f643636841b6999d72b5abaa0ed67771f04', 'luis@gmail.com', 0, '2017-11-19', '', NULL, NULL, NULL),
(5, 'l', 1513772546, 1513772546, '110c8a30c16070bf2813480d9492a1a170a7d80a', 'l@gmail.com', 0, '2017-12-20', 'WL70', 1, 0, 'Europa'),
(6, 'prueba22', 1513781249, 1513781249, 'e1fc912e504aa67644e3f3dc0f6981a07918f7d6', 't441931@mvrht.net', 0, '2017-12-20', '4TI5', 1, 0, 'América del Norte'),
(7, 'prueba44', 1513781625, 1513781625, 'cd5cd56dc9ff2ab4b224bcb75027a8136af9f950', 't443831@mvrht.net', 0, '2017-12-20', 'YBJ9', 0, 0, 'América del Norte'),
(8, 'prueba33', 1513782866, 1513782866, '9ff311bd3f9f3ab5a4c605c0abac406c1001b5bd', 't446110@mvrht.net', 0, '2005-02-17', '67F7', 1, 0, 'Europa');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `torneo`
--

CREATE TABLE `torneo` (
  `idTorneo` int(11) NOT NULL,
  `Usuarios_idUsuarios` int(11) NOT NULL,
  `T_fechaInicio` datetime DEFAULT NULL,
  `T_fechaFin` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `amigos`
--
ALTER TABLE `amigos`
  ADD PRIMARY KEY (`idAmigos`);

--
-- Indices de la tabla `ciudad`
--
ALTER TABLE `ciudad`
  ADD PRIMARY KEY (`idCiudad`,`Continente_idContinente`),
  ADD KEY `fk_Ciudad_Continente1_idx` (`Continente_idContinente`);

--
-- Indices de la tabla `continente`
--
ALTER TABLE `continente`
  ADD PRIMARY KEY (`idContinente`);

--
-- Indices de la tabla `fotos`
--
ALTER TABLE `fotos`
  ADD PRIMARY KEY (`idfotos`);

--
-- Indices de la tabla `partida`
--
ALTER TABLE `partida`
  ADD PRIMARY KEY (`idPartida`);

--
-- Indices de la tabla `smf_members`
--
ALTER TABLE `smf_members`
  ADD PRIMARY KEY (`id_member`),
  ADD KEY `member_name` (`member_name`),
  ADD KEY `date_registered` (`date_registered`),
  ADD KEY `birthdate` (`birthdate`),
  ADD KEY `last_login` (`last_login`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `amigos`
--
ALTER TABLE `amigos`
  MODIFY `idAmigos` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `partida`
--
ALTER TABLE `partida`
  MODIFY `idPartida` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `smf_members`
--
ALTER TABLE `smf_members`
  MODIFY `id_member` mediumint(8) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `ciudad`
--
ALTER TABLE `ciudad`
  ADD CONSTRAINT `fk_Ciudad_Continente1` FOREIGN KEY (`Continente_idContinente`) REFERENCES `continente` (`idContinente`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
