namespace Business;

public enum ControlChartType
{
    MeanRange, // x-bar by r
    MeanStandardDeviation, // x-bar by s
    Range, // r for x-bar
    StandardDeviation, // s
    Individual, // x
    MovingRange, // rm
    Median, // x-tilde
    ProportionDefective, // p
    NumberDefective, // np
    NumberDefects, // c
    DefectsPerUnit, // u


    MeanPreSpecified, // x-bar
    RangePreSpecified, // r for x-bar PreSpecified
    StandardDeviationPreSpecified,
    IndividualPreSpecified, // x pre-specified
    MovingRangePreSpecified, // rm pre-specified
    MedianPreSpecified, // x-tilde pre-specified
    ProportionDefectivePreSpecified, // p pre-specified
    NumberDefectivePreSpecified, // np pre-specified
    NumberDefectsPreSpecified, // c pre-specified
    DefectsPerUnitPreSpecified // u pre-specified
}