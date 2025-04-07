using Business.ControlCharts;
using Business.ControlCharts.Individual;
using Business.ControlCharts.Mean;
using Business.ControlCharts.Range;
using Business.ControlCharts.StandardDeviation;

namespace Business
{
    public interface IControlChartFactory
    {
        IControlChart CreateControlChart(ControlChartType chartType,
            Dictionary<string, decimal> parameters);
    }

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
                case ControlChartType.StandardDeviationPreSpecified:
                    chart = CreateStandardDeviationPreSpecifiedChart(_subgroups, parameters);
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
            var mu0 = Helpers.GetParameterValue(parameters, "mu0");
            var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");

            return new XBarChartPreSpecified(subgroups, mu0, sigma0);
        }

        private static RChartPreSpecified CreateRangePreSpecifiedChart(List<ISubgroup> subgroups,
            Dictionary<string, decimal> parameters)
        {
            var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");
            return new RChartPreSpecified(subgroups, sigma0);
        }

        private static SChartPreSpecified CreateStandardDeviationPreSpecifiedChart(List<ISubgroup> subgroups,
            Dictionary<string, decimal> parameters)
        {
            var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");
            return new SChartPreSpecified(subgroups, sigma0);
        }
    }

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
                default:
                    throw new ArgumentException();
            }

            chart.Calculate();

            return chart;
        }

        private RChart CreateRangeChart(List<decimal> _individualValues, Dictionary<string, decimal> parameters)
        {
            var subgroupSize = (int)Helpers.GetParameterValue(parameters, "subgroupSize");
            return new RChart(_individualValues, subgroupSize);
        }

        private static RMChartPreSpecified CreateMovingRangePreSpecified(List<decimal> individualValues, Dictionary<string, decimal> parameters)
        {
            var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");
            return new RMChartPreSpecified(individualValues, sigma0);
        }

        private static XIndividualPreSpecified CreateIndividualPreSpecifiedChart(List<decimal> individualValues, Dictionary<string, decimal> parameters)
        {
            var mu0 = Helpers.GetParameterValue(parameters, "mu0");
            var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");
            return new XIndividualPreSpecified(individualValues, mu0, sigma0);
        }

    }
}