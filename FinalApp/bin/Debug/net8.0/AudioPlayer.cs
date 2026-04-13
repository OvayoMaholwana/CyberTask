using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace CybersecurityAwarenessChatbot
{
    internal static class AudioPlayer
    {
        public static void PlayVoiceGreeting()
        {
            const string fileName = "welcome.wav";
            string fullPath = Path.Combine(AppContext.BaseDirectory, fileName);

            if (!File.Exists(fullPath))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Note: {fileName} not found. Skipping audio greeting.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("🎤 Playing voice greeting...");

            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // Play asynchronously using WinMM PlaySound to avoid dependency on System.Windows.Extensions
                    bool ok = PlaySound(fullPath, IntPtr.Zero, SND_FILENAME | SND_ASYNC);
                    if (!ok)
                    {
                        int err = Marshal.GetLastWin32Error();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Audio playback failed (PlaySound returned false). Win32 Error: {err}");
                        Console.ResetColor();
                    }
                }
                else
                {
                    // Fallback: open with the default system handler (cross-platform)
                    try
                    {
                        var psi = new ProcessStartInfo(fullPath)
                        {
                            UseShellExecute = true
                        };
                        Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("🎤 Voice greeting is not supported on this platform or failed to start the default player.");
                        Console.WriteLine($"Audio playback failed: {ex.Message}");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Audio playback failed: {ex.Message}");
                Console.ResetColor();
            }
        }

        // Win32 PlaySound (used only on Windows)
        [DllImport("winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        private const uint SND_SYNC = 0x0000;
        private const uint SND_ASYNC = 0x0001;
        private const uint SND_FILENAME = 0x00020000;
    }
}