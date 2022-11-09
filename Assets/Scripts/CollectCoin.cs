using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public int maxScore;
    public TextMeshProUGUI scoreTxt;
    public PlayerController playerController;
    public GameObject player;
    private Animator anim;
    public GameObject finishPanel;
    private void Start()
    {
        anim = player.GetComponent<Animator>();
        finishPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.CompareTag("Coin"))
        {
            // Collect Coin...!
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("End"))
        {
            //Congrats...
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180f, transform.rotation.z, Space.Self);
            finishPanel.SetActive(true);

            if (score >= maxScore)
            {
                // You Win...!
                anim.SetBool("Win", true);
            }
            else
            {
                // You Lose...!"
                anim.SetBool("Lose", true);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Touched Obstacle...!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden baþlat
        }
    }
    public void AddCoin()
    {
        score++;
        scoreTxt.text = "Score: " + score.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden baþlat
    }
}
