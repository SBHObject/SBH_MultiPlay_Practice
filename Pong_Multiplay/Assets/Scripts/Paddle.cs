using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Paddle : MonoBehaviourPun
{
    public float speed;

    private void Update()
    {
        if (!photonView.IsMine) return;
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, move, 0);
    }
}
