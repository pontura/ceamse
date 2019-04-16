using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectsManager : MonoBehaviour
{
    public List<SceneObject> all;
    public List<SceneObject> inGame;
    public List<SceneObject> pool;

    public GameObject container;

    void Start()
    {
        Invoke("Loop", 1);
    }
    void Loop()
    {
        AddNewSceneObejct(false);
        Invoke("Loop", 3);
    }
    void AddNewSceneObejct(bool top_down)
    {
        SceneObject so = GetRandomSO();
        SceneObject newSO = GetFromPool(so.type);
        if (newSO == null)
            newSO = Instantiate(so);

        AddToContainer(newSO, false);
    }
    void AddToContainer(SceneObject newSO, bool top_down)
    {             
        newSO.transform.SetParent(container.transform);
        newSO.transform.localScale = Vector3.one;

        Tile tile;
        if (top_down)
            tile = Game.Instance.lanesManager.AddSceneObjectToSecondLane(newSO);
        else
            tile = Game.Instance.lanesManager.AddSceneObjectToFirstLane(newSO);

        print("add sceneo top_down " + top_down);
        AddSOToTile(newSO, tile);
    }
    public void AddSOToTile(SceneObject so, Tile tile)
    {
        tile.AddSceneObject(so);
        so.transform.gameObject.SetActive(true);
        so.transform.localPosition = tile.transform.position;
        so.Init(tile);
        inGame.Add(so);
    }
    void Update()
    {
        foreach (SceneObject so in inGame)
        {
            so.Move();
        }
    }

    SceneObject GetRandomSO()
    {
        return all[Random.Range(0, all.Count)];
    }
    SceneObject GetRandomOfType(SceneObject.types type )
    {
        List<SceneObject> allSOOfType = new List<SceneObject>();
        foreach (SceneObject so in all)
        {
            if(so.type == type)
            {
                allSOOfType.Add( so);
            }
        }
        if (allSOOfType.Count == 0)
            return null;
        else
            return allSOOfType[Random.Range(0, allSOOfType.Count)];
    }
    public void EndLane(SceneObject so, bool top_down)
    {
        if (!top_down)
        {
            print("cambia " + so.type + so.myTile);
            AddToContainer(so, true);
        }
        else
        {
            inGame.Remove(so);
            pool.Add(so);
            so.gameObject.SetActive(false);
            so.myTile = null;
            print("Wrong " + so.type + so.myTile);
        }
    }
    SceneObject GetFromPool(SceneObject.types type)
    {
        SceneObject soToInsert = null;
        foreach (SceneObject so in pool)
        {
            if (so.type == type)
            {
                soToInsert = so;
            }
        }
        if(soToInsert != null)
        {
            pool.Remove(soToInsert);
            return soToInsert;
        }
        return null;
    }
}
