using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text textPeach;
    [SerializeField] private Text textWatermelon;
    [SerializeField] private Text textApple;
    [SerializeField] private Text textGold;

    [SerializeField]  private InventoryManager mgInventory;
    [SerializeField]  private GameObject panelItems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFoodUI();
    }

     void UpdateFoodUI()
    {
        int[] foodCount = mgInventory.GetFoodQuantity();
        textPeach.text = "x"+foodCount[0];
        textWatermelon.text = "x"+foodCount[1];
        textApple.text = "x"+foodCount[2];
    }

    public void TooglePanel()
    {
        panelItems.SetActive(!panelItems.activeSelf);
    }
}
