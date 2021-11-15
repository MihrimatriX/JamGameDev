using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGrounded : MonoBehaviour
{
    public GameObject coin;
    public GameObject para;
    public GameObject tas;
    public LayerMask yer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        if (Physics2D.Raycast(coin.transform.position, Vector2.down, 0.9f, yer))
        {
            coin.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        if (Physics2D.Raycast(para.transform.position, Vector2.down, 0.9f, yer))
        {
            para.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        if (Physics2D.Raycast(tas.transform.position, Vector2.down, 0.9f, yer))
        {
            tas.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
}