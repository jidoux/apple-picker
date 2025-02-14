using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set these ApplePicker values in the inspector yes?")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start() {
        basketList = new List<GameObject>(); // makes the list usable
        for (int i = 0; i < numBaskets; i++) {
            // WHY IS IT T ?? WHAT IS THIS T? ?? WHAT ON EARTH IS THE T??
            GameObject tBasketGameObject = Instantiate<GameObject>(basketPrefab);
            Vector3 position = Vector3.zero;
            position.y = basketBottomY + (basketSpacingY * i);
            tBasketGameObject.transform.position = position;
            basketList.Add(tBasketGameObject);
        }
    }

    void Update() {
    }

    public void AppleDestroyed() {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); // cpu-intensive function btw so be careful with usage
        foreach (GameObject tGameObject in tAppleArray) {
            Destroy(tGameObject);
        }

        int lastBasketIndex = basketList.Count - 1;
        GameObject tBasketGameObject = basketList[lastBasketIndex]; // reference to the last basket index
        basketList.RemoveAt(lastBasketIndex);
        Destroy(tBasketGameObject);

        if (basketList.Count == 0) {
            GameObject scoreGameObject = GameObject.Find("ScoreCounter"); // finding the ScoreCounter GameObject
            TMP_Text currScore = scoreGameObject.GetComponent<TMP_Text>();
            EndGame(currScore);
        }
    }

    public void EndGame(TMP_Text currScoreText) {
        int score = int.Parse(currScoreText.text.Substring(7));
        StaticClass.userScore = score;
        SceneManager.LoadScene("_EndScreen_");
    }

    public void BranchDestroyed() {

    }
}
