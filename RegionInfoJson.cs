using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongUsRegionsEditor
{
    public class RegionInfoJson
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Server
        {
            public string Name { get; set; }
            public string Ip { get; set; }
            public int Port { get; set; }
            public int Players { get; set; }
            public int ConnectionFailures { get; set; }
        }

        public class Region
        {
            [JsonProperty("$type")]
            public string type { get; set; }
            public string Fqdn { get; set; }
            public string DefaultIp { get; set; }
            public int Port { get; set; }
            public string useDtls { get; set; }
            public string Name { get; set; }
            public string PingServer { get; set; }
            public List<Server> Servers { get; set; }
            public int TranslateName { get; set; }
        }

        public class Root
        {
            public float CurrentRegionIdx { get; set; }
            public List<Region> Regions { get; set; }
        }
    }
}
