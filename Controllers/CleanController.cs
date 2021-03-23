using System;
using System.Collections.Generic;
using System.Linq;
using AUroomAPI.Controllers;
using AUroomAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AURoomAPI.Controllers
{
    [Route("api/[controller]")]
    public class CleanController : BaseController
    {
        public CleanController(ApplicationDbContext db) : base(db) { }

        [HttpGet]
        public ActionResult Index()
        {
            var timeSpan = new TimeSpan(18, 0, 0);
            var result = _db.CourseExaminationSlots.Include(x => x.ExaminationSlot)
                .Where(x => TimeSpan.Compare(timeSpan, x.ExaminationSlot.TimeStart) != 1);

            // _db.CourseExaminationSlots.RemoveRange(result);
            // _db.SaveChanges();
            return Ok("done");
        }

        [HttpGet("room")]
        public ActionResult Room()
        {
            var campusId = 2; // suvan campus
            var buildingIds = new List<long> { 14, 15, 16 }; // SR, SM, SG

            var rooms = _db.Rooms.Include(x => x.Building)
                                 .Where(x => x.Building.CampusId == campusId
                                             && !buildingIds.Contains(x.BuildingId))
                                 .ToList();
            
            rooms.Select(x => {
                x.IsAllowAutoAssign = false;
                return x;
            }).ToList();

            _db.SaveChanges();
            return Ok("done");
        }

        [HttpGet("seatused")]
        public ActionResult SeatUsed()
        {
            var sections = _db.Sections;
            
            foreach(var i in sections){
                i.SeatUsed = _db.StudentStudyCourses.Count(x => x.SectionId == i.Id);
            }

            _db.SaveChanges();
            return Ok("done");
        }

        [HttpGet("sectiondetail")]
        public ActionResult SectionDetail()
        {
            var sectionIds = _db.SectionDetails.Select(x => x.SectionId)
                                               .Distinct()
                                               .ToList();

            var section = _db.Sections.Where(x => !sectionIds.Contains(x.Id)).ToList();

            section.Select(x => {
                                    x.IsActive = false;
                                    return x;
                                })
                   .ToList();

            _db.SaveChanges();

            return Ok("done");
        }

        [HttpGet("academicProgram")]
        public ActionResult AcademicProgram()
        {
            var student = _db.StudentStudyCourses.Include(x => x.Student)
                                                     .ThenInclude(x => x.AcademicInformation)
                                                     .ThenInclude(x => x.AcademicProgram)
                                                 .Where(x => x.Student.AcademicInformation.AcademicProgramId != 1);

            _db.StudentStudyCourses.RemoveRange(student);
            _db.SaveChanges();

            return Ok("done");
        }

        // [HttpGet("studyCourse")]
        // public ActionResult StudyCourse()
        // {
        //     var activeSections = _db.Sections.IgnoreQueryFilters()
        //                                        .Where(x => x.IsActive)
        //                                        .Select(x => x.Id)
        //                                        .ToList();

        //     var students = _db.StudentStudyCourses.Where(x => !activeSections.Contains(x.SectionId));

        //     _db.StudentStudyCourses.RemoveRange(students);
        //     _db.SaveChanges();

        //     return Ok("done");
        // }

        // [HttpGet("courseslot")]
        // public ActionResult CourseSlot()
        // {
        //     var coursesSlots = _db.CourseExaminationSlots.Include(x => x.ExaminationSlot)
        //                                                  .Include(x => x.Course)
        //                                                      .ThenInclude(x => x.Sections)
        //                                                  .Where(x => !x.Course.Sections.Where(y => y.SemesterId == x.ExaminationSlot.SemesterId)
        //                                                                                .Any());

        //     _db.CourseExaminationSlots.RemoveRange(coursesSlots);
        //     _db.SaveChanges();
            
        //     return Ok("done");
        // }

        // [HttpGet("course")]
        // public ActionResult Course()
        // {
        //     var courses = _db.Courses.Include(x => x.Sections)
        //                              .Where(x => !x.Sections.Any());

        //     _db.Courses.RemoveRange(courses);
        //     _db.SaveChanges();

        //     return Ok("done");
        // }

        // academic program
    }
}