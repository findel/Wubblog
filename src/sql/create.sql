DROP TABLE IF EXISTS `comments`;
DROP TABLE IF EXISTS `entries`;

CREATE TABLE `entries` (
  `entryId` int(10) unsigned NOT NULL auto_increment,
  `title` varchar(255) NOT NULL,
  `reference` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `markdown` text NOT NULL,
  `keywords` text NOT NULL,
  `createdDate` datetime NOT NULL,
  `publishDate` datetime NOT NULL,
  `active` tinyint(1) NOT NULL,
  PRIMARY KEY  USING BTREE (`entryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `comments` (
  `commentId` int(10) unsigned NOT NULL auto_increment,
  `name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `website` varchar(45) NOT NULL,
  `twitter` varchar(45) NOT NULL,
  `content` text NOT NULL,
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
