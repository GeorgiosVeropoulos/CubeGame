using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    
    private Scene currentscene;

	private void Awake()
	{
        Time.timeScale = 1f;
	}
	// Start is called before the first frame update
	void Start()
    {
        currentscene = SceneManager.GetActiveScene();
        //Debug.Log(currentscene.buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
	{
        SceneManager.LoadScene(currentscene.buildIndex + 1);
	}
}
