﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Dialogue : MonoBehaviour {

	public bool hasChoice;

	public string[] names;

	[TextArea(3, 10)]
	public string[] dialogue;

	public string choice1Text;
	public Dialogue choice1;

	public string choice2Text;
	public Dialogue choice2;

	public string choice3Text;
	public Dialogue choice3;

}
