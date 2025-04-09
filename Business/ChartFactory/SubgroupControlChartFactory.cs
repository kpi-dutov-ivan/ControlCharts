using Business.ChartFactory;
using Business.ControlCharts;
using Business.ControlCharts.Individual;
using Business.ControlCharts.Mean;
using Business.ControlCharts.Range;
using Business.ControlCharts.StandardDeviation;

namespace Business
{

    public class SubgroupControlChartFactory<T>(List<ISubgroup<T>> subgroups) : IControlChartFactory<T> where T : IValue<T>
    {

        private readonly List<ISubgroup<T>> _subgroups = subgroups;

        public IControlChart<T> CreateControlChart(ControlChartType chartType,
            Dictionary<string, decimal> parameters)
        {
            IControlChart<T> chart;
            switch (chartType)
            {
                case ControlChartType.MeanRange:
                    chart = new XBarChartCalculatedWithRange<T>(_subgroups);
                    break;
                case ControlChartType.MeanStandardDeviation:
                    chart = new XBarChartCalculatedWithStandardDeviation<T>(_subgroups);
                    break;
                case ControlChartType.StandardDeviation:
                    chart = new SChart<T>(_subgroups);
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

        private static XBarChartPreSpecified<T> CreateMeanPreSpecifiedChart(List<ISubgroup<T>> subgroups,
            Dictionary<string, decimal> parameters)
        {
            var mu0 = ControlChartFactoryHelpers<T>.GetParameterValue(parameters, "mu0");
            var sigma0 = ControlChartFactoryHelpers<T>.GetParameterValue(parameters, "sigma0");

            return new XBarChartPreSpecified<T>(subgroups, mu0, sigma0);
        }

        private static RChartPreSpecified<T> CreateRangePreSpecifiedChart(List<ISubgroup<T>> subgroups,
            Dictionary<string, decimal> parameters)
        {
            var sigma0 = ControlChartFactoryHelpers<T>.GetParameterValue(parameters, "sigma0");
            return new RChartPreSpecified<T>(subgroups, sigma0);
        }
    }

    
}