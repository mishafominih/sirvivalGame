using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public Vector2 DefPosition;
    public Vector2 AttackPosition;
    public bool isSit;

    public Vector2 GetPosition(string target)
    {
        if(isSit)
        {
            return DefPosition;
        }
        if (target == "def")
        {
            return DefPosition;
        }
        return AttackPosition;
    }
}
