using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowBestTimer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int _level;
    public float bestimer;

    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
        //TimeData data = SaveSystem.LoadPlayer();
        //bestimer = data.Timer[_level];
        // text.text = data.Timer[_level].ToString();
        TimeData data = SaveManager.Load();
        bestimer = data.Timer[_level];
        text.text = data.Timer[_level].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
