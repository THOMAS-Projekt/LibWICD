using LibWICD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WICDDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            WICD wicd = new WICD();
            WICDWireless wireless = wicd.GetWireless();

            WirelessInfo info = wireless.GetInfo();

            Console.WriteLine("Current:");
            Console.WriteLine($" - SSID: {info.QuerySSID()}");
            Console.WriteLine($" - SignalStrength: {info.QuerySignalStrength()}");
            Console.WriteLine($" - DBM: {info.QueryDBM()}");
            Console.WriteLine($" - Bitrate: {info.QueryBitrate()}");
            Console.WriteLine();

            wireless.ScanCompleted += Wireless_ScanCompleted;
            wireless.Scan(false);

            Console.ReadLine();
        }

        private static void Wireless_ScanCompleted(object sender, EventArgs e)
        {
            // Do further DBus-Requests after the event-invoke is completed.
            Task.Run(() =>
            {
                try
                {
                    Dictionary<int, AccessPoint> accessPoints = ((WICDWireless)sender).GetScanResult();

                    foreach (KeyValuePair<int, AccessPoint> entry in accessPoints)
                    {
                        Console.WriteLine($"[{entry.Key}] {entry.Value.SSID}:");
                        Console.WriteLine($" - BSSID: {entry.Value.BSSID}");
                        Console.WriteLine($" - SignalStrength: {entry.Value.SignalStrength}");
                        Console.WriteLine($" - DBM: {entry.Value.Dbm}");
                    }
                    Console.WriteLine();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
    }
}
