using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISystem : MonoBehaviour
{
    #region Variables
    [Header("System Events")]
    public UnityEvent onSwitchedScreens = new UnityEvent();

	private Component[] screens = new Component[0];

	private UIScreen previousScreen;
	private UIScreen currentScreen;

	public UIScreen PreviousScreen { get {return previousScreen;}}
	public UIScreen CurrentScreen { get {return currentScreen;}}

	#endregion

	#region Main Methods
    // Start is called before the first frame update
    void Start()
    {
         screens = GetComponentsInChildren<UIScreen>(true);
    }

    #endregion

    #region Helper Methods
    public void SwitchScreen(UIScreen aScreen)
    {

    	if(aScreen){

    		if(currentScreen){
    			//currentScreen.Close();
    			previousScreen = currentScreen;
    		}

    		currentScreen = aScreen;
    		currentScreen.gameObject.SetActive(true);
    		//currentScreen.StartScreen();

    		if(onSwitchedScreens != null){
    			onSwitchedScreens.Invoke();
    		}
    	}

    }

    public void GoToPreviousScreen()
    {
    	if(previousScreen){
    		SwitchScreen(previousScreen);
    	}
    }


    public void LoadScene(int sceneIndex)
    {
    	StartCoroutine(WaitToLoadScene(sceneIndex));
    }

    IEnumerator WaitToLoadScene(int sceneIndex)
    {
    	yield return null;
    }


    #endregion
}
