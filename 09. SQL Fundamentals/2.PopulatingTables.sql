INSERT INTO Users (FirstName, LastName, Email, City, Country)
VALUES
('Andrei', 'Dan', 'andreidan@gmail.com', 'Timisoara', 'Romania'),
('Alina', 'Marinescu', 'adinamarinescu@yahoo.com', 'Timisoara', 'Romania'),
('Miruna', 'Andrei', 'mirunaandrei@yahoo.com', 'Targoviste', 'Romania'),
('Cosmin', 'Diaconescu', 'c.diaconescu@gmail.com', 'Targoviste', 'Romania'),
('Radu', 'Voicu', 'r.voicu@gmail.com', 'Bucuresti', 'Romania'),
('Vlad', 'Enache', 'vladutenache@gmail.com', 'Pucioasa', 'Romania'),
('Irina', 'Login', 'irinalogin@gmail.com', 'Cluj', 'Romania'),
('Mirel', 'Lorin', 'mirel.l@yahoo.com', 'Cluj', 'Romania'),
('Tudor', 'Iordanescu', 't.iordanescu97@gmail.com', 'Targoviste', 'Romania'),
('Alex', 'Sma', 'alex.sma@yahoo.com', 'Cluj', 'Romania')

INSERT INTO Cats(UserId, PetName, Gender, Breed, BirthDate)
VALUES
(1, 'Amun', 'Female', 'Sphynx', '2020-11-11'),
(1, 'Luna', 'Female', 'British', '2021-10-20'),
(2, 'Milo', 'Male', 'ScottishFold', '2018-01-14'),
(3, 'Oliver', 'Male', 'British', '2019-03-11'),
(5, 'Leo', 'Male', 'ScottishFold', '2020-04-05'),
(6, 'Loki', 'Male', 'British', '2022-01-01'),
(7, 'Bella', 'Female', 'ScottishFold', '2020-10-14'),
(7, 'Charlie', 'Male', 'British', '2021-11-11'),
(1, 'Willow', 'Female', 'Sphynx', '2020-05-16'),
(4, 'Ozzy', 'Male', 'British', '2021-12-12'),
(4, 'Lucy', 'Female', 'British', '2020-10-13'),
(9, 'Kitty', 'Female', 'ScottishFold', '2019-06-24'),
(9, 'Nala', 'Female', 'Sphynx', '2020-07-13')


INSERT INTO Cats_Photos(CatId, Url)
VALUES
(1, 'https://url1'),
(1, 'https://url2'),
(1, 'https://url3'),
(2, 'https://url4'),
(2, 'https://url5'),
(2, 'https://url6'),
(3, 'https://url7'),
(1, 'https://url8'),
(3, 'https://url9'),
(4, 'https://url10'),
(5, 'https://url11'),
(6, 'https://url12'),
(7, 'https://url13'),
(1, 'https://url14'),
(2, 'https://url15'),
(3, 'https://url16'),
(4, 'https://url17'),
(5, 'https://url18'),
(6, 'https://url19'),
(6, 'https://url20'),
(1, 'https://url21'),
(9, 'https://url22'),
(2, 'https://url23'),
(3, 'https://url24')

INSERT INTO Dogs(UserId, PetName, Gender, Breed, BirthDate)
VALUES
(3, 'Max', 'Male', 'Bulldog', '2020-11-11'),
(2, 'Milo', 'Female', 'Husky', '2021-10-20'),
(1, 'Charlie', 'Male', 'Bichon', '2018-01-14'),
(9, 'Rex', 'Male', 'Bulldog', '2019-03-11'),
(1, 'Cash', 'Male', 'Bichon', '2020-04-05'),
(3, 'Loki', 'Male', 'Bulldog', '2022-01-01'),
(4, 'Rudy', 'Female', 'Husky', '2020-10-14'),
(5, 'Charlie', 'Male', 'Bulldog', '2021-11-11'),
(1, 'Jenny', 'Female', 'Bichon', '2020-05-16'),
(6, 'Chip', 'Male', 'Bulldog', '2021-12-12'),
(6, 'Lucy', 'Female', 'Husky', '2020-10-13'),
(8, 'Joey', 'Female', 'Bichon', '2019-06-24'),
(7, 'Lena', 'Female', 'Bulldog', '2020-07-13')

INSERT INTO Dogs_Photos(DogId, Url)
VALUES
(2, 'https://url1'),
(3, 'https://url2'),
(4, 'https://url3'),
(1, 'https://url4'),
(5, 'https://url5'),
(6, 'https://url6'),
(8, 'https://url7'),
(9, 'https://url8'),
(1, 'https://url9'),
(2, 'https://url10'),
(3, 'https://url11'),
(4, 'https://url12'),
(5, 'https://url13'),
(6, 'https://url14'),
(7, 'https://url15'),
(3, 'https://url16'),
(4, 'https://url17'),
(5, 'https://url18'),
(6, 'https://url19'),
(6, 'https://url20'),
(1, 'https://url21'),
(9, 'https://url22'),
(2, 'https://url23'),
(3, 'https://url24')