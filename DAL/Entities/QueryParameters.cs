namespace WebApi.Controllers
{
    public class QueryParameters
    {
        const int maxPagSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public string Name { get; set; } = string.Empty;
        public int PageSize
        {
            get { return pageSize;  }
            set { pageSize = (value > maxPagSize ? maxPagSize : value); }
        }
    }
}
