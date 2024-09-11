using ModelsApi.Models;
using ModelsApi.Models.Employee;
using ModelsApi.Models.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.Services.InterfacesApi
{
    public interface IApiPosition
    {
        #region Get
        public ModelApiResponse getPositions();
        #endregion

        #region Post

        public ModelApiResponse insertPosition(Positions position);
        public ModelApiResponse updatePosition(Positions position);
        public ModelApiResponse deletePosition(Positions position);

        #endregion
    }
}