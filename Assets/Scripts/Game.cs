using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Control Control;

    [SerializeField]
    private GameObject _winPanel;

    [SerializeField]
    private GameObject _losePanel;

    private void Start()
    {
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
    }

    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing)
        {
            return;
        }

        CurrentState = State.Loss;
        Control.enabled = false;
        Debug.Log("Game Over!");
        //RealoadLevel();
        _losePanel.SetActive(true);
    }

    internal void OnPlayerReachFinish()
    {
        if (CurrentState != State.Playing)
        {
            return;
        }

        CurrentState = State.Won;
        Control.enabled = false;
        Debug.Log("You won!");
        LevelIndex++;
        //RealoadLevel();
        _winPanel.SetActive(true);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LEVELINDEX, 0);
        private set
        {
            PlayerPrefs.SetInt(LEVELINDEX, value);
            PlayerPrefs.Save();
        }
    }

    private const string LEVELINDEX = "LevelIndex";

    public void RealoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}