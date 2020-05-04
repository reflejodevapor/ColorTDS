using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarBehavior : MonoBehaviour
{
    public Transform currentOwner;

    private void Start()
    {
    }

    private void Update()
    {
        if(currentOwner == null)
        {
            Destroy(this.gameObject);
        }    


            this.transform.position = Camera.main.WorldToScreenPoint(new Vector2(currentOwner.transform.position.x, currentOwner.transform.position.y - 0.75f));
            this.transform.GetChild(0).GetComponent<Image>().color = currentOwner.GetComponent<Unit>().color;
        this.transform.GetChild(0).GetComponent<Image>().fillAmount = (currentOwner.GetComponent<Unit>().unitHealth) / 100;
    }

}
