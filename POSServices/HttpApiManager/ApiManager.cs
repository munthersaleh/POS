using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace POSServices.HttpApiManager
{
	public class ApiManager : IApiManager
	{
		private readonly HttpClient _httpClient;
		//private readonly ILocalStorageService _localStorage;

		public ApiManager(HttpClient httpClient)
		{
			_httpClient = httpClient;

		}

		public async Task<T> GetAsync<T>(string uri)
		{
			return await CallAPI<T>(HttpMethod.Get, uri, null);
		}
		public async Task<T> GetAsync<T>(string uri, object data)
		{
			return await CallAPI<T>(HttpMethod.Get, uri, data);
		}

		public async Task<T> PostAsync<T>(string uri, T data)
		{
			return await CallAPI<T>(HttpMethod.Post, uri, data);
		}

		public async Task<TR> PostAsync<T, TR>(string uri, T data)
		{
			return await CallAPI<TR>(HttpMethod.Post, uri, data);
		}

		public async Task<T> PostAsync<T>(string uri, object data)
		{
			return await CallAPI<T>(HttpMethod.Post, uri, data);
		}

		public async Task<T> PutAsync<T>(string uri, object data)
		{
			return await CallAPI<T>(HttpMethod.Put, uri, data);
		}

		public async Task<R> PutAsync<T, R>(string uri, T data)
		{
			return await CallAPI<R>(HttpMethod.Put, uri, data);
		}

		private async Task<T> CallAPI<T>(HttpMethod method, string uri, object data)
		{
			try
			{
				string jsonResult = string.Empty;
				var req = new HttpRequestMessage(method, uri);
				req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				if (data != null)
				{
					req.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
				}
				//string userid = Preferences.Get("UserId", null);
				//string token = Preferences.Get("Token", null);
				string userid = "";
				string token = "";
				if (!string.IsNullOrEmpty(token))
				{
					token = token.Replace("\"", string.Empty);
					
				}
				//req.Headers.Add("Content-Type", "application/json; charset=utf-8");
				req.Headers.Add("Cookie", "ASP.NET_SessionId=xakp1ua20y5oeo4yku5m5f1y; timezone=Central+Standard+Time; FloorzapAuthCookie=YtepOYPxvTQdNEjsOKF0dgarnYEM0j7GLfJFXysgAw_M28NHL1lx4O3rta0EmuCOGws7d7sUVrC8asIYakxwxhi3foNGhecl45EotZRFQnq04FNAB0j2MLPqMQzeXiSziNRX1G0yVsSbRQhChEPCZ_wJVW-hsD5MGi9gqXXyTaRaiiutsrGCltXM9FFUMx44JKhoU_uomnx-lQ0kvo7eKeSwiO-R5C6XocK3F2O39LXiwbOFQbLi035pZttanqauiCIkRzT7ljnIqqG4a7koj6Q23QG7hkULFxOnDLRsC5OGFo4Fpu4aIN2Xq6AImkLttHSQ6FORjW-WJiXHE1k3GxlTDswaWCTs9tOKti4cT9DGXzrgotQ6v3hbDLlkqppe1na20EOsWKzgxHuGSsJTA16ajFtTCSaq0qO16mfc2uO855sBs5rquliuFfMod3b5wZDsAsaG3oPWCGPeDrAMYjwJZ9ZC2x7B9Rf8sDOJxUUxpYUdZSDtiF7IC104yZSAK7pout7I-NbThlncJlgoYg");
				var response = await _httpClient.SendAsync(req);
				if (response.IsSuccessStatusCode)
				{
					var options = new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true,
					};
					jsonResult = await response.Content.ReadAsStringAsync();
					var json = JsonSerializer.Deserialize<T>(jsonResult, options);
					return json;
				}


				throw new HttpRequestException(jsonResult);
				//throw new HttpRequestException(response.StatusCode, jsonResult);
			}
			catch (Exception e)
			{
				Debug.WriteLine($"{e.GetType().Name} : {e.Message}");
				throw;
			}
		}

		public async Task<T> DeleteAsync<T>(string uri)
		{
			return await CallAPI<T>(HttpMethod.Delete, uri, null);
		}

		public async Task<R> DeleteAsync<T, R>(string uri, T data)
		{
			return await CallAPI<R>(HttpMethod.Delete, uri, data);
		}

		public async Task<T> GetAsync<T>(string uri, T data)
		{
			return await CallAPI<T>(HttpMethod.Get, uri, data);
		}


	}
}
