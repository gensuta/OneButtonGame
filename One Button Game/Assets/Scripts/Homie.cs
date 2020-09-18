using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Homie",menuName ="Custom Class/Homie",order = 0)]
public class Homie : ScriptableObject
{
    public string _name;
    public float kissTime;
    public Animator myAnim;
    public enum Action
    {
        lookAway,
        pointFingers,
        squint
    };

    public Action myAction;

}

