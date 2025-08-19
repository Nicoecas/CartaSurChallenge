using CartaSurChallenge.Models;

namespace CartaSurChallenge.Services
{
    public interface IApiService
    {
        Task<ApiModel> GetApiStatusAsync();
    }

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _api;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _api = "https://svct.cartasur.com.ar/api/dummy";
        }

        public async Task<ApiModel> GetApiStatusAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_api);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (content.Contains("Status:", StringComparison.OrdinalIgnoreCase))
                    {
                        var statusValue = content
                            .Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                            .LastOrDefault();

                        if (!string.IsNullOrEmpty(statusValue))
                        {
                            return new ApiModel { Status = statusValue };
                        }
                    }
                }

                return new ApiModel { Status = "Error" };
            }
            catch (Exception ex)
            {
                return new ApiModel { Status = "ParseError" };
            }
        }
    }
}