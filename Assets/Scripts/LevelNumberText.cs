using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour
{
    public Text Text;
    public Game Game;

    private void Start()
    {
        Text.text = $"Level {Game.LevelIndex + 1}";
    }


}
