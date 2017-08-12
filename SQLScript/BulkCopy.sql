Alter PROCEDURE Emp_Import
@PathFileName varchar(100) = 'c:\Emp.txt',
@OrderID integer = 1,
@FileType tinyint = 2
AS

--Step 1: Build Valid BULK INSERT Statement
DECLARE @SQL varchar(2000)
IF @FileType = 1
 BEGIN
  -- Valid format: "John","Smith","john@smith.com"
  SET @SQL = "BULK INSERT dbo.tbl_tempEmp FROM '"+@PathFileName+"' WITH (FIELDTERMINATOR = '"",""') "
 END
ELSE
 BEGIN
  -- Valid format: John,Smith,john@smith.com
  SET @SQL = "BULK INSERT dbo.tbl_tempEmp FROM '"+@PathFileName+"' WITH (FIELDTERMINATOR = ',') "
 END

--Step 2: Execute BULK INSERT statement
EXEC (@SQL)

--Step 3: INSERT data into final table
INSERT dbo.tbl_Emp  (EName,DOB,DeptID,CityID,Salary)
	SELECT EName,DOB,DeptID,CityID,Salary
FROM dbo.tbl_tempEmp 

--Step 4: Empty temporary table
TRUNCATE TABLE dbo.tbl_tempEmp 
go



---------------------------------------------------------------------------------------------------------



Select * from Information_Schema.tables


bcp "dbo.tbl_emp" -N -S 127.0.0.1 -U sa -P  -h "TABLOCKX"

BULK INSERT dbo.tbl_tempEmp  FROM 'c:\Emp.txt' WITH (FIELDTERMINATOR = ',')
Create table dbo.tbl_tempEmp Select * from dbo.tbl_Emp where eid=deptid

Select * from dbo.tbl_tempEmp 
Select * from dbo.tbl_emp


exec Emp_Import
Select* from 