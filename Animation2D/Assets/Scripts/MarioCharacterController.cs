using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioCharacterController : MonoBehaviour {

    public float motionSpeed;
    public float jumpForce;

    bool isMoving;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        isMoving = false;

        // Horizontal Motion
        if(Input.GetKey(KeyCode.RightArrow)) {
            isMoving = true;
            this.transform.Translate(Vector3.right * motionSpeed);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if(Input.GetKey(KeyCode.LeftArrow)) {
            isMoving = true;
            this.transform.Translate(Vector3.left * motionSpeed);
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        this.GetComponent<Animator>().SetBool("MarioIsMoving", isMoving);

        // Jump
        if(Input.GetKeyDown(KeyCode.Space)) {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            this.GetComponent<Animator>().SetBool("MarioIsOnFloor", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        this.GetComponent<Animator>().SetBool("MarioIsOnFloor", true);
    }
}
