Select * from dbo.tbl_emp
select * from dbo.tbl_emp_Insert
select * from dbo.tbl_emp_Update
select * from dbo.tbl_emp_Delete
delete from dbo.tbl_emp where Eid=25
Insert into dbo.tbl_emp values('Mark Zuckerberg',getDate(),123333333.0)
Update dbo.tbl_emp set EName = 'Zuckerberg Mark' where Eid = 26
--create table dbo.tbl_emp_Insert (Eid int,Ename varchar(100),DOB datetime,Sawlary money,InsertTime DateTime default getdate())
--create table dbo.tbl_emp_Delete (Eid int,Ename varchar(100),DOB datetime,Salary money,DeleteTime DateTime default getdate())
--create table dbo.tbl_emp_Update (Eid int,Ename varchar(100),DOB datetime,Salary money,UpdatedEname varchar(100),UpdatedDOB datetime,UpdatedSalary money,UpdateTime DateTime default getDate())
--
--
--Insert into dbo.tbl_emp values('Inserted',getdate(),123456)

--Trigger
ALTER TRIGGER trgAfterInsUpDel
ON dbo.tbl_emp
FOR INSERT,UPDATE,DELETE

AS

DECLARE @operation_type CHAR(1)

BEGIN

IF EXISTS (SELECT * FROM Inserted)
	IF EXISTS (SELECT * FROM Deleted)
		SELECT @operation_type = 'U'
	ELSE
		SELECT @operation_type = 'I'
ELSE
	SELECT @operation_type = 'D'

IF @operation_type = 'I'
		INSERT dbo.tbl_emp_Insert(Eid,Ename,DOB,Salary)
			SELECT INSERTED.Eid,INSERTED.Ename,INSERTED.DOB,INSERTED.Salary FROM INSERTED

IF @operation_type = 'U'
	BEGIN
		IF UPDATE(EName)
			INSERT dbo.tbl_emp_Update(Eid,UpdatedEName,EName)
				SELECT INSERTED.Eid,INSERTED.Ename,DELETED.Ename FROM INSERTED INNER JOIN DELETED
					ON INSERTED.Eid = DELETED.Eid

		IF UPDATE(DOB)
			INSERT dbo.tbl_emp_Update(Eid,UpdatedDOB,DOB)
				SELECT INSERTED.Eid,INSERTED.DOB,DELETED.DOB FROM INSERTED INNER JOIN DELETED
					ON INSERTED.Eid = DELETED.Eid

		IF UPDATE(Salary)
			INSERT dbo.tbl_emp_Update(Eid,UpdatedSalary,Salary)
				SELECT INSERTED.Eid,INSERTED.Salary,DELETED.Salary FROM	INSERTED INNER JOIN DELETED
					ON INSERTED.Eid = DELETED.Eid
	END

IF @operation_type = 'D'
	INSERT dbo.tbl_emp_Delete(Eid,EName,DOB,Salary)
			SELECT Deleted.Eid,Deleted.EName,Deleted.DOB,Deleted.Salary FROM Deleted
END
