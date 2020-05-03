using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarBehavior : MonoBehaviour
{
    public Transform currentOwner;

    private void Update()
    {
        if (currentOwner != null)
        {
            this.transform.position = new Vector2(currentOwner.transform.position.x, currentOwner.transform.position.y - 0.75f);
            this.transform.GetChild(1).GetComponent<SpriteRenderer>().color = currentOwner.GetComponent<Unit>().color;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

}
