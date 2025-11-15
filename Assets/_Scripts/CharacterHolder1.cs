using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterHolder", menuName = "Scriptable Objects/CharacterHolder")]
public class CharacterHolder : ScriptableObject
{
    //C = character
    //behold, the awful way to store all the codes

    public List<string> CharacterIDs = new List<string>
    {
        "42b29160-aac2-11f0-8084-42010a7be025",
        "ffac4032-aac1-11f0-a0db-42010a7be025",
        "3aa0f5d0-aac1-11f0-8084-42010a7be025",
        "6e553f2a-aac2-11f0-82c9-42010a7be025",
        "2c614592-aac1-11f0-ab6d-42010a7be025",
        "1e66f02c-aac1-11f0-ab6d-42010a7be025",
        "bd6f691a-aac1-11f0-8b48-42010a7be025",
        "c2caa2f2-aac2-11f0-af3d-42010a7be025",
        "9df9cf3e-aac2-11f0-9d8d-42010a7be025",
        "bb6b192e-aac2-11f0-93cb-42010a7be025",
        "6078534c-aac2-11f0-8084-42010a7be025",
        "a33795cc-aac1-11f0-b47e-42010a7be025",
        "4b1bf644-aac1-11f0-82c9-42010a7be025",
        "63e4c43a-aac6-11f0-82c9-42010a7be025",
        "ad32c704-aac1-11f0-b897-42010a7be025",
        "ba7d98b2-aac1-11f0-9d8d-42010a7be025",
        "7f2e92ce-aac2-11f0-93cb-42010a7be025",
        "bcc46df2-aac2-11f0-b7b1-42010a7be025",
        "0f888106-aac1-11f0-b7b1-42010a7be025"
    };

}
