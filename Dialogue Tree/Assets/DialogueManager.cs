using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public static DialogueManager dm;

	public Dialogue dialogueCache;
	public bool inDialogue = false;
	public bool inChoice = false;

	public Image textBox;
	public Text text;
	public Text _name;

	public Button choice1;
	public Button choice2;
	public Button choice3;

	public Button continueButton;

	private Queue<string> dialogue;
	private Queue<string> names;

	void Start () {
		dialogue = new Queue<string>();
		names = new Queue<string>();
		if (dm == null)
		{
			dm = this;
		}
		else
		{
			Destroy(this);
		}
	}

	public void LoadDialogue(Dialogue dialogue)
	{
		dialogueCache = dialogue;
		inDialogue = true;
		inChoice = false;
		foreach (string sentence in dialogue.dialogue)
		{
			this.dialogue.Enqueue(sentence);
		}

		foreach (string name in dialogue.names)
		{
			this.names.Enqueue(name);
		}
		RefreshTextBox();
		NextDialogue();
	}

	public void NextDialogue()
	{
		Debug.Log("Next Dialogue");
		if (this.dialogue.Count <= 0)
		{
			Debug.Log("Ending Dialogue");
			EndDialogue();
			return;
		}

		if(this.dialogue.Count == 1 && dialogueCache.hasChoice) //enables choices if there are choices on the final dialogue text
		{
			inChoice = true;
			continueButton.gameObject.SetActive(false);
			//choices and load in next dialogue
			//enable choice buttons
			if (dialogueCache.choice1 != null)
			{
				choice1.gameObject.SetActive(true);
				choice1.GetComponentInChildren<Text>().text = dialogueCache.choice1Text;
			}

			if (dialogueCache.choice2 != null)
			{
				choice2.gameObject.SetActive(true);
				choice2.GetComponentInChildren<Text>().text = dialogueCache.choice2Text;
			}

			if (dialogueCache.choice3 != null)
			{
				choice3.gameObject.SetActive(true);
				choice3.GetComponentInChildren<Text>().text = dialogueCache.choice3Text;
			}
		}

		text.text = this.dialogue.Dequeue();
		_name.text = this.names.Dequeue();
	}

	public void EndDialogue()
	{
		inDialogue = false;
		textBox.gameObject.SetActive(false);
	}

	#region Choices linked to UI buttons

	public void Choice1()
	{
		dialogueCache = dialogueCache.choice1;
		LoadDialogue(dialogueCache);
	}

	public void Choice2()
	{
		dialogueCache = dialogueCache.choice2;
		LoadDialogue(dialogueCache);
	}

	public void Choice3()
	{
		dialogueCache = dialogueCache.choice3;
		LoadDialogue(dialogueCache);
	}

	#endregion

	private void RefreshTextBox() //resets text box to default state
	{
		Debug.Log("Refreshing Text Box");
		textBox.gameObject.SetActive(true);
		continueButton.gameObject.SetActive(true);
		choice1.gameObject.SetActive(false);
		choice2.gameObject.SetActive(false);
		choice3.gameObject.SetActive(false);
	}
}
