using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public List<GameObject> poolingList = new List<GameObject> ();

    private bool isGameOver = false; // 게임 오버가 되었는지 아닌지
    public bool IsGameOver
    {
        set
        {
            isGameOver = value;
        }
        get
        {
            return isGameOver;
        }
    }
    public Text scoreText;
    public GameObject gameOverObject;
    private float score;
    private void Awake()
    {
        PoolManager.instance = gameObject.AddComponent<PoolManager>();
        foreach(GameObject item in poolingList)
        {
            PoolManager.instance.CreatePool(item, transform, 10);
        }
        if(Instance != null)
        {
            Debug.LogError("두개의 게임매니저가 존재하고 있습니다.");
        }
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)&&isGameOver == true) // 좌클릭을 누르고 게임오버 상태이면
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재로드
        }
    }
    
    public void AddScore(int newScore)
    {
        if (isGameOver == false)
        {
            score += newScore;
            scoreText.text = "Score :" + score;
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverObject.SetActive(true);
    }
}
