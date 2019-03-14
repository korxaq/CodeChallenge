using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CodeChallenge.Common.JsonConverter
{
    public interface IJsonConverter
    {
        TResult DeserializeObject<TResult>(string value);
        string SerializeObject(object obj);
    }
}
