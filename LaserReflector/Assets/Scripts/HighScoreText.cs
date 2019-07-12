using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{

    public Text _highScore;

	void Start ()
    {
        _highScore.text = PlayerPrefs.GetString("Player Name") + " " + PlayerPrefs.GetInt("HighScore");
    }

}
