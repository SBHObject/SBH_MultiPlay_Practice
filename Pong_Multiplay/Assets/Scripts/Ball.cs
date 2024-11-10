using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviourPun
{
    public float speed;
    public Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if(!photonView.IsMine)
        {
            Launch();
        }
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(x* speed, y* speed);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Invoke("Launch", 1f);
    }
}
