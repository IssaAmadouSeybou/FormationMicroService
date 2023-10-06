using Mango.web.Models;
using Mango.web.Service.IService;
using Newtonsoft.Json;
using System.Text;
using static Mango.web.Utulity.SD;

namespace Mango.web.Service
{
	public class BaseService : IBaseService
	{
		private readonly IHttpClientFactory _httpClientFactory;
        public BaseService()
        {

        }
		public BaseService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
		{
			try
			{
                HttpClient client = _httpClientFactory.CreateClient("MangoAPi");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? apiResponse = null;
                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                switch (apiResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new() { Success = false, Message = "Not found" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new() { Success = false, Message = "Access Denied" };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new() { Success = false, Message = "Not found" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new() { Success = false, Message = "Error Internal Server Detected" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }catch(Exception ex)
            {
                var dto = new ResponseDto()
                {
                    Message = ex.Message.ToString(),
                    Success = false
                };
                return dto;
            }
			
		}
	}
}
