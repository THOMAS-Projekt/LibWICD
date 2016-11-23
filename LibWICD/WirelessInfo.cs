using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWICD
{
    public class WirelessInfo
    {
        private IWICDWireless _wirelessInterface;
        private string _iwconfigVariant;

        internal WirelessInfo(IWICDWireless wirelessInterface, string iwconfig)
        {
            _wirelessInterface = wirelessInterface;
            _iwconfigVariant = Utils.StringToVariant(iwconfig);
        }

        public string QuerySSID() => _wirelessInterface.GetCurrentNetwork(_iwconfigVariant);
        public int QuerySignalStrength() => _wirelessInterface.GetCurrentSignalStrength(_iwconfigVariant);
        public int QueryDBM() => _wirelessInterface.GetCurrentDBMStrength(_iwconfigVariant);
        public string QueryBitrate() => _wirelessInterface.GetCurrentBitrate(_iwconfigVariant);
    }
}
