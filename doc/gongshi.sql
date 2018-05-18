/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 50022
Source Host           : localhost:3306
Source Database       : duqiu

Target Server Type    : MYSQL
Target Server Version : 50022
File Encoding         : 65001

Date: 2018-05-18 17:43:49
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `gongshi`
-- ----------------------------
DROP TABLE IF EXISTS `gongshi`;
CREATE TABLE `gongshi` (
  `id` varchar(100) NOT NULL,
  `groupid` varchar(100) default NULL,
  `gailv` double(10,2) default NULL,
  `kaili` double(10,2) default NULL,
  `peilv` double(10,2) default NULL,
  `peifulv` double(10,2) default NULL,
  `peilvchazhi` double(10,2) default NULL,
  `xiangduipeilv` double(10,2) default NULL,
  `gailvchazhi1` double(10,2) default NULL,
  `gailvchazhi2` double(10,2) default NULL,
  `addtime` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of gongshi
-- ----------------------------
INSERT INTO `gongshi` VALUES ('1', '2', '3.00', '4.00', '5.00', '6.00', '7.00', '8.00', '9.00', '10.00', '2018-05-18 17:35:46');
INSERT INTO `gongshi` VALUES ('2', '3', '1.00', '2.00', '3.00', '4.00', '5.00', '6.00', '7.00', '8.00', '2018-05-18 17:40:25');
