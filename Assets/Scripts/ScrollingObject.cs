using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScrollingObject : MonoBehaviour
{
     public static ScrollingObject instance;
    [SerializeField] float AddPower;
    public float speed = 10f;
    public List<GameObject> obj = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        foreach (var objItem in obj)
        {
            if (GameManager.Instance.IsGameOver == false)
            {
                objItem.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }
}
