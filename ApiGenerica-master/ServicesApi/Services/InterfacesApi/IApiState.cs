using ModelsApi.Models;
using ModelsApi.Models.Position;
using ModelsApi.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.Services.InterfacesApi
{
    public interface IApiState
    {
        #region Get
        public ModelApiResponse getStates();

        #endregion

        #region Post
        public ModelApiResponse insertState(States state);
        public ModelApiResponse updateState(States state);
        public ModelApiResponse deleteState(States state);

        #endregion
    }
}
