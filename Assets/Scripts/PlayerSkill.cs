using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] Inventory inven;
    [SerializeField] float AddPower;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)&& !(inven.slots[0].isEmpty))
        {
            StartCoroutine(Dash());
            inven.slots[0].isEmpty = true;
            Destroy(inven.slots[0].Image);
        }
    }
    IEnumerator Dash()
    {
        ScrollingObject.instance.speed = 20f;
        yield return new WaitForSeconds(0.3f);
        ScrollingObject.instance.speed = 10f;
    }
}
