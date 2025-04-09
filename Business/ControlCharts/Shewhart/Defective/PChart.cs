namespace Business.ControlCharts.Defective
{
    public class PChart<T> : DefectiveControlChart<T> where T: IValue<T>
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
            throw new NotImplementedException();
            // var defectiveProportionAverage = Defectives.Average(d => (T)d.DefectiveCount).Divide _overallCount;
            // var threeSigma = Decimal.Sqrt(defectiveProportionAverage * (1.0m - defectiveProportionAverage) / _overallCount);
            // CenterLine = defectiveProportionAverage;
            // LowerControlLine = CenterLine - threeSigma;
            // UpperControlLine = CenterLine + threeSigma;
        }
    }
}
