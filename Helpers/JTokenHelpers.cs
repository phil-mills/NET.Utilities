namespace NET.Utilities.Helpers
{
    using Newtonsoft.Json.Linq;

    /// Summary:
    ///     A collection of jtoken helper methods.
    ///     ** This class contains a dependacy to Newtonsoft.Json.Linq;
    public static class JTokenHelpers
    {
        public static bool TryParse(string json, out JToken value)
        {
            try 
            {
                value = JToken.Parse(json);

                return true;
            }
            catch 
            {
                value = default(JToken);

                return false;
            }
        }

        public static JToken ParseValue(string json)
        {
            try 
            {
                return JToken.Parse(json);
            }
            catch 
            {
                return json;
            }
        }
    }
}