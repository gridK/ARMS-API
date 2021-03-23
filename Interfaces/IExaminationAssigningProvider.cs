using System.Collections.Generic;
using AUroomAPI.Models.DataModels;
using AURoomAPI.Models;

namespace AURoomAPI.Interfaces
{
    public interface IExaminationAssigningProvider
    {
        ExaminationAssigningResultViewModel ManualAssigning(ExaminationAssigningViewModel model);
        ExaminationAssigningResultViewModel AutoAssigning(ExaminationAssigningViewModel model);
    }
}