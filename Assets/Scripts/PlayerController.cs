using System;
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

    public Animator crosshairAnim;

    public float blue_rotation = 10.0f;

    public float ROF_RED = 0.0f;
    public float ROF_GREEN = 0.0f;
    public float ROF_BLUE = 0.0f;

    public float AMMO_RED, AMMO_GREEN, AMMO_BLUE;


    public Transform shootHole;

    public GameObject rshell, gshell, bshell;

    public Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
    }


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
        var Reload = Input.GetButtonDown("Reload");

        var LeftClick = Input.GetButton("Fire1");

        this.gameObject.transform.Translate(new Vector2(Horizontal, Vertical) * playerSpeed * Time.deltaTime, Space.World);

        if (GunR && unit.unitColor != Unit.CurrentColor.red)
        {
            unit.unitColor = Unit.CurrentColor.red;
        }
        else if (GunG && unit.unitColor != Unit.CurrentColor.green)
        {
            unit.unitColor = Unit.CurrentColor.green;
        }
        else if (GunB && unit.unitColor != Unit.CurrentColor.blue)
        {
            unit.unitColor = Unit.CurrentColor.blue;
        }

        if (Dash && currentlyDashing == false && !(Horizontal == 0 && Vertical == 0))
        {
            StartCoroutine(Dashing());
        }

        if (Reload)
        {
            switch (unit.unitColor)
            {
                case Unit.CurrentColor.red:
                    AMMO_RED = 30;
                    crosshairAnim.SetTrigger("reload");
                    break;
                case Unit.CurrentColor.green:
                    if (!currentlyShootingG && AMMO_GREEN > 0) { StartCoroutine(ShootGreen()); }
                    break;
                case Unit.CurrentColor.blue:
                    if (!currentlyShootingB && AMMO_BLUE > 0) { StartCoroutine(ShootBlue()); }
                    break;
                default: break;
            }
        }

        if (LeftClick)
        {
            switch (unit.unitColor)
            {
                case Unit.CurrentColor.red:
                    if (!currentlyShootingR && AMMO_RED > 0) { StartCoroutine(ShootRed()); }
                    break;
                case Unit.CurrentColor.green:
                    if (!currentlyShootingG && AMMO_GREEN > 0) { StartCoroutine(ShootGreen());}
                    break;
                case Unit.CurrentColor.blue:
                    if (!currentlyShootingB && AMMO_BLUE > 0) { StartCoroutine(ShootBlue()); }
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
        currentlyDashing = true;
        playerSpeed *= 3.1f;
        yield return new WaitForSeconds(0.2f);
        playerSpeed /= 3.1f;
        currentlyDashing = false;
    }

    IEnumerator ShootRed()
    {
        AMMO_RED--;
        currentlyShootingR = true;
        Instantiate(rshell, new Vector3(shootHole.position.x,shootHole.position.y,0.0f), this.transform.localRotation);
        yield return new WaitForSeconds(ROF_RED);
        currentlyShootingR = false;
    }

    IEnumerator ShootGreen()
    {
        AMMO_GREEN--;
        currentlyShootingG = true;
        Instantiate(gshell, new Vector3(shootHole.position.x, shootHole.position.y, 0.0f), this.transform.localRotation);
        yield return new WaitForSeconds(ROF_GREEN);
        currentlyShootingG = false;
    }

    IEnumerator ShootBlue()
    {
        AMMO_BLUE--;
        currentlyShootingB = true;
        float[] rotaciones = {37.5f,22.5f,7.5f,-7.5f,-22.5f, -37.5f };
        for(int i = 1;i < 6; i++)
        {
            var bullet = Instantiate(bshell, new Vector3(shootHole.position.x, shootHole.position.y, 0.0f),this.transform.localRotation);
            bullet.transform.Rotate(0, 0,this.transform.rotation.z - rotaciones[i-1]);
        }

        yield return new WaitForSeconds(ROF_BLUE);
        currentlyShootingB = false;
    }
}
