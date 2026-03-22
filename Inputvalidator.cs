namespace CyberBot.Core
{
    public static class InputValidator
    {
        // The only topic keywords the user is allowed to type
        private static string[] validTopics =
        {
            "password", "phishing", "safe browsing", "malware", "ransomware",
            "social engineering", "mitm", "ddos", "data breach", "2fa"
        };

        // Returns true if the user typed nothing
        public static bool IsEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        // Returns true if the input matches one of the valid topic keywords
        public static bool IsValidTopic(string input)
        {
            foreach (string topic in validTopics)
            {
                if (input.ToLower().Trim() == topic)
                    return true;
            }
            return false;
        }

        // Returns true if the post-topic input is menu or exit
        public static bool IsValidPostChoice(string input)
        {
            string clean = input.ToLower().Trim();
            return clean == "menu" || clean == "exit";
        }

        // Returns true if the name only contains letters and spaces
        public static bool IsValidName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (char c in input.Trim())
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }
    }
}