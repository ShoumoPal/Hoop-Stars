using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : GenericMonoLazySingleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _botScoreText;
    [SerializeField] private CanvasGroup _backgroundUI;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _leftJump;
    [SerializeField] private Button _rightJump;

    private void Start()
    {
        _playerScoreText.text = "Player : 0";
        _botScoreText.text = "Bot : 0";

        _replayButton.onClick.AddListener(ReplayLevel);
        _quitButton.onClick.AddListener(QuitGame);
        _leftJump.onClick.AddListener(PlayerController.Instance.OnJumpLeft);
        _rightJump.onClick.AddListener(PlayerController.Instance.OnJumpRight);
    }

    public void AddPlayerScoreAndShow(int _playerScore)
    {
        _playerScoreText.text = "Player : " + _playerScore;
    }

    public void AddBotScoreAndShow(int _botScore)
    { 
        _botScoreText.text = "Bot : " + _botScore;
    }

    public void ShowGameOverPanel(string title)
    {
        Time.timeScale = 0f;

        _backgroundUI.blocksRaycasts = false;
        _titleText.text = title + " Wins!";
        _gameOverPanel.SetActive(true);
    }

    public void ReplayLevel()
    {
        _gameOverPanel.SetActive(false);
        _backgroundUI.blocksRaycasts = true;

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
