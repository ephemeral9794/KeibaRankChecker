using Newtonsoft.Json;

namespace SeleniumMock
{
    [JsonObject]
    public struct Config
    {
        [JsonProperty("profile")]
        public string ProfileDir { get; set; }
        [JsonProperty("useragent")]
        public string UserAgent { get; set; }
    }
}