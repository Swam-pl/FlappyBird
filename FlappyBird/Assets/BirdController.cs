using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Vector2 JumpForce;

    public GameObject GameOverPanel;
    public TextMeshProUGUI PointsTextureField;
    public TextMeshProUGUI HighscorePointsTextureField;


    public AudioSource audioSource;

    public AudioClip hitSfx;
    public AudioClip jumpSfx;
    public AudioClip scoreSfx;

    public Animator Anim;

    public static bool GameOver;
    public static bool HasStarted;

    public int Points;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        HasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        PointsTextureField.text = Points.ToString();
        if (GameOver)
            return;
        // Debug.Log("Hello World per frame");
        if (Input.GetButtonDown("Jump"))
        {
            audioSource.clip = jumpSfx;
            audioSource.Play();

            Anim.SetTrigger("FlapWings");

            if (HasStarted == false)
            {
                HasStarted = true;
                rb2D.gravityScale = 1;

            }
            rb2D.AddForce(JumpForce, ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver = true;
        GameOverPanel.SetActive(true);

        audioSource.clip = hitSfx;
        audioSource.Play();

        var currentHighscore = PlayerPrefs.GetInt("CDV_Highscore");

        if(currentHighscore < Points)
        {
            PlayerPrefs.SetInt("CDV_Highscore", Points);
            currentHighscore = Points;
        }

        HighscorePointsTextureField.text = currentHighscore.ToString();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Points++;

        audioSource.clip = scoreSfx;
        audioSource.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene("FlappyBird"); // ładowanie sceny początkowej
    }

}
