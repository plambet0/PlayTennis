using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTennis.Web.ViewModels.Trainer
{
    public class AllTrainersViewModel : PagingViewModel
    {
        public IEnumerable<TrainerViewModel> Trainers { get; set; }
    }
}
