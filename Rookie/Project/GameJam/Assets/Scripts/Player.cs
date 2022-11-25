using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator playerAnimator;

    bool isAlive = true;
    bool isGliding = false;
    bool flip = false;

    float horizontalInput;
    float speedAt = 0f;
    float speedTo = 0f;
    float speedIncrease = 0.002f;

    float horizontalLimit = 2.5f;
    float moveHFactor = 5f;
    float startX;
    float startY;
    float startYoffset = -10;

    void Start() {
        playerAnimator = GetComponent<Animator>();
        startX = transform.position.x;
        startY = transform.position.y;
    }

    void Update() {
        if (isAlive) {
            HorPos();
            VertPos();
            GameManager.Instance.UpdateScore( speedAt );
        }
    }

    void HorPos() {
        horizontalInput = Input.GetAxis( "Horizontal" ) * moveHFactor * Time.deltaTime * (speedAt * 0.05f);
        if (!(transform.position.x + horizontalInput < -horizontalLimit) || !(transform.position.x + horizontalInput > horizontalLimit)) {
            transform.position = new Vector2( transform.position.x + horizontalInput, transform.position.y );
        }
        if (horizontalInput > 0 && flip == true) {
            flip = false;
            transform.localRotation = Quaternion.Euler( 0, 0, 0 );
        } else if (horizontalInput < 0 && flip == false) {
            flip = true;
            transform.localRotation = Quaternion.Euler( 0, 180, 0 );
        }
    }

    void VertPos() {
        startYoffset = Mathf.Lerp( startYoffset, 0, 0.01f );
        float xtraV = (speedAt * 0.15f);
        if (xtraV > 3) xtraV = 3;
        transform.position = new Vector2( transform.position.x, startY - xtraV - startYoffset );
        speedTo += speedIncrease;
        speedAt = Mathf.Lerp( speedAt, speedTo, 0.01f );
        if (!isGliding) {
            if (Input.GetKeyDown( KeyCode.Space )) {
                Stop();
            }
        }
    }

    IEnumerator GlideWait() {
        yield return new WaitForSeconds( 1f );
        Fall();
    }

    IEnumerator DeathWait() {
        yield return new WaitForSeconds( 2f );
        Restart();

    }
    void Stop() {
        playerAnimator.SetTrigger( "glide" );
        isGliding = true;
        speedTo = speedTo * 0.3f;
        StartCoroutine( GlideWait() );
        // change animation
    }

    void Fall() {
        playerAnimator.SetTrigger( "fall" );
        isGliding = false;
        Debug.Log("faller");
        // change animation
    }

    void Restart() {
        GameManager.Instance.ResetMe();
        speedAt = 0;
        speedTo = 0;
        //counter = 0;
        isAlive = true;
        isGliding = false;
        startYoffset = -10;
        playerAnimator.SetTrigger( "fall" ); 
        transform.position = new Vector3( startX, transform.position.y, 0f );
    }

    void OnTriggerEnter2D( Collider2D col ) {
        playerAnimator.SetTrigger( "die" );
        speedAt = 0;
        GameManager.Instance.speed = 0;
        isAlive = false;
        col.GetComponent<Crow>().Hit();
        StopAllCoroutines();
        StartCoroutine( DeathWait() );
    }
}
