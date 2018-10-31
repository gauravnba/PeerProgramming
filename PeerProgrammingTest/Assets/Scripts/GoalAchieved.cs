using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAchieved : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Game Over. You succeeded");
            Time.timeScale = 0;
            DisplayGameOver.GameOver.Invoke();
        }
    }
}
