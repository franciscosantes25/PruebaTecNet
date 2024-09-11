using AccessControl.Services;
using DAOApi;
using ModelsApi.Models;
using Oracle.ManagedDataAccess.Client;
using ServicesApi.Services.InterfacesApi;
using System.Data;
using ModelsApi.Models.Employee;

namespace ServicesApi.Services.ImplementacionApi
{
    public class ApiEmployees : IApiEmployee
    {
        private readonly IJwtHandler _jwt;
        private readonly ConexionOracle _conexionOracle;
        private ListaDeOracleParameters _lista;

        public ApiEmployees(IJwtHandler jwt, ConexionOracle conexion, ListaDeOracleParameters lista)
        {
            _jwt = jwt;
            _conexionOracle = conexion;
            _lista = lista;
        }

        public ModelApiResponse getEmployees()
        {
            ModelApiResponse ApiResponseEmployees = new ModelApiResponse();
            List<Employees> EmployeeDetail = new List<Employees>();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_ACTIVO", OracleDbType.Boolean, 1, ParameterDirection.Input));

                    OracleDataReader EmployeeDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_EMPLOYEES + ".[SP_EMPLOYEELIST]", _lista.Parameters);

                    EmployeeDetail = EmployeeDatailReader.MapToList<Employees>();

                }

                if (EmployeeDetail.Count > 0)
                {
                    ApiResponseEmployees.StatusCode = 0;
                    ApiResponseEmployees.Data = EmployeeDetail;
                }
                else
                {
                    ApiResponseEmployees.Message = Constants.PeticionSinDatos;
                }
                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponseEmployees.Message += ex.ToString();
                return ApiResponseEmployees;

            }

            return ApiResponseEmployees;
        }

        public ModelApiResponse insertEmployee(Employees employees)
        {
            ModelApiResponse ApiResponseEmployees = new ModelApiResponse();
            Employees Employee = new Employees();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_Photograph", OracleDbType.BinaryFloat, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(1, new OracleParameter("PA_Name", OracleDbType.Varchar2, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(2, new OracleParameter("PA_LastName", OracleDbType.Varchar2, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(3, new OracleParameter("PA_PositionId", OracleDbType.Int32, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(4, new OracleParameter("PA_BirthDate", OracleDbType.Date, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(5, new OracleParameter("PA_HiringDate", OracleDbType.Date, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(6, new OracleParameter("PA_Address", OracleDbType.Varchar2, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(7, new OracleParameter("PA_Phone", OracleDbType.Varchar2, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(8, new OracleParameter("PA_Email", OracleDbType.Varchar2, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(9, new OracleParameter("PA_StateId", OracleDbType.Byte, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(10, new OracleParameter("PA_InsertUserId", OracleDbType.Int64, employees.Photograph, ParameterDirection.Input));

                    OracleDataReader EmployeeDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_EMPLOYEES + ".[SP_EMPLOYEEINSERT]", _lista.Parameters);

                    Employee = EmployeeDatailReader.MapToItem<Employees>();

                }

                if (Employee.Id > 0)
                {
                    ApiResponseEmployees.StatusCode = 0;
                    ApiResponseEmployees.Data = Employee;
                }
                else
                {
                    ApiResponseEmployees.Message = Constants.PeticionSinDatos;
                }

                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponseEmployees.Message += ex.ToString();
                return ApiResponseEmployees;

            }

            return ApiResponseEmployees;
        }

        public ModelApiResponse updateEmployee(Employees employees)
        {
            ModelApiResponse ApiResponseEmployees = new ModelApiResponse();
            Employees Employee = new Employees();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_Id", OracleDbType.Int64, employees.Id, ParameterDirection.Input));
                    _lista.Parameters.Insert(1, new OracleParameter("PA_Photograph", OracleDbType.BinaryFloat, employees.Photograph, ParameterDirection.Input));
                    _lista.Parameters.Insert(2, new OracleParameter("PA_Name", OracleDbType.Varchar2, employees.Name, ParameterDirection.Input));
                    _lista.Parameters.Insert(3, new OracleParameter("PA_LastName", OracleDbType.Varchar2, employees.LastName, ParameterDirection.Input));
                    _lista.Parameters.Insert(4, new OracleParameter("PA_PositionId", OracleDbType.Int32, employees.PositionId, ParameterDirection.Input));
                    _lista.Parameters.Insert(5, new OracleParameter("PA_BirthDate", OracleDbType.Date, employees.BirthDate, ParameterDirection.Input));
                    _lista.Parameters.Insert(6, new OracleParameter("PA_HiringDate", OracleDbType.Date, employees.HiringDate, ParameterDirection.Input));
                    _lista.Parameters.Insert(7, new OracleParameter("PA_Address", OracleDbType.Varchar2, employees.Address, ParameterDirection.Input));
                    _lista.Parameters.Insert(8, new OracleParameter("PA_Phone", OracleDbType.Varchar2, employees.Phone, ParameterDirection.Input));
                    _lista.Parameters.Insert(9, new OracleParameter("PA_Email", OracleDbType.Varchar2, employees.Email, ParameterDirection.Input));
                    _lista.Parameters.Insert(10, new OracleParameter("PA_StateId", OracleDbType.Byte, employees.StateId, ParameterDirection.Input));
                    _lista.Parameters.Insert(11, new OracleParameter("PA_InsertUserId", OracleDbType.Int64, employees.InsertUserId, ParameterDirection.Input));

                    OracleDataReader EmployeeDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_EMPLOYEES + ".[SP_EMPLOYEEUPDATE]", _lista.Parameters);

                    Employee = EmployeeDatailReader.MapToItem<Employees>();
                }

                if (Employee.Id > 0)
                {
                    ApiResponseEmployees.StatusCode = 0;
                    ApiResponseEmployees.Data = Employee;
                }
                else
                {
                    ApiResponseEmployees.Message = Constants.PeticionSinDatos;
                }

                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponseEmployees.Message += ex.ToString();
                return ApiResponseEmployees;

            }

            return ApiResponseEmployees;
        }

        public ModelApiResponse deleteEmployee(Employees employees)
        {
            ModelApiResponse ApiResponseEmployees = new ModelApiResponse();
            Employees Employee = new Employees();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_Id", OracleDbType.Int64, employees.Id, ParameterDirection.Input));
                    _lista.Parameters.Insert(1, new OracleParameter("PA_UpdateUserId", OracleDbType.Int64, employees.UpdateUserId, ParameterDirection.Input));

                    OracleDataReader EmployeeDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_EMPLOYEES + ".[SP_EMPLOYEEDELETE]", _lista.Parameters);

                    Employee = EmployeeDatailReader.MapToItem<Employees>();
                }

                if (Employee.Id > 0)
                {
                    ApiResponseEmployees.StatusCode = 0;
                    ApiResponseEmployees.Data = Employee;
                }
                else
                {
                    ApiResponseEmployees.Message = Constants.PeticionSinDatos;
                }

                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponseEmployees.Message += ex.ToString();
                return ApiResponseEmployees;

            }

            return ApiResponseEmployees;
        }
    }
}
