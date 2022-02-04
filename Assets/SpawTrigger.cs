using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawTrigger : MonoBehaviour
{
    public List<SpawnGholsArea> SpawnAreas;

    private void OnTriggerEnter(Collider other)
    {
        foreach(var area in SpawnAreas)
        {
            area.StartSpawn();
        }
    }

}
