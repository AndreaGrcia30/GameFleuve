using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
     bool[] isFull;
     GameObject[] slots;

     public bool[] IsFull => isFull;
     public GameObject[] Slots => slots;
}
