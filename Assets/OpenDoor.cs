using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class OpenDoor : MonoBehaviour
{
    public NPCConversation myConversation;
    public GameObject door;
    public Animator anim;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerController.instance.canMove == true)
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }

    public void OpenDoor1()
    {
        anim.SetBool("Open", true);
    }
}
