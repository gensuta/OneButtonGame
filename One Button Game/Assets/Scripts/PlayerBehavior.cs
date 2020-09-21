using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    GameController gc;
    public IndicatorMovement intimidateIndicator, kissIndicator;
    bool canKiss;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gc.gameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !canKiss) //intimidate
            {
                canKiss = intimidateIndicator.canDoAction();
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

}
