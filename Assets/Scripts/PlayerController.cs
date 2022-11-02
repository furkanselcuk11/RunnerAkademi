using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    float _touchXDelta = 0;
    float _newX = 0;
    public float xSpeed;
    public float limitX;
    void Start()
    {

    }
    void Update()
    {
        SwipeCheck();
    }
    private void FixedUpdate()
    {
        //SwipeCheck();
    }
    void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Finger is moved...!
            //Debug.Log(Input.GetTouch(0).deltaPosition.x/Screen.width);  // Kayd�rma mesafesini ekran boyutuna g�re ayarlar
            _touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _touchXDelta = 0;
        }

        _newX = transform.position.x + xSpeed * _touchXDelta * Time.deltaTime;  // Karakterin X eksenindeki pozisyonu
        _newX = Mathf.Clamp(_newX, -limitX, limitX);    // X ekseninde gidebilece�i max ve min de�erleri

        Vector3 newPosition = new Vector3(_newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        // Karakter _newX de�erine g�re X ekseininde hareket eder ve ileri y�nde runningSpeed h�z�dna ilerler
        transform.position = newPosition;   // Karakter yeni pozisyonu al�r
    }
}
