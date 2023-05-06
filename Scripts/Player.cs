using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Speeds { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 };
public enum Gamemodes { Cube = 0, Ship = 1, UFO = 2 };

public class Player : MonoBehaviour
{
    [SerializeField] private Speeds CurrentSpeed;
    [SerializeField] private Speeds PrevSpeed;
    [SerializeField] private Gamemodes CurrentGamemode;
    //                       0      1      2       3      4
    private float[] SpeedValues = { 25f, 35f, 45f, 55f, 65f };

    [SerializeField] private Transform ColliderTransform;

    [SerializeField] private GameObject Cube;
    [SerializeField] private GameObject Ship;
    [SerializeField] private GameObject UFO;
    [SerializeField] private GameObject IncSpeed;
    [SerializeField] private GameObject DecSpeed;
    [SerializeField] private GameObject CubeExplosionEffect;
    [SerializeField] private GameObject ShipExplosionEffect;
    [SerializeField] private GameObject UFOExplosionEffect;
    [SerializeField] private GameObject EndGameEffect;
    [SerializeField] private GameObject JumpEffect;
    [SerializeField] private GameObject MoveEffect;
    [SerializeField] private GameObject FlyEffect;

    [SerializeField] private bool isDead;

    [SerializeField] private AudioClip DeathSound;
    [SerializeField] private AudioClip EndSound;
    [SerializeField] private AudioSource audioSource;

    private Vector2 startPos;

    protected Rigidbody2D rb;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        Collider2D collider = ColliderTransform.GetChild(0).GetComponent<Collider2D>();
        collider.enabled = true;
        isDead=false;
    }

    void Update()
    {
        if (isDead)
            rb.velocity = Vector2.zero;
        else
        {
            transform.position += Vector3.right * SpeedValues[(int)CurrentSpeed] * Time.deltaTime;     
        }
    }
    private void jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 90f, ForceMode2D.Impulse);
    }

    public void ChangeThroughPortal(Gamemodes Gamemode, Speeds Speed, int State)
    {
        switch (State)
        {   
            case 0:
                CurrentSpeed = Speed; 
                break;
            case 1:
                PrevSpeed = CurrentSpeed;
                CurrentGamemode = Gamemode;
                rb.gravityScale = 12.41067f;
                switch (Gamemode)
                {
                    case Gamemodes.Cube:
                        Cube.SetActive(true);
                        Ship.SetActive(false);
                        UFO.SetActive(false);
                        MoveEffect.SetActive(true);
                        JumpEffect.SetActive(false);
                        FlyEffect.SetActive(false);
                        break;
                    case Gamemodes.Ship:
                        Cube.SetActive(false);
                        Ship.SetActive(true);
                        UFO.SetActive(false);
                        MoveEffect.SetActive(false);
                        JumpEffect.SetActive(false);
                        FlyEffect.SetActive(false);
                        break;
                    case Gamemodes.UFO:
                        Cube.SetActive(false);
                        Ship.SetActive(false);
                        UFO.SetActive(true);
                        MoveEffect.SetActive(false);
                        JumpEffect.SetActive(true);
                        FlyEffect.SetActive(false);
                        break;
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {          
            isDead = true;
            if (CurrentGamemode == Gamemodes.Cube)
            {
                Cube.SetActive(false);
                audioSource.clip = DeathSound;
                audioSource.Play();
                CubeExplosionEffect.SetActive(true);             
                StartCoroutine(Respawn(1f));
            }
                
            else if (CurrentGamemode == Gamemodes.Ship)
            {
                Ship.SetActive(false);
                ShipExplosionEffect.SetActive(true);
                StartCoroutine(Respawn(1f));
            }
            else
            {
                UFO.SetActive(false);
                UFOExplosionEffect.SetActive(true);
                StartCoroutine(Respawn(1f));
            }

        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CheckPoint"))
            startPos = transform.position;
        if(collision.gameObject.CompareTag("BeforeGate"))
        {
            Time.timeScale = 0.1f;
            if (CurrentGamemode == Gamemodes.Cube)
                jump();
        }
        if (collision.gameObject.CompareTag("Gate"))
        {
            isDead = true;
            Time.timeScale = 1f;
            StartCoroutine(ThroughGate());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("IncSpeed"))
        {
            IncSpeed.SetActive(true);
            StartCoroutine(IncSpeedEffect());
        }
        if (collision.gameObject.CompareTag("DecSpeed"))
        {
            DecSpeed.SetActive(true);
            StartCoroutine(DecSpeedEffect());
        }
    }
    IEnumerator ThroughGate()
    {
        rb.velocity = Vector2.zero;
        if (CurrentGamemode == Gamemodes.Cube)
            Cube.SetActive(false);
        else if (CurrentGamemode == Gamemodes.Ship)
            Ship.SetActive(true);
        else UFO.SetActive(true);
        audioSource.clip = EndSound;
        audioSource.Play();
        EndGameEffect.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("End");
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        isDead = false;
        rb.gravityScale = 12.41067f;
        CurrentSpeed=PrevSpeed;
        if (CurrentGamemode == Gamemodes.Cube)
        {
            Cube.SetActive(true);
            CubeExplosionEffect.SetActive(false);
        }

        else if (CurrentGamemode == Gamemodes.Ship)
        {
            Ship.SetActive(true);
            ShipExplosionEffect.SetActive(false);
        }
        else
        {
            UFO.SetActive(true);
            UFOExplosionEffect.SetActive(false);
        }
    }
    IEnumerator IncSpeedEffect()
    {
        yield return new WaitForSeconds(1f);
        IncSpeed.SetActive(false);
    }
    IEnumerator DecSpeedEffect()
    {
        yield return new WaitForSeconds(1f);
        DecSpeed.SetActive(false);
    }

}