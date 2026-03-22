using CyberBot.Core;

// Step 1: Play the voice greeting when the app starts
AudioPlayer.PlayGreeting("greeting.wav");

// Step 2: Start the chatbot
ChatSession chat = new ChatSession();
chat.Start();