using Business.ControlCharts;
using Business.ControlCharts.Individual;
using Business.ControlCharts.Mean;
using Business.ControlCharts.Range;
using Business.ControlCharts.StandardDeviation;

namespace Business;

public interface IControlChartFactory
{
    public ControlChart CreateControlChart(ControlChartType chartType,
        Dictionary<string, double> parameters);
}

public class SubgroupControlChartFactory(List<Subgroup> subgroups) : IControlChartFactory
{

    private readonly List<Subgroup> _subgroups = subgroups;

    public ControlChart CreateControlChart(ControlChartType chartType,
        Dictionary<string, double> parameters)
    {
        ControlChart chart = chartType switch
        {
            ControlChartType.MeanRange => new XBarChartCalculatedWithRange(_subgroups),
            ControlChartType.MeanStandardDeviation => new XBarChartCalculatedWithStandardDeviation(_subgroups),
            ControlChartType.Range => new RChart(_subgroups),
            ControlChartType.StandardDeviation => new SChart(_subgroups),
            ControlChartType.MovingRange => new RMChart(_subgroups),
            ControlChartType.Median => throw new NotImplementedException(),
            ControlChartType.ProportionDefective => throw new NotImplementedException(),
            ControlChartType.NumberDefective => throw new NotImplementedException(),
            ControlChartType.NumberDefects => throw new NotImplementedException(),
            ControlChartType.DefectsPerUnit => throw new NotImplementedException(),
            ControlChartType.MeanPreSpecified => CreateMeanPreSpecifiedChart(_subgroups, parameters),
            ControlChartType.RangePreSpecified => CreateRangePreSpecifiedChart(_subgroups, parameters),
            ControlChartType.StandardDeviationPreSpecified => CreateStandardDeviationPreSpecifiedChart(_subgroups,
                parameters),
            ControlChartType.MovingRangePreSpecified => CreateMovingRangePreSpecified(_subgroups, parameters),
            ControlChartType.ProportionDefectivePreSpecified => throw new NotImplementedException(),
            ControlChartType.NumberDefectivePreSpecified => throw new NotImplementedException(),
            ControlChartType.NumberDefectsPreSpecified => throw new NotImplementedException(),
            ControlChartType.DefectsPerUnitPreSpecified => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException(nameof(chartType), chartType, null)
        };

        chart.Calculate();
        return chart;
    }

    private static RMChartPreSpecified CreateMovingRangePreSpecified(List<Subgroup> subgroups, Dictionary<string, double> parameters)
    {
        var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");
        return new(subgroups, sigma0);
    }

    private static XBarChartPreSpecified CreateMeanPreSpecifiedChart(List<Subgroup> subgroups,
        Dictionary<string, double> parameters)
    {
        var mu0 = Helpers.GetParameterValue(parameters, "mu0");
        var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");

        return new(subgroups, mu0, sigma0);
    }

    private static RChartPreSpecified CreateRangePreSpecifiedChart(List<Subgroup> subgroups,
        Dictionary<string, double> parameters)
    {
        var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");
        return new(subgroups, sigma0);
    }

    private static SChartPreSpecified CreateStandardDeviationPreSpecifiedChart(List<Subgroup> subgroups,
        Dictionary<string, double> parameters)
    {
        var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");
        return new(subgroups, sigma0);
    }
}

public class IndividualControlChartsFactory(List<double> individualValues) : IControlChartFactory
{
    private readonly List<double> _individualValues = individualValues;
    public ControlChart CreateControlChart(ControlChartType chartType, Dictionary<string, double> parameters)
    {
        ControlChart chart = chartType switch
        {
            ControlChartType.Individual => new XIndividual(_individualValues),
            ControlChartType.IndividualPreSpecified => CreateIndividualPreSpecifiedChart(_individualValues, parameters),
            _ => throw new ArgumentException()
        };

        chart.Calculate();

        return chart;
    }

    private static XIndividualPreSpecified CreateIndividualPreSpecifiedChart(List<double> individualValues, Dictionary<string, double> parameters)
    {
        var mu0 = Helpers.GetParameterValue(parameters, "mu0");
        var sigma0 = Helpers.GetParameterValue(parameters, "sigma0");
        return new(individualValues, mu0, sigma0);
    }

}