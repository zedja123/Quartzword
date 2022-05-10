using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class InitialConversation : MonoBehaviour
{

    public NPCConversation myConversation;

    private void Awake()
    {
        ConversationManager.Instance.StartConversation(myConversation);
        PlayerController.instance.canMove = false;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
