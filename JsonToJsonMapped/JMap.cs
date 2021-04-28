using System;
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
            foreach (var item in dict
                .Where(item => !json.Properties()
                    .Any(x => x.Name
                        .Equals(
                            item.Key, 
                            StringComparison.InvariantCultureIgnoreCase))))
            {
                dict.Remove(item.Key);
            }
            
            foreach (var prop in json.Properties().ToArray())
            {
                if (!dict.Keys.Any(x => x.Equals(
                    prop.Name, StringComparison.InvariantCultureIgnoreCase)))
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
            foreach (var item in dict
                .Where(item => !json.Properties()
                    .Any(x => x.Name
                        .Equals(
                            item.Key, 
                            StringComparison.InvariantCultureIgnoreCase))))
            {
                dict.Remove(item.Key);
            }
            
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
