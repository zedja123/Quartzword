using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Dialogo : MonoBehaviour
{
    // Start is called before the first frame update
    public NPCConversation conversation;
    public ConversationManager cvm;

    private void Start()
    {
        cvm = ConversationManager.Instance;
    }

    private void OnMouseDown()
    {
        if(CharacterController2D.instance.currentState == CharacterController2D.States.Exploring)
        {
            ConversationManager.Instance.StartConversation(conversation);
            CharacterController2D.instance.ChangeState(CharacterController2D.States.Talking);
        }
    }
    public void StopDialogue()
    {
        CharacterController2D.instance.ChangeState(CharacterController2D.States.Exploring);
    }
}
