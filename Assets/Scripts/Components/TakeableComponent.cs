using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TakeableComponent
{
    [HideInInspector] public Transform StartTransform;
    [HideInInspector] public Transform EndTransform;
    public float Time;
    public float CurrentTime;
    public bool Takeable;
}
