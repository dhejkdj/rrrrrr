

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public static GUIManager instance;


	
	public Text moveCounterTxt;

	private int  moveCounter;

	void Awake() {
		instance = GetComponent<GUIManager>();
		moveCounter = 9;
	}

	

	public int MoveCounter {
		get {
			return moveCounter;
		}

		set {
			moveCounter = value;
			if (moveCounter <= 0) {
				moveCounter = 0;
				StartCoroutine(WaitForShifting());
			}
			moveCounterTxt.text = moveCounter.ToString();
		}
	}

	private IEnumerator WaitForShifting() {
		yield return new WaitUntil(() => !BoardManager.instance.IsShifting);
		yield return new WaitForSeconds(.25f);
	
	}

}
