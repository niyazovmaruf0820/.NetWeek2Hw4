create table Employees
(
       EmployeeID serial primary key, 
       FirstName varchar, 
       LastName varchar, 
       DepartmentID int references Departments(DepartmentID) , 
       Position varchar, 
       HireDate date
) ;
insert into Employees (FirstName, LastName, DepartmentID, Position, HireDate) values( 'Shodmon', 'Inoyatzoda',1,'Teacher','2023-06-06') ,
                                                                  					( 'Alijon', 'Zabiri', 1,'Teacher','2022-06-06') , 
            																		( 'Olimjon', 'Tojiev', 1,'Developer C#','2021-06-06') ,
																					( 'Said', 'Saidov',2,'Teacher','2023-06-06') ,
                                                                  					( 'Vali', 'Mahmudov', 2,'Python Developer','2022-06-06') , 
            																		( 'Lotman', 'Andreev', 2,'Teacher','2021-06-06') ,
																					( 'Sobir', 'Samiev',3,'Teacher','2023-06-06') ,
                                                                  					( 'Dilovarov', 'Dilovarov', 3,'C# developer','2022-06-06') , 
            																		( 'Bohid', 'Davlatov', 3,'Js Developer','2021-06-06') 


create table Departments
(
       DepartmentID serial primary key, 
       DepartmentName varchar
) ;

insert into Departments (DepartmentName) values('SoftClubi Profsoyuz') , 
             ('SoftClubi 103mkr') , 
            ('SoftClubi Sadbarg') 



create table Salaries
(
       SalaryID serial primary key, 
       EmployeeID int references Employees (EmployeeID) , 
       Amount decimal, 
       GetDate date
);


insert into Salaries(EmployeeID,Amount,GetDate)values(1,5000,'2024-03-09'),
													 (2,6000,'2024-03-09'),
													 (3,5000,'2024-03-09'),
													 (4,5000,'2024-03-09'),
													 (5,2000,'2024-03-09'),
													 (6,9000,'2024-03-09'),
													 (7,5000,'2024-03-09'),
													 (8,4000,'2024-03-09'),
													 (9,3000,'2024-03-09')


select Avg(s.Amount) from Salaries as s
join Employees as e on s.EmployeeID = e.EmployeeID 
where e.DepartmentID = 1


select Avg(s.Amount) from Salaries as s
join Employees as e on s.EmployeeID = e.EmployeeID 
where GetDate < current_date and GetDate >= current_date - (interval 1 month)


