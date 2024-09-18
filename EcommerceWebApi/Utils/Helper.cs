using EcommerceWebApi.Dtos.Response;

namespace EcommerceWebApi.Utils
{
    public static class Helper
    {
        public static PaginationDto<T> GetPaginationResult<T>(List<T> dataList, int count)
        {

            if (dataList == null)
                throw new ArgumentException("Data is invalid.");

            int totalPage = (int)Math.Ceiling((double)count / ConstConfig.PageSize);

            var result = new PaginationDto<T>
            {
                Data = dataList,
                TotalPage = totalPage
            };

            return result;
        }

        public static PaginationDto<T> GetPaginationResult<T>(List<T> dataList, int count, int pageSize)
        {
            if (dataList == null || pageSize <= 0)
                throw new ArgumentException("Data or page size is invalid.");

            int totalPage = (int)Math.Ceiling((double)count / pageSize);

            var result = new PaginationDto<T>
            {
                Data = dataList,
                TotalPage = totalPage
            };

            return result;
        }

        public static ErrorDto ErrorResponse(string message)
        {
            return new ErrorDto
            {
                Message = message
            };
        }
    }
}
