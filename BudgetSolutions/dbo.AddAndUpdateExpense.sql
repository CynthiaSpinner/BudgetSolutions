ALTER PROCEDURE dbo.AddAndUpdateExpense ( 

	@category_category VARCHAR(MAX),
	@category_type2 VARCHAR(MAX), 
	@category_name VARCHAR(MAX), 
	@category_datepicker DATE, 
	@category_amount DECIMAL, 
	@category_grace VARCHAR(MAX), 
	@category_latefee DECIMAL, 
	@category_passeddue VARCHAR(MAX), 
	@category_howmuch DECIMAL, 
	@category_30late VARCHAR(MAX)
	
	)

AS
BEGIN

	DECLARE @name1 VARCHAR
	

	SELECT @name1 = expenses.name FROM expenses WHERE @category_name = name

	IF (@name1 IS NULL) 
	INSERT INTO expenses (expenses.category, expenses.type, expenses.name, expenses.date, expenses.amount, expenses.grace, expenses.lateFee, expenses.passed, expenses.passedAmount, expenses.creditIssue)
           VALUES (@category_category, @category_type2, @category_name, @category_datepicker, @category_amount, @category_grace, @category_latefee, @category_passeddue, @category_howmuch, @category_30late)



	ELSE
	UPDATE expenses SET category = @category_category, type = @category_type2, date = @category_datepicker, amount = @category_amount, grace = @category_grace, lateFee = @category_latefee, passed = @category_passeddue, passedAmount = @category_howmuch, creditIssue = @category_30late WHERE expenses.name = @category_name

END

