using AccessControl.Services;
using DAOApi;
using ModelsApi.Models;
using Oracle.ManagedDataAccess.Client;
using ServicesApi.Services.InterfacesApi;
using System.Data;
using ModelsApi.Models.State;
using ModelsApi.Models.Position;
using ModelsApi.Models.Employee;

namespace ServicesApi.Services.ImplementacionApi
{
    public class ApiPositions : IApiPosition
    {
        private readonly IJwtHandler _jwt;
        private readonly ConexionOracle _conexionOracle;
        private ListaDeOracleParameters _lista;

        public ApiPositions(IJwtHandler jwt, ConexionOracle conexion, ListaDeOracleParameters lista)
        {
            _jwt = jwt;
            _conexionOracle = conexion;
            _lista = lista;
        }

        public ModelApiResponse getPositions()
        {
            ModelApiResponse ApiResponsePositions = new ModelApiResponse();
            List<Positions> PositionDetail = new List<Positions>();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_ACTIVO", OracleDbType.Boolean, 1, ParameterDirection.Input));

                    OracleDataReader PositionsDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_POSITIONS + ".[SP_POSITIONLIST]", _lista.Parameters);

                    PositionDetail = PositionsDatailReader.MapToList<Positions>();

                }

                if (PositionDetail.Count > 0)
                {
                    ApiResponsePositions.StatusCode = 0;
                    ApiResponsePositions.Data = PositionDetail;
                }
                else
                {
                    ApiResponsePositions.Message = Constants.PeticionSinDatos;
                }
                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponsePositions.Message += ex.ToString();
                return ApiResponsePositions;

            }

            return ApiResponsePositions;
        }

        public ModelApiResponse insertPosition(Positions position)
        {
            ModelApiResponse ApiResponsePositions = new ModelApiResponse();
            Positions Position = new Positions();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_Name", OracleDbType.Varchar2, position.Name, ParameterDirection.Input));
                    _lista.Parameters.Insert(1, new OracleParameter("PA_InsertUserId", OracleDbType.Int64, position.InsertUserId, ParameterDirection.Input));

                    OracleDataReader PositionDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_POSITIONS + ".[SP_POSITIONINSERT]", _lista.Parameters);

                    Position = PositionDatailReader.MapToItem<Positions>();

                }

                if (Position.Id > 0)
                {
                    ApiResponsePositions.StatusCode = 0;
                    ApiResponsePositions.Data = Position;
                }
                else
                {
                    ApiResponsePositions.Message = Constants.PeticionSinDatos;
                }

                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponsePositions.Message += ex.ToString();
                return ApiResponsePositions;

            }

            return ApiResponsePositions;
        }

        public ModelApiResponse updatePosition(Positions position)
        {
            ModelApiResponse ApiResponsePosition = new ModelApiResponse();
            Positions Position = new Positions();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_Id", OracleDbType.Int64, position.Id, ParameterDirection.Input));
                    _lista.Parameters.Insert(1, new OracleParameter("PA_Name", OracleDbType.Varchar2, position.Name, ParameterDirection.Input));
                    _lista.Parameters.Insert(2, new OracleParameter("PA_InsertUserId", OracleDbType.Int64, position.InsertUserId, ParameterDirection.Input));

                    OracleDataReader DatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_POSITIONS + ".[SP_POSITIONUPDATE]", _lista.Parameters);

                    Position = DatailReader.MapToItem<Positions>();
                }

                if (Position.Id > 0)
                {
                    ApiResponsePosition.StatusCode = 0;
                    ApiResponsePosition.Data = Position;
                }
                else
                {
                    ApiResponsePosition.Message = Constants.PeticionSinDatos;
                }

                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponsePosition.Message += ex.ToString();
                return ApiResponsePosition;

            }

            return ApiResponsePosition;
        }

        public ModelApiResponse deletePosition(Positions position)
        {
            ModelApiResponse ApiResponseEmployees = new ModelApiResponse();
            Employees Employee = new Employees();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_Id", OracleDbType.Int64, position.Id, ParameterDirection.Input));
                    _lista.Parameters.Insert(1, new OracleParameter("PA_UpdateUserId", OracleDbType.Int64, position.UpdateUserId, ParameterDirection.Input));

                    OracleDataReader EmployeeDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_POSITIONS + ".[SP_EMPLOYEEDELETE]", _lista.Parameters);

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
