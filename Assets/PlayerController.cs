using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 0.0f;
    bool currentlyDashing = false;
    bool currentlyShootingR = false;
    bool currentlyShootingG = false;
    bool currentlyShootingB = false;


    public float ROF_RED = 0.0f;
    public float ROF_GREEN = 0.0f;
    public float ROF_BLUE = 0.0f;


    public Transform shootHole;

    public GameObject rshell, gshell, bshell;


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

        var LeftClick = Input.GetButton("Fire1");

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

        if (LeftClick)
        {
            switch (Color)
            {
                case CurrentGun.red:
                    if (!currentlyShootingR) { StartCoroutine(ShootRed()); }
                    break;
                case CurrentGun.green:
                    if (!currentlyShootingG) { StartCoroutine(ShootGreen());}
                    break;
                case CurrentGun.blue:
                    if (!currentlyShootingB) { StartCoroutine(ShootBlue()); }
                    break;
                default:break;
            }
        }


        var addAngle = 270;
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        /* Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         transform.LookAt(mouseWorldSpace,Vector3.forward);*/

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

    IEnumerator ShootRed()
    {
        Debug.Log("ShootRed");
        currentlyShootingR = true;
        Instantiate(rshell, new Vector3(shootHole.position.x,shootHole.position.y,0.0f), this.transform.localRotation);
        yield return new WaitForSeconds(ROF_RED);
        currentlyShootingR = false;
    }

    IEnumerator ShootGreen()
    {
        Debug.Log("ShootGreen");
        currentlyShootingG = true;
        Instantiate(gshell, new Vector3(shootHole.position.x, shootHole.position.y, 0.0f), this.transform.localRotation);
        yield return new WaitForSeconds(ROF_GREEN);
        currentlyShootingG = false;
    }

    IEnumerator ShootBlue()
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
