using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cember : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    public GameObject AitOlduguStand;
    public GameObject AitOlduguCemberSoketi;
    public bool _hareketEdebilirMi;
    public string _renk;

    GameObject _hareketPosizyonu;
    GameObject _aitOlduguStand;

    bool _secildi, _posDegistir, _soketOtur, _soketeGeriGit;

    public void HareketEt(string islem, GameObject Stand = null, GameObject Soket = null, GameObject GidilecekObje = null)
    {
        switch (islem)
        {
            case "Secim":
                _hareketPosizyonu = GidilecekObje;
                _secildi = true;
                break;
            case "PozisyonDegistir":

                break;
            case "SoketeOtur":

                break;
            case "SoketeGeriGit":

                break;
        }
    }
    void Update()
    {
        if (_secildi)
        {
            transform.position = Vector3.Lerp(transform.position, _hareketPosizyonu.transform.position, 0.2f);
            if (Vector3.Distance(transform.position, _hareketPosizyonu.transform.position) < 0.10)
            {
                _secildi = false;
            }
        }
    }
}
