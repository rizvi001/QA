using System;
using QA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QA.Provider
{
	public interface IApiProvider
	{
        ApiResult<T> Get<T>(string url, Dictionary<string, string> headers = null);

        Task<ApiResult<T>> Post<T, TR>(string url, TR body, Dictionary<string, string> headers = null);
    }
}

