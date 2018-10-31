using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float Speed = 5.0f;

    private float mFloorBoundX;
    private float mFloorBoundZ;

	// Use this for initialization
	void Start () {
        MeshCollider collider = GameObject.FindGameObjectWithTag("Floor").GetComponent<MeshCollider>();
        mFloorBoundX = collider.bounds.extents.x;
        mFloorBoundZ = collider.bounds.extents.z;
	}
	
	// Update is called once per frame
	void Update () {
        float xMovement = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        float zMovement = Input.GetAxis("Vertical") * Time.deltaTime * Speed;

        // Move the player on the horizontal plane.
        transform.Translate(new Vector3(xMovement, 0.0f, zMovement));

        // Clamp movements to the GameFloor.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -mFloorBoundX, mFloorBoundX), transform.position.y, Mathf.Clamp(transform.position.z, -mFloorBoundZ, mFloorBoundZ));
	}
}