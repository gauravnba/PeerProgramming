using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DisplayGameOver : MonoBehaviour {
    public static UnityEvent GameOver;

    [SerializeField]
    private Texture2D RestartTexture;
    [SerializeField]
    private Texture2D QuitTexture;

    private float mRestartButtonPositionX;
    private float mQuitButtonPositionX;
    private float mButtonPositionY;


    // Use this for initialization
    void Start()
    {
        if (GameOver == null)
        {
            GameOver = new UnityEvent();
        }
        GameOver.AddListener(DisplayUI);

        // Set button positons values
        mRestartButtonPositionX = (Screen.width/4) - 25;
        mQuitButtonPositionX = (Screen.width * 3/4) - 25;
        mButtonPositionY = Screen.height * 2/3;

        gameObject.SetActive(false);
    }

    void DisplayUI() {
        gameObject.SetActive(true);
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(mRestartButtonPositionX, mButtonPositionY, 50, 50), RestartTexture)) {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1.0f;
        }

        if(GUI.Button(new Rect(mQuitButtonPositionX, mButtonPositionY, 50, 50), QuitTexture)) {
            Application.Quit();
        }
    }
}
