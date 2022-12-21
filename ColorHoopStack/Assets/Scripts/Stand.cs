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
    int _cemberTamamlanmaSayisi;

    public GameObject EnUsttekiCemberiVer()
    {
        return Cemberler[^1];
    }
    public GameObject MusaitSoketiVer()
    {
        return Soketler[_bosOlanSoket];
    }
    public void SoketDegistirmeIslemler(GameObject SilinecekObje)
    {
        Cemberler.Remove(SilinecekObje);
        
        if (Cemberler.Count != 0)
        {
            _bosOlanSoket--;
            Cemberler[^1].GetComponent<Cember>()._hareketEdebilirMi = true;
        }
        else
        {
            _bosOlanSoket = 0;
        }
    }
    public void CemberleriKontrolEt()
    {
        if (Cemberler.Count == 4)
        {
            string Renk = Cemberler[0].GetComponent<Cember>()._renk;

            foreach (var item in Cemberler)
            {
                if (Renk == item.GetComponent<Cember>()._renk) _cemberTamamlanmaSayisi++;
            }
            if (_cemberTamamlanmaSayisi == 4)
            {
                GameManager.StandTamamlandi();
                TamamlanmisStandIslemleri();
            }
            else
            {
                _cemberTamamlanmaSayisi = 0;
            }
        }
    }
    void TamamlanmisStandIslemleri()
    {
        foreach (var item in Cemberler)
        {
            item.GetComponent<Cember>()._hareketEdebilirMi = false;

            Color32 _color = item.GetComponent<MeshRenderer>().material.GetColor("Color");
            _color.a = 100;
            item.GetComponent<MeshRenderer>().material.SetColor("Color", _color);
            gameObject.tag = "TamamlanmisStand";
        }
    }
}
