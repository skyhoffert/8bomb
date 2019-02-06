using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start(){
        int l1 = LayerMask.NameToLayer("l1");
        int l2 = LayerMask.NameToLayer("l2");
        Physics2D.IgnoreLayerCollision(l1, l2, true);
    }
}
