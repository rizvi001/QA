using System;
using Newtonsoft.Json;
using QA.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QA.Provider
{
	public class ApiProvider : IApiProvider
	{
        private readonly HttpClient _httpClient;
        public ApiProvider()
        {

            HttpClientHandler handler = new HttpClientHandler();
            _httpClient = new HttpClient(handler);
            TimeSpan ts = TimeSpan.FromMilliseconds(100000);
            _httpClient.Timeout = ts;
        }

        public ApiResult<T> Get<T>(string url, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage result = null;
            try
            {
                lock (_httpClient)
                {
                    if (headers != null)
                    {
                        AddHeadersToClient(headers);
                    }
                    result = _httpClient.GetAsync(url).Result;
                    if (headers != null)
                    {
                        RemoveHeadersFromClient(headers);
                    }
                }

                var rawResult = result.Content.ReadAsStringAsync().Result;

                try
                {
                    var deserialized = JsonConvert.DeserializeObject<T>(rawResult);
                    return new ApiResult<T>(rawResult, (int)result.StatusCode, deserialized);
                }
                catch (Exception ex)
                {
                    return new ApiResult<T>(rawResult, 501, Activator.CreateInstance<T>());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Message is :-" + e.Message);
            }

            return new ApiResult<T>(null, null != result ? (int)result.StatusCode : 0, default(T));
        }

        public async Task<ApiResult<T>> Post<T, TR>(string url, TR body, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage result = null;
            string returnResult = string.Empty;
            try
            {
                lock (_httpClient)
                {
                    if (headers != null)
                    {
                        AddHeadersToClient(headers);
                    }
                    var x = JsonConvert.SerializeObject(body);
                    var y = JsonConvert.SerializeObject(headers);
                    if (body != null)
                    {
                        result = _httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")).Result;
                    }
                    else
                    {
                        _httpClient.DefaultRequestHeaders.Range = new System.Net.Http.Headers.RangeHeaderValue(0, 1500000);
                    }

                    if (headers != null)
                    {
                        RemoveHeadersFromClient(headers);
                    }
                }

                var rawResult = result.Content.ReadAsStringAsync().Result;

                var deserialized = "";
                try
                {
                    var deserialized1 = JsonConvert.DeserializeObject<T>(rawResult);
                    return new ApiResult<T>(rawResult, (int)result.StatusCode, deserialized1);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                    return new ApiResult<T>(rawResult, 501, Activator.CreateInstance<T>());
                }


            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Message is :-" + e.Message);
            }
            return new ApiResult<T>(null, null != result ? (int)result.StatusCode : 0, default(T));
        }

        void AddHeadersToClient(Dictionary<string, string> headers)
        {
            foreach (var kv in headers)
            {
                try
                {
                    _httpClient.DefaultRequestHeaders.Add(kv.Key, kv.Value);
                }
                catch (Exception ex)
                { }
            }
        }

        void RemoveHeadersFromClient(Dictionary<string, string> headers)
        {
            foreach (var kv in headers)
            {
                _httpClient.DefaultRequestHeaders.Remove(kv.Key);
            }
        }
    }
}

