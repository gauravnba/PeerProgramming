using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour {
    [SerializeField]
    float LerpSpeed = 0.01f;
    [SerializeField]
    float DetectionRange = 2.5f;

    private float mFloorBoundX;
    private float mFloorBoundZ;

    private Vector3 moveToLocation;
    private float toleranceForMoveTo = 0.1f;

    private GameObject mPlayer;

	// Use this for initialization
	void Start () {
        MeshCollider collider = GameObject.FindGameObjectWithTag("Floor").GetComponent<MeshCollider>();
        mFloorBoundX = collider.bounds.extents.x;
        mFloorBoundZ = collider.bounds.extents.z;

        mPlayer = GameObject.FindGameObjectWithTag("Player");

        moveToLocation = new Vector3(Random.Range(-mFloorBoundX, mFloorBoundX), transform.position.y, Random.Range(-mFloorBoundZ, mFloorBoundZ));
    }
	
	// Update is called once per frame
	void Update () {
        // Check if player is within detection range and set moveTo to that. Otherwise, just keep moving to random locations.
        if (Vector3.Distance(mPlayer.transform.position, transform.position) <= DetectionRange) {
            moveToLocation = mPlayer.transform.position;
        }
		else if (Vector3.Distance(moveToLocation, transform.position) <= toleranceForMoveTo) {
            moveToLocation = new Vector3(Random.Range(-mFloorBoundX, mFloorBoundX), transform.position.y, Random.Range(-mFloorBoundZ, mFloorBoundZ));
        }

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, moveToLocation.x, LerpSpeed * Time.deltaTime), transform.position.y, Mathf.Lerp(transform.position.z, moveToLocation.z, LerpSpeed * Time.deltaTime));
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Game Over. You failed");
            Time.timeScale = 0;
            DisplayGameOver.GameOver.Invoke();
        }
    }
}