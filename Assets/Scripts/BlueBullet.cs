using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BlueBullet : MonoBehaviour
{
    private Transform target;
    private Rigidbody rigid;

    public float turn;
    public float BulletVelocity;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        target = FindObjectOfType<PlayerMove>().transform;

        Destroy(gameObject, 3f); // 3초뒤삭제
    }

    public void FixedUpdate() // 유도탄
    {
        rigid.velocity = transform.forward * BulletVelocity;
        var bulletTargetRotation = Quaternion.LookRotation(target.position + new Vector3(0, 0.8f) - transform.position);
        rigid.MoveRotation(Quaternion.RotateTowards(transform.rotation, bulletTargetRotation, turn));
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMove playerMove = other.GetComponent<PlayerMove>(); //클래스불러오기

            if (playerMove != null)
            {
                playerMove.Dmage(); //총알에 닿이면 Die실행
                gameObject.SetActive(false);
            }
            if (PlayerMove.life <= 0)
            {
                playerMove.Die();
            }
        }
    }
}