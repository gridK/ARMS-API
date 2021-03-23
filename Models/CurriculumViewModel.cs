using System;
using System.Collections.Generic;
using AUroomAPI.Models.DataModels.Curriculums;

namespace AUroomAPI.Models
{
    public class CurriculumViewModel
    {
        public Curriculum Curriculum { get; set; }
        public CurriculumVersion Version { get; set; }
        public List<long> InstructorIds { get; set; }
    }
}