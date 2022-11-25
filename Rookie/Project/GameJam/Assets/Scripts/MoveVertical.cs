using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    public float speedFactor = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.up * Time.deltaTime * speedFactor * GameManager.Instance.speed;
        EdgeCheck();
    }

    void EdgeCheck() {
        //Debug.Log( this.transform.position.y );

        if (this.transform.position.y > 9) {

            this.transform.position = new Vector3( Random.Range( -4f, 5f ), -6f, 0f );
        }
    }
}
