using System;
namespace QA.Models
{
	public class ApiResult<T>
	{
        public ApiResult(string rawResult, int code, T result)
        {
            RawResult = rawResult;
            Code = code;
            Result = result;
        }
        public ApiResult(byte[] rawResult, int code)
        {
            byteResult = rawResult;
            Code = code;
        }
        public string RawResult { get; private set; }
        public byte[] byteResult { get; private set; }

        public int Code { get; private set; }

        public T Result { get; private set; }

        public bool IsSuccessful
        {
            get { return Code >= 200 && Code < 300; }
        }

    }
}

