CREATE PROCEDURE dbo.AddAndUpdateExpense ( @id int, @type VARCHAR, @name VARCHAR, @date DATE, @amount DECIMAL, @grace VARCHAR, @lateFee DECIMAL, @passed VARCHAR, @passedAmount DECIMAL, @creditIssue VARCHAR)

AS
BEGIN

	DECLARE @id1 int;

	SELECT ID INTO id1 FROM expenses WHERE @id = expenses.id

	IF (id1 IS NULL) 
	INSERT INTO expenses (@type, @name, @date, @amount, @grace, @lateFee, @passed, @passedAmount, @creditIssue)
           VALUES (category_type2, category_name, category_datepicker, category_amount, category_grace, category_latefee, category_passeddue, category_howmuch, category_30late);



	ELSE
	UPDATE expense.expenses SET @ID = id, @type = category_type2, @name = category_name, @date=category_datepicker, @amount=category_amount, @grace=category_grace, @lateFee=category_latefee, @passed=category_passeddue, @passedAmount=category_howmuch, @creditIssue=category_30late WHERE expenses.id = id;

END;

