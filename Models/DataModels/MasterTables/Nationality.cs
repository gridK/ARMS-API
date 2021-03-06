using System;
using System.ComponentModel.DataAnnotations;

namespace AUroomAPI.Models.DataModels.MasterTables
{
    public class Nationality : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }
    }
}