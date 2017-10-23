using UnityEngine;

[RequireComponent(typeof(Dialogue))]
public class DialogueConversation : MonoBehaviour {

	public Dialogue dialogue;

	private bool trigger = false;

	void Start () {
		dialogue = this.GetComponent<Dialogue>();
	}
	
	void Update () {
		if (trigger && Input.GetKeyDown(KeyCode.Space) && !DialogueManager.dm.inDialogue)
		{
			Debug.Log("Load Dialogue");
			DialogueManager.dm.LoadDialogue(dialogue);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			trigger = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			trigger = false;
		}
	}
}
