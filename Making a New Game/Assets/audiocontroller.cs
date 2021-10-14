using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocontroller : MonoBehaviour
{
    public GameManager gamemanager;

    AudioSource Audio;
    public GameObject Play;
    public GameObject Stop;
    
    // Start is called before the first frame update
    void Start()
    {
       
        TrackAudio();
    }

    // Update is called once per frame
    void Update()
    {
        //TrackAudio();
    }
    public void PlayAudio()
	{
        Play.SetActive(false);
        Stop.SetActive(true);
        Audio.mute = !Audio.mute;
	}
    public void StopAudio()
    {
        Play.SetActive(true);
        Stop.SetActive(false);
        Audio.mute = !Audio.mute;
    }
    public void TrackAudio()
	{
        Audio = AudioSource.FindObjectOfType<GameManager>().GetComponent<AudioSource>();
    }
}
