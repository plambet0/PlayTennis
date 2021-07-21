

using PlayTennis.Web.ViewModels.Trainer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
    public interface ITrainersService
    {
        Task CreateAsync(TrainerInputModel input, string userId);

        IEnumerable<TrainerViewModel> GetAll(int page, int itemsPerPage = 12);

        bool IsAPlayer(string userId);
    }
}
