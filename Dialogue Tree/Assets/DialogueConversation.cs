using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dialogue))]
public class DialogueConversation : MonoBehaviour {

	public Dialogue dialogue;

	// Use this for initialization
	void Start () {
		dialogue = this.GetComponent<Dialogue>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		Debug.Log("Triggered");
		if (collision.CompareTag("Player"))
		{
			if (Input.GetKeyDown(KeyCode.Space) && !DialogueManager.dm.inDialogue)
			{
				Debug.Log("Load Dialogue");
				DialogueManager.dm.LoadDialogue(dialogue);
			}
		}
	}
}
