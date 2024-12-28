using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform player; // Takip edilen oyuncu
    public Vector2 minBounds; // Minimum s�n�rlar
    public Vector2 maxBounds; // Maksimum s�n�rlar
    public float cameraZ = -10f; // Kamera Z ekseni

    void LateUpdate()
    {
        float clampedX = Mathf.Clamp(player.position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(player.position.y, minBounds.y, maxBounds.y);
        transform.position = new Vector3(clampedX, clampedY, cameraZ);
    }

}
