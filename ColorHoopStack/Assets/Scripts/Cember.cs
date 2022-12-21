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
    GameObject _gidecegiStand;

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
                _gidecegiStand = Stand;
                AitOlduguCemberSoketi = Soket;
                _hareketPosizyonu = GidilecekObje;
                _posDegistir = true;
                break;

            case "SoketeGeriGit":
                _soketeGeriGit = true;
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
        if (_posDegistir)
        {
            transform.position = Vector3.Lerp(transform.position, _hareketPosizyonu.transform.position, 0.2f);
            if (Vector3.Distance(transform.position, _hareketPosizyonu.transform.position) < 0.10)
            {
                _posDegistir = false;
                _soketOtur = true;
            }
        }
        if (_soketOtur)
        {
            transform.position = Vector3.Lerp(transform.position, _hareketPosizyonu.transform.position, 0.2f);
            if (Vector3.Distance(transform.position, _hareketPosizyonu.transform.position) < 0.10)
            {
                transform.position = AitOlduguCemberSoketi.transform.position;
                _soketOtur = false;

                AitOlduguStand = _gidecegiStand;

                if (AitOlduguStand.GetComponent<Stand>().Cemberler.Count > 1)
                {
                    AitOlduguStand.GetComponent<Stand>().Cemberler[^2].GetComponent<Cember>()._hareketEdebilirMi = false;
                }

                GameManager._hareketVar = false;
            }
        }
        if (_soketeGeriGit)
        {
            transform.position = Vector3.Lerp(transform.position, _hareketPosizyonu.transform.position, 0.2f);
            if (Vector3.Distance(transform.position, _hareketPosizyonu.transform.position) < 0.10)
            {
                transform.position = AitOlduguCemberSoketi.transform.position;
                _soketeGeriGit = false;
                GameManager._hareketVar = false;
            }
        }
    }
}
