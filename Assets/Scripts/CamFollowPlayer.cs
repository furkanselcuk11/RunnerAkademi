using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public float sSpeed = 10f;
    public Vector3 dist;
    public Transform lookTarget;
    private void LateUpdate()
    {
        Vector3 dPos = cameraTarget.position + dist;    // Takip edilecek mesafe
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime); // Kameran�n yumu�ak �ekilde takip et
        transform.position = sPos;  // Kameran�n pozisyonu
        transform.LookAt(lookTarget.position);  // Kameran�n bakaca�� y�n
    }
}
