using NDesk.DBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWICD
{
    public class WICD
    {
        private const string BusName = "org.wicd.daemon";
        private const string WirelessObjectPath = "/org/wicd/daemon/wireless";

        Bus _systemBus;

        public WICD()
        {
            _systemBus = Bus.System;
        }

        public WICDWireless GetWireless()
        {
            IWICDWireless wirelessInterface = _systemBus.GetObject<IWICDWireless>(BusName, new ObjectPath(WirelessObjectPath));
            return new WICDWireless(wirelessInterface);
        }
    }
}
