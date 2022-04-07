using UnityEngine;


public enum ItemType
{
    Empty,
    Ball,
    Barrel,
    Stone,
    Box,
    Dynamite,    
    Star
}

public class Item : MonoBehaviour
{
    public ItemType ItemType;
}
