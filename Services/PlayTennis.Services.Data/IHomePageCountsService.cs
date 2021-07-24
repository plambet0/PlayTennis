namespace PlayTennis.Services.Data
{
    using PlayTennis.Web.ViewModels.Home;

    public interface IHomePageCountsService
    {

        IndexViewModel GetCounts();
    }
}
