namespace api.Services
{
    public class PaginationMetadata
    {
        public int TotalCardCount { get; set; } 
        public int TotalPageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PaginationMetadata(int totalCardCount, int pageSize, int currentPage) 
        { 
            TotalCardCount = totalCardCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPageCount = (int)Math.Ceiling(totalCardCount / (double)9);
        }
    }
}
