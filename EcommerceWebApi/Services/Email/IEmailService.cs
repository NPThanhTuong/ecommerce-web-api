using EcommerceWebApi.Dtos.Request;

namespace EcommerceWebApi.Services.Email
{
    public interface IEmailService
    {
        public void SendEmail(EmailReqDto emailRequest);
    }
}
