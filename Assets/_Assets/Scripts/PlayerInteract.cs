using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteract : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
               if (collider.TryGetComponent(out NPCInteractable npcInteractable))
               {

                   npcInteractable.Interact();
                }
                // Check tables
                TableInteractable table = collider.GetComponentInParent<TableInteractable>();
                if (table != null)
                {
                    table.OnClick();
                    Debug.Log("ITS TABLE");
                    return; // only interact with one object per press
                }
            }
        }
    }
    
    public NPCInteractable GetInteractableObject()
    {
        List<NPCInteractable> npcInteractableList = new List<NPCInteractable>();
            float interactRange = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                npcInteractableList.Add(npcInteractable);

            }
        }

        NPCInteractable closestNPCInteractable = null; 
        foreach (NPCInteractable npcInteractable in npcInteractableList)
        {
            if(closestNPCInteractable == null)
            {
                closestNPCInteractable = npcInteractable;
            }
            else
            {
                if(Vector3.Distance(transform.position, npcInteractable.transform.position) <
                    Vector3.Distance(transform.position, closestNPCInteractable.transform.position))
                {
                    //closer
                    closestNPCInteractable=npcInteractable;
                }
            }
        }
            return closestNPCInteractable;
        }
    
}

