﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeExpansionMenu : MonoBehaviour {

    //Holds the collider status, indexed by First, Second, Third etc
    //The collider status will be true if still there, false if destroyed
    //private Dictionary<string, bool> ColliderStatus = new Dictionary<string, bool>();
    public BoolToKey[] ColliderStatus;

    //Contains prices for destroying the colliders
    //private Dictionary<string, int> ColliderPrice = new Dictionary<string, int>();
    public PriceToKey[] ColliderPrice;

    public NamedPriceLabels[] PriceLabels;
    public GameObject ConfirmationDialog;
    public GameObject Stats;
    private GameObject PurchaseBuffer;

    //Use this for initialization
    void Start () {
        UpdatePriceLabels();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    //TODO: (F) Complete this
    private void UpdatePriceLabels()
    {
        for (int i = 0; i < PriceLabels.Length; i++)
        {
            PriceLabels[i].label.text = getPrice(PriceLabels[i].name).price.ToString();
        }
    }

    public void ClearBuffer()
    {
        PurchaseBuffer = null;
    }

    //Bring up confirmation screen
    public void TryDestroyCollider(GameObject collider)
    {
        if(collider!=null){
            if (getStatus(collider.name).status)
            {
                PurchaseBuffer = collider;
                //show confirm dialog
                ConfirmationDialog.SetActive(true);
            }
        }
    }

    public void CloseConfirmationDialog()
    {
        ConfirmationDialog.SetActive(false);
    }

    public void ConfirmDestroyCollider()
    {
        Destroy(PurchaseBuffer);
        Stats statsComp = (Stats)Stats.GetComponent("Stats");
        statsComp.gold -= getPrice(PurchaseBuffer.name).price;
        statsComp.update = true;
        setStatus(PurchaseBuffer.name, false);
    }

    private void setStatus(string s, bool b)
    {
        for (int i=0; i<ColliderStatus.Length; i++)
        {
            if (ColliderStatus[i].name.Equals(s))
            {
                ColliderStatus[i].status = b;
                break;
            }
        }
    }

    private BoolToKey getStatus(string s)
    {
        foreach (BoolToKey p in ColliderStatus)
        {
            if (p.name.Equals(s))
            {
                return p;
            }
        }
        print("Unable to find matching key");
        return new BoolToKey();
    }

    private PriceToKey getPrice(string s)
    {
        foreach (PriceToKey p in ColliderPrice)
        {
            if (p.name.Equals(s))
            {
                return p;
            }
        }
        print("Unable to find matching key");
        return new PriceToKey();
    }
}