using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Constants;

public class CollectingCupCakes : MonoBehaviour
{
    public int cupcakes;

    public UnityEvent<CollectingCupCakes> OnCupCakeCollected;

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag(Tags.CupCake))
        {
            Debug.Log("CupCake collected!");
            cupcakes++;
            Col.gameObject.SetActive(false);
            OnCupCakeCollected.Invoke(this);
            
        }
    }
    
        
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
