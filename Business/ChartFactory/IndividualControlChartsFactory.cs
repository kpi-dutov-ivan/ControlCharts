using Business.ControlCharts;
using Business.ControlCharts.Individual;
using Business.ControlCharts.Range;
using Business.ControlCharts.StandardDeviation;

namespace Business.ChartFactory;

public class IndividualControlChartsFactory : IControlChartFactory
    {
        private readonly List<decimal> _individualValues;

        public IndividualControlChartsFactory(List<decimal> individualValues)
        {
            _individualValues = individualValues;
        }

        public IControlChart CreateControlChart(ControlChartType chartType, Dictionary<string, decimal> parameters)
        {
            IControlChart chart;
            switch (chartType)
            {
                case ControlChartType.Range:
                    chart = CreateRangeChart(_individualValues, parameters);
                    break;
                case ControlChartType.MovingRange:
                    chart = new RMChart(_individualValues);
                    break;
                case ControlChartType.Individual:
                    chart = new XIndividual(_individualValues);
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

        private RChart CreateRangeChart(List<decimal> _individualValues, Dictionary<string, decimal> parameters)
        {
            var subgroupSize = (int)ControlChartFactoryHelpers.GetParameterValue(parameters, "subgroupSize");
            return new RChart(_individualValues, subgroupSize);
        }

        private static RMChartPreSpecified CreateMovingRangePreSpecified(List<decimal> individualValues, Dictionary<string, decimal> parameters)
        {
            var sigma0 = ControlChartFactoryHelpers.GetParameterValue(parameters, "sigma0");
            return new RMChartPreSpecified(individualValues, sigma0);
        }

        private static XIndividualPreSpecified CreateIndividualPreSpecifiedChart(List<decimal> individualValues, Dictionary<string, decimal> parameters)
        {
            var mu0 = ControlChartFactoryHelpers.GetParameterValue(parameters, "mu0");
            var sigma0 = ControlChartFactoryHelpers.GetParameterValue(parameters, "sigma0");
            return new XIndividualPreSpecified(individualValues, mu0, sigma0);
        }
        
        private static SChartPreSpecified CreateStandardDeviationPreSpecifiedChart(List<decimal> individualValues,
            Dictionary<string, decimal> parameters)
        {
            var sigma0 = ControlChartFactoryHelpers.GetParameterValue(parameters, "sigma0");
            var subgroupSize = (int)ControlChartFactoryHelpers.GetParameterValue(parameters, "subgroupSize");
            return new SChartPreSpecified(individualValues, sigma0, subgroupSize);
        }

    }