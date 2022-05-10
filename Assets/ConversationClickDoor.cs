using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class ConversationClickDoor : MonoBehaviour
{
    public NPCConversation semChave;
    public NPCConversation comChave;
    public Animator anim;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerController.instance.canMove == true && PlayerController.instance.chave1 == false)
            {
                ConversationManager.Instance.StartConversation(semChave);
                PlayerController.instance.canMove = false;
                PlayerController.instance.canAttack = false;
            }else if(PlayerController.instance.canMove == true && PlayerController.instance.chave1 == true) {
                ConversationManager.Instance.StartConversation(comChave);
                PlayerController.instance.canMove = false;
                PlayerController.instance.canAttack = false;
                anim.SetBool("Open", true);
            }
        }
    }
}
