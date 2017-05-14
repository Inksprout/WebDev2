USE [Cineplex];
GO

declare @guardians2 int;
insert into Movie (Title, ShortDescription, LongDescription, ImageUrl, Price)
values ('Guardians of the Galaxy Vol. 2', 'Set to the backdrop of Awesome Mixtape #2, ''Guardians of the Galaxy Vol. 2'' continues the team''s adventures as they unravel the mystery of Peter Quill''s true parentage. ', 'Marvel''s Guardians of the Galaxy Vol. 2 continues the team''s adventures as they traverse the outer reaches of the cosmos. The Guardians must fight to keep their newfound family together as they unravel the mysteries of Peter Quill''s true parentage. Old foes become new allies and fan-favorite characters from the classic comics will come to our heroes'' aid as the Marvel cinematic universe continues to expand.', 'Images/guardians2.jpg', 45.00);
set @guardians2 = SCOPE_IDENTITY();

declare @beautyAndBeast int;
insert into Movie (Title, ShortDescription, LongDescription, ImageUrl, Price)
values ('Beauty and the Beast', 'An adaptation of the fairy tale about a monstrous-looking prince and a young woman who fall in love.', 'Disney''s animated classic takes on a new form, with a widened mythology and an all-star cast. A young prince, imprisoned in the form of a beast, can be freed only by true love. What may be his only opportunity arrives when he meets Belle, the only human girl to ever visit the castle since it was enchanted.', 'Images/beauty.jpg', 45.00);
set @beautyAndBeast = SCOPE_IDENTITY();

declare @furyRoad int;
insert into Movie (Title, ShortDescription, LongDescription, ImageUrl, Price)
values ('Mad Max: Fury Road', 'A woman rebels against a tyrannical ruler in postapocalyptic Australia in search for her home-land with the help of a group of female prisoners, a psychotic worshipper, and a drifter named Max.', 'An apocalyptic story set in the furthest reaches of our planet, in a stark desert landscape where humanity is broken, and almost everyone is crazed fighting for the necessities of life. Within this world exist two rebels on the run who just might be able to restore order. There''s Max, a man of action and a man of few words, who seeks peace of mind following the loss of his wife and child in the aftermath of the chaos. And Furiosa, a woman of action and a woman who believes her path to survival may be achieved if she can make it across the desert back to her childhood homeland.', 'Images/furyRoad.jpg', 45.00);
set @furyRoad = SCOPE_IDENTITY();

declare @zootopia int;
insert into Movie (Title, ShortDescription, LongDescription, ImageUrl, Price)
values ('Zootopia', 'In a city of anthropomorphic animals, a rookie bunny cop and a cynical con artist fox must work together to uncover a conspiracy.', 'From the largest elephant to the smallest shrew, the city of Zootopia is a mammal metropolis where various animals live and thrive. When Judy Hopps becomes the first rabbit to join the police force, she quickly learns how tough it is to enforce the law. Determined to prove herself, Judy jumps at the opportunity to solve a mysterious case. Unfortunately, that means working with Nick Wilde, a wily fox who makes her job even harder.', 'Images/zootopia.jpg', 45.00);
set @zootopia = SCOPE_IDENTITY();

declare @arrival int;
insert into Movie (Title, ShortDescription, LongDescription, ImageUrl, Price)
values ('Arrival', 'When twelve mysterious spacecraft appear around the world, linguistics professor Louise Banks is tasked with interpreting the language of the apparent alien visitors.', 'When mysterious spacecraft touch down across the globe, an elite team - led by expert linguist Louise Banks - is brought together to investigate. As mankind teeters on the verge of global war, Banks and the team race against time for answers - and to find them, she will take a chance that could threaten her life, and quite possibly humanity.', 'Images/arrival.jpg', 45.00);
set @arrival = SCOPE_IDENTITY();

insert into CineplexMovie (CineplexID, MovieID) 
values (1, @guardians2);
insert into CineplexMovie (CineplexID, MovieID) 
values (1, @beautyAndBeast);
insert into CineplexMovie (CineplexID, MovieID) 
values (1, @furyRoad);
insert into CineplexMovie (CineplexID, MovieID) 
values (1, @zootopia);
insert into CineplexMovie (CineplexID, MovieID) 
values (1, @arrival);

insert into CineplexMovie (CineplexID, MovieID) 
values (2, @guardians2);
insert into CineplexMovie (CineplexID, MovieID) 
values (2, @beautyAndBeast);
insert into CineplexMovie (CineplexID, MovieID) 
values (2, @furyRoad);
insert into CineplexMovie (CineplexID, MovieID) 
values (2, @zootopia);
insert into CineplexMovie (CineplexID, MovieID) 
values (2, @arrival);

insert into CineplexMovie (CineplexID, MovieID) 
values (3, @guardians2);
insert into CineplexMovie (CineplexID, MovieID) 
values (3, @beautyAndBeast);
insert into CineplexMovie (CineplexID, MovieID) 
values (3, @furyRoad);
insert into CineplexMovie (CineplexID, MovieID) 
values (3, @zootopia);
insert into CineplexMovie (CineplexID, MovieID) 
values (3, @arrival);

insert into CineplexMovie (CineplexID, MovieID) 
values (4, @guardians2);
insert into CineplexMovie (CineplexID, MovieID) 
values (4, @beautyAndBeast);
insert into CineplexMovie (CineplexID, MovieID) 
values (4, @furyRoad);
insert into CineplexMovie (CineplexID, MovieID) 
values (4, @zootopia);
insert into CineplexMovie (CineplexID, MovieID) 
values (4, @arrival);

insert into CineplexMovie (CineplexID, MovieID) 
values (5, @guardians2);
insert into CineplexMovie (CineplexID, MovieID) 
values (5, @beautyAndBeast);
insert into CineplexMovie (CineplexID, MovieID) 
values (5, @furyRoad);
insert into CineplexMovie (CineplexID, MovieID) 
values (5, @zootopia);
insert into CineplexMovie (CineplexID, MovieID) 
values (5, @arrival);





insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (1, @guardians2, '2017-06-10 12:30:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (1, @beautyAndBeast, '2017-06-10 14:30:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (1, @furyRoad, '2017-06-10 9:30:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (1, @zootopia, '2017-06-10 22:00:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (1, @arrival, '2017-06-10 16:00:00');


insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (2, @guardians2, '2017-06-10 12:00:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (2, @beautyAndBeast, '2017-06-10 14:00:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (2, @furyRoad, '2017-06-10 21:30:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (2, @zootopia, '2017-06-10 10:00:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (2, @arrival, '2017-06-10 19:00:00');

insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (3, @guardians2, '2017-06-10 9:00:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (3, @beautyAndBeast, '2017-06-10 11:00:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (3, @furyRoad, '2017-06-10 13:30:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (3, @zootopia, '2017-06-10 15:00:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (3, @arrival, '2017-06-10 17:00:00');


insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (4, @guardians2, '2017-06-10 10:30:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (4, @beautyAndBeast, '2017-06-10 12:30:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (4, @furyRoad, '2017-06-10 14:30:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (4, @zootopia, '2017-06-10 16:30:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (4, @arrival, '2017-06-10 18:30:00');


insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (4, @guardians2, '2017-06-10 8:30:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (4, @beautyAndBeast, '2017-06-10 10:30:00');
insert into MovieSession (CineplexID, MovieID, SessionTime) 
values (4, @furyRoad, '2017-06-10 14:00:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (4, @zootopia, '2017-06-10 16:00:00');
insert into MovieSession(CineplexID, MovieID, SessionTime) 
values (4, @arrival, '2017-06-10 18:45:00');


