namespace Day5;

public record FreshRange(long StartId, long EndId)
{
    public bool InRange(long test) => StartId <= test && test <= EndId;

    public long GetNumberOfFreshIdsInRange() => EndId - StartId + 1;

    public bool HasOverlap(FreshRange other) => StartId <= other.EndId && other.StartId <= EndId;

    public FreshRange MergeRanges(FreshRange other) => new(Math.Min(StartId, other.StartId), Math.Max(EndId, other.EndId));
}
