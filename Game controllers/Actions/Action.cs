using UnityEngine;

abstract class Action
{
    public abstract Action Execute(PlayerController shipController);//, params object[] objects);
}