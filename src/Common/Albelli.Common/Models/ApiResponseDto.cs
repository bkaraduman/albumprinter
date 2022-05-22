using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Albelli.Common.Models
{
    public class ApiResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object? Result { get; set; }

        public ApiResponseDto()
        {
            IsSuccess = true;
            Message = "";
            StatusCode = (int)ResponseCode.Success;
        }

        public override string ToString()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

        }

    }
}
