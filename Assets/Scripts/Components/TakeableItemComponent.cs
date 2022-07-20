using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TakeableItemComponent
{
    [HideInInspector] public Vector3 StartPosition;
    [HideInInspector] public Quaternion StartRotation;
    [HideInInspector] public Vector3 EndPosition;
    [HideInInspector] public Quaternion EndRotation;
    public float Time;
    public float CurrentTime;
    public bool Takeable;
}
