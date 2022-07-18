namespace NET.Utilities.Helpers
{
    using System.Text.Json;

    /// Summary:
    ///     A collection of json helper methods.
    public static class JsonHelpers
    {
        public static bool TryDeserialise<T>(string json, out T value)
        {
            try
            {
                value = JsonSerializer.Deserialize<T>(json);
                
                return true;
            }
            catch
            {
                value = default(T);
                
                return false;
            }
        }

        public static object DeserialiseObject<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch
            {
                return json;
            }
        }
    }
}