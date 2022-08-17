using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using DG.Tweening;
using Zenject;
using Leopotam.Ecs;
using Voody.UniLeo;

public class Slice : MonoBehaviour
{
    public Material Material;
    private GameObject _slicedGO;
    private EcsWorld _world;
    public GameObject SlicedGO => _slicedGO;

    private void Start()
    {
        _world = WorldHandler.GetWorld();
        var plane = transform.position + new Vector3(0, 0.3f, 0);

        var slicedObj = gameObject.SliceInstantiate(plane, Vector3.up, Material);
        Sequence sequence = DOTween.Sequence();
        _slicedGO = slicedObj[0];
        var slicedObjTransform = slicedObj[0].transform;
        var offset = new Vector3(0, 0.4f, 0.3f);
        sequence.Append(slicedObjTransform.DOMove(slicedObjTransform.position + offset, 1));
        sequence.Join(slicedObjTransform.DORotateQuaternion(Quaternion.Euler(90, 0, 0), 1));
        sequence.SetDelay(0.5f);
        sequence.Join(slicedObjTransform.DOScale(2f, 0.5f));
        var entity = _world.NewEntity();
        entity.Get<BrickSpawnEvent>();
        ref var modelCompanent = ref entity.Get<ModelComponent>();
        ref var colorCompanent = ref entity.Get<ColorComponent>();
        colorCompanent.MaterialColor = Color.green;
        modelCompanent.ModelTransform = _slicedGO.transform;
        RemoveHerb();
        Destroy(gameObject);
    }
    private void RemoveHerb()
    {

        //var data = gameObject.GetComponent<ConvertToEntity>();
        //if (data.TryGetEntity().HasValue)
        //{
        //    var entity = data.TryGetEntity().Value;
        //    ref var parentCompanent = ref entity.Get<ParentCompanent>();
        //    ref var parentEntity = ref parentCompanent.ParentEntity;
        //    parentEntity.Del<BlockHole>();
        //}
    }
}
