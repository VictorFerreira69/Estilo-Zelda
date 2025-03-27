using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventario : MonoBehaviour
{
    public int totalSlots = 3;
    public GameObject slotPrefab;
    public Transform slotParent;
    public Color selectedColor = Color.yellow;
    public Color defaultColor = Color.white;
    public Sprite cadeadoSprite;

    private int selectedSlot = 0;
    private List<GameObject> slots = new List<GameObject>();
    private List<IItem> items = new List<IItem>();

    void Start()
    {
        for (int i = 0; i < totalSlots; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            Image slotImage = slot.GetComponent<Image>();
            slotImage.sprite = cadeadoSprite;
            slots.Add(slot);
        }
        UpdateSlotSelection();


        CajadoEscudo cajadoEscudo = FindObjectOfType<CajadoEscudo>();
        if (cajadoEscudo != null && !ContainsItem(cajadoEscudo))
        {
            AddItem(cajadoEscudo);
        }

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
        for (int i = 0; i < slots.Count; i++)
        {
            Image slotImage = slots[i].GetComponent<Image>();
            if (slotImage.sprite == cadeadoSprite)
            {
                slotImage.sprite = item.GetIcon();
                items.Add(item);
                return;
            }
        }
    }

    public IItem GetSelectedItem()
    {
        if (selectedSlot >= 0 && selectedSlot < items.Count)
        {
            return items[selectedSlot];
        }
        return null;
    }

    public void RemoveItem(IItem item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Image slotImage = slots[i].GetComponent<Image>();
            if (slotImage.sprite == item.GetIcon())
            {
                slotImage.sprite = cadeadoSprite;
                items.Remove(item);
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

    public bool ContainsItem(IItem item)
    {
        return items.Contains(item);
    }
}