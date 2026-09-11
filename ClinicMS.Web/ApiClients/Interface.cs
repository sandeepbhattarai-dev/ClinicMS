namespace ClinicMS.Web.ApiClients
{
  public interface IHttpService
  {
    Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken = default);
    Task<T?> PostAsync<T>(string url, Object? Payload, CancellationToken cancellationToken = default);
    Task<T?> PutAsync<T>(string url, Object? Payload, CancellationToken cancellationToken = default);
    Task<T?> DeleteAsync<T>(string url, CancellationToken cancellationToken = default);
  }
}
