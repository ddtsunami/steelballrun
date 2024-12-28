using UnityEngine;

public class LockCameraX : MonoBehaviour
{
    [SerializeField] private float lockedXPosition = 0f; // Sabit X pozisyonu

    void LateUpdate()
    {
        // Kameran�n pozisyonunu al�n
        Vector3 currentPosition = transform.localPosition;

        // X pozisyonunu sabit tut, di�er eksenlerde serbest b�rak
        transform.localPosition = new Vector3(lockedXPosition, currentPosition.y, currentPosition.z);
    }
}
