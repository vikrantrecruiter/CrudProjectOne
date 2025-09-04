Create Database Developer
use Developer

Create table Candidate
(
Id bigint Primary key identity,
Name nvarchar(50),
Email nvarchar(50),
Address nvarchar(100)
)

Select * from Candidate

Insert into Candidate(Name,Email,Address)values('Vikrant','vikrant@gmail.com','Noida')

Create Procedure InsertDataInCandidate
(
@Name nvarchar(50),
@Email nvarchar(50),
@Address nvarchar(100)
)
as
begin
Insert into Candidate(Name,Email,Address) values(@Name,@Email,@Address)
end

Exec InsertDataInCandidate 'Rohit','rohit@longfinch.com','Noida'

