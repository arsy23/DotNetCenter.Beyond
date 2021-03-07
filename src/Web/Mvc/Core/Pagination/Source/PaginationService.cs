namespace DotNetCenter.Beyond.Web.Mvc.Core.Pagination
{
    using System.Collections.Generic;
    public class PaginationService<T>
    {
        public PaginationModel<T> Model { get; private set; }
        public PaginationModel<T> GetPagination(List<T> data, int totalItems, int page = 1, int pageSize = 10, int maxPages = 10)
            => new PaginationModel<T>(data, page, totalItems, pageSize, maxPages);
        public void DataSubstitution(IEnumerable<T> data) => Model.DataSubstitution(data);
    }
}