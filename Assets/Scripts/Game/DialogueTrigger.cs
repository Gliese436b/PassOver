using UnityEngine;

public class DialogueTrigger:MonoBehaviour
{
    /// <summary>
    /// Conversacion a asignar al ConversationController
    /// </summary>
    public Conversation conversation;

    /// <summary>
    /// Pregunta a asignar al QuestionController
    /// </summary>
    public Question question;

    /// <summary>
    /// Al llamarse, usa el dialogue manager para dar las referencias necesarias al DialogueCanvas
    /// </summary>
    public void Dialogue()
    {
        if (conversation != null)
        {
            DialogueManager.Instance.SetUpConversation(conversation);
        }

        if (conversation != null)
        {
            DialogueManager.Instance.SetUpQuestion(question);
        }

        DialogueManager.Instance.AdvanceDialogue();
    }
}
