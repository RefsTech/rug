namespace Rug.Domain.Match.MatchReferees.MatchLimits
{
    public interface ILimit
    {
        bool IsInMaxRange(int number);

        bool IsValid(int number);
    }
}