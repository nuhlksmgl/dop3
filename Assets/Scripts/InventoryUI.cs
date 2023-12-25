using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI CupCakeText;


    
    void Start()
    {
        CupCakeText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCupcakeText(CollectingCupCakes CollectingCupCakes)
    {
        CupCakeText.text = CollectingCupCakes.cupcakes.ToString();
    }
}
