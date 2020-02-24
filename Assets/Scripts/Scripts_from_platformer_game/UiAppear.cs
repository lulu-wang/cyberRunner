using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAppear : MonoBehaviour
{
    //public Image customImage;
    //public Text dialogText;
    public Canvas canvas;

    //bool pressedC;
    Collider2D playerCol;

    private void Update()
    {
        if (canvas.enabled && Input.GetKey("c"))
        {
            //pressedC = true;
            playerCol.SendMessageUpwards("EquipWeapon");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        canvas.enabled = false;
        //customImage.enabled = false;
        //dialogText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            canvas.enabled = true;
            playerCol = col;

            //customImage.SendMessageUpwards("AnimateAppear");
            //customImage.enabled = true;
            //dialogText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            canvas.enabled = false;
            //customImage.enabled = false;
            //dialogText.enabled = false;
        }
    }
}
