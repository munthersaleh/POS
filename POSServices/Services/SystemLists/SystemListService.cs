using POSModel.Models;
using POSServices.Helpers;
using POSServices.HttpApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.SystemLists
{
	public class SystemListService : ISystemListService
	{
		private readonly IApiManager _apiManager;

		public SystemListService(IApiManager apiManager)
		{
			_apiManager = apiManager;
		}
		public async Task<IEnumerable<SystemList>> GetSystemListByListTypeID(int listTypeID)
		{
			try
			{
				var response = await _apiManager.GetAsync<IEnumerable<SystemList>>(AppConstants.baseAddress + "/SystemList?listType=" + listTypeID);
				return response;
			}
			catch (Exception ex)
			{
				return new List<SystemList>(); ;
			}
		}

        public async Task<IEnumerable<SystemList>> GetAllSystemList()
        {
            try
            {
				var response = await _apiManager.GetAsync<IEnumerable<SystemList>>(AppConstants.baseAddress + "/SystemList/GetCompleteList");
                return response;
            }
            catch (Exception ex)
            {
                return new List<SystemList>(); ;
            }
        }
    }
}
