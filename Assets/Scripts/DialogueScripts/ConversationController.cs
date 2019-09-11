using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class QuestionEvent:UnityEvent<Question> { }

public class ConversationController:MonoBehaviour
{
    public Conversation conversation;
    public QuestionEvent questionEvent;
    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    private int activeLineIndex = 0;
    private bool conversationStarted = false;

    private PlayerControl player;

    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }

    private void OnEnable()
    {
        PlayerControl.OnActivate += PlayerControl_OnActivate;
        InteractCharacter.OnTalk += InteractCharacter_OnTalk;
    }

    private void PlayerControl_OnActivate(PlayerControl _player)
    {
        player = _player;
    }

    private void OnDisable()
    {   
        PlayerControl.OnActivate -= PlayerControl_OnActivate;        
        InteractCharacter.OnTalk -= InteractCharacter_OnTalk;
    }

    private void InteractCharacter_OnTalk(bool playerIsIn)
    {
        AdvanceLine();
    }

    private void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            AdvanceLine();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            EndConversation();
        }
    }

    private void EndConversation()
    {
        conversation = null;
        conversationStarted = false;
        speakerUILeft.Hide();
        speakerUIRight.Hide();
        player.bCanPlay = true;
    }

    private void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;
    }

    private void AdvanceLine()
    {
        if (conversation == null) return;
        if (!conversationStarted) Initialize();

        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
        }
        else AdvanceConversation();
    }

    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUILeft.SpeakerIs(character))
        {
            SetDialogue(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            SetDialogue(speakerUIRight, speakerUILeft, line.text);
        }

        activeLineIndex += 1;
    }

    private void AdvanceConversation()
    {
        if (conversation.question != null)
            questionEvent.Invoke(conversation.question);
        else if (conversation.nextConversation != null)
            ChangeConversation(conversation.nextConversation);
        else EndConversation();

    }

    private void SetDialogue(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialogue = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
    }
}
