using System;
using System.Collections;
using System.Collections.Generic;

namespace Lista_5.ComparisonAdapterNamespace
{
    class ComparisonAdapter<T> : IComparer<T>, IComparer
    {
        Comparison<T> comparison;

        public ComparisonAdapter(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public int Compare(T x, T y)
        {
            return comparison(x, y);
        }

        public int Compare(object x, object y)
        {
            return Compare((T) x, (T) y);
        }
    }

    class AdapterExerciseShow
    {
        public static void Do()
        {
            ArrayList a = new ArrayList {1, 9, 8, 8, 535423, 2, 3, 4, 5, 6, 7, 8};

            a.Sort(new ComparisonAdapter<int>((int x, int y) => x.CompareTo(y)));
        }
    }
}
