using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody Brigid;

    public float speed = 8f;

    void Start()
    {
        Brigid = GetComponent<Rigidbody>(); //불러오기
        Brigid.velocity = transform.forward * speed; //총알속도,방향정하기

        Destroy(gameObject, 3f); // 3초뒤삭제
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerMove playerMove = other.GetComponent<PlayerMove>(); //클래스불러오기

            if(playerMove != null)
            {
                playerMove.Dmage();
                gameObject.SetActive(false);
            }
            if(PlayerMove.life <= 0)
            {
                playerMove.Die();
            }
        }
    }
}
