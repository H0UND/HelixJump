using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Control Control;

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
        RealoadLevel();
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
        RealoadLevel();
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

    private void RealoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}