using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogue", menuName = "Scriptable Objects/NPCDialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public float audoProgressDelay = 1.5f;
    public float typingSpeed;
    //public AudioClip voiceSound;
    //public float voicePitch = 1f;
    

}