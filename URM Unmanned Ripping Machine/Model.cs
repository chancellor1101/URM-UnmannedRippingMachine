using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URM_Unmanned_Ripping_Machine
{
    internal class RunDataForEncoder
    {
        public string Source;
        public string Destination;
        public string MovieName;
    }

    internal class RunDataForRipper
    {
        public string DriveName;
        public string MovieName;
    }

    internal class RunDataForFileMover
    {
        public string FileLocation;
        public string Destination;
        public string MovieName;
    }

    internal static class CleaningFunctions
    {
        public static string MakeValidFileName(string name)
        {
            var invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            var invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }
    }
}

