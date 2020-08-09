using DoFest.Business.Identity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class NewPasswordModelExtensions
    {
        public static NewPasswordModelRequest WithNewPassword(this NewPasswordModelRequest modelRequest, string newPassword)
        {
            modelRequest.NewPassword = newPassword;
            return modelRequest;
        }
    }
}
