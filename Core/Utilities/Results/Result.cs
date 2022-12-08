using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
     
        public Result(bool success , string message):this(success)  // ikinci contructorı da calıştırır.
        {
            Message = message;  // read onlyler contructor icinde set edilebilirler
         
        }
        // messajı vermek zorunda olmadığımız icin ikinci bir contructor olusturdum.
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
