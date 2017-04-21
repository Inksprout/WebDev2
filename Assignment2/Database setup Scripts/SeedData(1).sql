USE [Cineplex];
GO

declare @stKilda int;
insert into Cineplex (Location, ShortDescription, LongDescription, ImageUrl) 
values ('St Kilda', 'Short description...', 'Long description...', '~/Images/StKilda.png');
set @stKilda = SCOPE_IDENTITY();

declare @fitzroy int;
insert into Cineplex (Location, ShortDescription, LongDescription, ImageUrl) 
values ('Fitzroy', 'Short description...', 'Long description...', '~/Images/Fitzroy.png');
set @fitzroy = SCOPE_IDENTITY();

declare @melbourneCBD int;
insert into Cineplex (Location, ShortDescription, LongDescription, ImageUrl) 
values ('Melbourne CBD', 'Short description...', 'Long description...', '~/Images/MelbourneCBD.png');
set @melbourneCBD = SCOPE_IDENTITY();

declare @sunshine int;
insert into Cineplex (Location, ShortDescription, LongDescription, ImageUrl) 
values ('Sunshine', 'Short description...', 'Long description...', '~/Images/Sunshine.png');
set @sunshine = SCOPE_IDENTITY();

declare @lilydale int;
insert into Cineplex (Location, ShortDescription, LongDescription, ImageUrl) 
values ('Lilydale', 'Short description...', 'Long description...', '~/Images/Lilydale.png');
set @lilydale = SCOPE_IDENTITY();

insert into MovieComingSoon (Title, ShortDescription, LongDescription, ImageUrl)
values ('ASP.NET MVC 101', 'Short description...', 'Long description...', '~/Images/MovieComingSoon.png');

insert into MovieComingSoon (Title, ShortDescription, LongDescription, ImageUrl)
values ('WebForms Legacy', 'Short description...', 'Long description...', '~/Images/MovieComingSoon.png');

declare @theMatrix int;
insert into Movie (Title, ShortDescription, LongDescription, ImageUrl, Price)
values ('The Matrix', 'Short description...', 'Long description...', '~/Images/TheMatrix.png', 10.00);
set @theMatrix = SCOPE_IDENTITY();

declare @theMatrixReloaded int;
insert into Movie (Title, ShortDescription, LongDescription, ImageUrl, Price)
values ('The Matrix Reloaded', 'Short description...', 'Long description...', '~/Images/TheMatrixReloaded.png', 15.00);
set @theMatrixReloaded = SCOPE_IDENTITY();

declare @theMatrixRevolution int;
insert into Movie (Title, ShortDescription, LongDescription, ImageUrl, Price)
values ('The Matrix Revolution', 'Short description...', 'Long description...', '~/Images/TheMatrixRevolution.png', 20.00);
set @theMatrixRevolution = SCOPE_IDENTITY();

insert into CineplexMovie (CineplexID, MovieID) 
values (@stKilda, @theMatrix);

insert into CineplexMovie (CineplexID, MovieID) 
values (@stKilda, @theMatrixReloaded);

insert into CineplexMovie (CineplexID, MovieID) 
values (@stKilda, @theMatrixRevolution);

insert into CineplexMovie (CineplexID, MovieID) 
values (@fitzroy, @theMatrix);

insert into CineplexMovie (CineplexID, MovieID) 
values (@fitzroy, @theMatrixReloaded);

insert into CineplexMovie (CineplexID, MovieID) 
values (@melbourneCBD, @theMatrixRevolution);
