using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool canCollect = true; 

   
    public void ToggleCollect()
    {
        
        if (transform.parent != null && transform.parent.CompareTag("Player"))
        {
            canCollect = !canCollect; 
            Debug.Log("Can collect: " + canCollect);
        }
        else
        {
            Debug.Log("This object is not a child of the player.");
        }
    }
}
