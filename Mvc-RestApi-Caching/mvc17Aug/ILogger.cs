using System.Drawing;

namespace mvc17Aug
{
    public interface ILogger
    {
        public void AddLog(int userID, String LogType);
    }
}
