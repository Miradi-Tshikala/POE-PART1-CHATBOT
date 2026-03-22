// This file contains:
// 1. AllTopics  - the abstract base class (the template)
// 2. Ten child classes - one for each cybersecurity topic

using System;

namespace CyberBot.Topics
{
    // AllTopics is a template. Every topic MUST have a Name and
    // a ShowContent method. The child classes fill these in.
    public abstract class AllTopics
    {
        public abstract string Name { get; }
        public abstract void ShowContent(string userName);

        // Prints the opening CyberBot: message for a topic
        public void BotSay(string msg)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("CyberBot: ");
            Console.ResetColor();
            Console.WriteLine(msg);
        }

        // Prints a plain heading with no CyberBot prefix
        public void Heading(string h)
        {
            Console.WriteLine(" " + h);
        }

        // Prints a plain list of items - used for all sections
        public void List(string[] items)
        {
            foreach (string item in items)
                Console.WriteLine("    - " + item);
            Console.WriteLine();
        }
    }

    // ── Child class 1 ─────────────────────────────────────────
    public class PasswordTopic : AllTopics
    {
        public override string Name => "Password Safety";

        public override void ShowContent(string userName)
        {
            BotSay("What is a password?");
            List(new string[]
            {
                "A secret word or phrase that proves who you are when you log in.",
                "Example: logging into Gmail requires your email and password."
            });

            Heading("Why does it matter?");
            List(new string[]
            {
                "A weak password is like a door with no lock - anyone can get in.",
                "Hackers use automated tools that try millions of combinations per second."
            });

            Heading("How to stay safe:");
            List(new string[]
            {
                "Use at least 12 characters with letters, numbers and symbols",
                "Never use your name, birthday or the word 'password'",
                "Use a different password for every account",
                "Use a password manager like Bitwarden to remember them all"
            });

            Heading("Advantages of a strong password:");
            List(new string[]
            {
                "Stops hackers from guessing or cracking your account",
                "Protects your personal data, money and identity",
                "Gives you peace of mind knowing your accounts are secure",
                "Warning: reusing the same password puts ALL your accounts at risk",
                "Tip: use a passphrase - example: Coffee#Runs@Midnight!"
            });
        }
    }

    // ── Child class 2 ─────────────────────────────────────────
    public class PhishingTopic : AllTopics
    {
        public override string Name => "Phishing";

        public override void ShowContent(string userName)
        {
            BotSay("What is phishing?");
            List(new string[]
            {
                "A criminal sends a fake message pretending to be someone you trust.",
                "Example: an email that looks like it is from your bank saying your account is locked.",
                "The link takes you to a fake website that steals your login details."
            });

            Heading("Why does it matter?");
            List(new string[]
            {
                "Phishing is the most common cyberattack in the world.",
                "It tricks real people every day - even tech-savvy ones.",
                "It causes over 90% of all data breaches worldwide."
            });

            Heading("How to stay safe:");
            List(new string[]
            {
                "Check the sender's email address carefully for spelling mistakes",
                "Never click links in unexpected emails - go to the website yourself",
                "Do not enter your password or OTP if anything feels off",
                "Call the company directly using their official number to verify",
                "Tip: hover your mouse over a link before clicking to check if the URL looks real"
            });
        }
    }

    // ── Child class 3 ─────────────────────────────────────────
    public class SafeBrowsingTopic : AllTopics
    {
        public override string Name => "Safe Browsing";

        public override void ShowContent(string userName)
        {
            BotSay("What is safe browsing?");
            List(new string[]
            {
                "Using the internet in a way that protects your data and device.",
                "Example: before entering card details on a site, check for HTTPS."
            });

            Heading("Why does it matter?");
            List(new string[]
            {
                "Unsafe browsing can lead to malware, stolen passwords or identity theft.",
                "Many attacks happen simply because someone visited the wrong website."
            });

            Heading("How to stay safe:");
            List(new string[]
            {
                "Always check for HTTPS (padlock icon) before entering personal details",
                "Keep your browser updated - updates fix security vulnerabilities",
                "Avoid clicking on pop-up ads or unknown download links",
                "Use a VPN on public WiFi to encrypt your traffic",
                "Warning: HTTPS does not automatically mean the site is safe",
                "Tip: ProtonVPN is free and easy to use on public WiFi"
            });

            Heading("Advantages of safe browsing habits:");
            List(new string[]
            {
                "Reduces the risk of malware infecting your device",
                "Protects your passwords and payment details",
                "Keeps your browsing history private"
            });
        }
    }

    // ── Child class 4 ─────────────────────────────────────────
    public class MalwareTopic : AllTopics
    {
        public override string Name => "Malware";

        public override void ShowContent(string userName)
        {
            BotSay("What is malware?");
            List(new string[]
            {
                "Any software designed to harm your device or steal your data.",
                "Example: you download a free game from an untrusted site.",
                "Hidden inside is a keylogger that records every password you type."
            });

            Heading("Common types:");
            List(new string[]
            {
                "Virus     - spreads by attaching to files you open",
                "Trojan    - looks like a normal program but is secretly harmful",
                "Spyware   - watches what you do without you knowing",
                "Keylogger - records everything you type including passwords",
                "Ransomware- locks your files and demands money to unlock them"
            });

            Heading("How to stay safe:");
            List(new string[]
            {
                "Only download software from official websites",
                "Keep Windows and all apps updated",
                "Use antivirus software - Windows Defender is free and reliable",
                "Never open attachments from people you do not know",
                "Warning: if your device slows down suddenly or shows strange pop-ups, scan it immediately",
                "Tip: run a full scan at least once a month even if nothing seems wrong"
            });
        }
    }

    // ── Child class 5 ─────────────────────────────────────────
    public class RansomwareTopic : AllTopics
    {
        public override string Name => "Ransomware";

        public override void ShowContent(string userName)
        {
            BotSay("What is ransomware?");
            List(new string[]
            {
                "Malware that locks all your files and demands payment to unlock them.",
                "Example: you open an email attachment. Within minutes all your documents",
                "and photos are encrypted. A message appears: pay R5000 in Bitcoin or lose everything."
            });

            Heading("Why does it matter?");
            List(new string[]
            {
                "Ransomware has shut down hospitals, schools and businesses worldwide.",
                "Even if you pay, there is no guarantee you will get your files back."
            });

            Heading("How to stay safe:");
            List(new string[]
            {
                "Back up your files regularly and keep one backup offline",
                "Never open unexpected email attachments",
                "Keep your operating system and software updated",
                "Use antivirus software with ransomware protection",
                "Warning: never pay the ransom - recovery is not guaranteed"
            });

            Heading("Advantages of regular backups:");
            List(new string[]
            {
                "If attacked, you can restore your files without paying",
                "Also protects against accidental deletion",
                "Gives you peace of mind knowing your data is safe",
                "Tip: 3-2-1 rule - keep 3 copies, on 2 devices, with 1 stored offsite"
            });
        }
    }

    // ── Child class 6 ─────────────────────────────────────────
    public class SocialEngineeringTopic : AllTopics
    {
        public override string Name => "Social Engineering";

        public override void ShowContent(string userName)
        {
            BotSay("What is social engineering?");
            List(new string[]
            {
                "Manipulating a person into giving up private information.",
                "Instead of hacking technology, the attacker hacks the human.",
                "Example: someone calls pretending to be IT support and asks for your password."
            });

            Heading("Common techniques:");
            List(new string[]
            {
                "Pretexting   - making up a convincing story to earn your trust",
                "Vishing      - fake phone calls from your bank or Microsoft support",
                "Baiting      - leaving a USB drive in a car park for someone to find",
                "Tailgating   - walking into a secure building behind an authorised person",
                "Quid pro quo - offering help in exchange for your login details"
            });

            Heading("How to stay safe:");
            List(new string[]
            {
                "Never share your password or OTP with anyone - not even IT support",
                "Verify who you are speaking to before sharing any information",
                "When pressured urgently, slow down - urgency is the tactic",
                "Warning: no legitimate company will ever call and ask for your password",
                "Tip: if a call feels suspicious, hang up and call the official number yourself"
            });
        }
    }

    // ── Child class 7 ─────────────────────────────────────────
    public class MitmTopic : AllTopics
    {
        public override string Name => "Man-in-the-Middle Attacks";

        public override void ShowContent(string userName)
        {
            BotSay("What is a man-in-the-middle attack?");
            List(new string[]
            {
                "An attacker secretly sits between you and a website.",
                "They can read or change everything you send and receive.",
                "Example: you connect to Free_Airport_WiFi set up by an attacker.",
                "When you log into your bank, they capture your password silently."
            });

            Heading("Why does it matter?");
            List(new string[]
            {
                "Your data looks like it is going to the real website, but the attacker sees everything.",
                "You would not even know it was happening."
            });

            Heading("How to stay safe:");
            List(new string[]
            {
                "Use a VPN on any public or shared WiFi network",
                "Only use sites with HTTPS - check for the padlock in the address bar",
                "Never ignore browser warnings about insecure connections",
                "Avoid banking or sensitive logins on public networks",
                "Warning: public WiFi is the most common location for MITM attacks"
            });

            Heading("Advantages of using a VPN:");
            List(new string[]
            {
                "Encrypts your traffic so attackers cannot read it",
                "Hides your IP address for extra privacy",
                "Works on public WiFi, hotel networks and campus networks",
                "Tip: ProtonVPN has a free plan with no data limit"
            });
        }
    }

    // ── Child class 8 ─────────────────────────────────────────
    public class DdosTopic : AllTopics
    {
        public override string Name => "DDoS Attacks";

        public override void ShowContent(string userName)
        {
            BotSay("What is a DDoS attack?");
            List(new string[]
            {
                "DDoS stands for Distributed Denial of Service.",
                "Attackers flood a server with fake traffic until it crashes and goes offline.",
                "Example: imagine thousands of people blocking a shop door at once.",
                "Real customers cannot get in because the entrance is completely blocked."
            });

            Heading("Why does it matter?");
            List(new string[]
            {
                "DDoS attacks shut down websites, apps and online services.",
                "Businesses lose money and real users cannot access what they need."
            });

            Heading("Real examples:");
            List(new string[]
            {
                "GitHub (2018)  - received 1.35 Tbps of fake traffic",
                "Dyn (2016)     - took down Twitter, Netflix and Reddit at the same time",
                "Amazon (2020)  - 2.3 Tbps, the largest DDoS attack ever recorded"
            });

            Heading("Advantages of DDoS protection:");
            List(new string[]
            {
                "Keeps websites available for real users during an attack",
                "Prevents loss of income and damage to reputation",
                "Services like Cloudflare absorb attacks automatically and for free",
                "Tip: if you run a website, Cloudflare offers free DDoS protection"
            });
        }
    }

    // ── Child class 9 ─────────────────────────────────────────
    public class DataBreachTopic : AllTopics
    {
        public override string Name => "Data Breaches";

        public override void ShowContent(string userName)
        {
            BotSay("What is a data breach?");
            List(new string[]
            {
                "When private information is accessed or stolen without permission.",
                "Example: a company database is hacked and millions of passwords",
                "and credit card numbers are stolen and sold on the dark web."
            });

            Heading("Why does it matter?");
            List(new string[]
            {
                "Your stolen data can be used for identity theft, fraud or blackmail.",
                "You may not find out a breach happened until months later."
            });

            Heading("Common causes:");
            List(new string[]
            {
                "Weak or reused passwords on company systems",
                "Employees falling for phishing emails",
                "Unpatched software with known security vulnerabilities",
                "Poorly secured cloud storage"
            });

            Heading("What to do if your data is breached:");
            List(new string[]
            {
                "1. Change your password for the affected account immediately",
                "2. Enable 2FA on that account",
                "3. Check your bank statements for anything unusual",
                "4. Watch for phishing emails in the days that follow",
                "Warning: act immediately when a breach is announced - do not wait",
                "Tip: check if your email was in a breach at https://haveibeenpwned.com"
            });
        }
    }

    // ── Child class 10 ────────────────────────────────────────
    public class TwoFATopic : AllTopics
    {
        public override string Name => "Two-Factor Authentication (2FA)";

        public override void ShowContent(string userName)
        {
            BotSay("What is two-factor authentication?");
            List(new string[]
            {
                "A second security check after your password.",
                "Even if someone steals your password, they cannot log in without this second step.",
                "Example: after your Gmail password, your phone gets a 6-digit code.",
                "You type that code and only then are you allowed in."
            });

            Heading("Why does it matter?");
            List(new string[]
            {
                "Passwords alone are not enough - they get stolen, guessed or leaked.",
                "2FA means a stolen password is useless without your second factor."
            });

            Heading("Types of 2FA:");
            List(new string[]
            {
                "SMS code      - sent to your phone (easy but can be intercepted)",
                "Authenticator - app like Google Authenticator (much more secure)",
                "Hardware key  - physical device like YubiKey (most secure option)"
            });

            Heading("Advantages of 2FA:");
            List(new string[]
            {
                "Stops hackers even when they already have your password",
                "Free to set up on almost every major platform",
                "Takes less than 30 seconds to use each time you log in",
                "Warning: SMS-based 2FA can be bypassed - use an authenticator app instead",
                "Tip: enable 2FA on your email account first - it takes 2 minutes"
            });
        }
    }
}