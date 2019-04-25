using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectsManager : MonoBehaviour
{
    public List<int> allIdS;
    public List<SceneObject> all;
    public List<SceneObject> inGame;
    public List<SceneObject> pool;
    public GameObject container;
    LevelSignal levelSignal;

    void Start()
    {
        for (int a = 0; a < 6; a++)
            allIdS.Add(a);

        Utils.Shuffle(allIdS);

        Events.NewSlotInLane += NewSlotInLane;
        levelSignal = GetComponent<LevelSignal>();
    }
    void OnDestroy()
    {
        Events.NewSlotInLane -= NewSlotInLane;
    }
    int lanesEmpty = 10;
    void NewSlotInLane()
    {
        lanesEmpty++;


        bool addSO = false;
        int laneSeparationToSO = 5;

        if(levelSignal.level<2)
            laneSeparationToSO = 4;
        else  if (levelSignal.level < 3)
            laneSeparationToSO = 3;
        else if (levelSignal.level < 4)
            laneSeparationToSO = 2;
        else if (levelSignal.level < 5)
            laneSeparationToSO = 1;

        if (lanesEmpty > laneSeparationToSO)
            addSO = true;

        if(!addSO)
        {
            if (Random.Range(0, 100) < levelSignal.level*15)
                addSO = true;
        }


        if (addSO)
        {
            AddNewSceneObejct(false);
            lanesEmpty = 0;
        }
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


        Tile tile;
        if (top_down)
            tile = Game.Instance.lanesManager.AddSceneObjectToSecondLane(newSO);
        else
            tile = Game.Instance.lanesManager.AddSceneObjectToFirstLane(newSO);

        newSO.transform.SetParent(tile.transform);
        newSO.transform.localScale = Vector3.one;
        newSO.transform.localPosition = Vector3.zero;
        AddSOToTile(newSO, tile);
    }
    public void AddSOToTile(SceneObject so, Tile tile, bool fromDrag = false)
    {
        tile.AddSceneObject(so);
        so.transform.gameObject.SetActive(true);
        so.transform.SetParent(tile.transform);

        if (fromDrag)
        {
            so.Init(tile, so.id);
            so.transform.localPosition = new Vector3(0,0, 0);
        }
        else
        {
            so.Init(tile);
            so.transform.localPosition = new Vector3(4, -4, 0);
        }
        inGame.Add(so);
        Events.newSOAdded(fromDrag);
    }
    void Update()
    {
        foreach (SceneObject so in inGame)
        {
            // so.Move();
        }
    }

    SceneObject GetRandomSO()
    {
        int level = levelSignal.level;
        if (level < 5)
            return all[allIdS[Random.Range(0, level+1)]];
        else
            return all[Random.Range(0, all.Count)];
    }
    SceneObject GetRandomOfType(SceneObject.types type)
    {
        List<SceneObject> allSOOfType = new List<SceneObject>();
        foreach (SceneObject so in all)
        {
            if (so.type == type)
            {
                allSOOfType.Add(so);
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
            AddToContainer(so, true);
        }
        else
        {
            DestroySO(so);
            Events.OnIncorrect(so.type);
        }
    }
    public void DestroySO(SceneObject so)
    {
        inGame.Remove(so);
        pool.Add(so);
        so.gameObject.SetActive(false);
        so.myTile = null;
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
        if (soToInsert != null)
        {
            pool.Remove(soToInsert);
            return soToInsert;
        }
        return null;
    }
    public void StartDragging(SceneObject so)
    {
        inGame.Remove(so);
    }
    public SceneObject.types GetTypeByID(int id)
    {
        switch(id)
        {
            case 0:
                return SceneObject.types.CHAPA;
            case 1:
                return SceneObject.types.PLASTICO;
            case 2:
                return SceneObject.types.PAPEL;
            case 3:
                return SceneObject.types.LATAS;
            case 4:
                return SceneObject.types.TETRA;
            default:
                return SceneObject.types.VIDRIO;
        }
    }
}
