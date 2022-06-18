using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class ConversationClickIf : MonoBehaviour
{
    public NPCConversation semChave;
    public NPCConversation comChave;
    public Animator anim;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerController.instance.chave1 == false)
            {
                ConversationManager.Instance.StartConversation(semChave);
                PlayerController.instance.chave1 = true;
            }
            else if (PlayerController.instance.chave1 == true)
            {
                ConversationManager.Instance.StartConversation(comChave);
            }
        }
    }
}
