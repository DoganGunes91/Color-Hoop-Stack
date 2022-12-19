using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    public GameObject HareketPozisyonu;
    public GameObject[] Soketler;
    public List<GameObject> Cemberler = new();
    public int _bosOlanSoket;    

    public GameObject EnUsttekiCemberiVer()
    {
        return Cemberler[^1];
    }
}
