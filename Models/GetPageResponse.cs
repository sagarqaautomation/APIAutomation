using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGeneric.JsonProperties
{
    public class GetPageResponse
    {
        [JsonProperty("page")]
        public string Page { get; set; }
        [JsonProperty("per_page")]
        public string PerPage { get; set; }
        [JsonProperty("data")]
        public List<GetDataResponse> datavalues { get; set; }
        [JsonProperty("dataById")]
        public List<GetDataByID> dataByIDs { get; set; }
    }

    public class GetDataResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class PostPageResonse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class GetDataByID
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
