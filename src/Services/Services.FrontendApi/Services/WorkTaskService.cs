// 

using Services.FrontendApi.Models;

namespace Services.FrontendApi.Services;

public class WorkTaskBackendService
{
    private readonly HttpClient _client;

    public WorkTaskBackendService(HttpClient client)
    {
        _client = client;
    }
    public async Task< IEnumerable<WorkTask>> GetAllTasks()
    {

        using (var request = new HttpRequestMessage(HttpMethod.Get,"/WorkTaskBackend/All"))
        {
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<WorkTask>>();
        }

    }
}