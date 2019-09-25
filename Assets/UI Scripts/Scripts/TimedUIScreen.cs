using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedUIScreen : UIScreen
{
	#region Variables
	[Header("Timed Screen Properties")]
	public float screenTime = 2f;
	private float startTime;

	public UnityEvent onTimeCompleted = new UnityEvent();

	#endregion

    #region Helper Methods


    public override void StartScreen()
    {
    	base.StartScreen();

    	startTime = Time.time;

    	StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
    	yield return new WaitForSeconds(screenTime);

    	if(onTimeCompleted != null){
    		onTimeCompleted.Invoke();
    	}
    }

    #endregion
}
