using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class LevelData 
{
    private float timer1;
    private float timer2;
    private float timer3;
    private float timer4;

	public LevelData(float Level1, float Level2, float Level3, float Level4)
	{
		timer1 = Level1;
		timer2 = Level2;
		timer3 = Level3;
		timer4 = Level4;
	}
    public float Timer1 {
		get {
            return timer1;
		}
		set {
            timer1 = value;
		}
	}
	public float Timer2 {
		get {
			return timer2;
		}
		set {
			timer2 = value;
		}
	}
	public float Timer3 {
		get {
			return timer3;
		}
		set {
			timer3 = value;
		}
	}
	public float Timer4 {
		get {
			return timer4;
		}
		set {
			timer4 = value;
		}
	}

}
