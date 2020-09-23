using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    GameController gc;
    public IndicatorMovement intimidateIndicator, kissIndicator;
    HomieBehavior homie;

    bool canKiss;

    public Animator anim;
    Homie.Action myAction ;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        homie = FindObjectOfType<HomieBehavior>();
        anim = GetComponent<Animator>();
        myAction = (Homie.Action)Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gc.gameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !canKiss
                || Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !canKiss) //intimidate
            {
                canKiss = intimidateIndicator.canDoAction();
                if (canKiss)
                {
                    switch (myAction)
                    {
                        case (Homie.Action.lookAway):
                            SlowDownIndicators();
                            anim.Play("lookAway");
                            gc.ShowNewText("You teasingly looked away from " + homie.currentHomie._name);
                            break;
                        case (Homie.Action.wink):
                            FreezeIndicators();
                            anim.Play("wink");
                            gc.ShowNewText("You winked at " + homie.currentHomie._name);
                            break;
                        case (Homie.Action.smirk):
                            SpeedUpIndicators();
                            anim.Play("smirk");
                            gc.ShowNewText("You smirked flirtatiously at " + homie.currentHomie._name);
                            break;
                    }
                    gc.aud.clip = gc.right;
                    gc.aud.Play();
                }
                else
                {
                    switch (myAction)
                    {
                        case (Homie.Action.lookAway):
                            anim.Play("lookAwayFail");
                            gc.ShowNewText("You awkwardly looked away from " + homie.currentHomie._name);
                            break;
                        case (Homie.Action.wink):
                            anim.Play("winkFail");
                            gc.ShowNewText("You tried to wink at " + homie.currentHomie._name);
                            break;
                        case (Homie.Action.smirk):
                            anim.Play("smirkFail");
                            gc.ShowNewText("You made a weird smile at " + homie.currentHomie._name);
                            break;
                    }
                    gc.aud.clip = gc.wrong;
                    gc.aud.Play();
                }
            }

                if (Input.GetKeyUp(KeyCode.Space) && canKiss||
                Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended && canKiss) // kith
            {
                if (kissIndicator.canDoAction())
                {
                    gc.aud.clip = gc.right;
                    gc.aud.Play();
                    anim.Play("kiss");
                    gc.ShowNewText("You kissed " + homie.currentHomie._name + " goodnight! ;)");
                    gc.RestartMatch();
                    gc.gameEnd = true;
                }
                else
                {
                    anim.Play("kissFail");
                    gc.ShowNewText("You tried to give " + homie.currentHomie._name + " a smooch and missed!");
                    gc.aud.clip = gc.wrong;
                    gc.aud.Play();
                }
            }
        }

    }

    public void FreezeIndicators()
    {
        homie.anim.Play("shock");
        homie.kissIndicator.stunTimer = 1.5f;
        homie.intimidateIndicator.stunTimer = 1.5f;

        homie.kissIndicator.wasStunned = true;
        homie.intimidateIndicator.wasStunned = true;

        homie.kissIndicator.didStop = true;
        homie.intimidateIndicator.didStop = true;
    }

    public void SpeedUpIndicators()
    {
        homie.anim.Play("shock");
        homie.kissIndicator.speed += 0.03f;
        homie.intimidateIndicator.speed += 0.03f;
    }
    public void SlowDownIndicators()
    {
        homie.anim.Play("shock");
        homie.kissIndicator.speed -= 0.03f;
        homie.intimidateIndicator.speed -= 0.03f;
    }
}
