namespace Business
{
    class MeanMovingRangesChart(List<Subgroup> subgroups) : ControlChart(subgroups)
    {
        public override void Calculate(List<Subgroup> subgroups)
        {
            base.Calculate(subgroups);
            Values = subgroups.Select(subgroup => subgroup.Mean).ToList();
            var meanOfSubgroups = Values.Average();
            CenterLine = meanOfSubgroups;
        }
    }
}
