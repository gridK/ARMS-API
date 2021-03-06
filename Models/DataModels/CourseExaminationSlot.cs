using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUroomAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace AUroomAPI.Models.DataModels
{
    public class CourseExaminationSlot : UserTimeStamp
    {
        public long Id { get; set; }
        public long CourseId {get;set;}
        public long ExaminationSlotId {get; set;}
    

        
        [ForeignKey("CourseId")]
        public virtual Course Course {get; set;}

        [ForeignKey("ExaminationSlotId")]
        public virtual ExaminationSlot ExaminationSlot {get; set;}
        
        
    }
}