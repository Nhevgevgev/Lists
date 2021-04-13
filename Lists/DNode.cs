namespace Lists
{
    public class DNode
    {
        public int Value { get; set; }
        public DNode Next { get; set; }
        public DNode Previous { get; set; }

        public DNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}