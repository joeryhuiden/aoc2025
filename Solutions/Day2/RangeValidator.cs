using AocHelpers;
using System.Numerics;

namespace Day2;

public static class RangeValidator
{
    public static (BigInteger, BigInteger) ValidateRange(BigInteger startNumber, BigInteger endNumber)
    {
        BigInteger rangeResult = 0;
        BigInteger rangeResultPart2 = 0;
        foreach (var numberInRange in EnumerableExtensions.RangeBigInt(startNumber, endNumber - startNumber + 1))
        {
            var result = ValidateNumber(numberInRange.ToString());
            if (!result)
            {
                rangeResult += numberInRange;
            }

            var resultPart2 = ValidateNumberPart2(numberInRange.ToString());
            if (!resultPart2)
            {
                rangeResultPart2 += numberInRange;
            }
        }

        return (rangeResult, rangeResultPart2);
    }

    public static bool ValidateNumber(string number)
    {
        // Odd numbers are valid.
        if (number.Length % 2 != 0)
        {
            return true;
        }

        string firsthalf = number[..(number.Length / 2)];
        string secondhalf = number[(number.Length / 2)..];

        return firsthalf != secondhalf;
    }

    public static bool ValidateNumberPart2(string number)
    {
        for (int i = 1; i < number.Length; i++)
        {
            // If you can't create even sized chunks, then skip that size of chunks.
            if (number.Length % i != 0)
            {
                continue;
            }

            var chunks = number.SplitStringInChunks(i).ToArray();

            // If there is only one chunk and all characters are the same, it's invalid.
            if (chunks.Length == 1 && chunks[0].Distinct().Count() == 1)
            {
                return false;
            }
            else if (chunks.Distinct().Count() == 1)
            {
                // If all chunks are the same, it's invalid.
                return false;
            }
        }

        return true;
    }
}
