using Business.ControlCharts;
using Business.ControlCharts.Mean;
using Business.ControlCharts.Range;
using Business.ControlCharts.StandardDeviation;

namespace Business
{
    public class ControlChartFactory
    {
        public static ControlChart CreateControlChart(ControlChartType chartType, List<Subgroup> subgroups, Dictionary<string, double> parameters)
        {
            var chart = chartType switch
            {
                ControlChartType.MeanRange => new XBarChartCalculatedWithRange(subgroups),
                ControlChartType.MeanStandardDeviation => new XBarChartCalculatedWithStandardDeviation(subgroups),
                ControlChartType.Range => new RChart(subgroups),
                ControlChartType.StandardDeviation => new SChart(subgroups),
                ControlChartType.Individual => throw new NotImplementedException(),
                ControlChartType.MovingRange => throw new NotImplementedException(),
                ControlChartType.Median => throw new NotImplementedException(),
                ControlChartType.ProportionDefective => throw new NotImplementedException(),
                ControlChartType.NumberDefective => throw new NotImplementedException(),
                ControlChartType.NumberDefects => throw new NotImplementedException(),
                ControlChartType.DefectsPerUnit => throw new NotImplementedException(),
                ControlChartType.MeanPreSpecified => CreateMeanPreSpecifiedChart(subgroups, parameters),
                ControlChartType.RangePreSpecified => CreateRangePreSpecifiedChart(subgroups, parameters),
                ControlChartType.StandardDeviationPreSpecified => CreateStandardDeviationPreSpecifiedChart(subgroups, parameters),
                ControlChartType.IndividualPreSpecified => throw new NotImplementedException(),
                ControlChartType.MovingRangePreSpecified => throw new NotImplementedException(),
                ControlChartType.MedianPreSpecified => throw new NotImplementedException(),
                ControlChartType.ProportionDefectivePreSpecified => throw new NotImplementedException(),
                ControlChartType.NumberDefectivePreSpecified => throw new NotImplementedException(),
                ControlChartType.NumberDefectsPreSpecified => throw new NotImplementedException(),
                ControlChartType.DefectsPerUnitPreSpecified => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(nameof(chartType), chartType, null)
            };

            chart.Calculate(subgroups);
            return chart;
        }
        private static double GetParameterValue(Dictionary<string, double> parameters, string key)
        {
            if (!parameters.TryGetValue(key, out var value))
                throw new ArgumentException($"{key} value should be provided for calculating the control chart with pre-specified values.");
            return value;
        }

        private static ControlChart CreateMeanPreSpecifiedChart(List<Subgroup> subgroups, Dictionary<string, double> parameters)
        {
            var mu0 = GetParameterValue(parameters, "mu0");
            var sigma0 = GetParameterValue(parameters, "sigma0");

            return new XBarChartPreSpecified(subgroups, mu0, sigma0);
        }

        private static ControlChart CreateRangePreSpecifiedChart(List<Subgroup> subgroups,
            Dictionary<string, double> parameters)
        {
            var sigma0 = GetParameterValue(parameters, "sigma0");
            return new RChartPreSpecified(subgroups, sigma0);
        }

        private static ControlChart CreateStandardDeviationPreSpecifiedChart(List<Subgroup> subgroups,
            Dictionary<string, double> parameters)
        {
            var sigma0 = GetParameterValue(parameters, "sigma0");
            return new SChartPreSpecified(subgroups, sigma0);
        }


    }

}
