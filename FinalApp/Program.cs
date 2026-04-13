using System;

namespace CybersecurityAwarenessChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioPlayer.PlayVoiceGreeting();
            UIHelper.DisplayAsciiLogo();

            string userName = UIHelper.GetUserName();
            UIHelper.DisplayPersonalizedWelcome(userName);

            var bot = new Chatbot(userName);
            bot.Run();

            UIHelper.DisplayExitMessage(userName);
        }
    }
}