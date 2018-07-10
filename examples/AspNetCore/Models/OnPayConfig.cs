using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Models
{
    public class OnPayConfig
    {
        public string GatewayId { get; set; }
        public string WindowSecret { get; set; }
    }
}
