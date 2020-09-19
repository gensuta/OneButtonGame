using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float matchTimer; // checking how long the match is going. 
    public Homie currentHomie; // who are we about to kiss goodnight?

    public int score; // we have a score system we need to figure out

    public bool gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        StartMatch();
        currentHomie = Instantiate(currentHomie); // creating copy so we don't directly affect object in project
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!gameEnd)
        {
            matchTimer += Time.deltaTime;
            if (matchTimer >= currentHomie.intimidateTime)
            {
                if (!currentHomie.isdoingAction)
                {
                    Debug.Log(currentHomie._name + " started to " + currentHomie.myAction);
                    currentHomie.isdoingAction = true;
                    Camera.main.backgroundColor = Color.gray;
                }
            }

            if (matchTimer >= currentHomie.kissTime)
            {
                gameEnd = true;
                Debug.Log(currentHomie._name + " kissed YOU goodnight first!!");
                Camera.main.backgroundColor = Color.black;
            }
        }

    }

    void StartMatch()
    {
        Debug.Log("Match Start!\nAbout to kiss " + currentHomie._name + " goodnight!");
    }
}
