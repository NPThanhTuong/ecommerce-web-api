using Microsoft.IdentityModel.Tokens;

namespace EcommerceWebApi.Utils.QueryParams
{
    public class ProductQP
    {
        private int _page = 1;
        private string _sortBy = "id";
        private string _sortType = "asc";

        public string? FByPrice { get; set; }
        public string? FByType { get; set; }
        public string? Search { get; set; }

        public int Page
        {
            get => _page;
            set => _page = value >= 1 ? value : _page;
        }

        public string SortBy
        {
            get => _sortBy;
            set => _sortBy = value.IsNullOrEmpty() ? _sortBy : value.ToLower();
        }

        public string SortType
        {
            get => _sortType;
            set => _sortType = value.IsNullOrEmpty() ? _sortType : value.ToLower();
        }
    }
}
