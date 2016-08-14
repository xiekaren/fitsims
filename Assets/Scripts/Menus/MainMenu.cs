using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
	
	private const int noIFElements = 11;
	public GameObject[] InterfaceElements = new GameObject[noIFElements];
		
	private const int noScreens = 6;
	public GameObject[] Screens = new GameObject[noScreens];
	
	public GameObject gameManager;
	public bool constructionGreenlit = true;
	public GameObject BuildingCreatorOb;
	public GameObject ConfirmationScreen;

    //[HideInInspector]

    public void OnShop(){OnActivateButton (0);}
	public void OnCloseShop(){OnDeactivateButton (0);}
	public void OnCloseShopToBuild()
	{
		if (constructionGreenlit) 
		{
			Screens [0].SetActive (false);
            // Activate Buy and don't buy buttons.
            InterfaceElements[0].SetActive(true);
            InterfaceElements[1].SetActive(true);
        }
    }

	public void OnOptions(){OnActivateButton (1);}
	public void OnCloseOptions(){OnDeactivateButton (1);}

	public void OnUpgrade(){OnActivateButton (2);}
	public void OnCloseUpgrade(){OnDeactivateButton (2);}

    // For controlling exercise in progress frame.
    public void onDoingExercise() { OnActivateButton(3); }
    public void onCloseDoingExercise() { OnDeactivateButton(3); }

    // For controlling exercise done frame.
    public void OnExerciseDone() { OnActivateButton(4); }
    public void OnCloseExerciseDone (){ OnDeactivateButton(4); }

    // For help screen.
    public void OnHelp() { OnActivateButton(5); }
    public void OnCloseHelp() { OnDeactivateButton(5); }

    public void OnConfirmationScreen()	
	{ 
		ConfirmationScreen.SetActive (true); 
	}

	public void OnCloseConfirmationScreen() { ConfirmationScreen.SetActive (false); }

	public void OnDestBuilding()
	{
		((BuildingCreator)BuildingCreatorOb.GetComponent("BuildingCreator")).Cancel();
		ConfirmationScreen.SetActive (false);
	}
	public void OnCancelDestBuilding()
	{
		((BuildingCreator)BuildingCreatorOb.GetComponent("BuildingCreator")).OK();
		ConfirmationScreen.SetActive (false);
	}

	void OnActivateButton(int scrno)
	{
		bool pauseInput = false;
		
		pauseInput = ((Relay)gameManager.GetComponent("Relay")).pauseInput;
		
		if (!pauseInput) 
		{
			Screens [scrno].SetActive (true);
			((Relay)gameManager.GetComponent ("Relay")).pauseInput = true;
            DeactivateInterface();
		} 

	}

	void OnDeactivateButton(int scrno)
	{	
		((Relay)gameManager.GetComponent("Relay")).pauseInput = false;		
		Screens[scrno].SetActive(false);
		ActivateInterface();
	}

	public void ActivateInterface()
	{
		for (int i = 0; i < InterfaceElements.Length; i++) 
		{
			//if(i!=9)//to disable navigation buttons
			InterfaceElements[i].SetActive(true);
		}
	}

    public void DeactivateInterface()
    {
        for (int i = 0; i < InterfaceElements.Length; i++)
        {
            InterfaceElements[i].SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {
        OnHelp();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	
	
	

	
}
