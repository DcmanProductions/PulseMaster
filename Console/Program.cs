/*
PULSE Master (Performance and Utilization Monitoring for Load and System Efficiency) - LFInteractive LLC. (c) 2020-2024
a performance and utilization monitoring application geared toward load and system efficiency.
https://github.com/dcmanproductions/PulseMaster
Licensed under the GNU General Public License v3.0
https://www.gnu.org/licenses/lgpl-3.0.html
*/

using PulseMaster.Core.Controller;

namespace PulseMaster.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        LogController.Init();
    }
}