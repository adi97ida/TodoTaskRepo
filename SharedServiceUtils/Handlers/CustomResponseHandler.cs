using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServiceUtils.Handlers
{
    class CustomResponseHandler
    {
        static ErrorResponse DoReturnWithMessage(string message, int code)
        {
            return new ErrorResponse {
                Message = message,
                Code = code,
            };
        }
    }
}
