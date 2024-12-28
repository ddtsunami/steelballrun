using UnityEngine;

public class CameraLock : MonoBehaviour
{
    [SerializeField] private float lockedXPosition; // Kameran�n sabit x pozisyonu
    [SerializeField] private Transform target; // Takip edilecek nesne (�rne�in karakter)

    void LateUpdate()
    {
        if (target != null)
        {
            // Kameran�n sadece y ve z eksenlerini g�ncelle
            transform.position = new Vector3(
                lockedXPosition, // x pozisyonu sabit
                target.position.y, // Y ekseninde karakteri takip et
                transform.position.z // Z pozisyonu sabit
            );
        }
    }
}
