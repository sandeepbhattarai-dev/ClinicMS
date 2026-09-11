using System.Net;
using System.Text;
using System.Text.Json;

namespace ClinicMS.Web.ApiClients
{
  public class HttpService : IHttpService
  {

    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
      PropertyNameCaseInsensitive = true
    };


    private readonly HttpClient _httpClient;
    public HttpService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }
    public Task<T?> DeleteAsync<T>(string url, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<T?> PostAsync<T>(string url, object? Payload, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<T?> PutAsync<T>(string url, object? Payload, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    private async Task<T?> SendAsync<T>(HttpMethod Method, string url, Object? Payload, CancellationToken cancellationToken)
    {
      using var request = BuildHttpRequest(Method, url, Payload);
      using var response = await _httpClient.SendAsync(request, cancellationToken);

      var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

      if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
      {
        throw new Exception("Access Denied");
      }

      if (string.IsNullOrWhiteSpace(responseText))
      {
        return default;
      }

      // Deserialize both success and error payloads so callers can surface server-side messages.
      return JsonSerializer.Deserialize<T>(responseText, SerializerOptions);
    }

    private HttpRequestMessage BuildHttpRequest(HttpMethod Method, string url, Object? Payload)
    {
      using var request = new HttpRequestMessage(Method, url);
      if (Payload is not null)
      {
        var json = JsonSerializer.Serialize(Payload);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
      }
      return request;
    }
  }
}
