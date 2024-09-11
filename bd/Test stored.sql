

exec [Positions].[SP_POSITIONINSERT] 'Ventas Jr', 1
exec [Positions].[SP_POSITIONLIST] 1
EXEC [Positions].[SP_POSITIONUPDATE] 1, 'TI', 1
EXEC [Positions].[SP_POSITIONDELETE] 4, 1

EXEC [States].[SP_STATEINSERT] 'Campeche', 1
EXEC [States].[SP_STATEUPDATE] 4, 'Campechee', 1
exec [States].[SP_STATELIST] 1
EXEC [States].[SP_STATEDELETE] 4, 1

exec [Employees].[SP_EMPLOYEEINSERT] null
, 'Alberto'
, 'García'
, 1
, '1988-09-26'
, '2024-09-10'
, null
, '5612345678'
, 'alberto.garcia@gmail.com'
, 1
, 1

exec [Employees].[SP_EMPLOYEELIST] 1

exec [Employees].[SP_EMPLOYEEUPDATE] 2
, null
, 'Francisco'
, 'Santess'
, 1
, '1988-09-25'
, '2024-09-10'
, 'Actualización de dirección'
, '5512345678'
, 'ing.francisco.santes@gmail.com'
, 1
, 1

exec [Employees].[SP_EMPLOYEEDELETE] 3
, 1

