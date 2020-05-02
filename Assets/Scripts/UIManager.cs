using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public AnimationCurve BeatAnimation;
    public float maxTime = 0.0f;
    public float chrono = 0.0f;
    public float BPM = 0.0f;
    public PlayerController playerController;
    public GameObject playerHealthbar;

    public Image BPMBorder, CrosshairImage;
    public SpriteRenderer healthbarfill;
    public GameObject Crosshair;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthbar.transform.position = new Vector2(playerController.transform.position.x, playerController.transform.position.y - 0.7f);
        Crosshair.transform.position = Input.mousePosition;

        maxTime = 60 / BPM;

        chrono += Time.deltaTime;
        if(chrono > maxTime)
        {
            chrono = 0;
        }

        float alpha = BeatAnimation.Evaluate(chrono);
        BPMBorder.color = new Color(BPMBorder.color.r, BPMBorder.color.g, BPMBorder.color.b, alpha);

        switch (playerController.Color)
        {
            case PlayerController.CurrentGun.red:
                BPMBorder.color = new Color(Color.red.r, Color.red.g, Color.red.b, alpha);
                healthbarfill.color = Color.red;
                CrosshairImage.color = Color.red;
                CrosshairImage.fillAmount = (playerController.AMMO_RED * 100 / 30) / 100;
                Debug.Log((playerController.AMMO_RED * 100 / 30) / 100);
                break;
            case PlayerController.CurrentGun.green:
                BPMBorder.color = new Color(Color.green.r, Color.green.g, Color.green.b, alpha);
                healthbarfill.color = Color.green;
                CrosshairImage.color = Color.green;
                CrosshairImage.fillAmount = (playerController.AMMO_GREEN * 100 / 3) / 100;
                break;
            case PlayerController.CurrentGun.blue:
                BPMBorder.color = new Color(Color.blue.r, Color.blue.g, Color.blue.b, alpha);
                healthbarfill.color = Color.blue;
                CrosshairImage.color = Color.blue;
                CrosshairImage.fillAmount = (playerController.AMMO_BLUE * 100 / 8) / 100;
                break;


        }


    }
}
