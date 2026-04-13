using System;
using System.Collections.Generic;
using System.IO;

namespace CybersecurityAwarenessChatbot
{
    public sealed class Chatbot
    {
        private readonly string userName;
        private readonly HashSet<string> coveredTopics = new();
        private readonly List<string> conversationLog = new();

        public Chatbot(string name)
        {
            userName = name ?? "Friend";
            conversationLog.Add($"=== Chat started with {userName} on {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
        }

        public void Run()
        {
            Console.WriteLine("I'm ready! Ask me anything about cybersecurity.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("You: ");
                string? input = Console.ReadLine()?.Trim();
                Console.ResetColor();

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bot: Please type something.");
                    Console.ResetColor();
                    continue;
                }

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Log user input (but don't print it again)
                conversationLog.Add($"You: {input}");

                // Show user input cleanly (single line)
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"You: {input}");
                Console.ResetColor();

                Respond(input);
            }

            SaveConversationLog();
            ShowProgressSummary();
        }

        private void Respond(string input)
        {
            string lower = input.ToLower();
            string response = "";

            if (lower.Contains("phishing") || lower.Contains("email"))
            {
                response = "Phishing is very common in South Africa. Always check the sender's email address carefully. If it creates urgency or asks for personal info – delete it!";
                coveredTopics.Add("phishing");
            }
            else if (lower.Contains("password"))
            {
                response = "Use long, unique passwords (12+ characters). Enable 2FA wherever possible. A password manager like Bitwarden is a game changer.";
                coveredTopics.Add("password");
            }
            else if (lower.Contains("browse") || lower.Contains("https") || lower.Contains("website"))
            {
                response = "Always ensure the website starts with https:// and has a padlock icon. Avoid public Wi-Fi for banking or entering passwords.";
                coveredTopics.Add("browsing");
            }
            else if (lower.Contains("scam") || lower.Contains("fraud") || lower.Contains("sms"))
            {
                response = "Watch out for SARS refund scams, bank OTP scams, and fake delivery messages. Never share your OTP or banking details.";
                coveredTopics.Add("scam");
            }
            else if (lower.Contains("how are you"))
            {
                response = "I'm here 24/7 protecting digital lives! How are you doing today?";
            }
            else if (lower.Contains("purpose") || lower.Contains("who are you"))
            {
                response = "I was built to raise cybersecurity awareness among South Africans and help fight online scams.";
            }
            else
            {
                response = "I'm here to help with phishing, passwords, safe browsing, and common South African scams. What would you like to know?";
            }

            // Show bot response using the nice bubble (single clean output)
            UIHelper.PrintBotMessage(response);
            conversationLog.Add($"Bot: {response}");
        }

        private void SaveConversationLog()
        {
            try
            {
                string fileName = $"ChatHistory_{userName}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                File.WriteAllLines(fileName, conversationLog);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n💾 Your conversation has been saved to: {fileName}");
                Console.ResetColor();
            }
            catch { }
        }

        private void ShowProgressSummary()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("📊 Your Cybersecurity Learning Progress:");
            Console.WriteLine($"   Topics explored: {coveredTopics.Count}/4");
            Console.WriteLine($"   Phishing     : {(coveredTopics.Contains("phishing") ? "✅ Learned" : "⬜ Not yet")}");
            Console.WriteLine($"   Passwords    : {(coveredTopics.Contains("password") ? "✅ Learned" : "⬜ Not yet")}");
            Console.WriteLine($"   Safe Browsing: {(coveredTopics.Contains("browsing") ? "✅ Learned" : "⬜ Not yet")}");
            Console.WriteLine($"   Scams        : {(coveredTopics.Contains("scam") ? "✅ Learned" : "⬜ Not yet")}");
            Console.ResetColor();
        }
    }
}