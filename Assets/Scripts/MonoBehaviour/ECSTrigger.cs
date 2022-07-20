using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
public class ECSTrigger : MonoBehaviour
{
    [SerializeField] private string target = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(target)) return;
        Debug.Log("Triggered");
        var stashCompanent = WorldHandler.GetWorld().GetPool<StashCompanent>().Items;
        for (int i = 0; i < stashCompanent.Length; i++)
        {
            stashCompanent[i].emptySlotIndex += 1;
        }
    }
}
