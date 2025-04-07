using System.Collections.Generic;
using System.Linq;
using Business.ControlCharts;

namespace UI
{
    public static class Dummy
    {
        private class DummySubgroup : ISubgroup
        {
            public DummySubgroup(decimal mean, decimal range)
            {
                Mean = mean;
                Range = range;
            }

            public decimal Mean { get; set; }
            public decimal Median { get; set; }
            public decimal StandardDeviation { get; set; }
            public decimal Range { get; set; }
            public int Size => 5;
        }

        public static List<ISubgroup> PrepareSubgroups()
        {
            var values = new List<(decimal Xbar, decimal R)>
            {
                (14.0764m, 0.01m),
                (14.0726m, 0.012m),
                (14.0754m, 0.008m),
                (14.0770m, 0.007m),
                (14.0708m, 0.025m),
                (14.0698m, 0.025m),
                (14.0770m, 0.009m),
                (14.0744m, 0.025m),
                (14.0704m, 0.009m),
                (14.0744m, 0.022m),
                (14.0766m, 0.009m),
                (14.0568m, 0.011m),
                (14.0768m, 0.023m),
                (14.0692m, 0.012m),
                (14.0716m, 0.019m),
                (14.0748m, 0.021m),
                (14.0754m, 0.017m),
                (14.0734m, 0.017m),
                (14.0748m, 0.035m),
                (14.0754m, 0.033m),
                (14.0732m, 0.017m),
                (14.0740m, 0.025m),
                (14.0708m, 0.017m),
                (14.0760m, 0.017m),
                (14.0722m, 0.018m)            };

            var subgroups = values.Select(v => new DummySubgroup(v.Xbar, v.R)).Cast<ISubgroup>().ToList();
            return subgroups;
        }
    }
}
