using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class ApiRequest
    {
        public string Uri { get; set; }
        public object Body { get; set; }
        public ApiRequestType ApiRequestType { get; set; }

        public ApiRequest(ApiRequestType apiRequestType)
        {
            ApiRequestType = apiRequestType;
        }
    }

    public enum ApiRequestType
    {
        GET, POST, PUT, DELETE, STREAM
    }
}
