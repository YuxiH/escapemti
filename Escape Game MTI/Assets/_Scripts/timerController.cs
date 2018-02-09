using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerController : MonoBehaviour {
	public float time =10f;
	bool CountDownOn = true;
	// Use this for initialization
	void Start () {
		StartCoroutine (timer ());
	}

	IEnumerator timer()
	{
		while (time > 0) {
			time--;
			yield return new WaitForSeconds (1f);
			GetComponent<Text> ().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time/60), time % 60);
		}
	}

    public void changeTime(int reducedTime)
    {
        time -= reducedTime;
    }

    void Update()
    {
        if (time <= 0)
        {
            GameObject choice = GameObject.Find("GameInfo");
            choice.GetComponent<GameChoice>().brave = false;
            SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
        }
    }
}
