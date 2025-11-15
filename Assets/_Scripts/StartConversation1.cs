using Convai.Scripts.Runtime.Core;
using System.Collections.Generic;
using UnityEngine;


//grabs a random character personality on start 
//idk how to make it the non-obsolete version soooooo
public class StartConversation : MonoBehaviour
{
    public GameObject[] Character;
    public CharacterHolder CH;
    void Start()
    {
        int randomIndex = Random.Range(0, Character.Length);

        for (int i = 0; i < Character.Length; i++)
        {
           if (randomIndex != i)
            {
               Character[i].SetActive(false);
            }
            
        }

        int random = Random.Range(0, 20);
        ConvaiNPC npc = FindObjectOfType<ConvaiNPC>();
        npc.characterID = CH.CharacterIDs[random];

    }

    
}
