namespace NET.Utilities.Helpers
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// Summary:
    ///     A collection of clone helper methods.
    public static class CloneHelpers
    {
        public static object DeepClone(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                
                formatter.Serialize(stream, obj);
                stream.Position = 0;
                
                return formatter.Deserialize(stream);
            }
        }
    }
}