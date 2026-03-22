using System;
using System.Media; // Requires Windows

namespace CybersecurityChatbot
{
    class AudioPlayer
    {
        public static void PlayGreeting()
        {
            try
            {
                // Make sure greeting.wav is in your project folder
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync(); // Plays and waits until done
            }
            catch (Exception)
            {
                // If file not found, just skip it silently
                Console.WriteLine("[Voice greeting could not be played]");
            }
        }
    }
}