using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float ramp_up_t = 0.1f;
    private float ramp_down_t = 1.0f;
    private float counter = 0.0f;

    private float full_scale = 0.078f;

    void Start(){
        this.transform.localScale = new Vector3(0, 0, 0);   
        this.counter = this.ramp_up_t;
    }

    void Update(){
        if (this.counter > 0){
            this.counter -= Time.deltaTime;

            float portion = 1 - (this.counter / this.ramp_up_t);
            this.transform.localScale = new Vector3(portion * this.full_scale, portion * this.full_scale, 1);
        } else if (this.counter > -this.ramp_down_t){
            this.counter -= Time.deltaTime;

            float portion = -(this.counter / this.ramp_down_t);
            this.transform.localScale = new Vector3((1 - portion) * this.full_scale, (1 - portion) * this.full_scale, 1);
        } else {
            Destroy(this.gameObject);
        }

    }
}
