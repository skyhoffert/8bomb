using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{

    public GameObject bomb_prefab;

    public float x_size = 1.0f;
    public float y_size = 1.0f;

    public float odds_per_frame = 0.01f;

    void Update(){
        if (Random.value < this.odds_per_frame){
            Vector3 offset = new Vector3((0.5f - Random.value) * this.x_size, (0.5f - Random.value) * this.y_size, 0);
            Instantiate(bomb_prefab, this.transform.position + offset, Quaternion.identity);
        }
    }
}
