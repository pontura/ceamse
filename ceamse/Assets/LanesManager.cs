using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesManager : MonoBehaviour
{
    public List<Lane> all;
    float speed = 1;

    void Start()
    {
        foreach (Lane lane in all)
        {
            lane.Init();
        }
    }
    void Update()
    {
        foreach (Lane lane in all)
        {
            float value = speed*Time.deltaTime;
            lane.Move(value);
        }
    }
    public Tile AddSceneObjectToRandomLane(SceneObject so)
    {
        Lane lane = GetRandomLane();
        return lane.AddSceneObject(so);
    }
    Lane GetRandomLane()
    {
        return all[Random.Range(0, all.Count)];
    }
}
