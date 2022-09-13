// 

using Services.BackendApi.Models;

public class WorkTaskStorageService
{
    private readonly HttpClient _client;

    public WorkTaskStorageService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<WorkTaskInfo>> GetWorkTasks()
    {
        using (var request = new HttpRequestMessage(HttpMethod.Get,"/WorkTaskStorage/all"))
        {
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<WorkTaskInfo>>();
        }
    }
}