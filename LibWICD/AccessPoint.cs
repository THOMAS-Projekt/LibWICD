namespace LibWICD
{
    public class AccessPoint
    {
        public string SSID { get; }
        public string BSSID { get; }
        public int SignalStrength { get; }
        public int Dbm { get; }

        public AccessPoint (string ssid, string bssid, int signalStrength, int dbm)
        {
            SSID = ssid;
            BSSID = bssid;
            SignalStrength = signalStrength;
            Dbm = dbm;
        }
    }
}