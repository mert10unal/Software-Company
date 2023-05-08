# Software Company Database

The problems to be solved about the software company database are shown below : 

Design a SoftwareCompany database
 - Company table has company name, address.
 - There is a company detail table, detail of the company, such as tax number.
 - There are employees. Everyone in the company, including the boss, is an employee and has date of birth.
 - There are projects. software company, projects for other companies in my company table
  can develop. The project has a name, code, contract and employees
 - A contract is a contract between a software company and company x. 
    The contract has a spesific project, workers, total cost and a deadline.

The database scheme of the software company is designed : 

![Bildschirmfoto 2023-02-15 um 14 35 27](https://user-images.githubusercontent.com/120198895/219016833-ebb6656f-49b3-409d-969d-bf13b6095d03.png)


Sql codes of the SoftwareCompany database :

create table Company(
Id int primary key GENERATED ALWAYS AS IDENTITY,
CompanyName character varying(100),
Address character varying(100)
);
insert into Company(CompanyName,Address) values ('Amerco','Reno,Nevada')
insert into Company(CompanyName,Address) values ('Amazon','Californa 5th Avenue')
insert into Company(CompanyName,Address) values ('Verizon','Utah, Dungeon Street')
insert into Company(CompanyName,Address) values ('AT&T','Texas City Centre')
insert into Company(CompanyName,Address) values ('American Express','Miami Towers')
select * from Company

create table CompanyDetail(
Id int primary key GENERATED ALWAYS AS IDENTITY,
CompanyId int,
TaxNumber character varying(5)
);
insert into CompanyDetail (CompanyId,TaxNumber) values (1,12345)
insert into CompanyDetail (CompanyId,TaxNumber) values (2,56431)
insert into CompanyDetail (CompanyId,TaxNumber) values (3,80541)
insert into CompanyDetail (CompanyId,TaxNumber) values (4,12983)
insert into CompanyDetail (CompanyId,TaxNumber) values (5,45312)
select * from CompanyDetail

create table Worker(
Id int primary key GENERATED ALWAYS AS IDENTITY,
IdentityNumber character varying(11),
Salary float,
BirthOfDate date,
CompanyId int,
FOREIGN KEY(CompanyId) REFERENCES Company(Id)
);
insert into Worker(IdentityNumber,Salary,BirthOfDate,CompanyId) values ('10610545518',15400,'1998-09-09',1)
insert into Worker(IdentityNumber,Salary,BirthOfDate,CompanyId) values ('10325436149',10000,'1986-03-12',5)
insert into Worker(IdentityNumber,Salary,BirthOfDate,CompanyId) values ('11928347193',20500,'1976-04-06',4)
insert into Worker(IdentityNumber,Salary,BirthOfDate,CompanyId) values ('10457645508',22500,'1995-08-11',3)
insert into Worker(IdentityNumber,Salary,BirthOfDate,CompanyId) values ('10610545518',12000,'1988-11-10',2)
select * from Worker

create table Contract(
Id int primary key GENERATED ALWAYS AS IDENTITY,
TotalCost float,
Deadline date,
CompanyId int,
FOREIGN KEY (CompanyId) REFERENCES Company(Id)
);
insert into Contract(TotalCost,Deadline,CompanyId) values (10000,'2023-06-02',3)
insert into Contract(TotalCost,Deadline,CompanyId) values (123090,'2023-04-01',1)
insert into Contract(TotalCost,Deadline,CompanyId) values (30456,'2023-03-03',5)
insert into Contract(TotalCost,Deadline,CompanyId) values (54000,'2023-03-08',2)
insert into Contract(TotalCost,Deadline,CompanyId) values (45300,'2022-11-11',4)
select * from Contract

create table WorkerContract(
Id int primary key GENERATED ALWAYS AS IDENTITY,
WorkerId int,
ContractId int,
FOREIGN KEY (WorkerId) REFERENCES Worker(Id),
FOREIGN KEY (ContractId) REFERENCES Contract(Id)
);
insert into WorkerContract(WorkerId,ContractId) values (1,3)
insert into WorkerContract(WorkerId,ContractId) values (4,2)
insert into WorkerContract(WorkerId,ContractId) values (2,5)
insert into WorkerContract(WorkerId,ContractId) values (3,4)
insert into WorkerContract(WorkerId,ContractId) values (5,1)
select * from WorkerContract

create table Project(
Id int primary key GENERATED ALWAYS AS IDENTITY,
ProjectName character varying(100),
Code character varying(4),
ContractId int,
FOREIGN KEY (ContractId) REFERENCES Contract(Id)
);
insert into Project(ProjectName,Code,ContractId) values ('Abcde','3847',1)
insert into Project(ProjectName,Code,ContractId) values ('Mertt','3847',5)
insert into Project(ProjectName,Code,ContractId) values ('EfeMert','2039',4)
insert into Project(ProjectName,Code,ContractId) values ('EgeEfe','8675',3)
insert into Project(ProjectName,Code,ContractId) values ('MertKerem','1923',2)
select * from Project

create table WorkerProject(
Id int primary key GENERATED ALWAYS AS IDENTITY,
WorkerId int,
ProjectId int,
FOREIGN KEY (WorkerId) REFERENCES Worker(Id),
FOREIGN KEY (ProjectId) REFERENCES Project(Id)
);

insert into WorkerProject (WorkerId,ProjectId) values (2,3)
insert into WorkerProject (WorkerId,ProjectId) values (1,4)
insert into WorkerProject (WorkerId,ProjectId) values (3,5)
insert into WorkerProject (WorkerId,ProjectId) values (5,1)
insert into WorkerProject (WorkerId,ProjectId) values (4,2)

In line with my design, sql codes of some frequently asked questions asked by users:

-- code of the project with the company name "Verizon"
select Code from Company,Worker,WorkerProject,Project
where Company.Id=Worker.CompanyId
and Worker.Id= WorkerProject.WorkerId
and WorkerProject.ProjectId=Project.Id
and CompanyName = 'Verizon'

--project name of the company detail board with tax number = 12983
select TaxNumber,ProjectName from CompanyDetail,Company,Worker,WorkerProject,Project
where CompanyDetail.CompanyId=Company.Id
and Company.Id=Worker.CompanyId
and Worker.Id= WorkerProject.WorkerId
and WorkerProject.ProjectId=Project.Id
and TaxNumber = '12983'

--contract id of a project with total cost = 30456 
select Project.ContractId from Contract,WorkerContract,Worker,WorkerProject,Project
where Contract.Id=WorkerContract.ContractId
and WorkerContract.WorkerId=Worker.Id
and Worker.Id=WorkerProject.WorkerId
and WorkerProject.ProjectId = Project.Id
and TotalCost = 30456

