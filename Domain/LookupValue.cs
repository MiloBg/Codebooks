using System.Text.Json.Serialization;

namespace Domain
{
    public class LookupValue
    {
        public string Key { get; set; }

        public string Value { get; set; }

        [JsonIgnore]
        public LookupMaster LookupMaster { get; set; }

        public int LookupMasterId { get; set; }
    }
}
