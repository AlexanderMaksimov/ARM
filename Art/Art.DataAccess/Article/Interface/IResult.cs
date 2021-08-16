using System;
using System.Collections.Generic;
using System.Text;

namespace Art.DataAccess.Article.Interface
{
    public interface IResult
    {
        bool Failed { get; set; }
        string Message { get; set; }
        bool Succeeded { get; set; }
    }
    public class Result : IResult
    {
        public Result()
        { }

        public bool Failed { get;  set; }
        public string Message { get;  set; }
        public bool Succeeded { get;  set; }

        public static Result Fail()
        {
            Result result = new Result();
            result.Failed = false;
            result.Message = "";
            return result;
        }
        public static Result Fail(string message)
        {
            Result result = new Result();
            result.Failed = false;
            result.Message = message;
            return result;
        }
        public static Result Success()
        {
            Result result = new Result();
            result.Succeeded = true;
            result.Message = "";
            return result;
        }
        public static Result Success(string message)
        {
            Result result = new Result();
            result.Succeeded = true;
            result.Message = message;
            return result;
        }
    }
}
