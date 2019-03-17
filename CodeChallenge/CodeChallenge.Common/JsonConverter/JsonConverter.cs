using Newtonsoft.Json;

namespace CodeChallenge.Common.JsonConverter
{
    public class JsonConverter : IJsonConverter
    {
        public TResult DeserializeObject<TResult>(string value)
        {
            return JsonConvert.DeserializeObject<TResult>(value);
        }

        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
