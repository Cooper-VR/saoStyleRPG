using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findVariable : MonoBehaviour
{
    public bool hasFound = false;
    public bool interupt = true;
    public void switchVariable()
    {
        interupt = false;
        hasFound = true;
    }
}
