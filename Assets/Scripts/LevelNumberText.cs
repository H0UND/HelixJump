using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour
{
    public Game Game;

    private void Start()
    {
        var level = gameObject.GetComponent<Text>();
        level.text = $"Level {Game.LevelIndex + 1}";
    }
}