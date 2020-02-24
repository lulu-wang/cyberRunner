using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupKnife : MonoBehaviour
{
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
           
            col.SendMessageUpwards("EquipWeapon");
            Destroy(gameObject);
        }
    }

}
