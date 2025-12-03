using System.Numerics;

namespace Day3;

public static class JoltageFinder
{
    public static int FindMaxJoltage(string[] bank)
    {
        var result = 0;

        for (int i = 0; i <= bank.Length - 1; i++)
        {
            var firstNumber = bank[i];
            for (int j = i + 1; j < bank.Length; j++)
            {
                var toCheck = int.Parse($"{firstNumber}{bank[j]}");
                if (result < toCheck)
                {
                    result = toCheck;
                }
            }
        }

        return result;
    }

    public static BigInteger FindMaxJoltagePart2(string[] bank, int amountNeeded)
    {
        string max = "";

        int idx1 = 0;
        int idx2 = bank.Length - amountNeeded + 1;

        for (int i = 0; i < amountNeeded; i++)
        {
            var serie = bank[idx1..idx2];
            var maxSerie = serie.Max();
            var maxIdx = Array.FindIndex(serie.ToArray(), x => x == maxSerie);
            idx1 = idx1 + maxIdx + 1;
            idx2++;
            max = $"{max}{maxSerie}";
        }

        return BigInteger.Parse(max);
    }
}
