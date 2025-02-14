using UnityEngine;

public class Apple : MonoBehaviour {
    [Header("Set these values in inspector")]
    private static float yValWhereAppleIsBelowViewport = -17f; // its static so its shared by all instances of this class to be clear.
    void Start() {
        
    }

    void Update() {
        if (transform.position.y < yValWhereAppleIsBelowViewport) {
            // any time you want to destroy an entire GameObject from within an attached component class, you need to
            // call Destroy(this.gameObject), since Destroy(this) will just remove the script from the Apple GameObject instance.
            Destroy(this.gameObject);

            // grabbing a reference to the ApplePicker script component which is attached to the Main Camera.
            // note that here, the Camera class has a built-in static variable Camera.main, so using GameObject.Find("Main Camera")
            // to get a reference to the main camera is unnecessary (although that would work I believe)
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleDestroyed();
        }
    }
}
