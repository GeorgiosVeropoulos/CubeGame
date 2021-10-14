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
	private float timer8;
	private float timer9;
	private float timer10;
	private float timer11;
	private float timer12;
	private float timer13;

	public LevelData(float Level1, float Level2, float Level3, float Level4, float Level5, float Level6, float Level7
		, float Level8, float Level9, float Level10, float Level11, float Level12, float Level13)
	{
		timer1 = Level1;
		timer2 = Level2;
		timer3 = Level3;
		timer4 = Level4;
		timer5 = Level5;
		timer6 = Level6;
		timer7 = Level7;
		timer8 = Level8;
		timer9 = Level9;
		timer10 = Level10;
		timer11 = Level11;
		timer12 = Level12;
		timer13 = Level13;

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
	public float Timer8 {
		get {
			return timer8;
		}
		set {
			timer8 = value;
		}
	}
	public float Timer9 {
		get {
			return timer9;
		}
		set {
			timer9 = value;
		}
	}
	public float Timer10 {
		get {
			return timer10;
		}
		set {
			timer10 = value;
		}
	}
	public float Timer11 {
		get {
			return timer11;
		}
		set {
			timer11 = value;
		}
	}
	public float Timer12 {
		get {
			return timer12;
		}
		set {
			timer12 = value;
		}
	}
	public float Timer13 {
		get {
			return timer13;
		}
		set {
			timer13 = value;
		}
	}

}
