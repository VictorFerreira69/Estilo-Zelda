
using UnityEngine;

public class Collectable : MonoBehaviour,ICollectable,IItem
{
    [SerializeField] private Sprite itemIcon;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Sprite GetIcon()
    {
        return itemIcon;
    }
}
