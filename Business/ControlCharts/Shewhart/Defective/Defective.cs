namespace Business.ControlCharts.Defective
{
    public struct Defective
    {
        public int DefectiveCount;
        public int AllItemsCount;

        public Defective(int defectiveCount, int allItemsCount)
        {
            if (defectiveCount < 0)
            {
                throw new ArgumentException("Defective count can't be negative", nameof(defectiveCount));
            }
            DefectiveCount = defectiveCount;

            if (allItemsCount < defectiveCount)
            {
                throw new ArgumentException("There can't be more defectives than all item count.");
            }
            AllItemsCount = allItemsCount;
        }
    }
}
