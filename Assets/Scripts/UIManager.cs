using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel, gameOverPanel;

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += StateAction;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= StateAction;
    }

    private void StateAction(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                mainMenuPanel.SetActive(true);
                break;
            case GameState.GameOver:
                gameOverPanel.SetActive(true);
                break;
        }
    }

    public void TapToStartButton()
    {
        mainMenuPanel.SetActive(false);
        GameManager.Instance.UpdateGameState(GameState.Gameplay);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
