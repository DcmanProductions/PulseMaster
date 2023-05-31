/*
PULSE Master (Performance and Utilization Monitoring for Load and System Efficiency) - LFInteractive LLC. (c) 2020-2024
a performance and utilization monitoring application geared toward load and system efficiency.
https://github.com/dcmanproductions/PulseMaster
Licensed under the GNU General Public License v3.0
https://www.gnu.org/licenses/lgpl-3.0.html
*/

using System.Reflection;

namespace PulseMaster.Core.Data;

public static class DirectoryData
{
    public static string Root => Directory.GetParent(Assembly.GetExecutingAssembly().Location)?.FullName ?? "./";
    public static string Data => Directory.CreateDirectory(Path.Combine(Root, "data")).FullName;
    public static string Logs => Directory.CreateDirectory(Path.Combine(Data, "logs")).FullName;
}