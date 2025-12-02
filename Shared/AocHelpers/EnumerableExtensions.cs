using System.Numerics;

namespace AocHelpers;

public static class EnumerableExtensions
{
    public static IEnumerable<BigInteger> RangeBigInt(BigInteger start, BigInteger count)
    {
        for (BigInteger i = 0; i < count; i++)
        {
            yield return start + i;
        }
    }

    public static IEnumerable<string> SplitStringInChunks(this string str, int chunkSize)
    {
        return Enumerable.Range(0, str.Length / chunkSize)
            .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
}