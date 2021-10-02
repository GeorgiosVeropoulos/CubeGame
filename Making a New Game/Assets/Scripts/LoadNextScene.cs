using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField]
    private Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadAsyncOperation()
	{
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(1);
        

        while(gameLevel.progress < 1)
		{
            progressBar.fillAmount = gameLevel.progress;

            yield return new WaitForEndOfFrame();
		}

        
	}
}
