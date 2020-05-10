//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetDistro", menuName = "luisquid/ScriptableObject/Planet Distribution")]
public class PlanetDistro : ScriptableObject
{
    public float WhiteProbab;
    public float BlueProbab;
    public float GoldProbab;
    public GameObject[] Planets;
}
