using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Models
{
    public class ResultModel
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public Dictionary<string, object> Model { get; set; }
    }
}
