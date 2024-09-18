namespace EcommerceWebApi.Utils.QueryParams
{
    public class ProductTypeQP
    {
        private int _page = 1;

        public string? SortBy { get; set; }

        public int Page
        {
            get => _page;
            set => _page = value >= 1 ? value : _page;
        }
    }
}
