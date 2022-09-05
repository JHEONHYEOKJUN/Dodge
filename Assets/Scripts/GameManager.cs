using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임오버텍스트
    public Text timeText; //타임텍스트
    public Text recordText; //기록텍스트
    public Text lifeText;

    private float surviveTime; //생존시간
    private bool isGameover; //게임오버상태

    void Start()
    {
        surviveTime = 0; //시간 0으로 리셋
        isGameover = false; //게임오버상태에서 되돌림
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "x " + PlayerMove.life;

        if(!isGameover) //게임오버가 아니면
        {
            surviveTime += Time.deltaTime; //생존시간증가
            timeText.text = "Time: " + (int)surviveTime; //텍스트로 반영
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene"); //재시작
        }
    }

    public void EndGame()
    {
        isGameover = true; //게임오버상태
        gameoverText.SetActive(true); //게임오버텍스트등장

        float bestTime = PlayerPrefs.GetFloat("BestTime"); //베스트타임표시

        if(surviveTime > bestTime) //생존시간이 베스트타임보다 높으면 그시간을 베스트타임으로 설정
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: "+(int)bestTime;
    }
}