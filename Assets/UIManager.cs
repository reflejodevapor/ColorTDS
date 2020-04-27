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

    public Image BPMBorder;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
                break;
            case PlayerController.CurrentGun.green:
                BPMBorder.color = new Color(Color.green.r, Color.green.g, Color.green.b, alpha);
                break;
            case PlayerController.CurrentGun.blue:
                BPMBorder.color = new Color(Color.blue.r, Color.blue.g, Color.blue.b, alpha);
                break;


        }


    }
}
