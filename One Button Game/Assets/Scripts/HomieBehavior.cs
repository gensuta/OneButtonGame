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

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehavior>();
        gc = FindObjectOfType<GameController>();

        currentHomie = Instantiate(currentHomie); // creating copy so we don't directly affect object in project
        currentHomie.ChooseRandomAction();
        currentHomie.StartMatch();

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
                            player.SlowDownIndicators();
                            break;
                        case (Homie.Action.wink):
                            player.FreezeIndicators();
                            break;
                        case (Homie.Action.smirk):
                            player.SpeedUpIndicators();
                            break;
                    }
                }
                Debug.Log(currentHomie._name + "'s cankiss is now " + canKiss);
                actionTimer = 0f;
            }
            if (actionTimer >= currentHomie.kissTime && canKiss) // kith
            {
                if (kissIndicator.canDoAction())
                {
                    gc.gameEnd = true;
                    Debug.Log(currentHomie._name + " kissed YOU goodnight first!!");
                }
                else
                {
                    Debug.Log("You missed! Try again"); // tbh you should have to start from the top if you miss.
                    // test that l8r
                }
                currentHomie.kissTime = Random.Range(0.5f, 1f);
                actionTimer = 0f;
            }

            /// behavior end


        
        }
         
    }

    public void FreezeIndicators()
    {
        kissIndicator.stunTimer = 1.5f;
        intimidateIndicator.stunTimer = 1.5f;

        kissIndicator.wasStunned = true;
        intimidateIndicator.wasStunned = true;

        kissIndicator.wasStunned = true;
        intimidateIndicator.wasStunned = true;

        kissIndicator.didStop = true;
        intimidateIndicator.didStop = true;
    }

    public void SpeedUpIndicators()
    {
        kissIndicator.stunTimer += 0.03f;
        intimidateIndicator.stunTimer += 0.03f;
    }
    public void SlowDownIndicators()
    {
        kissIndicator.speed -= 0.03f;
        intimidateIndicator.speed -= 0.03f;
    }
}
