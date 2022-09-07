using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;
    [SerializeField] Transform fieldTransform;
    private void Awake()
    {
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        width = backGroundCollider.size.x;
    }

    private void Update()
    {
        if (transform.position.x < -width)
        {
            Repositioning();
        }
    }
    private void Repositioning()
    {
        //Vector2 offset = new Vector2(width * 2f, 0f);
        transform.position = fieldTransform.position + new Vector3(width, 0);
    }
}
