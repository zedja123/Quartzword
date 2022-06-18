using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class ConversationClick : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        print("onmouseover");
        if (Input.GetMouseButtonDown(0))
        {
            print("mousebuttondown");
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
