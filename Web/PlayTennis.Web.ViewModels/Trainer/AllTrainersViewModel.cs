namespace PlayTennis.Web.ViewModels.Trainer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AllTrainersViewModel : PagingViewModel
    {
        public IEnumerable<TrainerViewModel> Trainers { get; set; }
    }
}
