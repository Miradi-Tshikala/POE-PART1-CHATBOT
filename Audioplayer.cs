using System;
using System.IO;
using System.Media;

namespace CyberBot.Core
{
    public static class AudioPlayer
    {
        // Plays a WAV file from the same folder as the program
        public static void PlayGreeting(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (File.Exists(path))
            {
                // PlaySync plays the audio and waits for it to finish
                SoundPlayer player = new SoundPlayer(path);
                player.PlaySync();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Hello, welcome to the cybersecurity awarness bot");
                Console.ResetColor();
            }
        }
    }
}