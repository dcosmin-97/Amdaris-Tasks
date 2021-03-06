CREATE TABLE Users(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL CHECK (Email LIKE '%@%'),
	City NVARCHAR(50) NOT NULL,
	Country NVARCHAR(50) NOT NULL,
);

CREATE TABLE Cats(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(ID),
	PetName NVARCHAR(50) NOT NULL,
	Gender NVARCHAR(50) NOT NULL CHECK (Gender IN ('Male', 'Female')),
	Breed NVARCHAR(50) NOT NULL CHECK (Breed IN ('British', 'ScottishFold', 'Sphynx')),
	BirthDate DATE NOT NULL,
);

CREATE TABLE Cats_Photos(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	CatId INT NOT NULL FOREIGN KEY REFERENCES Cats(ID),
	Url NVARCHAR(50) NOT NULL,
);


CREATE TABLE Dogs(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(ID),
	PetName NVARCHAR(50) NOT NULL,
	Gender NVARCHAR(50) NOT NULL CHECK (Gender IN ('Male', 'Female')),
	Breed NVARCHAR(50) NOT NULL CHECK (Breed IN ('Bulldog', 'Husky', 'Bichon')),
	BirthDate DATE NOT NULL,
);

CREATE TABLE Dogs_Photos(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	DogId INT NOT NULL FOREIGN KEY REFERENCES Dogs(ID),
	Url NVARCHAR(50) NOT NULL,
);

