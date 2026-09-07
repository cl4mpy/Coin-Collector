using UnityEngine; 

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Pengaturan State Machine")]
    [SerializeField] private float jarakDeteksi = 6f;   // masuk CHASE
    [SerializeField] private float jarakSerang = 1.2f;  // masuk ATTACK
    [SerializeField] private float jedaSerang = 1f;     // detik antar serang

    // State sekarang -- mulai dari IDLE
    private StateZombie state = StateZombie.IDLE;
    private float waktuSerangTerakhir;

    [SerializeField] private int hp = 100;
    public float ms = 2f;
    protected Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PeriksaTransisi();

        switch (state)
        {
            case StateZombie.IDLE: PerilakuIdle(); break;
            case StateZombie.PATROL: PerilakuPatrol(); break;
            case StateZombie.CHASE: PerilakuChase(); break;
            case StateZombie.ATTACK: PerilakuAttack(); break;
        }
    }

    public void Kejar()
    {
        if (player == null) return;
        
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            ms * Time.deltaTime
        );
    }

    public virtual void Serang()
    {
        Debug.Log("Enemy menyerang!");
    }

    void PerilakuIdle()
    {

    }

    void PerilakuPatrol()
    {
        Debug.Log("Zombie Sedang Patroli");
    }

    void PerilakuChase()
    {
        Kejar();
    }

    void PerilakuAttack()
    {
        if (Time.time >= waktuSerangTerakhir + jedaSerang)
        {
            Serang();
            waktuSerangTerakhir = Time.time;
        }
    }

    public void KenaDamage(int jumlah)
    {
        hp -= jumlah;
        Debug.Log($"{gameObject.name} kena damage {jumlah}, HP sisa : {hp}");

        if (hp <= 0)
        {
            Mati();
        }
    }

    public void Mati()
    {
        Debug.Log($"{gameObject.name} Mati!");
        Destroy(gameObject);
    }

    public float JarakKePlayer()
    {
        if (player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, player.position);
    }

    void PeriksaTransisi()
    {
        float jarak = JarakKePlayer();

        if (jarak <= jarakSerang)
            state = StateZombie.ATTACK;
        
        else if (jarak <= jarakDeteksi)
            state = StateZombie.CHASE;

        else
            state = StateZombie.PATROL;
    }
}
