using POSModel.Models;
using POSServices.Helpers;
using POSServices.HttpApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Locations
{
    public class LocationService : ILocationService
    {
        private readonly IApiManager _apiManager;

        public LocationService(IApiManager apiManager)
        {
            _apiManager = apiManager;
        }
        public async Task<List<LocationDetails>> GetAllLocations()
        {
            try
            {
                var response = await _apiManager.GetAsync<List<LocationDetails>>(AppConstants.baseAddress + "/Location/GetAll");
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
