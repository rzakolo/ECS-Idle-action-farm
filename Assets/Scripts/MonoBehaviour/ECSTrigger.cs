using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
public class ECSTrigger : MonoBehaviour
{
    [SerializeField] private string target = "Player";
    private EcsWorld _world = null;
    private Slice _slice = null;
    private Collider _collider = null;

    private void Start()
    {
        _world = WorldHandler.GetWorld();
        _slice = gameObject.GetComponent<Slice>();
        _collider = gameObject.GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(target)) return;
        _slice.enabled = true;
        _collider.enabled = false;
        var components = _world.ComponentPools;
    }
}
