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
			INSERT INTO dbo.[address]
						(street,
						city,
						state,
						zip_code)
			SELECT street,
					city,
					state,
					zip_code
			FROM inserted i
			JOIN dbo.[address] on [address].address_id = i.address_id

			INSERT INTO dbo.[company]
						(name,
						address_id)
			SELECT i.company_name, 
				   (SELECT MAX(address_id)
					FROM dbo.[address])
			FROM inserted i
		END
END
