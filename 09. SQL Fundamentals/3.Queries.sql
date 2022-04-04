
--Select FirstName and Last name of users with email on gmail domain, order by FirstName 
Select u.FirstName, u.LastName
FROM Users as u
Where Email LIKE '%gmail%'
ORDER BY FirstName

--Select users whose city is Pucioasa
SELECT u.FirstName as 'Prenume', u.LastName as 'Nume', u.Country
FROM Users as u
Where City LIKE 'Pucioasa'
ORDER BY FirstName

--How many male cats are from each breed 
SELECT COUNT(ID) as 'No.Of Cats', c.Breed
from Cats as c
Where Gender LIKE 'Male'
GROUP BY Breed
ORDER BY COUNT(ID)

--How many dogs per gender desc
SELECT COUNT(ID) as 'No.Of Dogs', d.Gender 
FROM Dogs as d
GROUP BY Gender
ORDER BY COUNT(ID) desc

-- Show dogs with birthdate > '2020-04-01', order by petname
SELECT d.PetName, d.Gender, d.Breed, d.BirthDate, u.FirstName as 'Owner' 
FROM Users as u
INNER JOIN Dogs as d ON d.UserId = u.ID
Where d.BirthDate > '2020-04-01'
Order by d.PetName

-- How many Pictures per cat - also see cats without pictures (LEFT JOIN)
SELECT c.PetName, COUNT(cp.CatId) as 'Pictures per cat'
FROM Cats as c
LEFT JOIN Cats_Photos as cp ON cp.CatId = c.ID
Group by c.PetName

-- How many pictures per dogName whose owner is from Targoviste - at least one picture
Select d.PetName, COUNT(dp.DogId) as 'Pictures per dog'
From Users as u
INNER JOIN Dogs as d on d.UserId = u.ID
INNER JOIN Dogs_Photos as dp on dp.DogId = d.ID
Where u.City LIKE 'Targoviste'
Group by d.PetName

-- How many possible Matches for a Cat ( Match -> Same Country, Different Gender, Same Breed)
-- Gender: Male , Breed: British, Country = Romania, PETNAME = OZZY
SELECT COUNT(*) as 'Number of possible matches for Ozzy'
FROM Users as u
INNER JOIN Cats as c on c.UserId = u.ID
Where u.Country LIKE 'Romania'
AND c.Breed LIKE 'British'
AND c.Gender NOT LIKE 'Male'

-- Show all dog names that have a minimum of one picture that are possible matches for :
-- Male Dog, Country of user = Romania, 
SELECT d.PetName, u.Country, u.City
FROM Users as u
INNER JOIN Dogs as d on d.UserId = u.ID
INNER JOIN Dogs_Photos as dp on dp.DogId = d.ID
Where u.Country LIKE 'Romania'
AND d.Gender NOT LIKE 'Female'

-- Show no.Of Cats per user
Select u.FirstName, Count(c.UserId) as 'No of cats per user'
FROM Users as u
LEFT JOIN Cats as c on c.UserId = u.ID
Group by u.FirstName 
ORDER BY u.FirstName

-- Show no. of dogs per user city
Select u.City, Count(d.UserId) as 'No of dogs per city'
FROM Users as u
LEFT JOIN Dogs as d on d.UserId = u.ID
Group by u.City 
ORDER BY u.City