using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private float t_after_collision = 3.0f;
    private float t_left = 0.0f;
    private bool will_explode = false;

    private float explode_radius = 0.5f;

    private SpriteRenderer sr;

    public GameObject explosion_prefab;

    void Start(){
        this.sr = GetComponent<SpriteRenderer>();
    }

    void Update(){
        if (this.will_explode){
            this.t_left -= Time.deltaTime;

            float portion = 1 - (this.t_left / this.t_after_collision);
            if (portion < 0.167){
                sr.color = Color.white;
            } else if (portion < 0.333){
                sr.color = Color.black;
            } else if (portion < 0.5){
                sr.color = Color.white;
            } else if (portion < 0.666){
                sr.color = Color.black;
            } else if (portion < 0.833){
                sr.color = Color.white;
            } else {
                sr.color = Color.black;
            }
            
            if (this.t_left <= 0){
                Instantiate(this.explosion_prefab, this.transform.position, Quaternion.identity);

                Destroy(this.gameObject);

                LayerMask mask = LayerMask.GetMask("l1", "l2", "l3");
                Collider2D[] results = Physics2D.OverlapCircleAll(new Vector2(this.transform.position.x, this.transform.position.y), this.explode_radius, mask);

                for (int i = 0; i < results.Length; i++){
                    Destroy(results[i].gameObject);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll){
        this.t_left = this.t_after_collision;
        this.will_explode = true;
    }
}
