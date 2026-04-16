using System;

namespace CybersecurityAwarenessChatbot
{
    public static class UIHelper
    {
        public static void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ██████╗ ███████╗███████╗██████╗     ███████╗███████╗ ██████╗ ██╗   ██╗██████╗");
            Console.WriteLine("  ██╔════╝ ██╔════╝██╔════╝██╔══██╗    ██╔════╝██╔════╝██╔════╝ ██║   ██║██╔══██╗");
            Console.WriteLine("  ██║  ███╗█████╗  █████╗  ██████╔╝    ███████╗█████╗  ██║  ███╗██║   ██║██████╔╝");
            Console.WriteLine("  ██║   ██║██╔══╝  ██╔══╝  ██╔══██╗    ╚════██║██╔══╝  ██║   ██║██║   ██║██╔══██╗");
            Console.WriteLine("  ╚██████╔╝███████╗███████╗██║  ██║    ███████║███████╗╚██████╔╝╚██████╔╝██║  ██║");
            Console.WriteLine("   ╚═════╝ ╚══════╝╚══════╝╚═╝  ╚═╝    ╚══════╝╚══════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                  ┌────────────────────────────────────────────────────────────┐");
            Console.WriteLine("                  │                🔰  CYBER SHIELD  🔰                       │");
            Console.WriteLine("                  │         SOUTH AFRICA CYBERSECURITY AWARENESS BOT          │");
            Console.WriteLine("                  └────────────────────────────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine("             Protecting South Africa's Digital Future");
            Console.WriteLine("                        One Click at a Time");
            Console.ResetColor();
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();
        }

        public static string GetUserName()
        {
            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please enter your first name: ");
                Console.ResetColor();
                name = (Console.ReadLine() ?? string.Empty).Trim();

                if (string.IsNullOrEmpty(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Name cannot be empty. Please try again.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrEmpty(name));

            return name;
        }

        public static void DisplayPersonalizedWelcome(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║  Hello {userName}! Welcome to the Cybersecurity Awareness Bot!                        ║");
            Console.WriteLine("║  I'm here to help you stay safe from phishing, scams, and online threats in South Africa.║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("💡 You can ask me about:");
            Console.WriteLine("   • Phishing & suspicious emails");
            Console.WriteLine("   • Strong passwords & 2FA");
            Console.WriteLine("   • Safe browsing habits");
            Console.WriteLine("   • Common South African scams");
            Console.WriteLine();
            Console.WriteLine("Type 'exit' or 'quit' to end the chat.");
            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
        }

        public static void DisplayExitMessage(string userName)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Thank you, {userName}! 👋");
            Console.WriteLine("Stay safe online and keep learning about cybersecurity!");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }

        public static void ShowDivider()
        {
            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────");
        }

        public static void PrintBotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine($"│ Bot: {message,-82} │");
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────┘");
            Console.ResetColor();
        }

        public static void PrintUserMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"You: {message}");
            Console.ResetColor();
        }
    }
}