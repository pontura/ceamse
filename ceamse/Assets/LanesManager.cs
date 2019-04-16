using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesManager : MonoBehaviour
{
    public List<Lane> all;
    public float speed = 100;

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
    public Tile AddSceneObjectToFirstLane(SceneObject so)
    {
        Lane lane = all[1];
        return lane.AddSceneObject(so, false);
    }
    public Tile AddSceneObjectToSecondLane(SceneObject so)
    {
        Lane lane = all[0];
        return lane.AddSceneObject(so, true);
    }
}
