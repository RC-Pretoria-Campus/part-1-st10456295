using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;



namespace Chatbot1
{
    

    class Chatbot
    {
        static void Main()
        {
            // Set background to white and text to black
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear(); // Apply background color to the entire console

            Console.OutputEncoding = Encoding.UTF8;  
            PlayVoiceGreeting();
            DisplayAsciiArt();
            StartChatbot();
        }

        //Voice greeting method
        static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Record.wav"); 
                player.Play();
            }
            catch (Exception)
            {
                Console.WriteLine("Voice greeting not available. Ensure 'Record.wav' is in the correct location.");
            }
        }

        // The Cybersecurity ASCII Logo method
        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // Get console width for centering
            int consoleWidth = Console.WindowWidth;
            string[] logoLines = new string[]
            {
        "//=================================//",
        "//   CYBERSECURITY PROTECTION      //",
        "//=================================//",
        "//      ┌──────────────────┐       //",
        "//      │  ████████████    │       //",
        "//      │  ██      ██  █   │       //",
        "//      │  ██  ██  ██ ███  │       //",
        "//      │  ██  ██  ██  █   │       //",
        "//      │  ████████████    │       //",
        "//      └──────────────────┘       //",
        "//    Secure. Encrypt. Defend.     //",
        "//=================================//"
            };

            // Calculate padding for centering
            foreach (string line in logoLines)
            {
                int padding = (consoleWidth - line.Length) / 2;
                Console.WriteLine(new string(' ', Math.Max(0, padding)) + line);
            }

            Console.ResetColor();
        }







        //Starting the chatbot converstaion
        static void StartChatbot()
        {
            Console.Write("Hello! What's your name? ");
            string userName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.Write("Please enter a valid name: ");
                userName = Console.ReadLine();
            }

            Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Bot. How can I assist you today?");
            ChatLoop();
        }

        // Chatbot loop for user conversation
        static void ChatLoop()
        {
            bool running = true;
            while (running)
            {
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Bot: I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                switch (userInput)
                {
                    case "how are you":
                        Console.WriteLine("Bot: I'm just a chatbot, but I'm functioning automatically! Thanks for asking.");
                        break;
                    case "what’s your purpose?":
                    case "what do you do?":
                    case "what can i ask you about?":
                        Console.WriteLine("Bot: I educate users about cybersecurity threats and safe online practices.");
                        break;
                    case "tell me about phishing":
                        Console.WriteLine("Bot: Phishing is a type of cyber attack where attackers trick you into providing personal information via fake emails or websites.");
                        break;
                    case "how do i create a strong password":
                        Console.WriteLine("Bot: A strong password should have at least 12 characters, including letters, numbers, and special symbols.");
                        break;
                    case "exit":
                    case "quit":
                    case "end":
                        running = false;
                        Console.WriteLine("Bot: Goodbye! Stay safe online.");
                        break;
                    default:
                        Console.WriteLine("Bot: I’m not sure about that. Try asking me about cybersecurity topics!");
                        break;
                }
            }
        }
    }

}
