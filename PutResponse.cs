using Consul.Net.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Consul.Net
{
    public class PutResponse : ConsulResponse
    {
        public PutResponse(string body, HttpStatusCode statusCode) : base(body, statusCode)
        {
        }
    }
}
