using Business.ControlCharts;
using Business.ControlCharts.Individual;
using Business.ControlCharts.Range;
using Business.ControlCharts.StandardDeviation;

namespace Business.ChartFactory;

public class IndividualControlChartsFactory<T> : IControlChartFactory<T> where T : IValue<T>
    {
        private readonly List<T> _individualValues;

        public IndividualControlChartsFactory(List<T> individualValues)
        {
            _individualValues = individualValues;
        }

        public IControlChart<T> CreateControlChart(ControlChartType chartType, Dictionary<string, decimal> parameters)
        {
            IControlChart<T> chart;
            switch (chartType)
            {
                case ControlChartType.Range:
                    chart = CreateRangeChart(_individualValues, parameters);
                    break;
                case ControlChartType.MovingRange:
                    chart = new RMChart<T>(_individualValues);
                    break;
                case ControlChartType.Individual:
                    chart = new XIndividual<T>(_individualValues);
                    break;
                case ControlChartType.IndividualPreSpecified:
                    chart = CreateIndividualPreSpecifiedChart(_individualValues, parameters);
                    break;
                case ControlChartType.MovingRangePreSpecified:
                    chart = CreateMovingRangePreSpecified(_individualValues, parameters);
                    break;
                case ControlChartType.StandardDeviationPreSpecified:
                    chart = CreateStandardDeviationPreSpecifiedChart(_individualValues, parameters);
                    break;
                default:
                    throw new ArgumentException();
            }

            chart.Calculate();

            return chart;
        }

        private RChart<T> CreateRangeChart(List<T> _individualValues, Dictionary<string, decimal> parameters)
        {
            var subgroupSize = ControlChartFactoryHelpers<T>.GetParameterValue(parameters, "subgroupSize");
            return new RChart<T>(_individualValues, (int)subgroupSize.NumberValue);
        }

        private static RMChartPreSpecified<T> CreateMovingRangePreSpecified(List<T> individualValues, Dictionary<string, decimal> parameters)
        {
            var sigma0 = ControlChartFactoryHelpers<T>.GetParameterValue(parameters, "sigma0");
            return new RMChartPreSpecified<T>(individualValues, sigma0);
        }

        private static XIndividualPreSpecified<T> CreateIndividualPreSpecifiedChart(List<T> individualValues, Dictionary<string, decimal> parameters)
        {
            var mu0 = ControlChartFactoryHelpers<T>.GetParameterValue(parameters, "mu0");
            var sigma0 = ControlChartFactoryHelpers<T>.GetParameterValue(parameters, "sigma0");
            return new XIndividualPreSpecified<T>(individualValues, mu0, sigma0);
        }
        
        private static SChartPreSpecified<T> CreateStandardDeviationPreSpecifiedChart(List<T> individualValues,
            Dictionary<string, decimal> parameters)
        {
            var sigma0 = ControlChartFactoryHelpers<T>.GetParameterValue(parameters, "sigma0");
            var subgroupSize = ControlChartFactoryHelpers<T>.GetParameterValue(parameters, "subgroupSize");
            return new SChartPreSpecified<T>(individualValues, sigma0, (int)subgroupSize.NumberValue);
        }
    }