using System;

namespace PlayTennis.Web.ViewModels
{
    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.JobsCount / this.ItemsPerPage);

        public int JobsCount { get; set; }

        public int WorkersCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
