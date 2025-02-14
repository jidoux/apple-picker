using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Variables Created In AppleTree.cs")]
    public GameObject applePrefab;
    public GameObject branchPrefab;
    public float velocity = 10f;
    // this is the position where it (basically) touches the edge of the viewport but doesnt exit the view at all
    public float maxDistanceAwayFromCenter = 25.45f;
    public float chanceToChangeDirections = 0.001f;
    //private bool isGoingFaster = false;
    public float secondsBetweenDrops = 1f;
    private float chanceToDropBranch = 0.1f;

    // called once before first execution of update after monobehavior gets created
    void Start() {
        // start the dropping of apples every second
        Invoke(nameof(DropSomething), 2f); // calls the named function 2 seconds from now
    }

    // instantiates an apple at the AppleTree's location. Note that when this happened, I had to manually set the apple prefab
    // in unity editor. Then, I had to set the AppleTree's Rigidbody component's isKinematic property to true. The meaning of this is
    // that it can still be moved via code, but it won't react to collisions with other GameObjects.
    void DropSomething() {
        GameObject gameObjectToDrop;
        if (Random.value < chanceToDropBranch) {
            gameObjectToDrop = Instantiate<GameObject>(branchPrefab);
        }
        else {
            gameObjectToDrop = Instantiate<GameObject>(applePrefab);
        }
        gameObjectToDrop.transform.position = transform.position; // setting the GameObjects's position to the postiion of the AppleTree
        Invoke(nameof(DropSomething), secondsBetweenDrops);
    }

    // since update is called as fast as the cpu + gpu can render frames we need a consistent update
    // which is not fps-based, which is exactly this, called 50 times a second.
    void FixedUpdate() {
        // Random.value returns a value 0-1 (inclusive)
        if (Random.value < chanceToChangeDirections) { // changing directions here
            velocity *= -1;
        }
        // // this is just some random thing I played around with which is a small chance to trigger temporary change in something
        // if ((Random.value < 0.001 && !isGoingFaster) || (Random.value < 0.01 && isGoingFaster)) {
        //     print("I am changing speed now okay?");
        //     if (isGoingFaster) {
        //         velocity = defaultVelocity; // TODO maybe add a ramp-down feature I'd say.
        //     }
        //     isGoingFaster = !isGoingFaster;
        // }
        // // so basically we randomly ramp up the velocity
        // if (isGoingFaster) {
        //     velocity *= 1.01f;
        //     // this is a cap on it in the case where theoretically it can get unreasonably fast
        //     // TODO test this by changing the odds.
        //     if (velocity == defaultVelocity * 10) {
        //         velocity = defaultVelocity;
        //     }
        // }
    }

    // called once per frame
    void Update() {
        // basic movement, and changing direction
        Vector3 currPosition = transform.position;
        // deltaTime is a measure of the number of seconds since the last Update() call right?
        // whereas fixedDeltaTime is a measure of seconds since the last FixedUpdate() call.
        currPosition.x += velocity * Time.deltaTime;
        transform.position = currPosition; // we moditified the position, now we apply this position to the GameObject's transform itself

        // so I guess this works by setting velocity to positive or negative values, and if its negative value it goes left, positive goes right
        if (currPosition.x < -maxDistanceAwayFromCenter) {
            velocity = Mathf.Abs(velocity); // move right
        }
        else if (currPosition.x > maxDistanceAwayFromCenter) {
            velocity = -Mathf.Abs(velocity); // move left
        }
    }
}
