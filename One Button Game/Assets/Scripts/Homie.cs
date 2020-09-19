using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Homie",menuName ="Custom Class/Homie",order = 0)]
public class Homie : ScriptableObject
{
    public string _name;
    public float intimidateTime;
    public float kissTime;
    public Animator myAnim;

    public bool isdoingAction;

    public enum Action
    {
        lookAway,
        pointFingers,
        squint
    };

    public Action myAction;

}

