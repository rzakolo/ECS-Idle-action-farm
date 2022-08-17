using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPos : MonoBehaviour
{
    [SerializeField] private GameObject[] plants;
    [HideInInspector] public Vector3[] plantsPos;
    private void Start()
    {
        plantsPos = new Vector3[plants.Length - 1];
        for (int i = 0; i < plants.Length - 1; i++)
        {
            plantsPos[i] = plants[i].transform.position;
        }
    }
    public Vector3 GetFreePos()
    {

        foreach (var pos in plantsPos)
        {

            if (Physics.Raycast(pos, Vector3.one, out var ray))
            {
                if (ray.collider.CompareTag("Herb"))
                    return pos;
            }
        }
        return Vector3.zero;
    }
}
