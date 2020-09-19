using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    GameController gc;

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
            if (Input.GetKey(KeyCode.Space)) //intimidate
            {
                if (!gc.currentHomie.isdoingAction) gc.score += 1; // just trying to see something
            }
            if (Input.GetKeyUp(KeyCode.Space)) // kith
            {
                gc.score += 1;
                gc.gameEnd = true;
                Debug.Log("You kissed your homie goodnight uwu");
            }
        }

    }

}
