using UnityEngine;

public class Branch : MonoBehaviour {
    // The branch intentionally doesn't have a physics layer because i want it to collide with stuff like
    // the AppleTree. I just think it looks better this way; I like seeing the branch fall around wildly.
    [Header("Set these values in inspector")]
    private static float yValWhereAppleIsBelowViewport = -17f; // its static so its shared by all instances of this class to be clear.
    void Start() {
        
    }

    void Update() {
        if (transform.position.y < yValWhereAppleIsBelowViewport) {
            Destroy(this.gameObject);
        }
    }
}
