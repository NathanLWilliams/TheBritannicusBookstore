DROP TABLE IF EXISTS genres;
DROP TABLE IF EXISTS itemTypes;
DROP TABLE IF EXISTS tags;
DROP TABLE IF EXISTS conditions;
DROP TABLE IF EXISTS customerTypes;
DROP TABLE IF EXISTS employeePositions;

/* genres Table */
insert into genres (genreName) values ('Young Adult');
insert into genres (genreName) values ('Fantasy');
insert into genres (genreName) values ('Literary Fiction');
insert into genres (genreName) values ('Childrens');
insert into genres (genreName) values ('Science Fiction');
insert into genres (genreName) values ('Thriller');
insert into genres (genreName) values ('Horror');
insert into genres (genreName) values ('Romance');
insert into genres (genreName) values ('Historical');
insert into genres (genreName) values ('Womens Fiction');
/* itemTypes Table */
insert into itemTypes (itemTypeName) values ('Book');
insert into itemTypes (itemTypeName) values ('Map');
insert into itemTypes (itemTypeName) values ('Periodical');
/* tags Table */
insert into tags (tagDescription) values ('Medieval');
insert into tags (tagDescription) values ('World War 1');
insert into tags (tagDescription) values ('World War 2');
insert into tags (tagDescription) values ('Finance');
insert into tags (tagDescription) values ('Cyberpunk');
insert into tags (tagDescription) values ('Dystopia');
insert into tags (tagDescription) values ('Utopia');
insert into tags (tagDescription) values ('Ghosts');
insert into tags (tagDescription) values ('Gothic');
insert into tags (tagDescription) values ('Psychological');
/* conditions Table */
insert into conditions (conditionType) values ('Very Damaged');
insert into conditions (conditionType) values ('Damaged');
insert into conditions (conditionType) values ('Very Poor');
insert into conditions (conditionType) values ('Poor');
insert into conditions (conditionType) values ('Fair');
insert into conditions (conditionType) values ('Good');
insert into conditions (conditionType) values ('Very Good');
insert into conditions (conditionType) values ('Excellent');
insert into conditions (conditionType) values ('Near-Perfect');
insert into conditions (conditionType) values ('Perfect');
/* customerTypes Table */
insert into customerTypes (customerTypeName) values ('Collector');
insert into customerTypes (customerTypeName) values ('Buyer');
/* employeePositions Table */
insert into employeePositions (positionName) values ('Manager');
insert into employeePositions (positionName) values ('A. Manager');
insert into employeePositions (positionName) values ('CSR');