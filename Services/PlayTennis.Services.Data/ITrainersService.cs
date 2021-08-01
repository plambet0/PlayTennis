namespace PlayTennis.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PlayTennis.Web.ViewModels.Trainer;

    public interface ITrainersService
    {
        Task CreateAsync(TrainerInputModel input, string userId);

        IEnumerable<TrainerViewModel> GetAll(int page, int itemsPerPage = 12);

        bool IsAPlayer(string userId);

        bool IsRegistered(string userId);

        TrainerInputModel GetById(int id);
    }
}
