using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour {
    [Header("Set these values dynamically")]
    public TMP_Text currScore;

    void Start() {
        GameObject scoreGameObject = GameObject.Find("ScoreCounter"); // finding the ScoreCounter GameObject
        currScore = scoreGameObject.GetComponent<TMP_Text>();
        currScore.text = "Score: 0"; // setting starting score to 0
    }

    void Update() {
        Vector3 mousePosition2D = Input.mousePosition; // where the mouse is, in screen coords
        // making the mouse position work when its converted to 3D to get the world's point, so 
        mousePosition2D.z = -Camera.main.transform.position.z;
        // this converts the point from 2D screen space into the 3D screen, from the camera I believe. If it was from
        // 0, 0, 0 then the previous line was not needed, but the camera is z -10 so the 2d mouse position needed a +10
        // z to ensure this mouse position coordinate is acutally Z = 0. I think this is why its done this way.
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);

        // move x position of this basket to mouse's x position
        Vector3 position = this.transform.position;
        position.x = mousePosition3D.x;
        this.transform.position = position;
    }

    // this is the logic which handles "catching" apples
    void OnCollisionEnter(Collision collision) {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);

            // increasing score
            string scoreText = currScore.text;
            scoreText = scoreText.Substring(7); // scoreText starts with Score: <scoreNum> so we remove the text portion
            int scoreNum = int.Parse(scoreText);
            scoreNum += 100;
            currScore.text = $"Score: {scoreNum}";

            if (scoreNum > HighScore.score) {
                HighScore.score = scoreNum;
            }
        }
        else if (collidedWith.tag == "Branch") {
            // colliding with a branch should end the game immediately
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.EndGame(currScore);
        }
    }
}
