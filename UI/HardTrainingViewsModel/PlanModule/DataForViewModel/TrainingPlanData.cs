using System;

namespace HardTrainingViewsModel.PlanModule.DataForViewModel
{
    public class TrainingPlanData
    {
        public string NameOfPlan { get; set; }
        public string AimOfPlan { get; set; }

        public DateTime DateOfBegin { get; set; }
        public DateTime DateOfEnd { get; set; }
    }
}