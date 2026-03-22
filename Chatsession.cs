using System;
using System.Collections.Generic;
using System.Threading;
using CyberBot.Topics;

namespace CyberBot.Core
{
    public class ChatSession
    {
        // Stores the user's name for the whole session
        private string userName = "User";

        // List of all topic objects - one for each cybersecurity topic
        private List<AllTopics> topics = new List<AllTopics>
        {
            new PasswordTopic(),        new PhishingTopic(),
            new SafeBrowsingTopic(),    new MalwareTopic(),
            new RansomwareTopic(),      new SocialEngineeringTopic(),
            new MitmTopic(),            new DdosTopic(),
            new DataBreachTopic(),      new TwoFATopic()
        };

        // The keyword the user types to select each topic (same order as above)
        private List<string> keywords = new List<string>
        {
            "password",             "phishing",
            "safe browsing",        "malware",
            "ransomware",           "social engineering",
            "mitm",                 "ddos",
            "data breach",          "2fa"
        };

        // Entry point - called from Program.cs
        public void Start()
        {
            ShowLogo();
            AskForName();
            RunMenu();
        }

        // Shows the ASCII logo and welcome message
        private void ShowLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"   ______      __              ____        __  ");
            Console.WriteLine(@"  / ____/_  __/ /_  ___  _____/ __ )____  / /_ ");
            Console.WriteLine(@" / /   / / / / __ \/ _ \/ ___/ __  / __ \/ __/ ");
            Console.WriteLine(@"/ /___/ /_/ / /_/ /  __/ /  / /_/ / /_/ / /_   ");
            Console.WriteLine(@"\____/\__, /_.___/\___/_/  /_____/\____/\__/   ");
            Console.WriteLine();
            Console.ResetColor();
            PrintDivider();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  CYBERSECURITY AWARENESS BOT");
            Console.WriteLine("  Your guide to staying safe online");
            Console.ResetColor();
            PrintDivider();
        }

        // Asks the user for their name and saves it
        private void AskForName()
        {
            BotSay("Welcome! Before we start, what is your name?");
            string input = GetInput("You");

            if (!InputValidator.IsValidName(input))
            {
                BotSay("No problem - I will call you 'User'.");
            }
            else
            {
                // Capitalise the first letter of the name
                userName = char.ToUpper(input[0]) + input.Substring(1).ToLower();
                BotSay("Nice to meet you, " + userName + "!");
            }

            Thread.Sleep(300);
        }

        // Shows the topic menu and handles user input in a loop
        private void RunMenu()
        {
            BotSay("Type a topic name below to learn more about it.");

            while (true)
            {
                ShowMenu();
                string input = GetInput(userName).ToLower().Trim();

                // Check if the user typed nothing
                if (InputValidator.IsEmpty(input))
                {
                    BotSay("Please type a topic name from the menu.");
                    continue;
                }

                // Check if the user wants to exit
                if (input == "exit")
                {
                    ShowGoodbye();
                    break;
                }

                // Check if the input matches a valid topic
                if (!InputValidator.IsValidTopic(input))
                {
                    BotSay("'" + input + "' is not a topic. Please type one of the names from the menu.");
                    continue;
                }

                // Find the topic that matches the keyword and show it
                int index = keywords.IndexOf(input);
                AllTopics selectedTopic = topics[index];
                ShowTopicContent(selectedTopic);

                // Ask the user what to do next
                bool backToMenu = AskNextStep();
                if (!backToMenu)
                {
                    ShowGoodbye();
                    break;
                }
            }
        }

        // Shows the topic header and calls the topic's ShowContent method
        private void ShowTopicContent(AllTopics topic)
        {
            Console.WriteLine();
            PrintDivider();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  " + topic.Name.ToUpper());
            Console.ResetColor();
            PrintDivider();

            // This calls the correct ShowContent for whichever topic was selected
            topic.ShowContent(userName);
        }

        // Asks the user to go back to the menu or exit
        // Returns true for menu, false for exit
        private bool AskNextStep()
        {
            Console.WriteLine();
            PrintDivider();
            Console.WriteLine("  Type 'menu' to go back   |   Type 'exit' to quit");
            PrintDivider();

            while (true)
            {
                string choice = GetInput(userName).ToLower().Trim();

                if (!InputValidator.IsValidPostChoice(choice))
                {
                    BotSay("Please type 'menu' or 'exit'.");
                    continue;
                }

                return choice == "menu";
            }
        }

        // Shows the goodbye message
        private void ShowGoodbye()
        {
            Console.WriteLine();
            PrintDivider();
            BotSay("Thank you for using the Cybersecurity Awareness Bot, " + userName + ".");
            BotSay("Stay safe online. Goodbye!");
            PrintDivider();
        }

        // Shows the list of available topics
        private void ShowMenu()
        {
            Console.WriteLine();
            PrintDivider();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  SELECT A TOPIC - type the name exactly as shown:");
            Console.ResetColor();
            PrintDivider();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  password          phishing");
            Console.WriteLine("  safe browsing     malware");
            Console.WriteLine("  ransomware        social engineering");
            Console.WriteLine("  mitm              ddos");
            Console.WriteLine("  data breach       2fa");
            Console.ResetColor();
            PrintDivider();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Type 'exit' to quit.");
            Console.ResetColor();
            Console.WriteLine();
        }

        // ── Shared output helpers ─────────────────────────────────

        // Prints a message from the bot
        public static void BotSay(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  CyberBot: ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        // Prints a tip in yellow
        public static void ShowTip(string tip)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  TIP: " + tip);
            Console.ResetColor();
        }

        // Prints a warning in red
        public static void ShowWarning(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  WARNING: " + warning);
            Console.ResetColor();
        }

        // Prints a bullet point list
        public static void ShowList(string[] items)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            foreach (string item in items)
                Console.WriteLine("    - " + item);
            Console.ResetColor();
            Console.WriteLine();
        }

        // Prints a section heading
        public static void ShowHeading(string heading)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  " + heading);
            Console.ResetColor();
        }

        // Prints a divider line
        public static void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  " + new string('-', 55));
            Console.ResetColor();
        }

        // Shows a prompt and returns what the user typed
        public static string GetInput(string label)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  " + label + ": ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine() ?? string.Empty;
            Console.ResetColor();
            return input.Trim();
        }
    }
}