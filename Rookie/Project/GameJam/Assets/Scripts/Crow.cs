using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour {

    public float speedFactor = 1f;
    public float speedHorizontal = 1f;
    public Vector2 startPos;
    // Start is called before the first frame update
    void Start() {
        startPos = transform.position;
        RandomStart();
    }

    // Update is called once per frame
    void Update() {
        this.transform.position += Vector3.left * Time.deltaTime * speedHorizontal;
        EdgeCheck();
    }
    void EdgeCheck() {
        //Debug.Log( this.transform.position.x );

        if (this.transform.position.x > 5 || this.transform.position.x < -5) {

            //speedHorizontal = 0 - speedHorizontal;
            RandomStart();
        }
    }
    public void ResetCrow() {
        transform.position = startPos;
        RandomStart();
    }
    void RandomStart() {
        //int r = Random.Range( 0, 2 );
        float s = Random.Range( 1f, 5f ) * speedFactor;
        if (speedHorizontal < 0) {
            //this.transform.localScale.x = -1;
            speedHorizontal = s;
            transform.localRotation = Quaternion.Euler( 0, 0, 0 );
        } else {
            speedHorizontal = -s;
            transform.localRotation = Quaternion.Euler( 0, 180, 0 );
        }

    }
}
