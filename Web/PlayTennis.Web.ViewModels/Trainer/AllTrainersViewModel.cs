namespace PlayTennis.Web.ViewModels.Trainer
{
    using System.Collections.Generic;

    public class AllTrainersViewModel : PagingViewModel
    {
        public IEnumerable<TrainerViewModel> Trainers { get; set; }
    }
}
