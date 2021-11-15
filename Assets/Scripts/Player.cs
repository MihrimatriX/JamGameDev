using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool onGround = false;
    public float hiz;
    public float yukari;
    public Rigidbody2D rb;
    public GameObject gunumuz;
    public GameObject gecmis;
    public GameObject gelecek;
    public Transform ayak;
    public Transform karakter;
    public Animator anim;

    public GameObject tas;
    public GameObject para;
    public GameObject coin;

    public float SpawnRate = 2f;

    float nextSpawn = 0f;
    int gorevSayisi1 = 20;
    int gorevSayisi2 = 20;
    int gorevSayisi3 = 20;

    public int tasAdet;
    public int paraAdet;
    public int coinAdet;

    int oyunModu = 0;/**
                      * 0 -> gunumuz
                      * 1 -> gecmis
                      * 2 -> gelecek
                      * */

    float yatay;
    Vector3 camPosVector;
    Vector3 PosVector;

    void Start()
    {

    }

    void Update()
    {
        karakter.transform.position = transform.position;
        KarakterYon();
        IsGroundPlayer();
        Death();
        ifler();
        anim.SetBool("ziplamak", !onGround);
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (oyunModu == 0)
        {
            ParaSpawner();
        }
        if (oyunModu == 1)
        {
            TasSpawner();
        }
        if (oyunModu == 2)
        {
            CoinSpawner();
        }
    }
    void ifler()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (oyunModu == 1)
            {
                gecmis.SetActive(false);
                SecretObject("tas");

                gunumuz.SetActive(true);
                UnSecretObject("para");

                oyunModu = 0;
                karakter.transform.position += new Vector3(0, 5, 0);
            }
            else if (oyunModu == 0)
            {
                gunumuz.SetActive(false);
                SecretObject("para");

                gelecek.SetActive(true);
                UnSecretObject("coin");

                oyunModu = 2;
                karakter.transform.position += new Vector3(0, 5, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (oyunModu == 0)
            {
                gunumuz.SetActive(false);
                SecretObject("para");

                gecmis.SetActive(true);
                UnSecretObject("tas");

                oyunModu = 1;
                karakter.transform.position += new Vector3(0, 5, 0);
            }
            else if (oyunModu == 2)
            {
                gelecek.SetActive(false);
                SecretObject("coin");

                gunumuz.SetActive(true);
                UnSecretObject("para");

                oyunModu = 0;
                karakter.transform.position += new Vector3(0, 5, 0);
            }
        }
    }

    void KarakterYon()
    {
        yatay = Input.GetAxis("Horizontal");
        transform.position += new Vector3(yatay * hiz * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector3.up * yukari, ForceMode2D.Impulse);
            anim.SetBool("ziplamak", true);
        }
        if (yatay < 0)
        {
            transform.localScale = new Vector3(-5, 5, 1);
        }
        if (yatay > 0)
        {
            transform.localScale = new Vector3(5, 5, 1);
        }
    }

    public void IsGroundPlayer()
    {
        RaycastHit2D hit;
        if (Physics2D.Raycast(ayak.position, Vector2.down, .05f))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tas")
        {
            tasAdet++;
            Destroy(collision.gameObject);
            this.oyunModu = 1;
        }
        if (collision.gameObject.tag == "para")
        {
            paraAdet++;
            Destroy(collision.gameObject);
            this.oyunModu = 0;
        }
        if (collision.gameObject.tag == "coin")
        {
            coinAdet++;
            Destroy(collision.gameObject);
            this.oyunModu = 2;
        }
    }

    void Death()
    {
        if (transform.position.y < -8)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
        }
    }

    void SecretObject(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject a in gameObjects)
        {
            a.SetActive(false);
        }
    }
    void UnSecretObject(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject a in gameObjects)
        {
            a.SetActive(true);
        }
    }

    public void TasSpawner()
    {
        if (GorevList1())
        {
            Instantiate(tas, new Vector3((Random.Range(0, 40)), 5, 0), Quaternion.identity);
            gorevSayisi1--;

            nextSpawn = Time.time + SpawnRate;
        }
    }

    public void ParaSpawner()
    {
        if (GorevList2())
        {
            Instantiate(para, new Vector3((Random.Range(0, 40)), 5, 0), Quaternion.identity);
            gorevSayisi2--;

            nextSpawn = Time.time + SpawnRate;
        }
    }

    public void CoinSpawner()
    {
        if (GorevList3())
        {

            Instantiate(coin, new Vector3((Random.Range(0, 40)), 5, 0), Quaternion.identity);
            gorevSayisi3--;

            nextSpawn = Time.time + SpawnRate;
        }
    }

    bool GorevList1()
    {
        if (this.gorevSayisi1 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    bool GorevList2()
    {
        if (this.gorevSayisi2 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    bool GorevList3()
    {
        if (this.gorevSayisi3 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}