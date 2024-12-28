using UnityEngine;

public class LockCameraX : MonoBehaviour
{
    [SerializeField] private float lockedXPosition = 0f; // Sabit X pozisyonu

    void LateUpdate()
    {
        // Kameranýn pozisyonunu alýn
        Vector3 currentPosition = transform.localPosition;

        // X pozisyonunu sabit tut, diðer eksenlerde serbest býrak
        transform.localPosition = new Vector3(lockedXPosition, currentPosition.y, currentPosition.z);
    }
}
