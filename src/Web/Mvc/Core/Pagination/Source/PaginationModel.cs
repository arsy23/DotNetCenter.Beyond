namespace DotNetCenter.Beyond.Web.Mvc.Core.Pagination
{
    using System.Collections.Generic;
    public class PaginationModel<T>
    {
            public PaginationModel(IEnumerable<T> data,
                                   int page,
                                   int totalItems,
                                   int pageSize,
                                   int maxPages)
            {
                Items = data;
                Page = page;
                TotalItems = totalItems;
                PageSize = pageSize;
                MaxPages = maxPages;
                BuildPager();
            }
            public IEnumerable<T> Items { get; private set; }
            public int Page { get; private set; }
            public WebPageContentInfo Pager { get; private set; }
            public int TotalItems { get; private set; }
            public int PageSize { get; private set; }
            public int MaxPages { get; private set; }
            public void DataSubstitution(IEnumerable<T> data) => Items = data;
            private void BuildPager() 
                => Pager = new WebPageContentInfo (TotalItems, Page, PageSize, MaxPages);
    }
}
