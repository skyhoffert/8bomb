using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public GameObject objectToFollow;

    public float speed = 0.08f;

    private Camera cam;

    void Start(){
        this.cam = GetComponent<Camera>();
    }
	
	void FixedUpdate () {
        if (objectToFollow){
            Vector3 target = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, this.transform.position.z);
            float dist = (target - this.transform.position).magnitude;

            this.transform.position = Vector3.Lerp(this.transform.position, target, speed);
        }
	}

}
