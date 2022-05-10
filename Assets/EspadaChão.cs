using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class EspadaChão : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerController.instance.canMove == true)
            {
                ConversationManager.Instance.StartConversation(myConversation);
                PlayerController.instance.canMove = false;
                PlayerController.instance.canAttack = false;
            }
        }
    }
}
