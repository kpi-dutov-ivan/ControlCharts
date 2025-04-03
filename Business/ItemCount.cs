namespace Business
{
    public class ItemCount
    {
        public int Count { get; }
        public int MaxCount { get; }

        public ItemCount(int count, int maxCount)
        {
            if (count <= 0)
                throw new ArgumentException("Item count can't be negative.");
            if (maxCount < count)
                throw new ArgumentException("Max count can't be less than item count");
            Count = count;
            MaxCount = maxCount;
        }
    }
}
