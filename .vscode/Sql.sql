Select e.FirstName,e.LastName,d.Name as [Department Name] From Employees e 
INNER JOIN
Departments d 
on 
e.DepartmentId = d.Id


