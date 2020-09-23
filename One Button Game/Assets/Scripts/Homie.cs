using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Homie", menuName = "Custom Class/Homie", order = 0)]
public class Homie : ScriptableObject
{
    public string _name;
    public float maxIntimidateTime, minIntimidateTime, intimidateTime;
    public float maxKissTime, minKissTime, kissTime;
    public AnimatorController myAnim;


    public enum Action // ea. action's number reflects the time it'll take for the homie to do it
    {
        // actually cut all these times in half
        lookAway = 1,
        wink = 2,
        smirk = 3
    };

    public Action myAction;

    public void ChooseRandomAction()
    {
        myAction = (Action)Random.Range(1, 4);
        intimidateTime = (float)myAction;

        /*        Debug.Log("Testing to make sure! Action is currently " + myAction + " and the time it takes to do it is " + intimidateTime);*/
    }

    public void GetRandIntimidateTime()
    {
        intimidateTime = Random.Range(minIntimidateTime, maxIntimidateTime);
    }

    public void GetRandKissTime()
    {
        kissTime = Random.Range(minKissTime, maxIntimidateTime);
    }
}




