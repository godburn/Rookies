using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour {

    float speedFactor = 1f;
    float speedX = 1f;
    Vector2 startPos;
    bool isActive = true;
    // Start is called before the first frame update
    void Start() {
        startPos = transform.position;
        RandomStart();
    }

    // Update is called once per frame
    void Update() {
        if (isActive) {
            this.transform.position += Vector3.left * Time.deltaTime * speedX;
            EdgeCheck();
        }
    }
    public void Hit() {
        isActive = false;
    }

    void EdgeCheck() {
        if (this.transform.position.x > 5 || this.transform.position.x < -5) {
            RandomStart();
        }
    }
    public void ResetCrow() {
        isActive = true;
        transform.position = startPos;
        RandomStart();
    }
    void RandomStart() {
        float s = Random.Range( 1f, 3f ) * speedFactor;
        if (speedX < 0) {
            speedX = s;
            transform.localRotation = Quaternion.Euler( 0, 0, 0 );
        } else {
            speedX = -s;
            transform.localRotation = Quaternion.Euler( 0, 180, 0 );
        }
    }
}
