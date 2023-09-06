using mvc17Aug.Models;
namespace mvc17Aug
{
    public class DatabaseLogger : ILogger
    {
        private readonly IRepository<Logger> _context;
        public DatabaseLogger(IRepository<Logger> context)
        {
            this._context = context;
        }
        public void AddLog(int userID, String LogType)
        {
            var logger = new Logger
            {
                CreatedTime = DateTime.Now,
                UserID = userID,
                LogType = LogType
            };
            _context.Add(logger);
        }
    }
}
