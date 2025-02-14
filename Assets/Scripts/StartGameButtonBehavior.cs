using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButtonBehavior : MonoBehaviour {

    public void OnButtonPress() {
        StartGame();
    }

    private void StartGame() {
        SceneManager.LoadScene("_GameScreen_");
    }
    void Start() {
        
    }

    void Update() {
        
    }
}
