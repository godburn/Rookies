using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    float horizontalInput;
    float speed = 10.0f;
    float xRange = 2.5f;
    float factor = 5f;
    float speedIncrease = 0.01f;



    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {

        bool moveMe = true;
        horizontalInput = Input.GetAxis( "Horizontal" ) * factor * Time.deltaTime * (speed*0.1f);
        //transform.Translate( Vector3.right * horizontalInput * Time.deltaTime * speed );
        //Debug.Log(horizontalInput);
        if (transform.position.x + horizontalInput < -xRange) {
            moveMe = false;
        }

        if (transform.position.x + horizontalInput > xRange) {
            //transform.position = new Vector2( xRange, transform.position.y );
            moveMe = false;
        }

        if (moveMe) {
            transform.position = new Vector2( transform.position.x + horizontalInput, transform.position.y );
        }

        speed += speedIncrease;

        if (Input.GetKeyDown( KeyCode.Space )) {
            Stopper();
        }
        GameManager.Instance.speed = speed;
    }
        void OnTriggerEnter2D( Collider2D col ) {
            //if (col == null) {
            Debug.Log( col.gameObject.name + " : " + gameObject.name + " : " + Time.time );
            //}
        }
    void Stopper() {

        speed = 0;
        // change animation
    }

    

}
