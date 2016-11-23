using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWICD
{
    public static class Utils
    {
        public static string IntToVariant(int value) => $"GLib.Variant('i',{value})";
        public static string BoolToVariant(bool value) => $"GLib.Variant('b',{value})";
        public static string StringToVariant(string value) => $"GLib.Variant('s','{value}')";
    }
}
