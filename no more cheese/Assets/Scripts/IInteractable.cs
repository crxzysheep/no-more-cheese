using UnityEngine;

public interface IInteractable
{ 
    void Interact();
    bool CanInteract();
    void showInteractionIcon(bool toggle);

}
