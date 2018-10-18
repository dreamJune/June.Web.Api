using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June.Web.Api.Models
{
    public class Response
    {
        protected const int SuccessCode = 1;

        protected const int ExceptionCode = 0;

        protected const int ErrorCode = -1;

        public static Response Success<TData>()
        {
            return new Response<TData> { Code = SuccessCode, Message = "OK" };
        }

        public static Response Success()
        {
            return new Response<object> { Code = SuccessCode, Message = "OK" };
        }

        public static Response Success<TData>(string message)
        {
            return new Response<TData> { Code = SuccessCode, Message = message };
        }

        public static Response Success(string message)
        {
            return new Response<object> { Code = SuccessCode, Message = message };
        }

        public static Response Success<TData>(string message, TData data)
        {
            return new Response<TData> { Code = SuccessCode, Message = message, Data = data };
        }

        public static Response Error<TData>(int code = ErrorCode)
        {
            return new Response<TData> { Code = code };
        }

        public static Response Error(int code = ErrorCode)
        {
            return new Response<object> { Code = code };
        }

        public static Response Error<TData>(string message, int code = ErrorCode)
        {
            return new Response<TData> { Code = code, Message = message };
        }
        public static Response Error(string message, int code = ErrorCode)
        {
            return new Response<object> { Code = code, Message = message };
        }

        public static Response Error<TData>(string message, TData data, int code = ErrorCode)
        {
            return new Response<TData> { Code = code, Message = message, Data = data };
        }

        public static Response Exception<TData>()
        {
            return new Response<TData> { Code = ExceptionCode };
        }

        public static Response Exception()
        {
            return new Response<object> { Code = ExceptionCode };
        }

        public static Response Exception<TData>(string message)
        {
            return new Response<TData> { Code = ExceptionCode, Message = message };
        }

        public static Response Exception(string message)
        {
            return new Response<object> { Code = ExceptionCode, Message = message };
        }

        public static Response Exception(Exception exception)
        {
            return new TracingReponse { Code = ExceptionCode, Message = exception.Message, Tracing = exception };
        }
    }

    public class Response<TData> : Response
    {
        /// <summary>
        /// 返回代码 0：内部异常，正数：操作码，负数：外部异常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public TData Data { get; set; }

        public new static Response<TData> Success()
        {
            return new Response<TData> { Code = SuccessCode };
        }

        public new static Response<TData> Success(string message)
        {
            return new Response<TData> { Code = SuccessCode, Message = message };
        }

        public static Response<TData> Success(string message, TData data)
        {
            return new Response<TData> { Code = SuccessCode, Message = message, Data = data };
        }

        public new static Response<TData> Error(int code = ErrorCode)
        {
            return new Response<TData> { Code = code };
        }

        public new static Response<TData> Error(string message, int code = ErrorCode)
        {
            return new Response<TData> { Code = code, Message = message };
        }

        public static Response<TData> Error(string message, TData data, int code = ErrorCode)
        {
            return new Response<TData> { Code = code, Message = message, Data = data };
        }

        public new static Response<TData> Exception()
        {
            return new Response<TData> { Code = ExceptionCode };
        }
        public new static Response<TData> Exception(string message)
        {
            return new Response<TData> { Code = ExceptionCode, Message = message };
        }

        [Obsolete]
        public static Response<TData> Exception(string message, TData data)
        {
            return new Response<TData> { Code = ExceptionCode, Message = message, Data = data };
        }

        public new static Response<Exception> Exception(Exception exception)
        {
            return new TracingReponse { Code = ExceptionCode, Message = exception.Message, Tracing = exception };
        }
    }

    public class TracingReponse : Response<Exception>
    {
        public Exception Tracing { get; set; }
    }
}
