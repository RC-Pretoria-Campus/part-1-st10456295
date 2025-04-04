using System;
using System.Text.RegularExpressions;
using System.Media;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Chatbot1
{
    class Chatbot

    {
        static List<string> topicHistory = new List<string>();

        static Dictionary<string, string> keywordResponses = new Dictionary<string, string>
        {
    {"password", "**A strong password should have a combination of capital and lowercase letters, numbers,\nand symbols and be at least 12 characters long. Avoid using common words or easily\nguessable information like birthdays. Passwords should be unique for each account,\nand it's best to use a password manager to keep track of them safely.**"},

    {"phishing", "**Phishing is a kind of cyberattack in which scammers act as trustworthy organisations\nto trick individuals into revealing sensitive information such as usernames, passwords,\nor credit card numbers. This is typically done through fake emails, messages, or\nwebsites that appear legitimate.**"},

    {"malware", "**Viruses, worms, Trojan horses, ransomware, and spyware are examples of common\nmalware. These are malicious software programs designed to damage, disrupt, or\nillegally access computer systems. Malware can spread through infected files,\nemail attachments, or harmful websites.**"},

    {"firewall", "**A firewall is a type of security system that uses set security rules to track and control\nincoming and outgoing network traffic. Firewalls act as a barrier between trusted and\nuntrusted networks, helping to block unauthorized access while allowing legitimate\ncommunication.**"},

    {"encryption", "**Data is coded and made unreadable by anyone without the proper decryption key\nthrough the process of encryption. It is a crucial method for protecting sensitive\ninformation during storage or transmission, ensuring privacy and security in\ncommunications.**"},

    {"2fa", "**Before gaining access to an account, users must submit two forms of verification\nwhen using Two-Factor Authentication (2FA). This typically combines something you\nknow (like a password) with something you have (like a phone or security token),\nadding an extra layer of protection.**"},

    {"hacking", "**Hacking is the act of breaking into computer networks or systems without\nauthorisation. Hackers may do this to steal information, disrupt operations, or\nexplore systems. While often illegal, ethical hacking exists to test and improve\nsecurity systems.**"},

    {"data breach", "**Any unauthorised access, theft, or exposure of private, sensitive, or protected data\nis a data breach. This can happen due to poor security practices, successful attacks,\nor accidental leaks, and often results in identity theft or financial loss.**"},

    {"how are you", "**I'm just a chatbot, but I'm here and ready to assist you with cybersecurity\nknowledge!**"},

    {"what do you do", "**I am a Cybersecurity Awareness Chatbot, here to educate and assist you with\nonline security topics!**"},

    {"cybersecurity awareness", "**Cybersecurity awareness refers to the knowledge and practice of protecting personal\nand organizational digital assets from cyber threats. It includes recognizing online\nrisks, using secure tools, and maintaining good security habits.**"},

    {"your purpose", "**My purpose is to help you learn about cybersecurity awareness and stay safe\nonline!**"},

    {"what can I ask you about", "**You can ask me about cybersecurity topics such as cybersecurity awareness,\npasswords, phishing, malware, firewalls, encryption, hacking, and more!**"}
};



        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;

            MaximizeConsoleWindow();
            DisplayAsciiArt();
            DisplayWelcomeMessage();
            PlayVoiceGreeting();
            StartChatbot();
        }

        static void MaximizeConsoleWindow()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                try
                {
                    Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                    Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error maximizing window: " + e.Message);
                }
            }
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Recording.wav");
                player.Play(); // Plays asynchronously
            }
            catch (Exception)
            {
                Console.WriteLine("Voice greeting not available. Ensure 'Record.wav' is in the correct location.");
            }
        }


        static void DisplayAsciiArt()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            string[] headingLines = {
                @"   _______  _____      __  ________   ________  _______  ",
                @"  /// ____|  \\\ \    / / |||  _  \  |||  ____| |||  __ \ ",
                @" ||| |        \\\ \  / /  ||| |_)  | ||| |__    ||| |__) |",
                @" ||| |         \\\ \/ /   |||  _  <  |||  __|   |||  _  / ",
                @" ||| |____      |||  |    ||| |_)  | ||| |____  ||| | \ \ ",
                @"  \\\_____|     |||__|    |||_____/  |||______| |||_|  \_\",
                @"                                                ",
                @"         C Y B E R - S E C U R I T Y             "
            };

            string[] logoLines = {
                "||=================================||",
                "||   CYBERSECURITY PROTECTION      ||",
                "||=================================||",
                "||      ┌──────────────────┐       ||",
                "||      │  ████████████    │       ||",
                "||      │  ██      ██  █   │       ||",
                "||      │  ██  ██  ██ ███  │       ||",
                "||      │  ██  ██  ██  █   │       ||",
                "||      │  ████████████    │       ||",
                "||      └──────────────────┘       ||",
                "||    SECURE. ENCRYPT. DEFEAT.     ||",
                "||=================================||"
            };

            int consoleWidth = Console.WindowWidth;
            int logoWidth = logoLines.Max(line => line.Length);
            int logoStartPos = consoleWidth - logoWidth;
            int totalLines = Math.Max(headingLines.Length, logoLines.Length);

            for (int i = 0; i < totalLines; i++)
            {
                string headingPart = i < headingLines.Length ? headingLines[i] : new string(' ', headingLines[0].Length);
                string logoPart = i < logoLines.Length ? logoLines[i] : "";

                int spaceBetween = logoStartPos - headingPart.Length;
                spaceBetween = spaceBetween < 0 ? 0 : spaceBetween;

                Console.WriteLine($"{headingPart}{new string(' ', spaceBetween)}{logoPart}");
            }

            Console.WriteLine("\n");
            Console.ResetColor();
        }

        static void DisplayWelcomeMessage()
        {
            // Set the background and text color for the welcome message

            Console.ForegroundColor = ConsoleColor.White;
            int horizontalPadding = (Console.WindowWidth - "== Welcome to the Cybersecurity Awareness Chatbot! ==".Length) / 5;

            Console.SetCursorPosition(horizontalPadding, Console.CursorTop);
            Console.WriteLine("== Welcome to the Cybersecurity Awareness Chatbot! ==");
            Console.SetCursorPosition(horizontalPadding, Console.CursorTop);
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(horizontalPadding, Console.CursorTop);
            Console.WriteLine("I am here to help you learn about keeping your data safe.");
            Console.SetCursorPosition(horizontalPadding, Console.CursorTop);
            Console.WriteLine("Ask me about topics that are cybersecurity related such as: passwords, phishing, and more.");
            Console.SetCursorPosition(horizontalPadding, Console.CursorTop);
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            // Reset colors for the conversation text to remove the black background
            Console.ResetColor();
        }


        static void StartChatbot()
        {
            Console.WriteLine("\nWhat is your name? ");
            Console.ForegroundColor = ConsoleColor.Green; // User input green
            string userName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; // Bot response blue

            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Please enter a valid name: ");
                Console.ForegroundColor = ConsoleColor.Green; // User input green
                userName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue; // Bot response blue
            }

            PrintWithDelay($"\nWelcome, {userName}! I am your Cybersecurity Awareness Chatbot.", 1);
            AskHowAreYou();
        }


        static void AskHowAreYou()
        {
            PrintWithDelay("\nBot: How are you today?", 30);
            Console.ForegroundColor = ConsoleColor.Green; // User input green
            string userResponse = Console.ReadLine().ToLower();

            Console.ForegroundColor = ConsoleColor.Blue; // Bot response blue
            Console.ForegroundColor = ConsoleColor.Green; // User input green
            if (userResponse.Contains("good") || userResponse.Contains("well") || userResponse.Contains("fine"))
            {
                PrintWithDelay("\nBot: Glad to hear that! Do you have any questions for me before we start?", 30);

                bool askMore = true;
                while (askMore)
                {
                    Console.Write("\nYou: ");
                    Console.ForegroundColor = ConsoleColor.Green;

                    string question = Console.ReadLine().ToLower();
                    Console.ForegroundColor = ConsoleColor.Blue; // Bot response blue


                    if (keywordResponses.ContainsKey(question))
                    {
                        PrintWithDelay($"Bot: {keywordResponses[question]}", 30);
                    }
                    else
                    {
                        PrintWithDelay("Bot: I didn't quite understand that. Could you rephrase?", 30);
                    }

                    string continueAsking = "";
                    bool validResponse = false;

                    while (!validResponse)
                    {
                        PrintWithDelay("\nWould you like to ask anything else? (yes/no)", 30);
                        Console.ForegroundColor = ConsoleColor.Green;
                        continueAsking = Console.ReadLine().ToLower();

                        if (continueAsking == "yes")
                        {
                            validResponse = true;
                            // askMore stays true, so continue loop
                        }
                        else if (continueAsking == "no")
                        {
                            validResponse = true;
                            askMore = false; // exit loop
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            PrintWithDelay("Bot: Please respond with 'yes' or 'no'.", 30);
                        }
                    }

                }
            }

            DisplayMenu();
        }


        static void DisplayMenu()
        {
            bool menuActive = true;

            while (menuActive)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Learn about Cybersecurity Topics");
                Console.WriteLine("2. Exit");
                Console.WriteLine("3. View History of Learned Topics");

                Console.ForegroundColor = ConsoleColor.Green; // User input green
                Console.Write("\nEnter the number corresponding to your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayTopics();
                        break;
                    case "2":
                        PrintWithDelay("Bot: You have chosen to exit. Goodbye and stay safe online!", 50);
                        menuActive = false;
                        break;
                    case "3":
                        DisplayHistory();
                        break;
                    case "4":
                        PrintWithDelay("Bot: I am a Cybersecurity Awareness Chatbot, here to educate you about cybersecurity and protect your online safety.", 30);
                        break;
                    case "5":
                        PrintWithDelay("Goodbye! Stay safe online.", 30);
                        menuActive = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                }
            }

            Console.Clear();
            Environment.Exit(0);
        }

        static void DisplayHistory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            if (topicHistory.Count == 0)
            {
                Console.WriteLine("No topics have been viewed yet.");
            }
            else
            {
                Console.WriteLine("Previously viewed topics:\n");

                foreach (string topic in topicHistory)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"🔐 {topic.ToUpper()}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(keywordResponses[topic]);
                    Console.WriteLine(new string('-', 80));
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            DisplayMenu();
        }


        static void DisplayTopics()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Here are some topics you can learn about:");
            Console.WriteLine("1. Password Security");
            Console.WriteLine("2. Phishing Scams");
            Console.WriteLine("3. Malware");
            Console.WriteLine("4. Firewalls");
            Console.WriteLine("5. Encryption");
            Console.WriteLine("6. Two-Factor Authentication (2FA)");
            Console.WriteLine("7. Hacking");
            Console.WriteLine("8. Data Breaches");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nEnter the number of the topic you'd like to learn about (or '0' to return to the main menu): ");
            string topicChoice = Console.ReadLine();

            switch (topicChoice)
            {
                case "1":
                    DisplayTopicInfo("password");
                    break;
                case "2":
                    DisplayTopicInfo("phishing");
                    break;
                case "3":
                    DisplayTopicInfo("malware");
                    break;
                case "4":
                    DisplayTopicInfo("firewall");
                    break;
                case "5":
                    DisplayTopicInfo("encryption");
                    break;
                case "6":
                    DisplayTopicInfo("2fa");
                    break;
                case "7":
                    DisplayTopicInfo("hacking");
                    break;
                case "8":
                    DisplayTopicInfo("data breach");
                    break;
                case "0":
                    DisplayMenu();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 8, or '0' to return.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        static void DisplayTopicInfo(string topic)
        {
            // Display information about the selected topic
            if (keywordResponses.ContainsKey(topic))
            {
                // Add to history if not already there
                if (!topicHistory.Contains(topic))
                {
                    topicHistory.Add(topic);
                }

                PrintWithDelay($"Bot: {keywordResponses[topic]}", 30);
            }
            else
            {
                PrintWithDelay("Bot: I don't have information on that topic right now.", 30);
            }

            // After showing the information, return to the topic list
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEnter any key to return to the topics list...");
            Console.ReadKey();
            DisplayTopics();
        }

        static void ViewHistory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("History of Topics You've Learned:");

            if (topicHistory.Count == 0)
            {
                Console.WriteLine("No topics have been viewed yet.");
            }
            else
            {
                foreach (string topic in topicHistory)
                {
                    Console.WriteLine("- " + topic);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

        static void PrintWithDelay(string message, int delay)
        {
            message = message.Replace("cybersecurity", "CYBERSECURITY");
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        static void MatrixEffectAtEnd()
        {
            Random rand = new Random();
            int delayTime = 1;
            DateTime startTime = DateTime.Now;
            TimeSpan duration = TimeSpan.FromSeconds(3);

            while (DateTime.Now - startTime < duration)
            {
                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    Console.SetCursorPosition(rand.Next(Console.WindowWidth), rand.Next(Console.WindowHeight));
                    Console.Write((char)rand.Next(48, 58));
                    Thread.Sleep(delayTime);
                }
            }
        }
    }
}