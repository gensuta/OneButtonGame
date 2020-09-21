using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomieBehavior : MonoBehaviour
{
    public Homie currentHomie; // who are we about to kiss goodnight?

    GameController gc;

    public IndicatorMovement intimidateIndicator, kissIndicator;
    bool canKiss;

    float actionTimer;

    // Start is called before the first frame update
    void Start()
    {
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

            //Debug.Log(actionTimer);



            /// behavior end


        
        }
         
    }
}
