using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Business.ControlCharts;

namespace Tests
{
    public abstract class ControlChartTestCase<T> : IControlChart<T> where T : IValue<T>
    {
        public ControlChartTestCase(List<string> points, string centerLine, string upperControlLine, string lowerControlLine)
        {
            CenterLine = ValueFactory.CreateValue<T>(centerLine);
            UpperControlLine = ValueFactory.CreateValue<T>(upperControlLine);
            LowerControlLine = ValueFactory.CreateValue<T>(lowerControlLine);
            Points = points.Select(ValueFactory.CreateValue<T>).ToList();
        }

        public T CenterLine { get; set; }
        public T UpperControlLine { get; set; }
        public T LowerControlLine { get; set; }
        public List<T> Points { get; set; }

        public void Calculate()
        {
            throw new NotImplementedException();
        }
    }
}