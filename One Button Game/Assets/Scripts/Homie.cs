using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Homie",menuName ="Custom Class/Homie",order = 0)]
public class Homie : ScriptableObject
{
    public string _name;
    public float intimidateTime;
    public float kissTime;
    public Animator myAnim; // may switch with sprites bc animating characters is too much. keep that in mind

    public bool isdoingAction;

    public enum Action // ea. action's number reflects the time it'll take for the homie to do it
    {
        // actually cut all these times in half
        lookAway = 1,
        pointFingers = 2,
        squint = 3
    };

    public Action myAction;

    public void ChooseRandomAction()
    {
        myAction = (Action)Random.Range(1, 4);
        intimidateTime = (float)myAction / 2f;

        Debug.Log("Testing to make sure! Action is currently " + myAction + " and the time it takes to do it is " + intimidateTime);
    }
    public void StartMatch()
    {
        Debug.Log("Match Start!\nAbout to kiss " + _name + " goodnight!");
    }
}

