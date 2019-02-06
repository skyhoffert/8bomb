using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb2d;

    private float torque_factor = 5.0f;
    private float move_force_factor = 200.0f;
    private float jump_force_factor = 4000.0f;

    private bool jump_ready = true;

    void Start(){
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (this.transform.position.y < -50){
            this.transform.position = new Vector3(0, 8, 0);
            this.rb2d.velocity = new Vector2(0, 6);
        }
    }

    void FixedUpdate(){
        float turn = Input.GetAxis("Horizontal");
        this.rb2d.AddTorque(this.torque_factor * -turn);
        this.rb2d.AddForce(Vector3.right * this.move_force_factor * turn);

        if (this.jump_ready && Input.GetButtonDown("Jump")){
            this.rb2d.AddForce(Vector3.up * this.jump_force_factor);
            this.jump_ready = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll){
        if (!this.jump_ready){
            this.jump_ready = true;
        }
    }

}
