using System;
using System.Collections.Generic;
using Business.ControlCharts;

namespace Tests
{
    public abstract class ControlChartTestCase : IControlChart
    {
        public ControlChartTestCase(List<decimal> points, decimal centerLine, decimal upperControlLine, decimal lowerControlLine)
        {
            CenterLine = centerLine;
            UpperControlLine = upperControlLine;
            LowerControlLine = lowerControlLine;
            Points = points;
        }

        public decimal CenterLine { get; set; }
        public decimal UpperControlLine { get; set; }
        public decimal LowerControlLine { get; set; }
        public List<decimal> Points { get; set; }

        public void Calculate()
        {
            throw new NotImplementedException();
        }
    }
}