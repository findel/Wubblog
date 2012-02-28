DELETE FROM `entries`; # Will remove comments also (thanks to cascade). 

INSERT INTO `entries`
(`entryId`, `title`, `reference`, 
`description`, 
`markdown`, 
`keywords`, `createdDate`, `publishDate`, `active`)
VALUES
(1, 'Hello World', 'hello-world', 
'Lorem ipsum dolor sit amet.', 
'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sodales urna non odio egestas tempor. Nunc vel vehicula ante. Etiam bibendum iaculis libero, eget molestie nisl pharetra in. In semper consequat est, eu porta velit mollis nec.', 
'hello world, test, wubblog', '2012-02-26', '2012-02-26', true),
(2, 'Hello World 2', 'hello-world-2', 
'Aliquam sodales urna non odio egestas tempor.', 
'Aliquam sodales urna non odio egestas tempor. Nunc vel vehicula ante. Etiam bibendum iaculis libero, eget molestie nisl pharetra in. In semper consequat est, eu porta velit mollis nec.', 
'hello world, test, wubblog', '2012-02-27', '2012-02-27', true);

INSERT INTO `comments` 
(`name`, `email`, `website`, `twitter`, `markdown`, `authorised`, `postedDate`, `entryId`) 
VALUES 
('Joe Bloggs', 'joe@test.com', 'www.test.com', '@test', 'This is a test comment', 1, '2012-02-28 12:00:00', 1),
('John Doe', 'john@test.com', 'www.test.com', '@test2', 'This is a test comment also', 1, '2012-12-28 12:30:00', 1),
('Joe Bloggs', 'joe@test.com', 'www.test.com', '@test', 'This is a test comment', 1, '2012-02-28 12:00:00', 2),
('John Doe', 'john@test.com', 'www.test.com', '@test2', 'This is a test comment also', 1, '2012-12-28 12:30:00', 2);