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

Create Procedure ReadCadidateData
as
begin
Select * from Candidate
end

Exec ReadCadidateData

Exec InsertDataInCandidate 'Rohit','rohit@longfinch.com','Noida'

Create procedure UpdateCandidateData
(
@Id bigint,
@Name nvarchar(50),
@Email nvarchar(50),
@Address nvarchar(100)
)
as
begin
Update Candidate set Name=@Name,Email=@Email,Address=@Address where Id=@Id;
end

Exec UpdateCandidateData 3,'Yogesh','Yogesh@gmail.com','Noida'


