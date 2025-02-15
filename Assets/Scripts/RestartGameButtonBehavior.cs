using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameButtonBehavior : MonoBehaviour {

    void Awake() {
        int highScoreValue = 0;
        string playerPrefsHighScoreName = "HighScore";
        if (PlayerPrefs.HasKey(playerPrefsHighScoreName)) {
            highScoreValue = PlayerPrefs.GetInt(playerPrefsHighScoreName);
        }
        int userScore = StaticClass.userScore;
        GameObject highScoreGO = GameObject.Find("HighScoreText");
        TMP_Text highScoreText = highScoreGO.GetComponent<TMP_Text>();
        highScoreText.text = $"The High Score: {highScoreValue}";
        GameObject userScoreGO = GameObject.Find("ScoreText");
        TMP_Text scoreText = userScoreGO.GetComponent<TMP_Text>();
        scoreText.text = $"Your Score: {userScore}";
    }

    public void OnButtonPress() {
        RestartGame();
    }

    private void RestartGame() {
        SceneManager.LoadScene("_GameScreen_");
    }
    void Start() {

    }

    void Update() {

    }
}
