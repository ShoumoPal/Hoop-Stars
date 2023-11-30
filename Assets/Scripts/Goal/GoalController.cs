using UnityEngine;

public class GoalController : MonoBehaviour
{
    private int _playerTriggerCount;
    private int _botTriggerCount;

    private int _playerScore;
    private int _botScore;

    private void Awake()
    {
        _playerTriggerCount = 0;
        _botTriggerCount = 0;
        _playerScore = 0;
        _botScore = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>())
        {
            _playerTriggerCount++;
            if (_playerTriggerCount == 2)
            {
                _playerScore++;
                Debug.Log("Player: " + _playerTriggerCount);
                UIManager.Instance.AddPlayerScoreAndShow(_playerScore);
            }
        }
        if(other.GetComponentInParent<BotController>())
        {
            _botTriggerCount++;
            if (_botTriggerCount == 2)
            {
                _botScore++;
                Debug.Log("Bot: " + _botTriggerCount);
                UIManager.Instance.AddBotScoreAndShow(_botScore);
            }
        }

        if(_playerScore == 3)
        {
            UIManager.Instance.ShowGameOverPanel("player");
        }
        else if(_botScore == 3)
        {
            UIManager.Instance.ShowGameOverPanel("Bot");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>())
        {
            _playerTriggerCount--;
            Debug.Log("Player: " + _playerTriggerCount);
        }
        else if (other.GetComponentInParent<BotController>())
        {
            _botTriggerCount--;
            Debug.Log("Bot: " + _botTriggerCount);
        }
    }
}
