using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab; //총알설정
    public float minRate = 0.5f; //최소생성주기
    public float maxRate = 3.0f; //최대생성주기

    private Transform target; //타켓정하기
    private float spawnRate; //생성주기
    private float timeAfterSpawn; //최근생성시간 후 지난시간



    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(minRate, maxRate); //생성주기설정
        target = FindObjectOfType<PlayerMove>().transform; //플레이어한테방향설정
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime; //시간설정

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation); //총알생성
            bullet.transform.LookAt(target); //플레이어한테 벡터설정
            spawnRate = Random.Range(minRate, maxRate);
        }
    }
}
