using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSSHOW : MonoBehaviour
{
	//public int avgFrameRate;
	//public Text display_Text;
	private void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}
	//public void Update()
	//{
	//    float current = 0;
	//    current = Time.frameCount / Time.time;
	//    avgFrameRate = (int)current;
	//    display_Text.text = avgFrameRate.ToString() + " FPS";
	//}
}
