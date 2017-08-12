Use master
Go
Drop Database MyDatabase
Go
Create Database MyDatabase
Go
Use MyDatabase
Go

--Table creation
Create Table dbo.Emp
(
	eID int identity(1,1) Primary key,
	eName varchar(50) Not null,
	city varchar(50) default 'not seeded',
	dateOfBirth DateTime default GetDate(),
	salary float default 0.0
)
Go
Select * from dbo.Emp
Go

Alter table dbo.Emp Add managerID int references dbo.Emp(eID)
Go

Select * from dbo.Emp
Go

Alter table dbo.Emp Add SSN int unique
Go

Select * from dbo.Emp
Go

Create table dbo.Dept 
(
	dID int identity primary key,
	dName varchar(50) Unique,
	deptHead int not null references dbo.Emp(eID)
)
Go

exec sp_help 'Emp'
Go

Select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where table_name like '%emp%'
Go

Alter table dbo.Emp drop constraint FK__Emp__managerID__6383C8BA
Go

Alter table dbo.Emp drop column managerID
Go

Select * from dbo.Emp
Select * from dbo.Dept
Go

insert into dbo.Emp values('Hiren','Kalol',13-04-1989,30000.0,123456)
Go
insert into dbo.Emp values('Arpit','Kalol',01-06-1989,31000.0,123457)
Go
insert into dbo.Emp values('urvin','Abad',01-01-1989,32000.0,123458)
Go
insert into dbo.Emp values('Chandrakant','Gnagar',23-04-1989,33000.0,123459)
Go
insert into dbo.Emp values('Bhavin','Abad',13-04-1989,34000.0,123460)
Go
insert into dbo.Emp values('Nirmal','Gnagar',13-04-1989,35000.0,123461)
Go
insert into dbo.Emp values('Jatin','Abad',13-04-1989,36000.0,123462)
Go
insert into dbo.Emp values('Gunjan','Gnagar',13-04-1989,37000.0,123463)
Go
insert into dbo.Emp values('Abc','Surat',13-04-1989,38000.0,123464)
Go
insert into dbo.Emp values('Def','Surat',13-04-1989,39000.0,123465)
Go

Select * from dbo.Emp
Select * from dbo.Dept 
Go

insert into dbo.Dept values('Dept1',2)
Go
insert into dbo.Dept values('Dept2',4)
Go
insert into dbo.Dept values('Dept3',6)
Go
insert into dbo.Dept values('Dept4',7)
Go

Select * from dbo.Dept
Select * from dbo.Emp
Go

Alter table dbo.Emp Add deptID int references dbo.Dept(dID)
Go

Select * from dbo.Emp
Go

Update dbo.Emp Set deptId = (Select dID from dbo.Dept where deptHead = eId)
Go

Select * from dbo.Emp
Select * from dbo.Dept
Go

Update dbo.Emp Set deptID = 1 where eID = 3
Update dbo.Emp Set deptID = 2 where eID = 5
Update dbo.Emp Set deptID = 3 where eID in (8,9)
Update dbo.Emp Set deptID = null where eID in (10,11,12)
Go
	
Select * from dbo.Emp
Select * from dbo.Dept
Go

--Selects
Select * from dbo.Emp
Select * from dbo.Emp where deptID = 1
Select * from dbo.Emp where deptID = 1 order  by eName
Select city,COUNT(1) from dbo.Emp where deptID in (1,2,3) group by city order by city
Select top 50 percent city,COUNT(1) from dbo.Emp where deptID in (1,2,3) group by city order by city
Select top 50 percent city,COUNT(1) from dbo.Emp where deptID in (1,2,3) group by city having Count(1) > 2 order by city
Select top 50 percent city,COUNT(1) as CountOfEmps from dbo.Emp where deptID in (1,2,3) group by city order by city For XML RAW


--Distinct & All
Select distinct(city) from dbo.Emp
Select all(city) from dbo.Emp
Go

--Aggregates
Select AVG(Salary) as AvgSal ,MIN(Salary) as MinSal,MAX(Salary) as MaxSal,COUNT(1) as numOfEmps from dbo.Emp
Go

--Create table from another table
Select * into dbo.Emp_temp from dbo.Emp where eID = -1
Go
Select * from dbo.Emp_temp
Go

--Inserts
Insert into dbo.Emp_temp
	(eName,city,dateOfBirth,salary,SSN,deptID) 
	values	('A','A',GETDATE(),1.0,123,1),
			('A','A',GETDATE(),1.0,124,1),
			('A','A',GETDATE(),1.0,125,1)
Go

Select * from dbo.Emp_Temp
Go

Insert into dbo.Emp_Temp Select eName,city,dateOfBirth,salary,SSN,deptID from dbo.Emp
Go

Select * from dbo.Emp_Temp
Go

--Temporary Table
Begin
Declare @tempTable Table
(
	ColumnA int,
	ColumnB Varchar(25)
);


Insert into @tempTable (ColumnA, ColumnB) Values(1,'ABC')

Select ColumnA, ColumnB from @tempTable
End

--Updates
Select * from dbo.Emp
Select * from dbo.Dept
Go


Update dbo.Emp_temp set city = null
Go

--Update from one table to another
Select * from dbo.Emp_temp
Select * from dbo.Emp
Go

Update dbo.Emp_temp set dbo.Emp_temp.city = dbo.Emp.city from dbo.Emp_temp Inner Join dbo.Emp on dbo.Emp.eID = dbo.Emp_temp.eID
Go

Select * from dbo.Emp_temp 
Go

--Deletes
Delete from dbo.Emp_temp where eID > 10
Go
Delete from dbo.Emp_temp 
Go

--------------------- Joins -------------------------------
Select * from dbo.Emp
Select * from dbo.Dept
Go

Update dbo.emp set deptID = 1 where eID = 1
Update dbo.emp set deptID = 4 where eID = 10
Go
	
Select * from dbo.Emp
Select * from dbo.Dept
Go

--Inner Join - Exclusive in nature
Select Emp.eID, Emp.eName, Dept.dName,Dept.deptHead from dbo.Emp Inner Join dbo.Dept on Emp.deptID = Dept.dID
Go

--Default join is Inner Join when only join keyword is mentioned
Select Emp.eID, Emp.eName, Dept.dName,Dept.deptHead from dbo.Emp Join dbo.Dept on Emp.deptID = Dept.dID
Go

Update dbo.Emp
	set deptID = Null where eID = 10
Go
	
Select Emp.eID, Emp.eName, Dept.dName,Dept.deptHead from dbo.Emp Join dbo.Dept on Emp.deptID = Dept.dID
Go

--Outer Joins - Inclusive in nature
--Left
Select Emp.eID, Emp.eName, Dept.dName,Dept.deptHead from dbo.Emp Left Join dbo.Dept on Emp.deptID = Dept.dID
Go

--Right
Select Emp.eID, Emp.eName, Dept.dName,Dept.deptHead from dbo.Emp Right Join dbo.Dept on Emp.deptID = Dept.dID
Go

--Find orphan records
Select Emp.eID, Emp.eName, Dept.dName,Dept.deptHead from dbo.Emp Left Join dbo.Dept on Emp.deptID = Dept.dID
where Dept.dName is Null
Go

Select * from dbo.Dept 
Go

Insert into dbo.Dept values('Dept5', 1)
Go

--Full Join
Select Emp.eID, Emp.eName, Dept.dName,Dept.deptHead from dbo.Emp Full Join dbo.Dept on Emp.deptID = Dept.dID
Go

--Cross Join
Select Emp.*,Dept.* from dbo.Emp Cross Join dbo.Dept
Go

--Alternative syntax for Joins
--Inner in form of Equi join
Select * from dbo.Emp, dbo.Dept where Emp.deptId = Dept.dID

--Outer Jois
--Left
ALTER DATABASE MyDatabase
SET COMPATIBILITY_LEVEL = 80
Go

--Select * from dbo.Emp, dbo.Dept where Emp.deptId *= Dept.dID

--Right
--Select * from dbo.Emp, dbo.Dept where Emp.deptId =* Dept.dID

ALTER DATABASE MyDatabase
SET COMPATIBILITY_LEVEL = 100
Go

--Cross
Select * from dbo.Emp, dbo.Dept

--Unions
--Union - Gets all distinct values
Select GetDate()
Union 
Select GetDate()
Go

--Union All - Gets all distinct values
Select GetDate()
Union All
Select GetDate()
Go

--Craete Database
--With Primary(.mdf) Secondary(.ndf) and Log files(.ldf)
CREATE DATABASE SampleDB 
ON
PRIMARY ( NAME = SampleDB1,
      FILENAME = 'D:\Databases\SampleDB1.mdf',
      SIZE = 3MB,
      MAXSIZE = 10,
      FILEGROWTH = 2),
( NAME = SampleDB2,
   FILENAME = 'D:\Databases\SampleDB2.ndf',
   SIZE = 3MB,
   MAXSIZE = 10,
   FILEGROWTH = 2),
( NAME = SampleDB3,
   FILENAME = 'D:\Databases\SampleDB3.ndf',
   SIZE = 3MB,
   MAXSIZE = 10,
   FILEGROWTH = 2)
LOG ON 
( NAME = SampleDBLog1,
   FILENAME = 'D:\Databases\SampleDBLog1.ldf',
   SIZE = 3MB,
   MAXSIZE = 10,
   FILEGROWTH = 2),
( NAME = SampleDBLog2,
   FILENAME = 'D:\Databases\SampleDBLog2.ldf',
   SIZE = 3MB,
   MAXSIZE = 10,
   FILEGROWTH = 2)
GO

--Drop tables
Drop database SampleDB
Go

--Create Table
Create table dbo.SampleTable
(
	ID int identity(1,1) Primary key,
	Name varchar(50)
)
Go

exec sp_help'dbo.SampleTable'

--Global NewID
Select NEWID()

Alter table dbo.SampleTable Add RGUID UniqueIdentifier RowGUIDCOL
Go

Select * from dbo.SampleTable 
Insert into dbo.SampleTable values('Hiren',NEWID())
Go
Select * from dbo.SampleTable 

--Drops
--Multiple objects drop from single statement
--Create Proc usp_proc1 As Begin Select * from dbo.SampleTable End
--Go
--Create Proc usp_proc2 As Begin Select * from dbo.SampleTable End
--Go
--Create Proc usp_proc3 As Begin Select * from dbo.SampleTable End
--Go

--Drop Proc usp_proc1, usp_proc2, usp_proc3

Alter table dbo.SampleTable drop column RGUID
Go

Select * from dbo.SampleTable

exec sp_help'dbo.SampleTable'

--Begin
--Declare @var varchar(25)
--Select Top 1 @var = Constraint_Name from Information_Schema.TABLE_CONSTRAINTS where TABLE_NAME like 'SampleTable'
--Select @var
exec sp_helpconstraint'SampleTable'
Alter table dbo.SampleTable drop constraint PK__SampleTa__3214EC271367E606
--End
Go

Alter table dbo.SampleTable drop column ID
Go

Select * from dbo.SampleTable

Insert into dbo.SampleTable values ('Hiren')
Go

Select * from dbo.SampleTable

exec sp_help'dbo.SampleTable'

Truncate table dbo.SampleTable
Go

Drop table dbo.SampleTable
Go

--Constraints
	--Domain - Column Level - Rules
	--Entity - Ro9w level - unique constraint
	--Referential Constaint - Column level - referential constraint

Create table dbo.SampleTable 
(
	ID1 int identity(1,1) Primary Key, -- On table creation
	ID2 int
)
Go

Select * from dbo.SampleTable

exec sp_help'dbo.SampleTable'

Select top 1 CONSTRAINT_NAME from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where TABLE_NAME like 'SampleTable'

Alter table dbo.SampleTable Drop constraint PK__SampleTa__C49703DD173876EA
Go

Alter table dbo.SampleTable Alter column ID2 int not null
Go

--On existing table
Alter table dbo.SampleTable 
	Add constraint PK_SampleTable PRIMARY KEY (ID2)
Go

exec sp_help'dbo.SampleTable'

Select * from dbo.SampleTable

Alter table dbo.SampleTable add ID3 int
Go

Select * from dbo.SampleTable

Alter table dbo.SampleTable Add constraint FK_SampleTable FOREIGN KEY(ID3) references dbo.SampleTable(ID2)
Go
exec sp_help'dbo.SampleTable'

Insert into dbo.SampleTable values(1,Null)
Go

Select * from dbo.SampleTable

Insert into dbo.SampleTable values(2,Null)
Go

Select * from dbo.SampleTable

Insert into dbo.SampleTable values(4,Null)
Go

Select * from dbo.SampleTable

exec sp_help'dbo.SampleTable'

Select * from dbo.SampleTable

Insert into dbo.SampleTable(ID2,ID3) values(6,1)
Go

Select * from dbo.SampleTable

--Insert into dbo.SampleTable(ID2,ID3) values(6,10)

Select ID1 from dbo.SampleTable where exists (Select distinct ID1,ID2 from dbo.SampleTable where ID1 <> 8)

exec sp_help'dbo.SampleTable'

exec sp_helpconstraint'dbo.SampleTable'

Select * from dbo.SampleTable

--Self referencing
Alter table dbo.SampleTable Add ID4 int foreign key references dbo.SampleTable(ID2)
	--On Delete Cascade
	--On Delete set null
	On Delete No Action
	--On Delete set default
Go
	
exec sp_helpconstraint'dbo.SampleTable'

Drop table dbo.SampleTable
Go

Select * from dbo.Emp
Select * from dbo.Dept

exec sp_helpconstraint'dbo.Emp'
exec sp_helpconstraint'dbo.Dept'

Insert into dbo.Emp values('Ghi','Surat',GETDATE(),40000,111111,5)
Go

Alter table dbo.Emp Drop constraint FK__Emp__deptID__0F975522
Go

Alter table dbo.Emp add constraint FK_Emp_DeptID foreign key(deptID) references dbo.Dept(dID) on delete cascade
Go

Select * from dbo.Emp
Select * from dbo.Dept

Delete from dbo.Dept where dID = 5
Go

Select * from dbo.Emp
Select * from dbo.Dept

--Unique Constraint
--Create unique constraint on table creation
Create table dbo.SampleTable
(
	ID int identity(1,1),
	Name varchar(25),
	SSN int unique not null
)
Go

exec sp_helpconstraint'dbo.SampleTable'

Alter table dbo.SampleTable Add MobileNo  int
Go

Select * from dbo.SampleTable 

--Create unique constraint on existing column
Alter table dbo.SampleTable Add constraint uk_MobileNo Unique(MobileNo)
Go

exec sp_helpconstraint'dbo.SampleTable'

--Check Constraint
Select * from dbo.SampleTable

Alter table dbo.SampleTable Add Age int
Go

Select * from dbo.SampleTable 

Alter table dbo.SampleTable Add constraint Ck_Age check (Age between 0 and 100)
Go

exec sp_helpconstraint'dbo.SampleTable'

Select * from dbo.SampleTable

Insert into dbo.SampleTable  values('Hiren',1,1,0)
Go

Select * from dbo.SampleTable

Insert into dbo.SampleTable  values('Hiren',2,2,100)
Go

Select * from dbo.SampleTable

Insert into dbo.SampleTable  values('Hiren',3,3,100)
Go

Select * from dbo.SampleTable

exec sp_helpconstraint'dbo.SampleTable'

Alter table dbo.SampleTable Drop constraint Ck_Age
Go

exec sp_helpconstraint'dbo.SampleTable'

Alter table dbo.SampleTable Add constraint Ck_Age check (Age between 0 and 100)
Go

Alter table dbo.SampleTable Drop constraint Ck_Age
Go

Alter table dbo.SampleTable Add constraint Ck_AgeMin check (Age >= 0 )
Go

Alter table dbo.SampleTable Add constraint Ck_AgeMax check (Age <= 100 )
Go

--Default Constraint
Select * from dbo.SampleTable 

Alter table dbo.SampleTable Add Def1 varchar(25) not null default ''
Go

Select * from dbo.SampleTable 

exec sp_helpconstraint'dbo.SampleTable'

Alter table dbo.SampleTable Add Def2 varchar(25)
Go

Alter table dbo.SampleTable Add constraint Def_Def2 Default 'Def2' For Def2
Go

exec sp_helpconstraint'dbo.SampleTable'

--Disabling constraint WITH NoCheck

Select * from dbo.SampleTable

exec sp_helpconstraint'dbo.SampleTable'

Alter table dbo.SampleTable drop constraint uk_MobileNo
Go

Alter table dbo.SampleTable drop column MobileNo
Go

Alter table dbo.SampleTable Add MobileNo int
Go

Alter table dbo.SampleTable Add constraint CK_MobNo_Format Check (MobileNo like '[0-9][0-9][0-9][0-9][0-9][0-9]')
Go

Select * from dbo.SampleTable

Alter table dbo.SampleTable Add constraint DF_MobNo default 111111 for MobileNo
Go

Select * from dbo.SampleTable

Insert into dbo.SampleTable Values('Hiren',4,23,'',Null,123456)
Go

Select * from dbo.SampleTable

--You cannot alter constraint
Alter table dbo.SampleTable Drop constraint CK_MobNo_Format
Go

Alter table dbo.SampleTable 
	with NOCHECK
	Add constraint CK_MobNoFormat 
	check (MobileNo like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
Go
	
Select * from dbo.SampleTable

Insert into dbo.SampleTable Values('Hiren',5,23,'',Null,1234567890)
Go

Select * from dbo.SampleTable 

--Disable constraint
Alter table dbo.SampleTable NoCheck constraint CK_MobNoFormat
Go

exec sp_helpconstraint'dbo.SampleTable'

Insert into dbo.SampleTable Values('Hiren',6,23,'',Null,Null)
Go

Select * from dbo.SampleTable 

--Enable constraint
Alter table dbo.SampleTable Check constraint CK_MobNoFormat
Go

exec sp_helpconstraint'dbo.SampleTable'

--Rules : Simil;ar to check, but same rule can be bind to multiple columns
Select * from dbo.SampleTable

Create Rule greateThanZero
	AS @greateThanZero > 0
Go
	
exec sp_bindrule 'greateThanZero' ,'SampleTable.Age'
Go
exec sp_bindrule 'greateThanZero' ,'SampleTable.SSN'
Go
exec sp_bindrule 'greateThanZero' ,'SampleTable.MobileNo'
Go

exec sp_helpconstraint'dbo.SampleTable'
Go
exec sp_unbindrule 'SampleTable.MobileNo'
Go
--Drop rule
--Drop rule greaterThanZero
Go

--Defaults : To set one default value to multiple columns
--Create default
Create default DF_Zero as 0
Go

exec sp_helpconstraint'dbo.SampleTable'

Select * from dbo.SampleTable

Alter table dbo.SampleTable Add Salary int
Go

exec sp_bindefault 'DF_Zero', 'SampleTable.Salary'
Go

exec sp_helpconstraint'dbo.SampleTable'

exec sp_unbindefault 'SampleTable.Salary'
Go

exec sp_helpconstraint'dbo.SampleTable'
Go

Drop default DF_Zero
Go

--Depending objects
exec sp_depends 'dbo.SampleTable'

--DNR : Deferrec Name Resolution => Allows object to be used without its creation

--Nested subqueries : May return single value or a list of values
Select * from dbo.Emp
Select * from dbo.Dept

--Single return
Select * from dbo.Emp where eID = (Select eID from dbo.Emp where eID = 1)

Select * from dbo.Emp where deptID = (Select MIN(dID) from dbo.Dept)

Select Emp.* from dbo.Emp Inner Join dbo.Dept on Emp.deptID = Dept.dID where Dept.dID = (Select Min(dID) from dbo.Dept)

--List return
Select deptID,COUNT(deptID) from dbo.Emp group by deptID

Select * from dbo.Dept where dID in (Select distinct deptID from dbo.Emp)

Select distinct Dept.* from dbo.Emp Inner Join dbo.Dept on Emp.deptID = Dept.dID

--Find orphan records
Select Emp.* from dbo.Emp LEFT JOIN dbo.Dept on Emp.deptID = Dept.dID where Emp.deptID is null
Select Emp.* from dbo.Dept RIGHT JOIN dbo.Emp on Emp.deptID = Dept.dID where Emp.deptID is null

--Correlated subqueries
--Outer executes -> result inner -> inner executes -> result outer -> outer executes
Select * from dbo.Emp
Select * from dbo.Dept

Select * from dbo.Emp e1 where e1.deptID = (Select MIN(e2.deptID) from dbo.Emp e2 where e2.deptID = e1.deptID)

Select e.eName,(Select d.dName from dbo.Dept d where e.deptID = d.dID) as DeptName from dbo.Emp e

--IsNull fuction : IsNull(Test_expr, value_To_Replace_if_null)
Select e.eName,ISNULL((Select d.dName from dbo.Dept d where e.deptID = d.dID), 'Unallocated') as DeptName from dbo.Emp e

--Derived tables
Select e.eName, derTab1.dName from Emp e INNER JOIN (Select dID,dName from Dept) derTab1 on e.deptID = derTab1.dID

--Exists
Select dID,dName from Dept

Insert into Dept values('Dept',1)
Go

Select dID,dName from Dept

Select dID,dName from Dept where exists (Select deptID from Emp) --Returned dataset because exists returned true

Select dID,dName from Dept where exists (Select deptID from Emp where eID = 100) -- No data because exists returned false

if exists 
	(Select * from sys.objects where OBJECT_NAME(object_id) = 'table1' and SCHEMA_NAME(schema_id) = 'dbo' and OBJECTPROPERTY(object_id,'IsUserTable') = 1)
	Begin
		Drop table dbo.table1
		print 'Table1 dropped successfully'	
	End
else
	Begin
	Create table table1 (ID int Primary Key identity(1,1))
	print 'Table1 created successfully'	
	End
Go

Select * from dbo.table1

--Cast and convert for data-type conversion
Select CAST(123456 as Varchar) as Varchar

Select CONVERT(Varchar, 123456) as Varchar

Create Table ConvertTest
(
	ColInt int identity,
	ColTS timestamp
)
Go

Insert into ConvertTest Default Values
Go

Select * from ConvertTest

Select ColInt as Unconverted , Cast(ColTS as int) as Converted from ConvertTest

Select Convert(DateTime, GETDATE(), 111)

--Merge statement
Select * from dbo.Emp
Select * from dbo.Dept

Select * into dbo.Emp_1 from dbo.Emp where 1=2
Go

Select * from dbo.Emp_1

Insert into dbo.Emp_1 values('Xyz','Germany',GETDATE(),100000,1000,1)
Go

Select * from dbo.Emp
Select * from dbo.Emp_1

Select * into dbo.Emp_target from dbo.Emp where 1=2

Merge dbo.Emp_1 as e1
using
(
	Select eID,eName,city,dateOfBirth,salary,SSN,deptID from dbo.Emp
) as e
on e1.eID = e.eID 
when matched then delete
when not matched then insert(eName,city,dateOfBirth,salary,SSN,deptID) values(e.eName,e.city,e.dateOfBirth,e.salary,e.SSN,e.deptID);

Select * from dbo.Emp
Select * from dbo.Emp_1

--Output clause
Merge dbo.Emp_1 as e1
using
(
	Select eID,eName,city,dateOfBirth,salary,SSN,deptID from dbo.Emp
) as e
on e1.eID = e.eID 
when matched then delete
when not matched then insert(eName,city,dateOfBirth,salary,SSN,deptID) values(e.eName,e.city,e.dateOfBirth,e.salary,e.SSN,e.deptID)
Output	$action,
		deleted.eID,
		deleted.eName,
		inserted.eID,
		inserted.eName;
		
Select * from dbo.Emp
Select * from dbo.Emp_1

--Normalization
Create table tbl_Physician
(
	pID int identity(1,1) primary key,
	Physician varchar(50) not null
)
Go

Create table tbl_Hospital
(
	hID int identity(1,1) primary key,
	Hospital varchar(50) not null
)
Go
Create table tbl_Treatment
(
	tID int identity(1,1) primary key,
	Treatment varchar(50)
)
Go
Create table tbl_patient
(
	pID int identity(1,1) Primary Key,
	Patient varchar(50) not null,
	SSN int not null unique,
	Pysician int references tbl_Physician(pID) not null,
	Hospital int references tbl_Hospital(hID),
	Treatment int references tbl_Treatment(tID) not null,
	AdmitDate DateTime not null,
	ReleaseDate DateTime
)
Go
Select * from tbl_Physician
Select * from tbl_Hospital
Select * from tbl_Treatment
Select * from tbl_Patient

Insert into tbl_Physician values('Albert S')
Insert into tbl_Physician values('Sheila S')
Insert into tbl_Physician values('Mo Betta')
Go
Insert into tbl_Hospital values('Mayo Clinic')
Insert into tbl_Hospital values('Mustard Clinic')
Go
Insert into tbl_Treatment values('Lobotomy')
Insert into tbl_Treatment values('Cortizone Injection')
Insert into tbl_Treatment values('Pickle Extraction')
Insert into tbl_Treatment values('Cortizone Injection')
Go
Select * from tbl_Physician
Select * from tbl_Hospital
Select * from tbl_Treatment

Insert into tbl_Patient values('Sam Spade',555555555,1,1,1,GETDATE(),GETDATE())
Insert into tbl_Patient values('Sally Nally',33333333,1,null,2,GETDATE(),GETDATE())
Insert into tbl_Patient values('Peter Piper',22222222,3,2,3,GETDATE(),GETDATE())
Insert into tbl_Patient values('Nicki Dohickey',12345678,2,2,2,GETDATE(),GETDATE())
Go
Select * from tbl_Patient

Select tp.Patient, tp.SSN, tph.Physician, th.Hospital, tt.Treatment, tp.AdmitDate, tp.ReleaseDate
	from tbl_Patient tp 
	Inner Join tbl_Physician tph on tp.Pysician = tph.pID
	Left Join tbl_Hospital th on tp.Hospital = th.hID
	Inner Join tbl_Treatment tt on tp.Treatment = tt.tID
	

--Indexes
exec sp_helpindex'dbo.SampleTable'
Select * from dbo.SampleTable
Create Clustered index CIX_SampleTable_ID on SampleTable(ID)
exec sp_helpindex'dbo.SampleTable'


exec sp_helptext'CK_MobNoFormat'
Update dbo.SampleTable Set MobileNo = 1234567890 + ID

Create Unique NonClustered Index NCIX_SampleTable_MobileNo
	on dbo.SampleTable(MobileNo)
	
exec sp_helpindex'dbo.SampleTable'

Select * from dbo.SampleTable

Insert into dbo.SampleTable values('Hiren',(Select top 1 SSN from dbo.SampleTable order by SSN desc)+1,23,'',NULL,(Select top 1 MobileNo from dbo.SampleTable order by MobileNo desc)+1,NULL)
Insert into dbo.SampleTable values('Hiren',(Select top 1 SSN from dbo.SampleTable order by SSN desc)+1,23,'',NULL,(Select top 1 MobileNo from dbo.SampleTable order by MobileNo desc)+1,NULL)
Insert into dbo.SampleTable values('Hiren',(Select top 1 SSN from dbo.SampleTable order by SSN desc)+1,23,'',NULL,(Select top 1 MobileNo from dbo.SampleTable order by MobileNo desc)+1,NULL)
Insert into dbo.SampleTable values('Hiren',(Select top 1 SSN from dbo.SampleTable order by SSN desc)+1,23,'',NULL,(Select top 1 MobileNo from dbo.SampleTable order by MobileNo desc)+1,NULL)
Insert into dbo.SampleTable values('Hiren',(Select top 1 SSN from dbo.SampleTable order by SSN desc)+1,23,'',NULL,(Select top 1 MobileNo from dbo.SampleTable order by MobileNo desc)+1,NULL)
Go

Update dbo.SampleTable set Name = Name + '_' + Convert(Varchar(25), ID)
Update dbo.SampleTable set Age = 23
Go

Select * from dbo.SampleTable where MobileNo = 1234567899

--Disable Index
ALTER INDEX NCIX_SampleTable_MobileNo ON dbo.SampleTable DISABLE
GO
----Enable Index
ALTER INDEX CIX_SampleTable_ID ON dbo.SampleTable REBUILD
GO

--Disable All Indexes
ALTER INDEX All ON dbo.SampleTable DISABLE
GO
----Enable Index
ALTER INDEX All ON dbo.SampleTable REBUILD
GO

exec sp_helpindex'dbo.SampleTable'

Select * from dbo.SampleTable where MobileNo = 1234567899

--Drop Indexes
Drop Index dbo.SampleTable.CIX_SampleTable_ID
Go


--Views
Select * from dbo.Emp
Select * from dbo.Dept

Update dbo.Emp set deptID = 1 where eID in (1,2,3)
Update dbo.Emp set deptID = 2 where eID in (4,5)
Update dbo.Emp set deptID = 3 where eID in (6,8)
Update dbo.Emp set deptID = 4 where eID in (7,9)
Update dbo.Emp set deptID = 6 where eID in (10)
Go

Select e.eID, e.eName, e.city, e.dateOfBirth, d.dName, e1.eName as Head from 
dbo.Emp e Left Join dbo.Dept d on e.deptID = d.dID
Left Join dbo.Emp e1 on d.deptHead = e1.eID

Create view vw_EmpDept
As
Select e.eID, e.eName, e.city, e.dateOfBirth, d.dName, e1.eName as Head from 
dbo.Emp e Left Join dbo.Dept d on e.deptID = d.dID
Left Join dbo.Emp e1 on d.deptHead = e1.eID
Go

Select * from vw_EmpDept

--DateAdd and Cast fuction
Select DateAdd(Day, -10 , GETDATE())
Select DateAdd(Month, -10 , GETDATE())
Select DateAdd(Year, -10 , GETDATE())
Select DateAdd(week, -10 , GETDATE())
Select DateAdd(Minute, -10 , GETDATE())

Select Cast(GetDate() as varchar) as VarcharDate
Select Cast(GetDate() as Time) as TimeNow

--Updatable views
Select * from dbo.Dept

Create View vw_Dept with Encryption
As 
Select dID, dName, deptHead from dbo.Dept
Go

exec sp_helptext'vw_Dept'
Select * from vw_Dept

Insert into vw_Dept values('Dept6' , 1)

Select * from vw_Dept

Update vw_Dept set dName = 'Dept5' where dID = 6

Select * from vw_Dept

Delete from vw_Dept where dID = 7

Select * from vw_Dept

--Rename Column name or Table name
Select top 0 * from dbo.Emp
exec sp_rename 'Emp.dateOfBirth', 'DateOfBirth', 'Column'
Select top 0 * from dbo.Emp
exec sp_rename 'Emp', 'Emp_Renamed'
Select top 0 * from dbo.Emp
Select top 0 * from dbo.Emp_Renamed
exec sp_rename 'Emp_Renamed', 'Emp'
Select top 0 * from dbo.Emp

--Insert, Update Or Delete using Instead Of trigger
CREATE TABLE FirstHalf
(
  EmployeeID int NOT NULL PRIMARY KEY
, PhoneNo char (10) NOT NULL
)
Go

CREATE TABLE SecondHalf
(
  EmployeeID int NOT NULL PRIMARY KEY REFERENCES
  FirstHalf (EmployeeID)
  , Address varchar (50) NOT NULL
  , City varchar (25) NOT NULL
)
Go

Select * from FirstHalf
Select * from SecondHalf

CREATE VIEW vw_HalvesJoined
AS
	SELECT
	  f.EmployeeID
	, f.PhoneNo
	, s.Address
	, s.City
	FROM
		 FirstHalf  f
	JOIN SecondHalf s ON f.EmployeeID = s.EmployeeID
Go


CREATE TRIGGER trg_InsertIntoFirstAndSecondHalves ON vw_HalvesJoined
INSTEAD OF INSERT
AS
	IF @@ROWCOUNT = 0
		RETURN
	INSERT FirstHalf
		SELECT EmployeeID, PhoneNo FROM inserted
		
	INSERT SecondHalf
		SELECT EmployeeID, Address, City FROM inserted
Go

Insert into vw_HalvesJoined values(1, 9427081320, 'Kalol', 'Kalol')
Go

Select * from vw_HalvesJoined
Select * from FirstHalf
Select * from SecondHalf

--Delete from views
Alter table FirstHalf Add IsDeleted bit Default 0
Alter table SecondHalf Add IsDeleted bit Default 0

CREATE TRIGGER trg_DeleteFirstAndSecondHalves ON vw_HalvesJoined
INSTEAD OF Delete
AS
	IF @@ROWCOUNT = 0
		RETURN
	Update FirstHalf set IsDeleted = 1 where EmployeeID = (Select EmployeeID from Deleted)
		
	Update SecondHalf set IsDeleted = 1 where EmployeeID = (Select EmployeeID from Deleted)
Go

Select * from vw_HalvesJoined

Delete from vw_HalvesJoined where EmployeeID = 1

Select * from vw_HalvesJoined
Select * from FirstHalf
Select * from SecondHalf

--Definition of view
exec sp_helptext'vw_HalvesJoined'
Select * from sys.sql_modules where object_id = object_id('dbo.vw_HalvesJoined')

--Encrypting view definition
Alter view vw_HalvesJoined
With Encryption
AS
SELECT
	  f.EmployeeID
	, f.PhoneNo
	, s.Address
	, s.City
	FROM
		 FirstHalf  f
	JOIN SecondHalf s ON f.EmployeeID = s.EmployeeID
Go

exec sp_helptext'vw_HalvesJoined'
Select * from sys.sql_modules where object_id = object_id('dbo.vw_HalvesJoined')

--Schema-Binding with views : prevents views from being orphaned and to have Indexed view, we must have scehma binding
Alter view vw_HalvesJoined 
	WITH SCHEMABINDING
AS
	SELECT
	  f.EmployeeID
	, f.PhoneNo
	, s.Address
	, s.City
	FROM
		 dbo.FirstHalf  f
	JOIN dbo.SecondHalf s ON f.EmployeeID = s.EmployeeID
Go

Select * from sys.sql_modules where object_id = object_id('dbo.vw_HalvesJoined')

Select * from vw_HalvesJoined 

Drop table dbo.SecondHalf --Because this view is schema-bound


--Materialized View :
Create Unique Clustered Index IX_VW_HalvesJoined
On Vw_HalvesJoined(EmployeeID, PhoneNo, Address, City)

Select * from Vw_HalvesJoined

--Few system fubctions
Select @@DATEFIRST as FirstDayOfWeek
Select @@ERROR as Error
Select @@IDENTITY as IdentityVal
--Select IDENT_CURRENT() as IdentCurrent
Select SCOPE_IDENTITY() as ScopeIdentity
Select @@OPTIONS as Options
Select @@REMSERVER as RemoteServer
Select @@ROWCOUNT as RowCountVal
Select @@SERVERNAME as ServerName
Select @@TRANCOUNT as Transaction_Count
Select @@VERSION as Version

--Decalring a variable
Declare @myVar int;
Select * from dbo.Emp;
Select @myVar = @@ROWCOUNT;
Print @myVar

--Sample Batch file
--First Batch
Use MyDatabase

Declare @Var varchar(25) = 'Batch1'

Print @Var + ' executed successfully'

Go
--Second Batch
Declare @Var varchar(25) = 'Batch2'

Print @Var + ' executed successfully'

--New Batch
Use Master

Create Database Test

Create table test (ID int Primary Key Identity(1,1))

Go

Use Test
Select * from test -- Invalid object for Test database b'coz it is created in Master DB

Use Master
GO
Drop Database Test

--New Batch 2
Use Master

Create Database Test
Go

Use Test
Create table test (ID int Primary Key Identity(1,1))

Go

Select * from Test

--Drop created objects
Use Master
Go
Drop Database Test

--Dynamic SQL using exec command
Use MyDatabase
Select * from dbo.Emp
--Batch
Declare @schemaName varchar(25) = 'dbo', @tableName varchar(25) = 'Emp';
exec ('Select * from ' + @schemaName + '.' + @tableName)
Go

--Control of flow statements
--If....else
Declare @ifelse bit = 1
	if (@ifelse = 1)
		print 'true'
	else
		print 'false'
Go

--If....else...else
Declare @ifelse bit = null
	if (@ifelse = 1)
		print 'true'
	else if (@ifelse = 0)
		print 'false'
	else
		print 'undefined or null'
Go

--Blocks to group code
Begin
Declare @ifelse bit = null
	if (@ifelse = 1)
		print 'true'
	else if (@ifelse = 0)
		print 'false'
	else
		print 'undefined or null'
End
Go

--Case
Begin
Declare @ifelse bit = null
	Select	Case @ifelse 
				when 1 then 'true' 
				when 0 then 'false'
				else 'undefined or null'
			End
End
Go

--Looping with WHILE
Begin
Declare @myVar int = 0;
WHILE @myVar <= 20
	Begin
		if @myVar <> 10
			Begin
				Set @myVar = @myVar + 1;
				print 'Inside if ' + cast(@myVar as varchar);
				continue
			End
		else
			Begin
				print @myVar;
				break
			End
	End
End
Go

--WAITFOR
--Time
Begin
	WAITFOR TIME '16:01' --At specific time (Time format 24:00 clock)
	Print '16:01'
End

--Delay
Begin
	WAITFOR DELAY '00:00:10' --After delay f 10 secs
	Print '10 sec delay over'
End

--Try...catch block
Begin
	Declare @var1 int = 1;
	Declare @var2 int = 0;
	Declare @var3 int ;
	Begin Try
		Set @var3 = @var1/@var2;
		print convert(varchar, @var3);
	End Try
	Begin Catch
		Print convert(varchar, @@Error)
	End Catch
End

--Try...catch block
Begin
	Declare @var11 int = 1;
	Declare @var22 int = 0;
	Declare @var33 int ;
	Begin Try
		Set @var33 = @var11/@var22;
		print convert(varchar, @var33);
	End Try
	Begin Catch
		Declare @ErrorNo int, @Severity int, @State int, @LineNo int, @Message varchar(40);
		Select @ErrorNo = Error_Number(), @Severity = Error_Severity(), @State = Error_State(), @LineNo = Error_Line(), @Message = Error_Message();
		Print '@ErrorNo: ' + Convert(varchar,@ErrorNo) + ', @Severity: ' + Convert(varchar,@Severity) + ', @State: '+ Convert(varchar,@State) + 
				', @LineNo: ' + Convert(varchar,@LineNo) + ', @Message: ' + Convert(varchar,@Message);
	End Catch
End

--Error_Procedure() : To get which proc throws error

--Stored procedures
Create Proc usp_GetEmp
	@ID int 
With Encryption
	
As
	Begin
		Select * from dbo.Emp where eID = @ID
	End
Go
--Execute
exec usp_GetEmp 1
Go

--Table valued parameter
Select * from dbo.Emp
--User defined types
Create Type empType AS Table
(
	eName varchar(25),
	city varchar(25),
	dateOfBirth DateTime,
	salary int,
	SSN int,
	deptID int
)
Go

--ReadOnly param
Create Proc usp_InsertEmp
(
	@Values AS empType ReadOnly
)
With Encryption
	
As
	Begin
		Insert into Emp Select * from @Values;
	End
Go

--Insert using Table-valued parameter
Declare @empTypeValue AS empType;
Insert into @empTypeValue values('Table-valued','Abc',GETDATE(),100000,1234561,1)
exec usp_InsertEmp @empTypeValue
Go

Select * from Emp

--Output parameter
Drop Proc usp_GetEmployee
Go
Create Proc usp_GetEmployee
(
	@eID int,
	@eName AS varchar(Max) OUT
)
AS
Begin
	Select @eName = eName from dbo.Emp where eID = @eID;
	Print @eName;
	--Use of return
	Return 1;
	print 'This wont be printed'
End
--Exec

Declare @RetVal varchar(Max) = null;
exec @RetVal = usp_GetEmployee 1,null 
Select @RetVal


--Handling Inline Errors
Declare @Error int;
Insert into dbo.Emp values('error','City',GETDATE(),123456,11111,1000);
Select @Error = @@ERROR;
Print '@Error : ' + convert(varchar,@Error);
Print '@@Error : ' + convert(varchar,@@Error)


--Transactions :: For error handling before they occur
Select * from dbo.Emp

Drop Proc usp_TransactionDemo;
Go
Create Proc usp_TransactionDemo
(
	@eID int
)
With Execute As Caller
AS
Begin
	Declare @T1 varchar(20)
	Begin Try
		Begin Transaction @T1
			Update dbo.Emp set city = 'city' where eID = @eID;
			Delete from dbo.Emp where eId = @eID;
		Commit Transaction @T1
	End Try
	Begin Catch
		if @@TRANCOUNT > 0
			Begin
				print 'Number of operations : ' + convert(varchar,@@TRANCOUNT)
				Rollback Transaction @T1
			End
	End Catch
End
Go

exec usp_TransactionDemo 12
Go
Select * from dbo.Emp
Go
exec usp_TransactionDemo 12
Go

--Manually raising error :: RaisError
Begin
	Begin Try
		Print 'inside try'
		RaisError('Error',1,1);
	end Try
	Begin Catch
		Print 'inside catch'
		Print @@Error;
	End Catch
end

--With <option>
--With Log
Begin
	Begin Try
		Print 'inside try'
		RaisError('Error',1,1) with Log;
	end Try
	Begin Catch
		Print 'inside catch'
		Print @@Error;
	End Catch
end

--With seterror
Begin
	Begin Try
		Print 'inside try'
		RaisError('Error',1,1) with seterror;
	end Try
	Begin Catch
		Print 'inside catch'
		Print @@Error;
	End Catch
end

--With noWait
Begin
	Begin Try
		Print 'inside try'
		RaisError('Error',1,1) with noWait;
	end Try
	Begin Catch
		Print 'inside catch'
		Print @@Error;
	End Catch
end

--Add Custom error messages
sp_addMessage
	@msgnum = 60000,
	@severity = 10,
	@msgtext = 'msgtext'
	
Select * from sys.messages where message_id = 60000

sp_dropmessage 60000

Select * from sys.messages where message_id = 60000

--With Recompile
exec usp_TransactionDemo 12 with recompile --Generates new execution plan

--Recursion
Drop Proc usp_Factorial
Go

Create Proc usp_Factorial
(
	@ValueIn int,
	@ValueOut int output
)
AS
Begin
Declare @InWorking int, @OutWorking int;
	if @ValueIn = 1
		Select @ValueOut = 1;
	else
		Begin
			Select @InWorking = @ValueIn - 1;
			exec usp_Factorial @InWorking, @OutWorking output;
			Select @ValueOut = @ValueIn * @OutWorking;
		End
	return @ValueOut;
End
Go

Declare @WorkingOut int;
Declare @WorkingIn int;
Select @WorkingIn = 6;
exec usp_Factorial @WorkingIn , @WorkingOut output;
Print @WorkingOut
Go

--User Defined Functions
--One which returns a scalar
Create function udf_GetDate()
returns date
As
Begin
	Declare @sysdate Date;
	Select @sysdate = GetDate();
	return @sysdate;
End

--execute a function
Declare @var Date
Exec @var = udf_GetDate
print 'Date is : ' + convert(varchar,@var)

--One which returns a table
Create function udf_GetEmployees()
returns table
As
	return(Select * from dbo.Emp);


--execute
select * from udf_GetEmployees()

--Schema Bound function :: Determinism
Create function dbo.udf_getDateSchemaBound()
returns Date
with schemabinding
As
Begin
	Declare @date Date;
	Select @date = GetDate();
	return (@date);
End

--Exec
select dbo.udf_getDateSchemaBound();
Go

Select ObjectProperty(Object_id('udf_getDateSchemaBound'),'IsDeterministic');
Go

--Transactions
--Begin Transaction .... Commit Transaction .... Rollback Transaction .... Save Transaction
Begin Try
	Begin Transaction T1
		Print 'Before raise error';
		Raiserror('Error',16,1);
		Print 'After raise error';
	Commit Transaction T1
End Try
Begin Catch
	Print 'Before rollback';
	Rollback Transaction T1
	Print 'After rollback';
End Catch

--Triggers
--DDL Triggers that fires with DDL Statements
Create trigger trg_TruncateEmployee
on dbo.Emp
With Encryption
Instead of Delete
AS
	print 'Records can''t be deleted';
	
Delete from dbo.Emp
Go
Select * from dbo.Emp
Go

--Triggers
Select * from dbo.Emp

--Tables for audit
Create table Emp_Inserted (eID int)
Go
Create table Emp_Updated (eID int)
Go
Create table Emp_Deleted (eID int)
Go

Alter table Emp_Inserted add ename varchar(25),city varchar(25),dateOfBirth datetime, salary float, SSN int, deptID int
Alter table Emp_Deleted add ename varchar(25),city varchar(25),dateOfBirth datetime, salary float, SSN int, deptID int
Alter table Emp_Updated add ename varchar(25),city varchar(25),dateOfBirth datetime, salary float, SSN int, deptID int
Alter table Emp_Updated add old_ename varchar(25),old_city varchar(25),old_dateOfBirth datetime, old_salary float, old_SSN int, old_deptID int
Go

--Tables for audit
Alter table Emp_Inserted Add timeOfInsertion DateTime
Alter table Emp_Updated Add timeOfUpdation DateTime
Alter table Emp_Deleted Add timeOfDeletion DateTime

Create Trigger trg_ForInsertUpdateDeleteOnEmp
on dbo.Emp
For Insert, Update, Delete
As
Begin
	Declare @op_Type char(1);
	If exists(Select * from inserted)
		If exists(Select * from deleted)
			Set @op_Type = 'U';
		Else
			Set @op_Type = 'I';
	else
		Set @op_Type = 'D';

	if (@op_Type = 'I')
		insert dbo.Emp_Inserted(eID,eName,city,dateOfBirth,salary,SSN,deptID,timeOfInsertion) 
			select Inserted.eID,Inserted.eName,Inserted.city,Inserted.dateOfBirth,Inserted.salary,Inserted.SSN,Inserted.deptID,getDate() from Inserted
	else if(@op_Type = 'U')
	--Columns_updated
		if update(eName)
			insert dbo.Emp_Updated(eID,eName,old_Ename,timeOfUpdation)
				select inserted.eID, inserted.eName, deleted.eName,getDate() from INSERTED INNER JOIN DELETED
					on INSERTED.eID = DELETED.eID
		if update(city)				
			insert dbo.Emp_Updated(eID,city,old_city,timeOfUpdation)
					select inserted.eID, inserted.city, deleted.city,getDate() from INSERTED INNER JOIN DELETED
						on INSERTED.eID = DELETED.eID
		if update(dateOfBirth)				
			insert dbo.Emp_Updated(eID,dateOfBirth,old_dateOfBirth,timeOfUpdation)
					select inserted.eID, inserted.dateOfBirth, deleted.dateOfBirth,getDate() from INSERTED INNER JOIN DELETED
						on INSERTED.eID = DELETED.eID
		if update(SSN)				
			insert dbo.Emp_Updated(eID,SSN,old_SSN,timeOfUpdation)
					select inserted.eID, inserted.SSN, deleted.SSN,getDate() from INSERTED INNER JOIN DELETED
						on INSERTED.eID = DELETED.eID
		if update(salary)				
			insert dbo.Emp_Updated(eID,salary,old_salary,timeOfUpdation)
					select inserted.eID, inserted.salary, deleted.salary,getDate() from INSERTED INNER JOIN DELETED
						on INSERTED.eID = DELETED.eID
		if update(deptID)				
			insert dbo.Emp_Updated(eID,deptID,old_deptID,timeOfUpdation)
					select inserted.eID, inserted.deptID, deleted.deptID,getDate() from INSERTED INNER JOIN DELETED
						on INSERTED.eID = DELETED.eID
	else
		insert dbo.Emp_Deleted(eID,eName,city,dateOfBirth,salary,SSN,deptID,timeOfDeletion) 
			select Deleted.eID,Deleted.eName,Deleted.city,Deleted.dateOfBirth,Deleted.salary,Deleted.SSN,Deleted.deptID,getDate() from Deleted
End

Select * from dbo.Emp
Select * from dbo.Emp_Inserted
Select * from dbo.Emp_Updated
Select * from dbo.Emp_Deleted
Go

insert into dbo.Emp values('inserted','inserted',getDate(),1234567,11122,1)
Go

Select * from dbo.Emp
Select * from dbo.Emp_Inserted
Go

Delete from dbo.Emp where eID = 14
Go

Select * from dbo.Emp
Select * from dbo.Emp_Deleted
Go

Update dbo.Emp set eName = 'eName' where eID = 10
Go

Select * from dbo.Emp
Select * from dbo.Emp_Updated
Go

--Enable or disable triggers
Alter table dbo.Emp enable trigger all
Go
Alter table dbo.Emp disable trigger all
Go

--Dropping triggers
drop trigger trg_ForInsertUpdateDeleteOnEmp


--Cursors
Declare @eID int, @eName varchar(25),@city varchar(25);
Declare myCursor Cursor For
	Select eID, eName, city from dbo.Emp

open myCursor
	Fetch next from myCursor into @eID, @eName, @city
	
	while @@fetch_status = 0
	Begin
		print 'eID : ' + convert(varchar,@eID) + ', eName :' + @eName;
		Fetch next from myCursor into @eID, @eName, @city
	End
close myCursor
deallocate myCursor
