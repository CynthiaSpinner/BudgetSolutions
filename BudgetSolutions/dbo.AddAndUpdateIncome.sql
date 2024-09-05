CREATE PROCEDURE dbo.AddAndUpdateIncome ( 

	
	@category_type VARCHAR(MAX), 
	@category_name VARCHAR(MAX), 
	@category_datepicker DATE, 
	@category_amount DECIMAL

	)

AS
BEGIN

	DECLARE @name1 VARCHAR
	

	SELECT @name1 = income.name FROM income WHERE @category_name = name

	IF (@name1 IS NULL) 
	INSERT INTO income ( income.type, income.name, income.date, income.amount)
           VALUES (@category_type, @category_name, @category_datepicker, @category_amount)



	ELSE
	UPDATE income SET type = @category_type, date = @category_datepicker, amount = @category_amount WHERE income.name = @category_name

END