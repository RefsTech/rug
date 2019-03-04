using System.Linq;

namespace Rug.Domain.Match.MatchReferees.MatchLimits
{
    public class ValuesLimit : ILimit
    {
        private int[] _values;

        public ValuesLimit(params int[] values)
        {
            _values = values.OrderBy(o => o).ToArray();
        }

        public bool IsInMaxRange(int number)
        {
            return number <= _values[_values.Length - 1];
        }

        public bool IsValid(int number)
        {
            return _values.Contains(number);
        }
    }
}