using System;
using AUroomAPI.Data;
using AUroomAPI.Models;
using AURoomAPI.Interfaces;
using AURoomAPI.Models.DataModels;

namespace AURoomAPI.Providers
{
    public class LogProvider : ILogProvider
    {
        protected readonly ApplicationDbContext _db;

        public LogProvider(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool RecordExaminationAssigning(string logType, string activityType, string user, long semesterId, long examinationTypeId)
        {
            try
            {
                var model = new ExaminationAssigningLog
                            {
                                LogType = logType,
                                ActivityType = activityType,
                                CreatedAt = DateTime.UtcNow,
                                CreatedBy = user,
                                SemesterId = semesterId,
                                ExaminationTypeId = examinationTypeId
                            };

                _db.ExaminationAssigningLogs.Add(model);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RecordManualAssign(string course, string user, long semesterId, long examinationTypeId)
        {
            return RecordExaminationAssigning(Message.ManualAssign, Message.AssigningCompleted(course), user, semesterId, examinationTypeId);
        }

        public bool RecordAutoAssign(string user, long semesterId, long examinationTypeId)
        {
            return RecordExaminationAssigning(Message.AutoAssign, Message.AssigningCompleted(), user, semesterId, examinationTypeId);
        }

        public bool RecordDissolved(int code, string user, long semesterId, long examinationTypeId)
        {
            string dissolvedType;

            switch (code)
            {
                case 1: dissolvedType =Message.DissolvedAllManualCourses; break;
                case 2: dissolvedType = Message.DissolvedAllAutoCourses; break;
                default: dissolvedType = Message.DissolvedCourses; break;
            }
            return RecordExaminationAssigning(dissolvedType, Message.DissolvingCompleted(), user, semesterId, examinationTypeId);
        }

        public bool RecordDissolved(string course, string user, long semesterId, long examinationTypeId)
        {
            return RecordExaminationAssigning(Message.DissolvedCourse, Message.DissolvingCompleted(course), user, semesterId, examinationTypeId);
        }
    }
}