using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class will hold anything can can change duing a conflict
public class Move
{
    //used when varibales dont need to be seen in inapector
    public MoveBase Base { get; set; }
    public int Pp { get; set; }

    public Move(MoveBase pBase)
    {
        Base = pBase;
        Pp = pBase.Pp;
    }
}
