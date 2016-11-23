using NDesk.DBus;
using org.freedesktop.DBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWICD
{
    public delegate void ScanCompletedHandler();

    [Interface("org.wicd.daemon.wireless")]
    internal interface IWICDWireless : Introspectable
    {
        event ScanCompletedHandler SendEndScanSignal;

        string GetIwconfig();

        string GetCurrentNetwork(string iwconfig);
        int GetCurrentSignalStrength(string iwconfig);
        int GetCurrentDBMStrength(string iwconfig);
        string GetCurrentBitrate(string iwconfig);

        //string[] GetSavedWirelessNetworks();

        bool Scan(string sync);

        int GetNumberOfNetworks();
        string GetWirelessProperty(string networkId, string prop);
        void ConnectWireless(string networkId);
        void DisconnectWireless();
    }
}
