using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 35f;
    private float jumpingPower = 40f;
    private bool isFacingRight = true;
    private Animator anim;

    [SerializeField] public GameObject yeniden;
    [SerializeField] public GameObject Reset;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject startPlatform;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Transform startPosition;

    [SerializeField] private TMP_Text timerText; // Timer UI'si için referans
    private float timer = 60f; // Başlangıç süresi
    private bool isTimerRunning = true; // Timer çalışıyor mu kontrolü

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (transform.position.x < -1000f || transform.position.x > 1000f || transform.position.y < -500f)
        {
            Debug.Log("1");
            GameOver();
        }   
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isTimerRunning)
        {
            // Timer'ı azalt
            timer -= Time.deltaTime;

            // Timer sıfıra ulaştıysa oyun biter
            if (timer <= 0f)
            {
                timer = 0f;
                Debug.Log("2");
                GameOver();
            }

            // Timer'ı UI'de güncelle
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = $"Time: {minutes:00}:{seconds:00}";
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            anim.SetTrigger("Jump");
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            anim.SetTrigger("Jump");
        }

        Flip();
    }

    private void FixedUpdate()
    {
        anim.SetBool("isWalking", true);
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        if (rb.linearVelocity == new Vector2(0, 0))
        anim.SetBool("isWalking", false);
    }

    public void stopWalk()
    {

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer yıldızla çarpışılırsa
        if (collision.CompareTag("Star"))
        {
            timer += 1f; // Timer'a 1 saniye ekle
            Destroy(collision.gameObject); // Yıldızı yok et
        }

        // Başlangıç platformuna temas kontrolü
        if (collision.gameObject == startPlatform)
        {
            Debug.Log("3");
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        anim.SetTrigger("Land");
    }

    [System.Obsolete]
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    private void GameOver()
    {
        isTimerRunning = false; // Timer'ı durdur
        rb.linearVelocity = Vector2.zero; // Hareketi durdur
        rb.bodyType = RigidbodyType2D.Kinematic; // Fizik simülasyonunu durdur
        gameOverUI.SetActive(true); // Game Over panelini aktif yap
       
        yeniden.SetActive(true);
    }

    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(20f, 10f, 1f)); // Sınırları temsil eder
    }


}
