using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicMs.Shared.Models
{

  public class PaginatedResult
  {
    public int TotalCount { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)Math.Max(PageSize, 1));
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
  }
  public sealed class PaginatedResult<T> : PaginatedResult
  {
    public IReadOnlyCollection<T> Items { get; init; } = Array.Empty<T>();

    public static PaginatedResult<T> Create(IEnumerable<T> items, int totalCount, int page, int pageSize)
    {
      return new PaginatedResult<T>
      {
        IsSuccess = true,
        Items = items.ToArray(),
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize
      };
    }
    public static PaginatedResult<T> Fail(string message)
    {
      return new PaginatedResult<T>
      {
        IsSuccess = false,
        Message = message
      };
    }
  }
}
