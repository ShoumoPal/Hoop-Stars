using UnityEngine;

public class GoalController : MonoBehaviour
{
    private bool _playerCheck1;
    private bool _playerCheck2;
    private bool _botCheck1;
    private bool _botCheck2;

    private int _playerScore;
    private int _botScore;

    private void Awake()
    {
        _playerScore = 0;
        _botScore = 0;

        _playerCheck1 = false;
        _playerCheck2 = false;
        _botCheck1 = false;
        _botCheck2 = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>())
        {
            if(other.CompareTag("Check 1"))
                _playerCheck1 = true;
            else if(other.CompareTag("Check 2"))
                _playerCheck2 = true;

            if (_playerCheck1 && _playerCheck2)
            {
                _playerScore++;
                UIManager.Instance.AddPlayerScoreAndShow(_playerScore);
            }
        }
        if(other.GetComponentInParent<BotController>())
        {
            if (other.CompareTag("Check 1"))
                _botCheck1 = true;
            else if (other.CompareTag("Check 2"))
                _botCheck2 = true;

            if (_botCheck1 && _botCheck2)
            {
                _botScore++;
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
            if (other.CompareTag("Check 1"))
                _playerCheck1 = false;
            else if (other.CompareTag("Check 2"))
                _playerCheck2 = false;
        }
        else if (other.GetComponentInParent<BotController>())
        {
            if (other.CompareTag("Check 1"))
                _botCheck1 = false;
            else if (other.CompareTag("Check 2"))
                _botCheck2 = false;
        }
    }
}
