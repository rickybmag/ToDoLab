create database todolist;
use TODOLIST;

create table Employees(
Id int primary key not null auto_increment,
`Name` nvarchar(20),
Hours int not null,
Title nvarchar(40)
);

insert into employees values (0,'Rick',5, 'Dog Walker'),
(0, 'Meg', 10, 'Blogger'),
(0, 'James', 40, 'Garbage Truck Driver');



create table todos(
Id int primary key not null auto_increment,
`Name` nvarchar(25),
`Description` nvarchar(100),
assignedto int,
foreign key (assignedto) references Employees(id),
hoursneeded double,
iscompleted bit
);


create table Assignments(
Id int primary key not null auto_increment,
EmployeeId int,
ToDoId int,
foreign key (EmployeeId) references employees(Id),
foreign key (ToDoId) references todos(Id)
);

select * from employees;
select * from todos;
select * from assignments;

delete from todos where id = 2;