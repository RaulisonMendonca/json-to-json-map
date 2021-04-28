using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonToJsonMapped
{
    public static class JMap
    {
        public static string Bind(
            JObject[] json, Dictionary<string, string> dict)
        {
            foreach (var prop in json.Properties().ToArray())
            {
                if (!dict.Keys.Any(x => x.Contains(prop.Name)))
                {
                    prop.Remove();
                    continue;
                }

                prop.Replace(new JProperty(
                    dict[prop.Name], prop.Value));
            }

            return JsonConvert.SerializeObject(json, Formatting.Indented);
        }
        
        public static string Bind(
            JObject json, Dictionary<string, string> dict)
        {
            foreach (var prop in json.Properties().ToArray())
            {
                if (!dict.Keys.Any(x => x.Contains(prop.Name)))
                {
                    prop.Remove();
                    continue;
                }

                prop.Replace(new JProperty(
                    dict[prop.Name], prop.Value));
            }

            return JsonConvert.SerializeObject(json, Formatting.Indented);
        }
    }
}
