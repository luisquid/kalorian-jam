//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetType", menuName = "luisquid/ScriptableObject/Planet")]
public class PlanetType : ScriptableObject
{
    public int ClicksToExplode;
    public GameObject[] Loot;
}
