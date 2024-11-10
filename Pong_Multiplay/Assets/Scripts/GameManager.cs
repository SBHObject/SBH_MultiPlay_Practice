using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    private Ball ball;

    public Goal player1Goal;

    public Goal player2Goal;

    [Header("UI")]
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    private int player1Score;
    private int player2Score;

    private void Start()
    {
        SpawnPaddle();
        if(photonView.AmOwner)
        {
            SpawnBall();
        }
    }

    private void SpawnPaddle()
    {
        int index = PhotonNetwork.LocalPlayer.ActorNumber;
        GameObject prefab = Resources.Load<GameObject>("Paddle");

        if(index == 1)
        {
            PhotonNetwork.Instantiate(prefab.name, new Vector3(-12, 0, 0), Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(prefab.name, new Vector3(12, 0, 0), Quaternion.identity);
        }
    }

    private void SpawnBall()
    {
        GameObject prefab = Resources.Load<GameObject>("Ball");
        GameObject go = PhotonNetwork.Instantiate(prefab.name, Vector3.zero, Quaternion.identity);
        ball = go.GetComponent<Ball>();
    }

    public void Player1Scored()
    {
        player1Score++;
        player1Text.text = player1Score.ToString();
        ResetPosition();
    }

    public void Player2Scored()
    {
        player2Score++;
        player2Text.text = player2Score.ToString();
        ResetPosition();
    }

    public void UpdateScore(int score1, int scroe2)
    {
        player1Text.text = score1.ToString();
        player2Text.text = scroe2.ToString();

        if(score1 > 5 || scroe2 > 5)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    private void ResetPosition()
    {
        ball.Reset();       
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
}
