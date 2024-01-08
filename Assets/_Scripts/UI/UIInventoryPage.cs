using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;
    
    [SerializeField]
    private UIInventoryDescription itemDescription;

    [SerializeField]
    private RectTransform contentPanel;
    
    [SerializeField]
    private MouseFollower mouseFollower;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public Sprite image, image2;
    public int quantity;
    public string title, description;

    private int currentlyDraggedItemIndex = -1;

    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
        itemDescription.ResetDescription();
    }
    public void InitializeInventoryUI(int inventorysize)
    {
        for(int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem UIitem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            UIitem.transform.SetParent(contentPanel,false);
            listOfUIItems.Add(UIitem);
            UIitem.OnItemClicked += HandleItemSelection;
            UIitem.OnItemBeginDrag += HandleBeginDrag;
            UIitem.OnItemDroppedOn += HandleItemSwap;
            UIitem.OnItemEndDrag += HandleItemEndDrag;
            UIitem.OnRightMouseBtnClick += HandleItemShowItemActions;
        }
    }

    private void HandleItemShowItemActions(UIInventoryItem inventoryItemUI)
    {
        throw new NotImplementedException();
    }

    private void HandleItemEndDrag(UIInventoryItem inventoryItemUI)
    {
        mouseFollower.Toggle(false);
    }

    private void HandleItemSwap(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        Debug.Log("Item dragged");

        if (index == -1)
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
            return;
        }
        listOfUIItems[currentlyDraggedItemIndex].SetData(index == 0 ? image : image2, quantity);
        listOfUIItems[index].SetData(currentlyDraggedItemIndex == 0 ? image : image2, quantity);
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;

        currentlyDraggedItemIndex = index;
        mouseFollower.Toggle(true);

        mouseFollower.SetData(index == 0 ? image : image2, quantity);
    }

    private void HandleItemSelection(UIInventoryItem inventoryItemUI)
    {
        itemDescription.SetDescription(image, title, description);
        listOfUIItems[0].Select();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        itemDescription.ResetDescription();

        listOfUIItems[0].SetData(image, quantity);
        listOfUIItems[1].SetData(image2, quantity);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
