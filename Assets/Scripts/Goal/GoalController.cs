using Bot;
using UI;
using Player;
using Events;
using UnityEngine;
using Generics;

// Goal controller class helps to manage the score and communicate with the UI. Also maintains goal logic.

namespace Goal
{
    public class GoalController : GenericMonoLazySingleton<GoalController>
    {
        private bool _playerCheck1;
        private bool _playerCheck2;
        private bool _botCheck1;
        private bool _botCheck2;

        [SerializeField] private int _check1Layer;
        [SerializeField] private int _check2Layer;

        private int _playerScore;
        private int _botScore;

        private void OnEnable()
        {
            EventService.Instance.HasPlayerWon += HasPlayerWon;
            EventService.Instance.HasBotWon += HasBotWon;
        }

        private void Start()
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
            CheckIfScoredGoal(other);
        }

        private void OnTriggerExit(Collider other)
        {
            CheckExitedGoal(other);
        }

        private void CheckExitedGoal(Collider other)
        {
            if (other.GetComponentInParent<PlayerController>())
            {
                if (IsInLayerMask(other.gameObject.layer, _check1Layer))
                    _playerCheck1 = false;
                else if (IsInLayerMask(other.gameObject.layer, _check2Layer))
                    _playerCheck2 = false;
            }
            else if (other.GetComponentInParent<BotController>())
            {
                if (IsInLayerMask(other.gameObject.layer, _check1Layer))
                    _botCheck1 = false;
                else if (IsInLayerMask(other.gameObject.layer, _check2Layer))
                    _botCheck2 = false;
            }
        }

        private void CheckIfScoredGoal(Collider other)
        {
            if (other.GetComponentInParent<PlayerController>())
            {
                if (IsInLayerMask(other.gameObject.layer, _check1Layer))
                    _playerCheck1 = true;
                else if (IsInLayerMask(other.gameObject.layer, _check2Layer))
                    _playerCheck2 = true;

                if (_playerCheck1 && _playerCheck2)
                {
                    _playerScore++;
                    UIManager.Instance.AddPlayerScoreAndShow(_playerScore);
                }
            }
            if (other.GetComponentInParent<BotController>())
            {
                if (IsInLayerMask(other.gameObject.layer, _check1Layer))
                    _botCheck1 = true;
                else if (IsInLayerMask(other.gameObject.layer, _check2Layer))
                    _botCheck2 = true;

                if (_botCheck1 && _botCheck2)
                {
                    _botScore++;
                    UIManager.Instance.AddBotScoreAndShow(_botScore);
                }
            }

            HasPlayerWon();
            HasBotWon();
        }

        private bool HasPlayerWon()
        {
            return _playerScore == 3;
        }

        private bool HasBotWon()
        {
            return _botScore == 3;
        }

        private bool IsInLayerMask(int layer, int layerMask)
        {
            return (layerMask == layer);
        }

        private void OnDestroy()
        {
            EventService.Instance.HasPlayerWon -= HasPlayerWon;
            EventService.Instance.HasBotWon -= HasBotWon;
        }
    }
}

