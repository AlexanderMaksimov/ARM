using System;
using System.Collections.Generic;
using System.Text;

namespace Art.Engine.Article.Interface
{
    public interface IResultEngine
    {
        bool Failed { get; set; }
        string Message { get; set; }
        bool Succeeded { get; set; }
    }
    public class ResultEngine : IResultEngine
    {
        public ResultEngine()
        { }

        public bool Failed { get;  set; }
        public string Message { get; set; }
        public bool Succeeded { get;  set; }

        public static IResultEngine Fail()
        {
            ResultEngine result = new ResultEngine();
            result.Failed = false;
            result.Message = "";
            return result;
        }
        public static IResultEngine Fail(string message)
        {
            ResultEngine result = new ResultEngine();
            result.Failed = false;
            result.Message = message;
            return result;
        }
        public static IResultEngine Success()
        {
            ResultEngine result = new ResultEngine();
            result.Succeeded = true;
            result.Message = "";
            return result;
        }
        public static IResultEngine Success(string message)
        {
            ResultEngine result = new ResultEngine();
            result.Succeeded = true;
            result.Message = message;
            return result;
        }
    }
}
