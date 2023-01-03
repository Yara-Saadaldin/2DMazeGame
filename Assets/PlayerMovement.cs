using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;




public class PlayerMovement : MonoBehaviour {

    public float    MovementSpeed = 1;
    public          Rigidbody2D RigidBody;
    private         Vector2 MoveDirection;
    public          TMPro.TextMeshProUGUI counter;
    float           TimeRemaining = 60;


    void Update() {

        ProcessInputs();
        TimeRemaining -= Time.deltaTime;
    }


    void FixedUpdate() {

        Move();
    }


    void ProcessInputs() {

        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        MoveDirection = new Vector2(X, Y);
    }


    void Move() {

        RigidBody.velocity = new Vector2(MoveDirection.x * MovementSpeed, MoveDirection.y * MovementSpeed);
    }


    void OnTriggerEnter2D(Collider2D PrizeCollider) {
        if (PrizeCollider.gameObject.tag == "Finish") {

            Destroy(PrizeCollider.gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }
    }


    void OnGUI() {

        if (TimeRemaining > 0) {
 
            counter.text = "00 : " + (int)TimeRemaining;
        }
        else {

            counter.text = "TIME'S UP!";
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
