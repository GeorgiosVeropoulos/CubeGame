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
	private float timer5;
	private float timer6;
	private float timer7;

	public LevelData(float Level1, float Level2, float Level3, float Level4, float Level5, float Level6, float Level7)
	{
		timer1 = Level1;
		timer2 = Level2;
		timer3 = Level3;
		timer4 = Level4;
		timer5 = Level5;
		timer6 = Level6;
		timer6 = Level7;
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
	public float Timer5 {
		get {
			return timer5;
		}
		set {
			timer5 = value;
		}
	}
	public float Timer6 {
		get {
			return timer6;
		}
		set {
			timer6 = value;
		}
	}
	public float Timer7 {
		get {
			return timer7;
		}
		set {
			timer7 = value;
		}
	}

}
