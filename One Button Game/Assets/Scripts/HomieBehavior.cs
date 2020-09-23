using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomieBehavior : MonoBehaviour
{
    public Homie currentHomie; // who are we about to kiss goodnight?

    GameController gc;
    PlayerBehavior player;

    public IndicatorMovement intimidateIndicator, kissIndicator;
    bool canKiss;

    float actionTimer;
    public Animator anim;

    public Homie[] homies;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehavior>();
        gc = FindObjectOfType<GameController>();


        if (gc.round == 0)
            currentHomie = homies[0];
        else
            currentHomie = homies[Random.Range(0, homies.Length)];
        

        currentHomie = Instantiate(currentHomie); // creating copy so we don't directly affect object in project
        currentHomie.ChooseRandomAction();
        currentHomie.GetRandIntimidateTime();

        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = currentHomie.myAnim;

       
    }

    // Update is called once per frame
    void Update()
    {
        actionTimer += Time.deltaTime;

        if (!gc.gameEnd)
        {
            // behavior for trying to kiss and stuff

            if (actionTimer >= currentHomie.intimidateTime && !canKiss) //intimidate
            {
                canKiss = intimidateIndicator.canDoAction();
                if(canKiss)
                {
                    switch (currentHomie.myAction)
                    {
                        case (Homie.Action.lookAway):
                            SlowDownIndicators();
                            anim.Play("lookAway");
                            gc.ShowNewText(currentHomie._name + " looked away! Your side has slowed down.");
                            break;
                        case (Homie.Action.wink):
                            FreezeIndicators();
                            gc.ShowNewText(currentHomie._name + " winked at you! Your side has been frozen.");
                            anim.Play("wink");
                            break;
                        case (Homie.Action.smirk):
                            SpeedUpIndicators();
                            gc.ShowNewText(currentHomie._name + " smirked at you! Your side has sped up.");
                            anim.Play("smirk");
                            break;
                    }
                }
                else
                {
                    switch (currentHomie.myAction)
                    {
                        case (Homie.Action.lookAway):
                            anim.Play("lookAwayFail");
                            gc.ShowNewText(currentHomie._name + " started looking around the room");
                            break;
                        case (Homie.Action.wink):
                            anim.Play("winkFail");
                            gc.ShowNewText(currentHomie._name + " tried to flirt with you and failed.");
                            break;
                        case (Homie.Action.smirk):
                            anim.Play("smirkFail");
                            gc.ShowNewText(currentHomie._name + " smiled nervously at you");
                            break;
                    }
                    currentHomie.GetRandIntimidateTime();
                }
                actionTimer = 0f;
            }
            if (actionTimer >= currentHomie.kissTime && canKiss) // kith
            {
                if (kissIndicator.canDoAction())
                {
                    gc.ShowNewText(currentHomie._name + " kissed YOU goodnight ;)");
                    anim.Play("kiss");
                    gc.RestartMatch(true);
                    gc.gameEnd = true;
                }
                else
                {
                    anim.Play("kissFail");
                    gc.ShowNewText(currentHomie._name + " tried to give you a smooch and missed!");
                }
                currentHomie.GetRandKissTime();
                actionTimer = 0f;
            }

            /// behavior end


        
        }
         
    }

    public void FreezeIndicators()
    {
        player.anim.Play("shock");
        player.kissIndicator.stunTimer = 1.5f;
        player.intimidateIndicator.stunTimer = 1.5f;

        player.kissIndicator.wasStunned = true;
        player.intimidateIndicator.wasStunned = true;

        player.kissIndicator.wasStunned = true;
        player.intimidateIndicator.wasStunned = true;

        player.kissIndicator.didStop = true;
        player.intimidateIndicator.didStop = true;
    }

    public void SpeedUpIndicators()
    {
        player.anim.Play("shock");
        player.kissIndicator.speed += 0.03f;
        player.intimidateIndicator.speed += 0.03f;
    }
    public void SlowDownIndicators()
    {
        player.anim.Play("shock");
        player.kissIndicator.speed -= 0.03f;
        player.intimidateIndicator.speed -= 0.03f;
    }
}
