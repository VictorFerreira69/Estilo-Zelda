using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventario : MonoBehaviour
{
    public int totalSlots = 4;
    public GameObject slotPrefab;
    public Transform slotParent;
    public Color selectedColor = Color.yellow;
    public Color defaultColor = Color.white;

    private int selectedSlot = 0;
    private List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < totalSlots; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slots.Add(slot);
        }
        UpdateSlotSelection();
    }

    void Update()
    {
        int previousSlot = selectedSlot;

        for (int i = 0; i < totalSlots; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                selectedSlot = i;
                break;
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            selectedSlot = (selectedSlot + 1) % totalSlots;
        }
        else if (scroll < 0f)
        {
            selectedSlot = (selectedSlot - 1 + totalSlots) % totalSlots;
        }

        if (previousSlot != selectedSlot)
        {
            UpdateSlotSelection();
        }
    }

    public void AddItem(IItem item)
    {
        foreach (var slot in slots)
        {
            Image slotImage = slot.GetComponent<Image>();
            if (slotImage.sprite == null)
            {
                slotImage.sprite = item.GetIcon();
              
                return;
            }
        }

       
    }

    void UpdateSlotSelection()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Image slotImage = slots[i].GetComponent<Image>();
            if (slotImage != null)
            {
                slotImage.color = (i == selectedSlot) ? selectedColor : defaultColor;
            }
        }
    }
}
