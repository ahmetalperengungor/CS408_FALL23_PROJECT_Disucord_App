using System.Net.Sockets;

namespace CS408_PROJECT_DISUCORD_DAL
{
    [Serializable]
    public class DataMessage
    {
        public string Username { get; set; }
        public int ChannelId { get; set; } // 0 -> Server, 1 -> SPS, 2 -> IF
        public int Status { get; set; } // 0 -> Connect, 1 -> Disconnect, 2 -> Message
        public string Messaqe { get; set; }
    }
}