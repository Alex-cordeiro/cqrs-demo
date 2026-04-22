using System;

namespace CQRS.Demo.API.Models;

public class PagedResponse<T> where T : class
{
    public int CurrentPage { get; set; }
    public int TotalCount { get; set; }
    public int TotalRows { get; set; }
    public int PageSize { get; set; }
    public IList<T> Data { get; set; }
}
