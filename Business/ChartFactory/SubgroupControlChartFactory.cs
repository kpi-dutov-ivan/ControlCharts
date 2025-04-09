using Business.ChartFactory;
using Business.ControlCharts;
using Business.ControlCharts.Individual;
using Business.ControlCharts.Mean;
using Business.ControlCharts.Range;
using Business.ControlCharts.StandardDeviation;

namespace Business
{

    public class SubgroupControlChartFactory(List<ISubgroup> subgroups) : IControlChartFactory
    {

        private readonly List<ISubgroup> _subgroups = subgroups;

        public IControlChart CreateControlChart(ControlChartType chartType,
            Dictionary<string, decimal> parameters)
        {
            IControlChart chart;
            switch (chartType)
            {
                case ControlChartType.MeanRange:
                    chart = new XBarChartCalculatedWithRange(_subgroups);
                    break;
                case ControlChartType.MeanStandardDeviation:
                    chart = new XBarChartCalculatedWithStandardDeviation(_subgroups);
                    break;
                case ControlChartType.StandardDeviation:
                    chart = new SChart(_subgroups);
                    break;
                case ControlChartType.Median:
                case ControlChartType.ProportionDefective:
                case ControlChartType.NumberDefective:
                case ControlChartType.NumberDefects:
                case ControlChartType.DefectsPerUnit:
                    throw new NotImplementedException();
                case ControlChartType.MeanPreSpecified:
                    chart = CreateMeanPreSpecifiedChart(_subgroups, parameters);
                    break;
                case ControlChartType.RangePreSpecified:
                    chart = CreateRangePreSpecifiedChart(_subgroups, parameters);
                    break;
                case ControlChartType.ProportionDefectivePreSpecified:
                case ControlChartType.NumberDefectivePreSpecified:
                case ControlChartType.NumberDefectsPreSpecified:
                case ControlChartType.DefectsPerUnitPreSpecified:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(chartType), chartType, null);
            }

            chart.Calculate();
            return chart;
        }

        private static XBarChartPreSpecified CreateMeanPreSpecifiedChart(List<ISubgroup> subgroups,
            Dictionary<string, decimal> parameters)
        {
            var mu0 = ControlChartFactoryHelpers.GetParameterValue(parameters, "mu0");
            var sigma0 = ControlChartFactoryHelpers.GetParameterValue(parameters, "sigma0");

            return new XBarChartPreSpecified(subgroups, mu0, sigma0);
        }

        private static RChartPreSpecified CreateRangePreSpecifiedChart(List<ISubgroup> subgroups,
            Dictionary<string, decimal> parameters)
        {
            var sigma0 = ControlChartFactoryHelpers.GetParameterValue(parameters, "sigma0");
            return new RChartPreSpecified(subgroups, sigma0);
        }
    }

    
}