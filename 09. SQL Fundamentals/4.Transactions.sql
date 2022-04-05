BEGIN TRY
	BEGIN TRANSACTION
		UPDATE Users 
		SET City = 'Sinaia'
		WHERE ID = 1

		UPDATE Cats 
		SET Gender = 'Male'
		Where ID = 1

		-- it will fail because (Breed IN ('Bulldog', 'Husky', 'Bichon')),
		UPDATE Dogs
		SET Breed = 'Pomeranian'
		Where ID = 1

		-- it will fail because email must contain @ 
		/*UPDATE Users
		SET Email = 'test.com'
		WHERE ID = 1*/

		DELETE FROM Users
		WHERE ID = 1

		DELETE FROM Cats
		Where Breed LIKE 'British'
		AND Gender LIKE 'Male'

	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH