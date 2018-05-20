namespace QA.Core.Model.Users
{
    public class AthleteAccount
    {
        public static AthleteAccount GetNew()
        {
            return new AthleteAccount();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ADPId { get; set; }

        public ProfileSourceType SourceType { get; set; }
        public string SourceAthleteId { get; set; }
        public string SourceKey { get; set; }
    }
}