using System;
using System.Collections.Generic;
using System.Text;

namespace Entites
{

  public class APIResponseModel
    {
        public ResultResponseModel Result { get; set; }

    }

    public class ResultResponseModel
    {
        public string Action { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public object Data { get; set; }
        public object StackTrace { get; set; }
    }
}
