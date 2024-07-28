namespace Halan.Common
{
    public class PagedList<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}
