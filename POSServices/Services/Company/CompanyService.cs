using POSModel.Models;
using POSServices.Helpers;
using POSServices.HttpApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Company
{
	public class CompanyService : ICompanyService
	{
		private readonly IApiManager _apiManager;

		public CompanyService(IApiManager apiManager)
		{
			_apiManager = apiManager;
		}
		public async Task<CompanySettings> GetCompanySettingsAsync()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<CompanySettings>>(AppConstants.baseAddress + "/CompanySetting/SelectAll");
				AppConstants.companySettings = response[0];
                return response[0];
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
