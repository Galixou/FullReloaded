using UnityEngine;

public class PhoneScript : Interactable
{
    public GameObject phone;
    public GameObject storyTelling;

    public override string GetDescription()
    {
        return "Press [E] To answer the phone call.";
    }

    public override void Interact()
    {
        storyTelling.SetActive(true);
        phone.SetActive(false);
    }
}
