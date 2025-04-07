namespace Business.ControlCharts.Defective
{
    public class PChart : DefectiveControlChart
    {
        // TODO: Use of that for variable size
        private int _overallCount;
        public PChart(List<Defective> defectives, int? overallCount) : base(defectives)
        {
            if (!overallCount.HasValue)
                throw new NotImplementedException("Dynamic defective all item count is not supported yet");
            _overallCount = overallCount.Value;
        }

        public override void Calculate()
        {
            var defectiveProportionAverage = Defectives.Average(d => (decimal)d.DefectiveCount) / _overallCount;
            var threeSigma = Math.Sqrt(defectiveProportionAverage * (1.0m - defectiveProportionAverage) / _overallCount);
            CenterLine = defectiveProportionAverage;
            LowerControlLine = CenterLine - threeSigma;
            UpperControlLine = CenterLine + threeSigma;
        }
    }
}
