using TMPro;
using UnityEngine;

public class RoundSignifierManager : MonoBehaviour {
    // this just manages the top UI text element which shows what current round the user is on
    private int numBasketsKnown;
    private TMP_Text roundNumberDisplay;
    private ApplePicker apScript;

    // it seems if initial declarations should occur, they should go here rather than Start()
    // idk fully the details yet so prob isnt optimal for this project
    void Awake() {
        apScript = Camera.main.GetComponent<ApplePicker>();
        numBasketsKnown = apScript.numBaskets;
    }

    void Start() {
        GameObject scoreGameObject = GameObject.Find("RoundSignifier");
        roundNumberDisplay = scoreGameObject.GetComponent<TMP_Text>();
        roundNumberDisplay.text = "Round: 1"; // setting starting round here
    }

    void Update() {
        if (apScript.basketList.Count < numBasketsKnown) {
            numBasketsKnown = apScript.basketList.Count;
            string displayText = roundNumberDisplay.text;
            displayText = displayText.Substring(7); // roundDisplay starts with Round: <roundNum> so we remove the text portion
            int currRoundNumber = int.Parse(displayText);
            currRoundNumber++;
            roundNumberDisplay.text = $"Round: {currRoundNumber}";
            if (currRoundNumber > apScript.numBaskets) {
                roundNumberDisplay.text = "Game Over";
            }
        }
    }
}
