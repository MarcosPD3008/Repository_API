create database repository 
go

use repository
go

create table Students(
Id int identity primary key,
Name varchar(50) not null,
Lastname varchar(50) not null,
StudentCode varchar(8) unique not null
)
go

create table Subjects(
Id int identity primary key,
Name varchar(50) unique not null,
SubjectCode varchar(10) unique not null
)
go

create table StudentSubjects(
Id int identity primary key,
IdStudent int not null foreign key references Students(Id),
IdSubject int not null foreign key references Subjects(Id)
)
go

insert into Students values ('Juan', 'Diaz', 'JD1'), ('Ismael', 'Guerrero', 'IG1')
insert into Subjects values ('Spanish I', 'sp1'), ('English II', 'en2') 
insert into StudentSubjects values (1, 1), (2, 1), (2, 2)

select * from Students
select * from Subjects
select * from StudentSubjects