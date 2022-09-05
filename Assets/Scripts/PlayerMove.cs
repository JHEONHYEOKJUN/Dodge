using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rigid;

    public GameObject Spawn;

    public float speed = 8f;

    public static int life;

    void Start()
    {
        rigid = GetComponent<Rigidbody>(); //불러오기
        life = 3;
    }


    void Update()
    {
        float xInput = Input.GetAxis("Horizontal"); //키설정
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed; //방향벡터에 속도곱하기
        float zSpeed = zInput * speed;
        
        Vector3 newVelocity = new Vector3(xSpeed,0f,zSpeed); //방향+힘설정

        rigid.velocity = newVelocity; //움직임구현
    }

    public void Dmage()
    {
        life--;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Spawn.gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
    
}
