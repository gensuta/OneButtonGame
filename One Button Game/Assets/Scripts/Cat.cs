using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName = "Custom Class/Cat", order = 1)]
public class Cat : ScriptableObject
{
    public string _name;
    public float sniffTime,petTime,bowlAmt;
    public bool doesLikeWiggles;
    public int daysTillStay;

    public Animator myAnim;

}