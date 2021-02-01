use WFA3DotNet
select * from Employee

--Stored procedure for Update
create proc sp_UpdateEmp
@empid int,
@empname varchar(20),
@esal float,
@deptId int
as
begin
update Employee set EmpName=@empname, Salary=@esal,DeptNo=@deptId
where EmpID=@empid
end

execute sp_UpdateEmp 16,'Rajat',23232.33,102

select * from Department

--Stored procedure for Search
create proc sp_SelectEmps
@empid int
as
begin
select e.EmpId,e.EmpName,e.Salary,d.DeptName
from Employee e join Department d
on e.DeptNo=d.DeptId
where EmpID=@empid
end

execute sp_SelectEmps 5

--Stored procedure for Insert

create proc sp_InsertEmp
@ename varchar(20),
@sal float,
@dno int
as
begin
insert into Employee(EmpName,Salary,DeptNo) values(@ename,@sal,@dno)
end

execute sp_InsertEmp 'prachi',23232,102

--Stored procedure for Delete
create proc sp_DeleteEmp
@eid int
as 
begin
delete from Employee where EmpId=@eid
end

execute sp_DeleteEmp 1013

select * from Employee