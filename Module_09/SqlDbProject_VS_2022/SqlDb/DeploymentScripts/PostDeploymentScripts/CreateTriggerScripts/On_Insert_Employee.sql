CREATE TRIGGER [t_employee_table]
	ON [dbo].[employee]
	FOR INSERT
	AS
	BEGIN
		SET NOCOUNT ON;
		IF NOT EXISTS(SELECT *
					  FROM dbo.[company]
					  JOIN inserted ON [company].address_id = inserted.address_id)
		BEGIN

			DECLARE @Address_Id INT SET @Address_Id = (SELECT MAX(address_id) + 1 
													   FROM dbo.[address])

			DECLARE @Company_Id INT SET @Company_Id = (SELECT MAX(company_id) + 1 
													   FROM dbo.[company])

			INSERT INTO dbo.[address]
						(address_id,
						street,
						city,
						state,
						zip_code)
			SELECT @Address_Id,
					street,
					city,
					state,
					zip_code
			FROM inserted i
			JOIN dbo.[address] on [address].address_id = i.address_id

			INSERT INTO dbo.[company]
						(company_id,
						name,
						address_id)
			SELECT @Company_Id, 
				   i.company_name, 
				   @Address_Id
			FROM inserted i
		END
END