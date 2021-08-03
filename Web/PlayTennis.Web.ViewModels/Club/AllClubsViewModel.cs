namespace PlayTennis.Web.ViewModels.Club
{
    using System.Collections.Generic;

    public class AllClubsViewModel : PagingViewModel
    {
        public IEnumerable<ClubsViewModel> Clubs { get; set; }
    }
}
