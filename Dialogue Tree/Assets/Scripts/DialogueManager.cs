using System.Collections;
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
		if (dialogue.Count <= 0)
		{
			EndDialogue();
			return;
		}

		if(dialogue.Count == 1) //enables choices if there are choices on the final dialogue text
		{
			//choices and load in next dialogue
			//enable choice buttons
			if (dialogueCache.choice1 != null)
			{
				choice1.gameObject.SetActive(true);
				choice1.GetComponentInChildren<Text>().text = dialogueCache.choice1Text;
				inChoice = true;
			}

			if (dialogueCache.choice2 != null)
			{
				choice2.gameObject.SetActive(true);
				choice2.GetComponentInChildren<Text>().text = dialogueCache.choice2Text;
				inChoice = true;
			}

			if (dialogueCache.choice3 != null)
			{
				choice3.gameObject.SetActive(true);
				choice3.GetComponentInChildren<Text>().text = dialogueCache.choice3Text;
				inChoice = true;
			}

			if (inChoice)
			{
				continueButton.gameObject.SetActive(false);
			}
		}

		_name.text = names.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(dialogue.Dequeue()));
	}

	IEnumerator TypeSentence(string sentence) //individually puts letters into text box
	{
		text.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			text.text += letter;
			yield return null;
		}
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

	//resets Text Box to default state
	//By default, Text Box is disabled, all children of Text Box are enabled, and all children of Buttons are disabled
	private void RefreshTextBox()
	{
		textBox.gameObject.SetActive(true);
		continueButton.gameObject.SetActive(true);
		choice1.gameObject.SetActive(false);
		choice2.gameObject.SetActive(false);
		choice3.gameObject.SetActive(false);
	}
}
