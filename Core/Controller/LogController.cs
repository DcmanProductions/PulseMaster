/*
PULSE Master (Performance and Utilization Monitoring for Load and System Efficiency) - LFInteractive LLC. (c) 2020-2024
a performance and utilization monitoring application geared toward load and system efficiency.
https://github.com/dcmanproductions/PulseMaster
Licensed under the GNU General Public License v3.0
https://www.gnu.org/licenses/lgpl-3.0.html
*/

using PulseMaster.Core.Data;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace PulseMaster.Core.Controller;

public static class LogController
{
    public static void Init()
    {
        long start = DateTime.Now.Ticks;
        Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle> customThemeStyles = new()
        {
            {
                ConsoleThemeStyle.Text, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.White,
                }
            },
            {
                ConsoleThemeStyle.String, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Yellow,
                }
            },
            {
                ConsoleThemeStyle.Scalar, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Green,
                }
            },
            {
                ConsoleThemeStyle.Number, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Blue,
                }
            },
            {
                ConsoleThemeStyle.Boolean, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Cyan,
                }
            },
            {
                ConsoleThemeStyle.Null, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Red,
                }
            },
            {
                ConsoleThemeStyle.LevelDebug, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Blue,
                }
            },
            {
                ConsoleThemeStyle.LevelInformation, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Green,
                }
            },
            {
                ConsoleThemeStyle.LevelWarning, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.DarkYellow,
                }
            },
            {
                ConsoleThemeStyle.LevelError, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.Red,
                }
            },
            {
                ConsoleThemeStyle.LevelFatal, new SystemConsoleThemeStyle
                {
                    Foreground = ConsoleColor.DarkRed,
                }
            },
        };
        string template = "[Pulse Master] [{Level}] {Message:lj}{NewLine}{Exception}";
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(LogEventLevel.Debug, outputTemplate: template, theme: new SystemConsoleTheme(customThemeStyles))
            .WriteTo.File(FileData.LatestLogFile, LogEventLevel.Information, rollOnFileSizeLimit: true, fileSizeLimitBytes: 4000000, flushToDiskInterval: TimeSpan.FromMinutes(1), buffered: true, rollingInterval: RollingInterval.Day)
            .WriteTo.File(FileData.DebugLogFile, LogEventLevel.Verbose, rollOnFileSizeLimit: true, fileSizeLimitBytes: 4000000, flushToDiskInterval: TimeSpan.FromMinutes(1), buffered: true, rollingInterval: RollingInterval.Day)
            .WriteTo.File(FileData.ErrorLogFile, LogEventLevel.Error, rollOnFileSizeLimit: true, fileSizeLimitBytes: 4000000, buffered: false, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        AppDomain.CurrentDomain.ProcessExit += (s, e) =>
        {
            TimeSpan end = new(DateTime.Now.Ticks - start);
            Log.Debug("Pulse Master stopping after '{TIME}' of operation", end);
            Log.CloseAndFlush();
        };
    }
}