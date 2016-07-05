﻿using UnityEngine;
using System.Collections;

public class GoldCapIncrease : MonoBehaviour {

    Stats stats;
    BuildingCreator creator;

	// Use this for initialization
	void Start () {

        stats = (Stats)GameObject.Find("Stats").GetComponent("Stats");
        creator = (BuildingCreator)GameObject.Find("BuildingCreator").GetComponent("BuildingCreator");

        stats.maxStorageGold += int.Parse(creator.GetCurrentBuildingDictionary()["StoreCap"]);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        stats.maxStorageGold -= int.Parse(creator.GetCurrentBuildingDictionary()["StoreCap"]);//the destroyed building storage cap
        if (stats.gold > stats.maxStorageGold)//more gold than max storage?
        {
            stats.gold = stats.maxStorageGold;//discards resources exceeding storage capacity
        }
    }
}
