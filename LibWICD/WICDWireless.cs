using org.freedesktop.DBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWICD
{
    public class WICDWireless
    {
        private IWICDWireless _wirelessInterface;

        public event EventHandler ScanCompleted;

        internal WICDWireless(IWICDWireless wirelessInterface)
        {
            _wirelessInterface = wirelessInterface;
            _wirelessInterface.SendEndScanSignal += delegate ()
            {
                ScanCompleted?.Invoke(this, EventArgs.Empty);
            };
        }

        public WirelessInfo GetInfo()
        {
            string iwconfig = _wirelessInterface.GetIwconfig();
            return new WirelessInfo(_wirelessInterface, iwconfig);
        }

        //public string getsavednetworks()
        //{
        //    string[] networks = _wirelessinterface.getsavedwirelessnetworks();
        //    console.writeline(networks[0]);
        //    return "asf";
        //}

        public void Scan(bool sync)
        {
            _wirelessInterface.Scan(Utils.BoolToVariant(sync));
        }

        public int GetNumberOfNetworks()
        {
            return _wirelessInterface.GetNumberOfNetworks();
        }

        public Dictionary<int, AccessPoint> GetScanResult()
        {
            Dictionary<int, AccessPoint> accessPoints = new Dictionary<int, AccessPoint>();

            int networkCount = GetNumberOfNetworks();

            for (int i = 0; i < networkCount; i++)
            {
                string networkId = Utils.IntToVariant(i);

                string ssid = _wirelessInterface.GetWirelessProperty(networkId, Utils.StringToVariant("essid"));
                string bssid = _wirelessInterface.GetWirelessProperty(networkId, Utils.StringToVariant("bssid"));
                int signalStrength = int.Parse(_wirelessInterface.GetWirelessProperty(networkId, Utils.StringToVariant("quality")));
                int dbm = int.Parse(_wirelessInterface.GetWirelessProperty(networkId, Utils.StringToVariant("strength")));

                accessPoints[i] = new AccessPoint(ssid, bssid, signalStrength, dbm);
            }

            return accessPoints;
        }

        public void Connect(int networkId)
        {
            _wirelessInterface.ConnectWireless(Utils.IntToVariant(networkId));
        }

        public void Disconnect()
        {
            _wirelessInterface.DisconnectWireless();
        }
    }
}
