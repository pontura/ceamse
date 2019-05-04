using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanesManager : MonoBehaviour
{
    public List<Lane> all;
    public float speed = 40;
    public Vector2 speedLimits;
    public Slider slider;

    void Start()
    {
        speedLimits = new Vector2(30, 80);
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
    public void ChangeSpeed()
    {
        float range = speedLimits.y - speedLimits.x;
        speed = speedLimits.x + (slider.value * range);
    }
}
