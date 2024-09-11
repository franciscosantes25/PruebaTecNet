using ModelsApi.Models;
using ModelsApi.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.Services.InterfacesApi
{
    public interface IApiEmployee
    {
        #region Get
        public ModelApiResponse getEmployees();

        #endregion

        #region Post

        public ModelApiResponse insertEmployee(Employees employees);
        public ModelApiResponse updateEmployee(Employees employees);
        public ModelApiResponse deleteEmployee(Employees employees);

        #endregion
    }
}