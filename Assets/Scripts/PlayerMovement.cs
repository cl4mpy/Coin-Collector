using UnityEngine; 
using UnityEngine.InputSystem;   // WAJIB untuk Input System 
using TMPro;
  
public class PlayerMovement : MonoBehaviour 
{ 
    public float kecepatan = 5f;
    public int skor = 0;

    public GameManager gameManager;
    public TextMeshProUGUI text;

    [Header("Input Setup")]
    public InputActionReference moveAction;

    private Vector2 arahGerak;   // nilai dari action "Move" 
  
    // Dipanggil OTOMATIS oleh komponen Player Input 
    // saat action "Move" pada asset InputSystem_Actions aktif. 
    // Nama method WAJIB: On + nama action  ->  OnMove 
    void OnMove(InputValue value) 
    { 
        // TODO: ambil nilai Vector2 dari input, simpan ke arahGerak 
        arahGerak = moveAction.action.ReadValue<Vector2>();
    }
  
    void Update() 
    { 
        // TODO: gerakkan objek memakai arahGerak. 
        // Ingat kalikan kecepatan DAN Time.deltaTime! 
        Vector3 arah = new Vector3(arahGerak.x, arahGerak.y, 0); 
        transform.position += arah * kecepatan * Time.deltaTime; 
    }

    // Dipanggil otomatis saat Player menyentuh objek ber-Trigger 
    void OnTriggerEnter2D(Collider2D other) 
    { 
        // TODO: cek apakah yang disentuh punya tag "Coin" 
        if (other.CompareTag("Coin")) 
        { 
            // TODO: hancurkan koin yang tersentuh
            Destroy(other.gameObject);
            // TODO: tambah skor sebanyak 1
            skor += 1; 
            // TODO: tampilkan skor ke Console
            Debug.Log("Score : " + skor);
            text.text = skor + "";
            gameManager.AmbilKoin();
        }
    }
} 