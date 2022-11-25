using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 2.5f;
    public float factor = 5f;



    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {

        bool moveMe = true;
        horizontalInput = Input.GetAxis( "Horizontal" ) * factor * Time.deltaTime;
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


        //if (Input.GetKeyDown( KeyCode.Space )) {
            // Launch a projectile from the player
            //Instantiate( projectilePrefab, transform.position, projectilePrefab.transform.rotation );
        //}


    }
    void OnTriggerEnter2D( Collider2D col ) {
        //if (col == null) {
            Debug.Log( col.gameObject.name + " : " + gameObject.name + " : " + Time.time );
        //}
    }

    }
