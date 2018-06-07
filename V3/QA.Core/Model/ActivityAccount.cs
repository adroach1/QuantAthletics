using System;
using QA.Core.Model.Users;

namespace QA.Core.Model
{
    public class ActivityAccount
    {
        public static ActivityAccount GetNew()
        {
            return new ActivityAccount();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ActivityDataProviderId { get; set; }
        public ActivityDataProvider ActivityDataProvider { get; set; }
        public ProfileSourceType SourceType { get; set; }
        public string SourceAthleteId { get; set; }
        public string SourceKey { get; set; }
        public DateTime DateAdded { get; set; }
    }
}