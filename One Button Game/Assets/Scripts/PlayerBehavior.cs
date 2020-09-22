using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    GameController gc;
    public IndicatorMovement intimidateIndicator, kissIndicator;
    HomieBehavior homie;

    bool canKiss;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        homie = FindObjectOfType<HomieBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gc.gameEnd)
        {

            if (Input.GetKeyDown(KeyCode.Space) && !canKiss) //intimidate
            {
                canKiss = intimidateIndicator.canDoAction();
                if (canKiss)
                {
                    if (gc.matchTimer < 2)
                        SpeedUpIndicators();
                    else if (gc.matchTimer < 3)
                        FreezeIndicators();
                    else if (gc.matchTimer < 4)
                        SlowDownIndicators();
                }

                Debug.Log("canKiss is now " + canKiss);
            }
            if (Input.GetKeyUp(KeyCode.Space) && canKiss) // kith
            {
                if (kissIndicator.canDoAction())
                {
                    gc.score += 1;
                    gc.gameEnd = true;
                    Debug.Log("You kissed your homie goodnight uwu");
                }
                else
                {
                    Debug.Log("You missed! Try again"); // tbh you should have to start from the top if you miss.
                    // test that l8r
                }
            }
        }

    }

    public void FreezeIndicators()
    {
        homie.kissIndicator.stunTimer = 1.5f;
        homie.intimidateIndicator.stunTimer = 1.5f;

        homie.kissIndicator.wasStunned = true;
        homie.intimidateIndicator.wasStunned = true;

        homie.kissIndicator.didStop = true;
        homie.intimidateIndicator.didStop = true;
    }

    public void SpeedUpIndicators()
    {
        homie.kissIndicator.speed += 0.03f;
        homie.intimidateIndicator.speed += 0.03f;
    }
    public void SlowDownIndicators()
    {
        homie.kissIndicator.speed -= 0.03f;
        homie.intimidateIndicator.speed -= 0.03f;
    }
}
