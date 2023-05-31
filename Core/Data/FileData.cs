/*
PULSE Master (Performance and Utilization Monitoring for Load and System Efficiency) - LFInteractive LLC. (c) 2020-2024
a performance and utilization monitoring application geared toward load and system efficiency.
https://github.com/dcmanproductions/PulseMaster
Licensed under the GNU General Public License v3.0
https://www.gnu.org/licenses/lgpl-3.0.html
*/

namespace PulseMaster.Core.Data;

public static class FileData
{
    public static string LatestLogFile => Path.Combine(DirectoryData.Logs, "latest.log");
    public static string DebugLogFile => Path.Combine(DirectoryData.Logs, "debug.log");
    public static string ErrorLogFile => Path.Combine(DirectoryData.Logs, "error.log");
}