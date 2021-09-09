using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.Entities
{
    public class BLResult
    {
        public BLResult(bool success, string message)
            :this(success,message,null)
        {

        }
        public BLResult(bool success, string message, Exception exception)
        {
            Success = success;
            Message = message;
            InnerException = exception;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception InnerException { get; set; }
    }
}
