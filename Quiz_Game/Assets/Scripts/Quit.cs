using System.Collections;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{


    //audio
    public AudioSource backgroundMusic;
    public AudioSource audioSource;
    public AudioClip ButtonClick;

    //image
    public Texture2D cursorTexture;
    public VideoPlayer videoPlayer;



    void Start()
    {

        Cursor.visible = true;
        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }

            videoPlayer.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Demo_Scene");
    }
    public void QuitGame()
    {
       
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayGame()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        audioSource.PlayOneShot(ButtonClick);

        Invoke("LoadDemoScene", 2.5f);

        if (audioSource != null && ButtonClick != null)
        {
            Debug.Log("Playing button sound.");
            audioSource.PlayOneShot(ButtonClick);
        }
        else
        {
            Debug.Log("AudioSource or ButtonClick is not assigned.");
        }
    }

    private void LoadDemoScene()
    {
        SceneManager.LoadScene("Demo_Scene");
    }
}
