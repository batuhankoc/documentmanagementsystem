using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dms.Contract.ResponseContracts
{
    public class ApiResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { IsSuccessful = true, Data = data };
        }

        public static ApiResponse<T> Error(string message)
        {
            return new ApiResponse<T> { IsSuccessful = false, Message = message };
        }
    }
}
