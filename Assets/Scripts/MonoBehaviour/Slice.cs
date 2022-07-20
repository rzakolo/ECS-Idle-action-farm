using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using DG.Tweening;


public class Slice : MonoBehaviour
{
    public Material Material;
    private GameObject _slicedGO;
    public GameObject SlicedGO => _slicedGO;
    private void Start()
    {
        var plane = transform.position + new Vector3(0, 0.4f, 0);

        var slicedObj = gameObject.SliceInstantiate(plane, Vector3.up, Material);
        Sequence sequence = DOTween.Sequence();
        _slicedGO = slicedObj[0];
        var slicedObjTransform = slicedObj[0].transform;
        var offset = new Vector3(0, 0.4f, 0.3f);
        sequence.Append(slicedObjTransform.DOMove(slicedObjTransform.position + offset, 1));
        sequence.Join(slicedObjTransform.DORotateQuaternion(Quaternion.Euler(90, 0, 0), 1));
        sequence.SetDelay(0.5f);
        sequence.Join(slicedObjTransform.DOScale(1f, 1));
        Destroy(gameObject);
    }
}
