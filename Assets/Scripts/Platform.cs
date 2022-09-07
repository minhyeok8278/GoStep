using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool isStep = false;

    private void OnEnable()
    {
        isStep = false;

        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0) //3분의 1 확률로 발생되는거예요
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (transform.position.x <= -15f)
        {
            ScrollingObject.instance.obj.Remove(this.gameObject);
            PoolManager.instance.Push(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && isStep == false)
        {
            isStep = true;
            GameManager.Instance.AddScore(1);
        }
    }
}
