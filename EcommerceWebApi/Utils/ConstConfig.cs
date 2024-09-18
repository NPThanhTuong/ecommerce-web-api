namespace EcommerceWebApi.Utils
{
    public class ConstConfig
    {
        // Pagination
        public const int PageSize = 2;


        // Error message
        public const string InvalidId = "Id is invalid!";
        public const string NotFound = "Not found!";
        public const string InternalServer = "Something went wrong!";

        // Field's Length
        public const int DisplayNameLength = 32;
        public const int ShortNameLength = 32;
        public const int MediumNameLength = 64;
        public const int LongNameLength = 128;
        public const int ImagePathLength = 256;
        public const int MinPasswordLength = 8;
        public const int MaxPasswordLength = 20;
        public const int DescriptionLength = 4096;
        public const int LongDescriptionLength = 8000;
    }
}
