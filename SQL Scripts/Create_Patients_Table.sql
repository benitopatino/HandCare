BEGIN TRANSACTION;

BEGIN TRY
    -- Check if the table already exists and drop it if necessary
    IF OBJECT_ID('dbo.Patients', 'U') IS NULL
	BEGIN

		-- Create the table
		CREATE TABLE dbo.Patients (
			PatientId UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
			FirstName VARCHAR(50),
			LastName VARCHAR(50),
			DateOfBirth DATE
		);
	END
    -- Commit the transaction if all steps succeed
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    -- Rollback the transaction if there is an error
    ROLLBACK TRANSACTION;
    
    -- Optionally, handle or log the error
    PRINT ERROR_MESSAGE();
END CATCH;
