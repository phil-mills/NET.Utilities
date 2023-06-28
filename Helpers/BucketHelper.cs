namespace NET.Utilities.Helpers
{
    using System.IO;
    using System.Threading.Tasks;
    using NET.Utilities.Extensions;

    /// Summary:
    ///     A collection of bucket helper methods.
    public static class BucketHelper
    {
        public static async Task BucketAsync(string inPath, string outPath, int chunkSize)
        {
            var lines = await File.ReadAllLinesAsync(inPath);
            var buckets = lines.Partition(chunkSize);

            var c = 1;
            foreach(var bucket in buckets)
            {
                using (StreamWriter sw = File.CreateText($"{outPath}/bucket_{c++}.txt"))
                {
                    foreach(var line in bucket)
                    {
                        await sw.WriteLineAsync(line + ",");
                    }
                }
            }
        }
    }
}