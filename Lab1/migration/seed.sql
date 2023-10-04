CREATE TABLE `AspNetRoles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(256) NULL,
    `NormalizedName` varchar(256) NULL,
    `ConcurrencyStamp` longtext NULL,
    PRIMARY KEY (`Id`)
);
CREATE TABLE `AspNetUsers` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FirstName` varchar(50) NOT NULL,
    `Surname` varchar(50) NOT NULL,
    `UserName` varchar(256) NULL,
    `NormalizedUserName` varchar(256) NULL,
    `Email` varchar(256) NULL,
    `NormalizedEmail` varchar(256) NULL,
    `EmailConfirmed` tinyint(1) NOT NULL,
    `PasswordHash` longtext NULL,
    `SecurityStamp` longtext NULL,
    `ConcurrencyStamp` longtext NULL,
    `PhoneNumber` longtext NULL,
    `PhoneNumberConfirmed` tinyint(1) NOT NULL,
    `TwoFactorEnabled` tinyint(1) NOT NULL,
    `LockoutEnd` datetime(6) NULL,
    `LockoutEnabled` tinyint(1) NOT NULL,
    `AccessFailedCount` int NOT NULL,
    PRIMARY KEY (`Id`)
);
CREATE TABLE `Projects` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(50) NOT NULL,
    `Description` varchar(500) NOT NULL,
    PRIMARY KEY (`Id`)
);
CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` int NOT NULL,
    `ClaimType` longtext NULL,
    `ClaimValue` longtext NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);
CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` int NOT NULL,
    `ClaimType` longtext NULL,
    `ClaimValue` longtext NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);
CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(255) NOT NULL,
    `ProviderKey` varchar(255) NOT NULL,
    `ProviderDisplayName` longtext NULL,
    `UserId` int NOT NULL,
    PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);
CREATE TABLE `AspNetUserRoles` (
    `UserId` int NOT NULL,
    `RoleId` int NOT NULL,
    PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);
CREATE TABLE `AspNetUserTokens` (
    `UserId` int NOT NULL,
    `LoginProvider` varchar(255) NOT NULL,
    `Name` varchar(255) NOT NULL,
    `Value` longtext NULL,
    PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);
CREATE TABLE `Tasks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(50) NOT NULL,
    `Description` varchar(500) NOT NULL,
    `CreationDate` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `LastUpdate` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `Deadline` datetime(6) NOT NULL,
    `TaskStatus` int NOT NULL,
    `TaskPriority` int NOT NULL,
    `ProjectId` int NOT NULL,
    `UserId` int NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Tasks_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE SET NULL,
    CONSTRAINT `FK_Tasks_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE
);
CREATE TABLE `UsersProjects` (
    `ProjectId` int NOT NULL,
    `UserId` int NOT NULL,
    PRIMARY KEY (`ProjectId`, `UserId`),
    CONSTRAINT `FK_UsersProjects_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_UsersProjects_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE
);

INSERT INTO `AspNetRoles` (`Id`, `ConcurrencyStamp`, `Name`, `NormalizedName`)
VALUES (1, NULL, 'Admin', 'ADMIN');
INSERT INTO `AspNetRoles` (`Id`, `ConcurrencyStamp`, `Name`, `NormalizedName`)
VALUES (2, NULL, 'Manager', 'MANAGER');
INSERT INTO `AspNetRoles` (`Id`, `ConcurrencyStamp`, `Name`, `NormalizedName`)
VALUES (3, NULL, 'User', 'USER');

INSERT INTO `AspNetUsers` (`Id`, `AccessFailedCount`, `ConcurrencyStamp`, `Email`, `EmailConfirmed`, `FirstName`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `SecurityStamp`, `Surname`, `TwoFactorEnabled`, `UserName`)
VALUES (1, 0, '347cf869-ba64-4c3e-8ecf-ed3ed37f77c3', 'admin@gmail.com', TRUE, 'Adminname', FALSE, NULL, 'ADMIN@GMAIL.COM', 'ADMIN', 'AQAAAAIAAYagAAAAEMVVFhrMEM4V+UX09kHybmYqHMR7weo1bNW99DsZShy4C9MrKN4tp54VcdZ66Wf4MA==', NULL, FALSE, 'f0fb7b62-e1d1-4c11-a95e-4d378cd439ad', 'Adminsurname', FALSE, 'admin');
INSERT INTO `AspNetUsers` (`Id`, `AccessFailedCount`, `ConcurrencyStamp`, `Email`, `EmailConfirmed`, `FirstName`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `SecurityStamp`, `Surname`, `TwoFactorEnabled`, `UserName`)
VALUES (2, 0, '343df79f-f01c-456e-b905-dbfe965c1e49', 'manager@gmail.com', TRUE, 'Managername', FALSE, NULL, 'MANAGER@GMAIL.COM', 'MANAGER', 'AQAAAAIAAYagAAAAENC9on9F8RH4I71IZK+/x7gfvSG5XTQFVyUBGkfFmvxmcIA+GCLF6Ria0CCiviKSpQ==', NULL, FALSE, '6608d38c-fd88-414c-ad4f-0b1b6d9e01d5', 'Managersurname', FALSE, 'manager');
INSERT INTO `AspNetUsers` (`Id`, `AccessFailedCount`, `ConcurrencyStamp`, `Email`, `EmailConfirmed`, `FirstName`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `SecurityStamp`, `Surname`, `TwoFactorEnabled`, `UserName`)
VALUES (3, 0, 'ad477648-47e7-421a-a513-6291ffdbdf33', 'user@gmail.com', TRUE, 'Username', FALSE, NULL, 'USER@GMAIL.COM', 'USER', 'AQAAAAIAAYagAAAAEGWRqtjM+laDYlkW2K4mkCuwm9EbRktcNPHeVRTj7hO2mfvZ1kO6eaWzTmaBkYdfeQ==', NULL, FALSE, '45a47563-64c0-4852-9ce7-7b3592033f0c', 'Usersurname', FALSE, 'user');
INSERT INTO `AspNetUsers` (`Id`, `AccessFailedCount`, `ConcurrencyStamp`, `Email`, `EmailConfirmed`, `FirstName`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `SecurityStamp`, `Surname`, `TwoFactorEnabled`, `UserName`)
VALUES (4, 0, '05a3df56-dc28-4cf9-b68a-57087d56d0ea', 'user2@gmail.com', TRUE, 'Username2', FALSE, NULL, 'USER2@GMAIL.COM', 'USER2', 'AQAAAAIAAYagAAAAEFgdP8ChJpNJ1VB36l0dq76v/0FJCM7cS81dFHl1uW4Hu3cZgULTMnR04hDF+wSjsw==', NULL, FALSE, '0a573bbe-afe3-4a5f-833d-1325782d38bd', 'Usersurname2', FALSE, 'user2');

INSERT INTO `Projects` (`Id`, `Description`, `Name`)
VALUES (1, 'Web project 1 description', 'Web project 1');
INSERT INTO `Projects` (`Id`, `Description`, `Name`)
VALUES (2, 'Web project 2 description', 'Web project 2');
INSERT INTO `Projects` (`Id`, `Description`, `Name`)
VALUES (3, 'Web project 3 description', 'Web project 3');

INSERT INTO `AspNetUserRoles` (`RoleId`, `UserId`)
VALUES (1, 1);
INSERT INTO `AspNetUserRoles` (`RoleId`, `UserId`)
VALUES (2, 2);
INSERT INTO `AspNetUserRoles` (`RoleId`, `UserId`)
VALUES (3, 3);
INSERT INTO `AspNetUserRoles` (`RoleId`, `UserId`)
VALUES (3, 4);

INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (1, '2023-09-05 16:36:11.158635', 'Task1 description', 'Task1', 1, 2, 1, 3);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (2, '2023-09-06 16:36:11.158642', 'Task2 description', 'Task2', 1, 1, 2, 3);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (3, '2023-09-03 16:36:11.158642', 'Task3 description', 'Task3', 1, 3, 3, 3);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (4, '2023-09-08 16:36:11.158643', 'Task4 description', 'Task4', 1, 2, 2, 3);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (5, '2023-09-04 16:36:11.158643', 'Task5 description', 'Task5', 1, 1, 1, 4);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (6, '2023-09-06 16:36:11.158650', 'Task6 description', 'Task6', 1, 3, 3, 4);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (7, '2023-09-05 16:36:11.158650', 'Task7 description', 'Task7', 1, 2, 1, 3);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (8, '2023-09-07 16:36:11.158651', 'Task8 description', 'Task8', 1, 4, 1, 4);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (9, '2023-09-03 16:36:11.158651', 'Task9 description', 'Task9', 1, 4, 2, 4);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (10, '2023-09-05 16:36:11.158651', 'Task10 description', 'Task10', 1, 1, 4, 3);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (11, '2023-09-08 16:36:11.158652', 'Task11 description', 'Task11', 1, 2, 5, 4);
INSERT INTO `Tasks` (`Id`, `Deadline`, `Description`, `Name`, `ProjectId`, `TaskPriority`, `TaskStatus`, `UserId`)
VALUES (12, '2023-09-06 16:36:11.158652', 'Task12 description', 'Task12', 1, 3, 2, 3);

INSERT INTO `UsersProjects` (`ProjectId`, `UserId`)
VALUES (1, 1);
INSERT INTO `UsersProjects` (`ProjectId`, `UserId`)
VALUES (1, 2);
INSERT INTO `UsersProjects` (`ProjectId`, `UserId`)
VALUES (1, 3);
INSERT INTO `UsersProjects` (`ProjectId`, `UserId`)
VALUES (2, 1);
INSERT INTO `UsersProjects` (`ProjectId`, `UserId`)
VALUES (2, 2);
INSERT INTO `UsersProjects` (`ProjectId`, `UserId`)
VALUES (2, 3);
INSERT INTO `UsersProjects` (`ProjectId`, `UserId`)
VALUES (3, 1);
INSERT INTO `UsersProjects` (`ProjectId`, `UserId`)
VALUES (3, 2);
INSERT INTO `UsersProjects` (`ProjectId`, `UserId`)
VALUES (3, 3);


CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

CREATE INDEX `IX_Tasks_ProjectId` ON `Tasks` (`ProjectId`);

CREATE INDEX `IX_Tasks_UserId` ON `Tasks` (`UserId`);

CREATE INDEX `IX_UsersProjects_UserId` ON `UsersProjects` (`UserId`);
