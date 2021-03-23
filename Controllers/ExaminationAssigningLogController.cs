using System;
using System.Linq;
using System.Threading.Tasks;
using AUroomAPI.Data;
using AUroomAPI.Interfaces;
using AUroomAPI.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AUroomAPI.Controllers
{
     [Route("api/[controller]")]
    public class ExaminationAssigninglogController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public ExaminationAssigninglogController(ApplicationDbContext db,
                                               IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
        

        [HttpGet("semesterid={id},ExaminationTypeId={Typeid}")]

        //GET api/room
        public IActionResult Index(long id,long Typeid)
        {
           var Logs = _db.ExaminationAssigningLogs.Where(x => x.SemesterId == id 
                                                            && x.ExaminationTypeId == Typeid)
                                                 .Select(x => new {
                                                    x.LogType,
                                                    x.ActivityType,
                                                    x.CreatedAt,
                                                    x.CreatedBy
                                                 })
                                                 .ToList();

            return Ok(Logs);
        }

    }
}
