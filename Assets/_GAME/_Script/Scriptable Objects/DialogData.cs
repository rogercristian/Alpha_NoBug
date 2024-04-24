using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Dialog")]
public class DialogData : ScriptableObject
{
    public List<DialogSentence> Sentences;
}

[Serializable]
public class DialogSentence
{
    public CharacterData ActorData;
    [TextArea(3,10)]
    public string Content;
}