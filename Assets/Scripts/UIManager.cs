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

    public Image BPMBorder, CrosshairImage, CrosshairImageTwo;
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
       
        Crosshair.transform.position = Input.mousePosition;

        maxTime = 60 / BPM;

        chrono += Time.deltaTime;
        if(chrono > maxTime)
        {
            chrono = 0;
        }

        float alpha = BeatAnimation.Evaluate(chrono);
        BPMBorder.color = new Color(BPMBorder.color.r, BPMBorder.color.g, BPMBorder.color.b, alpha);

        switch (playerController.unit.unitColor)
        {
            case Unit.CurrentColor.red:
                BPMBorder.color = new Color(GlobalColor.red.r, GlobalColor.red.g, GlobalColor.red.b, alpha);
                CrosshairImage.color = GlobalColor.red;
                CrosshairImageTwo.color = GlobalColor.red;
                CrosshairImage.fillAmount = (playerController.AMMO_RED * 100 / 30) / 100;
                break;
            case Unit.CurrentColor.green:
                BPMBorder.color = new Color(GlobalColor.green.r, GlobalColor.green.g, GlobalColor.green.b, alpha);
                CrosshairImage.color = GlobalColor.green;
                CrosshairImageTwo.color = GlobalColor.green;
                CrosshairImage.fillAmount = (playerController.AMMO_GREEN * 100 / 3) / 100;
                break;
            case Unit.CurrentColor.blue:
                BPMBorder.color = new Color(GlobalColor.blue.r, GlobalColor.blue.g, GlobalColor.blue.b, alpha);
                CrosshairImage.color = GlobalColor.blue;
                CrosshairImageTwo.color = GlobalColor.blue;
                CrosshairImage.fillAmount = (playerController.AMMO_BLUE * 100 / 8) / 100;
                break;


        }


    }
}
