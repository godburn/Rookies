using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    float horizontalInput;
    float speed = 10.0f;
    float xRange = 2.5f;
    float factor = 5f;
    float speedIncrease = 0.01f;
    public Animator playerAnimator;
    bool gliding = false;
    float startH;
    float startV;
    public bool isAlive = true;
    int counter = 0;


    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start() {
        //playerAnimator = GetComponent<Animator>();

        startH = transform.position.x;
        startV = transform.position.y;

    }

    // Update is called once per frame
    void Update() {

        if (isAlive) {
            if (gliding) {

                if (speed > 3) {
                    Faller();
                }
            }


            bool moveMe = true;
            horizontalInput = Input.GetAxis( "Horizontal" ) * factor * Time.deltaTime * (speed * 0.1f);
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
                float xtraV = (speed * 0.2f);
                if (xtraV > 10) {
                    xtraV = 10;
                }
                transform.position = new Vector2( transform.position.x + horizontalInput, startV + xtraV );
            }

            speed += speedIncrease;
            if (!gliding) {
                if (Input.GetKeyDown( KeyCode.Space )) {
                    Stopper();
                }
            }

            //UpdateScore( float _speed )
            GameManager.Instance.UpdateScore( speed );
        } else {
            Debug.Log( "counbter = " + counter );
            counter++;
            if (counter > 500) {
                Restart();
            }
        }
    }


    void OnTriggerEnter2D( Collider2D col ) {
        //if (col == null) {
        speed = 0;
        GameManager.Instance.speed = 0;
        isAlive = false;
        //Debug.Log( col.gameObject.name + " : " + gameObject.name + " : " + Time.time );
        //}
    }


    void Stopper() {
        playerAnimator.SetBool( "fall", false );
        playerAnimator.SetBool( "glide", true );
        gliding = true;
        speed = speed * 0.2f;
        // change animation
    }

    void Faller() {
        playerAnimator.SetBool( "glide", false );
        playerAnimator.SetBool( "fall", true );
        gliding = false;
        // change animation
    }

    void Restart() {
        playerAnimator.SetBool( "glide", false );
        playerAnimator.SetBool( "fall", false );
        gliding = false;
        speed = 0;
        transform.position = new Vector3( startH, transform.position.y, 0f );
        counter = 0;
        isAlive=true;
        GameManager.Instance.distance = 0;
    }

}
