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
    public class ApiStates : IApiState
    {
        private readonly IJwtHandler _jwt;
        private readonly ConexionOracle _conexionOracle;
        private ListaDeOracleParameters _lista;

        public ApiStates(IJwtHandler jwt, ConexionOracle conexion, ListaDeOracleParameters lista)
        {
            _jwt = jwt;
            _conexionOracle = conexion;
            _lista = lista;
        }

        public ModelApiResponse getStates()
        {
            ModelApiResponse ApiResponseStates = new ModelApiResponse();
            List<States> StateDetail = new List<States>();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_ACTIVO", OracleDbType.Boolean, 1, ParameterDirection.Input));

                    OracleDataReader StatesDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_STATES + ".[SP_STATELIST]", _lista.Parameters);

                    StateDetail = StatesDatailReader.MapToList<States>();

                }

                if (StateDetail.Count > 0)
                {
                    ApiResponseStates.StatusCode = 0;
                    ApiResponseStates.Data = StateDetail;
                }
                else
                {
                    ApiResponseStates.Message = Constants.PeticionSinDatos;
                }
                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponseStates.Message += ex.ToString();
                return ApiResponseStates;

            }

            return ApiResponseStates;
        }

        public ModelApiResponse insertState(States state)
        {
            ModelApiResponse ApiResponseState = new ModelApiResponse();
            States State = new States();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_Name", OracleDbType.Varchar2, state.Name, ParameterDirection.Input));
                    _lista.Parameters.Insert(1, new OracleParameter("PA_InsertUserId", OracleDbType.Int64, state.InsertUserId, ParameterDirection.Input));

                    OracleDataReader StateDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_STATES + ".[SP_STATEINSERT]", _lista.Parameters);

                    State = StateDatailReader.MapToItem<States>();

                }

                if (State.Id > 0)
                {
                    ApiResponseState.StatusCode = 0;
                    ApiResponseState.Data = State;
                }
                else
                {
                    ApiResponseState.Message = Constants.PeticionSinDatos;
                }

                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponseState.Message += ex.ToString();
                return ApiResponseState;

            }

            return ApiResponseState;
        }

        public ModelApiResponse updateState(States state)
        {
            ModelApiResponse ApiResponseState = new ModelApiResponse();
            States State = new States();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_Id", OracleDbType.Int64, state.Id, ParameterDirection.Input));
                    _lista.Parameters.Insert(1, new OracleParameter("PA_Name", OracleDbType.Varchar2, state.Name, ParameterDirection.Input));
                    _lista.Parameters.Insert(2, new OracleParameter("PA_InsertUserId", OracleDbType.Int64, state.InsertUserId, ParameterDirection.Input));

                    OracleDataReader DatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_STATES + ".[SP_STATEUPDATE]", _lista.Parameters);

                    State = DatailReader.MapToItem<States>();
                }

                if (State.Id > 0)
                {
                    ApiResponseState.StatusCode = 0;
                    ApiResponseState.Data = State;
                }
                else
                {
                    ApiResponseState.Message = Constants.PeticionSinDatos;
                }

                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponseState.Message += ex.ToString();
                return ApiResponseState;

            }

            return ApiResponseState;
        }

        public ModelApiResponse deleteState(States state)
        {
            ModelApiResponse ApiResponseState = new ModelApiResponse();
            States State = new States();
            try
            {
                if (_conexionOracle.openConnection())
                {
                    _lista.Parameters.Insert(0, new OracleParameter("PA_Id", OracleDbType.Int64, state.Id, ParameterDirection.Input));
                    _lista.Parameters.Insert(1, new OracleParameter("PA_UpdateUserId", OracleDbType.Int64, state.UpdateUserId, ParameterDirection.Input));

                    OracleDataReader StateDatailReader = _conexionOracle.ExcuteStoreProcedureAny(OraclePackage.SCHEMA_PA_STATES + ".[SP_STATEDELETE]", _lista.Parameters);

                    State = StateDatailReader.MapToItem<States>();
                }

                if (State.Id > 0)
                {
                    ApiResponseState.StatusCode = 0;
                    ApiResponseState.Data = State;
                }
                else
                {
                    ApiResponseState.Message = Constants.PeticionSinDatos;
                }

                _conexionOracle.CloseConnection();

            }
            catch (Exception ex)
            {
                ApiResponseState.Message += ex.ToString();
                return ApiResponseState;

            }

            return ApiResponseState;
        }
    }
}
