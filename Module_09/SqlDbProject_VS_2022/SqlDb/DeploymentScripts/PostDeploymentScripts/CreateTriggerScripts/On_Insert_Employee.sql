CREATE TRIGGER [dbo].[t_employee_table]
	ON [dbo].[employee]
	AFTER INSERT
	AS
	BEGIN
		SET NOCOUNT ON;

		IF NOT EXISTS(SELECT *
					  FROM dbo.[company]
					  JOIN inserted ON [company].address_id = inserted.address_id)
			BEGIN

					DECLARE @company_name VARCHAR(50) = (SELECT company_name FROM inserted)
					DECLARE @address_id INT = (SELECT address_id FROM inserted)

					INSERT INTO dbo.[company] (name, address_id)
					VALUES (@company_name, @address_id) 
			END
END

