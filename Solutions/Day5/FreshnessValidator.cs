namespace Day5;

public class FreshnessValidator
{
    public List<FreshRange> _freshnessRanges;

    public FreshnessValidator(List<FreshRange> freshnessRanges)
    {
        _freshnessRanges = [.. freshnessRanges.OrderBy(r => r.StartId)];
    }

    public int KeepCombiningOverlappingRangesUntilDone()
    {
        int combined = CombineOverlappingRanges();
        while (combined > 0)
        {
            combined = CombineOverlappingRanges();
        }

        return _freshnessRanges.Count;
    }

    public int CombineOverlappingRanges()
    {
        var combinedRanges = new List<FreshRange>();
        foreach (var range in _freshnessRanges)
        {
            if (combinedRanges.Count == 0)
            {
                combinedRanges.Add(range);
            }
            else
            {
                var lastRange = combinedRanges[^1];
                if (lastRange.HasOverlap(range))
                {
                    combinedRanges[^1] = lastRange.MergeRanges(range);
                }
                else
                {
                    combinedRanges.Add(range);
                }
            }
        }
        var diff = _freshnessRanges.Count - combinedRanges.Count;
        _freshnessRanges = combinedRanges;

        return diff;
    }

    public bool IsItemFresh(long id)
    {
        foreach (var range in _freshnessRanges)
        {
            if (range.InRange(id))
            {
                return true;
            }
        }

        return false;
    }

    public long GetAmountOfFreshnessIds() => _freshnessRanges.Sum(r => r.GetNumberOfFreshIdsInRange());
}
