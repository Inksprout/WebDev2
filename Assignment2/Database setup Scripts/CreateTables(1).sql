CREATE DATABASE [Cineplex];
GO

USE [Cineplex];
GO

create table Cineplex
(
	CineplexID int not null identity primary key,
	Location nvarchar(max) not null,
	ShortDescription nvarchar(max) not null,
	LongDescription nvarchar(max) not null,
	ImageUrl nvarchar(max) null
);

create table Enquiry
(
	EnquiryID int not null identity primary key,
	Email nvarchar(max) not null,
	Message nvarchar(max) not null
);

create table MovieComingSoon
(
	MovieComingSoonID int not null identity primary key,
	Title nvarchar(max) not null,
	ShortDescription nvarchar(max) not null,
	LongDescription nvarchar(max) not null,
	ImageUrl nvarchar(max) null
);

create table Movie
(
	MovieID int not null identity primary key,
	Title nvarchar(max) not null,
	ShortDescription nvarchar(max) not null,
	LongDescription nvarchar(max) not null,
	ImageUrl nvarchar(max) null,
	Price money not null
);

create table CineplexMovie
(
	CineplexID int not null foreign key references Cineplex (CineplexID),
	MovieID int not null foreign key references Movie (MovieID),
	primary key (CineplexID, MovieID)
);

USE [Cineplex];
GO

create table RegisteredUser
(
	UserId int not null identity primary key,
	Name nvarchar(max) not null,
	Email nvarchar(max) not null,
	Password nvarchar(50) not null
);