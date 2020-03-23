using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 0.0f;
    bool currentlyDashing = false;
    public enum CurrentGun
    {
        red,
        green,
        blue
    }

    public CurrentGun Color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Horizontal = Input.GetAxis("Horizontal");
        var Vertical = Input.GetAxis("Vertical");

        var GunR = Input.GetButtonDown("GunR");
        var GunG = Input.GetButtonDown("GunG");
        var GunB = Input.GetButtonDown("GunB");

        var Dash = Input.GetButtonDown("Dash");

        this.gameObject.transform.Translate(new Vector2(Horizontal, Vertical) * playerSpeed * Time.deltaTime, Space.World);

        if (GunR && Color != CurrentGun.red)
        {
            Debug.Log("GunR");
            Color = CurrentGun.red;
        }
        else if (GunG && Color != CurrentGun.green)
        {
            Debug.Log("GunG");
            Color = CurrentGun.green;
        }
        else if (GunB && Color != CurrentGun.blue)
        {
            Debug.Log("GunB");
            Color = CurrentGun.blue;
        }

        if (Dash && currentlyDashing == false && !(Horizontal == 0 && Vertical == 0))
        {
            StartCoroutine(Dashing());
        }

        
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(mouseWorldSpace,Vector3.forward);

    }

    IEnumerator Dashing()
    {
        Debug.Log("Dash Started");
        currentlyDashing = true;
        playerSpeed *= 3.1f;
        yield return new WaitForSeconds(0.2f);
        playerSpeed /= 3.1f;
        currentlyDashing = false;
        Debug.Log("Dash Finished");
    }
}
