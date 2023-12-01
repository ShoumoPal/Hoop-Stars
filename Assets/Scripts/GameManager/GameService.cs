using Events;
using Generics;

// Game Manager which handles game win condition

namespace GameManager
{
    public class GameService : GenericMonoLazySingleton<GameService>
    {
        private bool _isGameOverShown;

        private void Start()
        {
            _isGameOverShown = false;
        }

        private void Update()
        {
            if(EventService.Instance.InvokeHasPlayerWon() && !_isGameOverShown)
            {
                EventService.Instance.InvokeShowGameOverPanel("player");
                _isGameOverShown = true;
            }
            else if(EventService.Instance.InvokeHasBotWon() && !_isGameOverShown)
            {
                EventService.Instance.InvokeShowGameOverPanel("bot");
                _isGameOverShown = true;
            }
        }
    }
}

