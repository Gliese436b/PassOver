using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation conversation;
    public Question question;
    bool bFirstInteract;

    public void Dialogue()
    {
        if (!bFirstInteract)
        {
            if (conversation != null)
            {
                DialogueManager.Instance.SetUpConversation(conversation);
            }

            if (conversation != null)
            {
                DialogueManager.Instance.SetUpQuestion(question);
            }

            bFirstInteract = true;
        }
        DialogueManager.Instance.AdvanceDialogue();
    }
}
