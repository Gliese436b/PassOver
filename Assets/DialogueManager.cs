public class DialogueManager:Singleton<DialogueManager>
{
    public delegate void FNotifyDialogue();
    public static event FNotifyDialogue OnTalk, OnFinishTalk;

    public ConversationController conversationController;
    public QuestionController questionController;

    public void AdvanceDialogue()
    {
        OnTalk?.Invoke();
    }

    public void SetUpConversation(Conversation Conversation)
    {
        conversationController.conversation = Conversation;
    }

    public void SetUpQuestion(Question Question)
    {
        questionController.question = Question;
    }

    public void FinalizeConversation()
    {
        OnFinishTalk?.Invoke();
    }
}
