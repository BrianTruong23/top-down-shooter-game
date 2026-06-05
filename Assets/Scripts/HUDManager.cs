using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TMP_Text hudText;
    public Image[] healthIcons;
    int health = 3;
    int score = 0;
    bool gameOver = false;
    public AudioSource audioSource;
    public AudioClip explosionClip;
    public AudioClip playerHitClip;


    void Start()
    {
        UpdateHUD();
        UpdateHealthIcons();
        
    }

    public void PlayExplosionSound()
    {
        audioSource.PlayOneShot(explosionClip);
    }

    public void PlayPlayerHit()
    {
        audioSource.PlayOneShot(playerHitClip);
    }


    void UpdateHealthIcons()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            healthIcons[i].enabled = i < health;
        }
    }

    public void AddScore(int amount)
    {
        if (gameOver){
            return;
        }
        score += amount; 
        UpdateHUD();
        PlayExplosionSound();
    }

    public void TakeDamage(int amount)
    {
        if (gameOver){
            return;
        }
        health -= amount;
        UpdateHUD();
        UpdateHealthIcons();

        if (health <= 0)
        {
            gameOver = true;
            hudText.text = "Game Over!\nFinal Score: " + score;

            PlayExplosionSound();
            
            // wait for 2 seconds and then reload the scene
            // stop everything else from happening
            Time.timeScale = 0f;
            StartCoroutine(GameOverSequence());

        }
        else
        {
            PlayPlayerHit();
        }
    }

    IEnumerator GameOverSequence()
    {
        yield return new WaitForSecondsRealtime(1f);
        hudText.text = "Good luck next time!";

        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateHUD()
    {
        hudText.text = ""  + "\nScore: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
