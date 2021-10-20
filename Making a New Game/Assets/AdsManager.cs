using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour , IUnityAdsListener
{
	//#if UNITY_ANDROID
	//    string gameID = "4415449";
	//#else
	//    string gameID = "4415448";
	//#endif
	// Start is called before the first frame update

	public ScoreManager scoremanager;
    void Start()
    {
		scoremanager = FindObjectOfType<ScoreManager>();
		
		Advertisement.Initialize("4415449");
		Advertisement.AddListener(this);
    }

    
    public void PlayAd()
	{
		if (Advertisement.IsReady("Rewarded"))
		{
            Advertisement.Show("Rewarded");
		}
		else
		{
			Debug.Log("Rewarded ad is not ready");
		}
	}

	public void OnUnityAdsReady(string placementId)
	{
		Debug.Log("Ad Ready");
	}

	public void OnUnityAdsDidError(string message)
	{
		Debug.Log("ERROR + " + message);
	}

	public void OnUnityAdsDidStart(string placementId)
	{
		Debug.Log("VIDEO STARTED");
	}

	public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	{
		if(placementId == "Rewarded" && showResult == ShowResult.Finished)
		{
			Debug.Log("Player Should be rewarded");
			scoremanager.scores[0] += 100;
			scoremanager.SaveData();
			Debug.Log(scoremanager.scores[0]);
		}
	}
}
