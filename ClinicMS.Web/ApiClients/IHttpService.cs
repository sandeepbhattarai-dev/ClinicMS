namespace ClinicMS.Web.ApiClients
{
  public interface IHttpService
  {
    Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken);
    Task<T?> PostAsync<T>(string url, Object? Payload, CancellationToken cancellationToken);
    Task<T?> PutAsync<T>(string url, Object? Payload, CancellationToken cancellationToken);
    Task<T?> DeleteAsync<T>(string url, CancellationToken cancellationToken);
  }
}
