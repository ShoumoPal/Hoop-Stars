using Generics;
using System;

// EventService used to trigger certain events and helps in implementing Observer Pattern

namespace Events
{
    public class EventService : GenericMonoSingleton<EventService>
    {
        public event Func<bool> HasPlayerWon;
        public event Func<bool> HasBotWon;
        public event Action<string> ShowGameOverPanel;

        public bool InvokeHasPlayerWon()
        {
            return (bool)HasPlayerWon?.Invoke();
        }
        public bool InvokeHasBotWon()
        {
            return (bool)HasBotWon?.Invoke();
        }
        public void InvokeShowGameOverPanel(string title)
        {
            ShowGameOverPanel?.Invoke(title);
        }
    }
}
