namespace PlayTennis.Web.ViewModels.Player
{
    using System.Collections.Generic;

    public class AllPlayersViewModel : PagingViewModel
    {
        public IEnumerable<PlayersViewModel> Players { get; set; }
    }
}
