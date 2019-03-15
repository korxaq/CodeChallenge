namespace CodeChallenge.Common.JsonConverter
{
    public interface IJsonConverter
    {
        TResult DeserializeObject<TResult>(string value);
        string SerializeObject(object obj);
    }
}
