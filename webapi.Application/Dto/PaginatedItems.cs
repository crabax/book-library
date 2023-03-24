namespace webapi.Application.Dto
{
    public class PaginatedItems<T>
    {
        public PaginatedItems(T items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
        public T Items { get; set; }
        public int TotalCount { get; set; }
    }
}
