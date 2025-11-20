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

        ConvaiNPC npc = FindObjectOfType<ConvaiNPC>();

        // Choose ID list based on randomIndex
        if (randomIndex == 0)
        {
            // male selection
            int malePick = Random.Range(0, CH.MaleIDs.Count);
            npc.characterID = CH.MaleIDs[malePick];
        }
        else if (randomIndex == 1)
        {
            // female selection
            int femalePick = Random.Range(0, CH.FemaleIDs.Count);
            npc.characterID = CH.FemaleIDs[femalePick];
        }

    }

    
}
