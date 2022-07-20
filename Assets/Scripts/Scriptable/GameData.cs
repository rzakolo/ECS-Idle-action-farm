using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Config", menuName = "Game Config/Config")]
public class GameData : ScriptableObject
{
    public float PickableDistance = 5;
    public float TakingTime = .3f;
    public int StashSize = 40;
    public int MoneyTakingAmount = 15;
    public Color GrassColor = Color.green;
    public Color WheatColor = Color.yellow;
}
