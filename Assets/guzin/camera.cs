using UnityEngine;

public class CameraLock : MonoBehaviour
{
    [SerializeField] private float lockedXPosition; // Kameranýn sabit x pozisyonu
    [SerializeField] private Transform target; // Takip edilecek nesne (örneðin karakter)

    void LateUpdate()
    {
        if (target != null)
        {
            // Kameranýn sadece y ve z eksenlerini güncelle
            transform.position = new Vector3(
                lockedXPosition, // x pozisyonu sabit
                target.position.y, // Y ekseninde karakteri takip et
                transform.position.z // Z pozisyonu sabit
            );
        }
    }
}
