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
    private CajadoEscudo cajadoEscudo;

    void Start()
    {
        cajadoEscudo = FindObjectOfType<CajadoEscudo>();

        for (int i = 0; i < totalSlots; i++)
            slots.Add(Instantiate(slotPrefab, slotParent));

        UpdateSlotSelection();

        if (cajadoEscudo != null && !ContainsItem(cajadoEscudo))
            AddItem(cajadoEscudo);
    }

    void Update()
    {
        int previousSlot = selectedSlot;

        for (int i = 0; i < totalSlots; i++)
            if (Input.GetKeyDown((i + 1).ToString())) 
                selectedSlot = i;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f) 
            selectedSlot = (selectedSlot + (scroll > 0f ? 1 : -1) + totalSlots) % totalSlots;

        if (previousSlot != selectedSlot)
            UpdateSlotSelection();
    }

    public void AddItem(IItem item)
    {
        if (items.Contains(item)) return;

        for (int i = 0; i < totalSlots; i++)
            if (slots[i].GetComponent<Image>().sprite == cadeadoSprite)
            {
                slots[i].GetComponent<Image>().sprite = item.GetIcon();
                items.Add(item);
                break;
            }
    }

    public void AtualizarIconePocao(int usosRestantes, Sprite poçaoIcon, Sprite[] spritesPoçao)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i] is PocaoCura pocao)
            {
                int spriteIndex = Mathf.Clamp(usosRestantes - 1, 0, spritesPoçao.Length - 1);
                slots[i].GetComponent<Image>().sprite = spritesPoçao[spriteIndex];
                break;
            }
    }

    public void AtualizarIconeCadeado(IItem item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i] == item)
            {
                slots[i].GetComponent<Image>().sprite = cadeadoSprite;
                break;
            }
    }

    public void AtualizarIconeCajado(Sprite novoIcone)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i] is CajadoEscudo)
            {
                slots[i].GetComponent<Image>().sprite = novoIcone;
                break;
            }
    }

    public IItem GetSelectedItem() => selectedSlot >= 0 && selectedSlot < items.Count ? items[selectedSlot] : null;

    public void RemoveItem(IItem item)
    {
        for (int i = 0; i < totalSlots; i++)
            if (slots[i].GetComponent<Image>().sprite == item.GetIcon())
            {
                slots[i].GetComponent<Image>().sprite = cadeadoSprite;
                items.Remove(item);
                break;
            }
    }

    void UpdateSlotSelection()
    {
        for (int i = 0; i < totalSlots; i++)
            slots[i].GetComponent<Image>().color = (i == selectedSlot) ? selectedColor : defaultColor;
    }

    public bool ContainsItem(IItem item) => items.Contains(item);
}