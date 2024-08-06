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
				req.Headers.Add("Cookie", "ASP.NET_SessionId=ezl4dyr3sshabfgc1djj4b4k; timezone=Central+Standard+Time; FloorzapAuthCookie=aAGkZkjLkaCUZPY2tHI9ZRyvuL3eY_hHZPrSfyUWo-6BrL7mH5bQWLGBQ64yPRCBUH7QXMWqkKSiPsr-YrQIpmXWYSheyJU1x5tctGRwn8Wmbwq2Gg9yphN7kKWJx75C73MYTJ5LN_HZYTgSmG1Eg236zBgpWphplNNmnR9EhKObWkjwhhm4qH0Rk4DAsFqMjXPJIZMyqN1tJnWGaaIJrA3X7uRk9quHFIc_ijX9ACQufLdn-jQFkpCACW_imdmegRFyFeup8VJw7rdx9VJ_gIrAQDlv4uQTy5myVwDcjR7ek7HcVEL2mJZvFV8CJZiErGA6Qzkd8HVCBxYQEftVuvrZflCyn_DxCZ93YMRo5CTgvnrvat8KDdK_PUd5SuTx-7tZwrsiQ9xkzwWWQi8qJ4_TUzt-tKmfTA-YFMw8As4KmHWLxc0Ks-w62jSxQCH8q-CylpGjZQoLPlToODZ0iB_9vQq2Cdnt6E2Y83jePhC7Q5bl8YGyY8ZwVJL-606PJb06PWpOETNXYRNlK8R5pw");
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
