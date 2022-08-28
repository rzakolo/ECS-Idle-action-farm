using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class SellTrigger : MonoBehaviour
{
    [SerializeField] private string target = "Player";
    private EcsWorld _world = null;
    private void Start()
    {
        _world = WorldHandler.GetWorld();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(target))
        {
            var moneySellEvent = WorldHandler.GetWorld().NewEntity();
            moneySellEvent.Get<SellEvent>();
        }
    }
}
