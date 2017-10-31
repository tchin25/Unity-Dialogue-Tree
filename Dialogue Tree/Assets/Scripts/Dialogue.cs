using UnityEngine;

public class Dialogue : MonoBehaviour {

	public string[] names;

	[TextArea(3, 10)]
	public string[] dialogue;

	public string choice1Text;
	public Dialogue choice1;

	public string choice2Text;
	public Dialogue choice2;

	public string choice3Text;
	public Dialogue choice3;

	public int choiceNumber;

	public void EndChoice()
	{
		GetComponentInParent<DialogueConversation>().endChoice = choiceNumber;
	}

}
