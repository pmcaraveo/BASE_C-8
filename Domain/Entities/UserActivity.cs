using System;

namespace TSJ.Domain
{
    public class UserActivity 
    {
        public int Id { get; set; }
        public string url { get; set; }
        public string data { get; set; }
        public string username { get; set; }
        public string ipAddress { get; set; }
        public DateTime activityDate { get; set; } = DateTime.Now;
        public string macAddress { get; set; }
    }
}