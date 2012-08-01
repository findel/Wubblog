DROP TABLE IF EXISTS `comments`;
DROP TABLE IF EXISTS `entries`;
DROP TABLE IF EXISTS `authors`;

CREATE TABLE `authors` (
  `authorId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `userName` varchar(45) NOT NULL,
  `displayName` varchar(45) NOT NULL,
  `passwordHash` varchar(128) NOT NULL,
  PRIMARY KEY (`authorId`),
  UNIQUE KEY `userName_UNIQUE` (`userName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `entries` (
  `entryId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `reference` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `markdown` text NOT NULL,
  `keywords` text NOT NULL,
  `createdDate` datetime NOT NULL,
  `publishDate` datetime NOT NULL,
  `active` tinyint(1) NOT NULL,
  `authorId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`entryId`) USING BTREE,
  KEY `entries_authors` (`authorId`),
  CONSTRAINT `entries_authors` FOREIGN KEY (`authorId`) REFERENCES `authors` (`authorId`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `comments` (
  `commentId` int(10) unsigned NOT NULL auto_increment,
  `name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `website` varchar(45) NOT NULL,
  `twitter` varchar(45) NOT NULL,
  `markdown` text NOT NULL,
  `authorised` tinyint(1) NOT NULL,
  `postedDate` datetime NOT NULL,
  `entryId` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`commentId`),
  KEY `comments_entries` (`entryId`),
  CONSTRAINT `comments_entries` 
      FOREIGN KEY (`entryId`) 
      REFERENCES `entries` (`entryId`) 
      ON DELETE CASCADE 
      ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
