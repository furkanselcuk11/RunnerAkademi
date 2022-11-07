using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreTxt;
    public PlayerController playerController;
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
            Debug.Log("Congrats...!");
            playerController.runningSpeed = 0;            
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
}
