using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invintory : MonoBehaviour, IInventory
{
    public int score { get => _score; set => _score = value; }

    private int _score = 0;
}
