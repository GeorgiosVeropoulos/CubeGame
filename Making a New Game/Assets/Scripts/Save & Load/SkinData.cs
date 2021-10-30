using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class SkinData
{

    private bool skin1;
    private bool skin2;
    private bool skin3;
    private bool skin4;
    private bool skin5;
	private bool skin6;


	public SkinData(bool Skin1, bool Skin2, bool Skin3, bool Skin4, bool Skin5, bool Skin6)
	{
        skin1 = Skin1;
		skin2 = Skin2;
		skin3 = Skin2;
		skin4 = Skin4;
		skin5 = Skin5;
		skin6 = Skin6;
	}

	public bool Skin1 {
		get {
			return skin1;
		}
		set {
			skin1 = value;
		}
	}
	public bool Skin2 {
		get {
			return skin2;
		}
		set {
			skin2 = value;
		}
	}
	public bool Skin3 {
		get {
			return skin3;
		}
		set {
			skin3 = value;
		}
	}
	public bool Skin4 {
		get {
			return skin4;
		}
		set {
			skin4 = value;
		}
	}
	public bool Skin5 {
		get {
			return skin5;
		}
		set {
			skin5 = value;
		}
	}
	public bool Skin6 {
		get {
			return skin6;
		}
		set {
			skin6 = value;
		}
	}
}
