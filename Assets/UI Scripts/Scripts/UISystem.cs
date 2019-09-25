using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UISystem : MonoBehaviour
{
    #region Variables
	[Header("Main Properties")]
	public UIScreen StartScreen;

    [Header("System Events")]
    public UnityEvent onSwitchedScreens = new UnityEvent();

	private Component[] screens = new Component[0];

	private UIScreen previousScreen;
	private UIScreen currentScreen;

	public UIScreen PreviousScreen { get {return previousScreen;}}
	public UIScreen CurrentScreen { get {return currentScreen;}}

	[Header("Fader Properties")]
	public Image fader;
	public float fadeInDuration =1f;
	public float fadeOutDuration = 1f;

	#endregion

	#region Main Methods
    // Start is called before the first frame update
    void Start()
    {
         screens = GetComponentsInChildren<UIScreen>(true);

         InitializeScreens();

         if(StartScreen)
         {
         	SwitchScreen(StartScreen);
         }

        if(fader)
         {
       		fader.gameObject.SetActive(true);
       	 }

       	 FadeIn();
    }

    #endregion

    #region Helper Methods
    public void SwitchScreen(UIScreen aScreen)
    {

    	if(aScreen){

    		if(currentScreen){
    			currentScreen.CloseScreen();
    			previousScreen = currentScreen;
    		}

    		currentScreen = aScreen;
    		currentScreen.gameObject.SetActive(true);
    		currentScreen.StartScreen();

    		if(onSwitchedScreens != null){
    			onSwitchedScreens.Invoke();
    		}
    	}

    }

    public void FadeIn(){

    	if(fader){
    		fader.CrossFadeAlpha(0f, fadeInDuration, false);
    	}
    }

    public void FadeOut(){
    	if(fader){
    		fader.CrossFadeAlpha(1f, fadeOutDuration, false);
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

    void InitializeScreens(){
    	foreach(var screen in screens){
    		screen.gameObject.SetActive(true);
    	}
    }

    #endregion
}
