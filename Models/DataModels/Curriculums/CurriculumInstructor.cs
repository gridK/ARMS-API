using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUroomAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;
using System.Linq;

namespace AUroomAPI.Models.DataModels.Curriculums
{
    public class CurriculumInstructor : UserTimeStamp
    {
        public long CurriculumVersionId { get; set; }
        public long InstructorId { get; set; }

        [JsonIgnore]
        public virtual CurriculumVersion CurriculumVersion { get; set; }

        [JsonIgnore]
        public virtual Instructor Instructor { get; set; }
    }
}