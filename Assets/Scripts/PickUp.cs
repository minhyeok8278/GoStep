using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Inventory inven = collision.GetComponent<Inventory>();
            for(int i =0; i < inven.slots.Count; i++)
            {
                if (inven.slots[i].isEmpty)
                {
                    inven.slots[i].Image = Instantiate(slotItem,inven.slots[i].slotObj.transform,false);
                    inven.slots[i].isEmpty = false;
                    ScrollingObject.instance.obj.Remove(this.gameObject);
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }
}
