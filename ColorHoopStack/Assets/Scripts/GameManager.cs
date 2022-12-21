using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject SeciliObje;
    GameObject SeciliStand;
    Cember Cember;
    public bool _hareketVar;
    public int _hedefStandSayisi;
    int _tamamlananStandSayisi;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                if (hit.collider != null && hit.collider.CompareTag("Stand"))
                {
                    if (SeciliObje !=null && SeciliStand != hit.collider.gameObject)
                    {
                        Stand _stand = hit.collider.GetComponent<Stand>();

                        if (_stand.Cemberler.Count !=4 && _stand.Cemberler.Count !=0)
                        {
                            if (Cember._renk == _stand.Cemberler[^1].GetComponent<Cember>()._renk)
                            {
                                SeciliStand.GetComponent<Stand>().SoketDegistirmeIslemler(SeciliObje);
                                Cember.HareketEt("PozisyonDegistir", hit.collider.gameObject, _stand.MusaitSoketiVer(), _stand.HareketPozisyonu);

                                _stand._bosOlanSoket++;
                                _stand.Cemberler.Add(SeciliObje);
                                _stand.CemberleriKontrolEt();
                                SeciliObje = null;
                                SeciliStand = null;
                            }
                            else
                            {
                                Cember.HareketEt("SoketeGeriGit");
                                SeciliObje = null;
                                SeciliStand = null;
                            }                            
                        }
                        else if (_stand.Cemberler.Count == 0)
                        {
                            SeciliStand.GetComponent<Stand>().SoketDegistirmeIslemler(SeciliObje);
                            Cember.HareketEt("PozisyonDegistir", hit.collider.gameObject, _stand.MusaitSoketiVer(), _stand.HareketPozisyonu);

                            _stand._bosOlanSoket++;
                            _stand.Cemberler.Add(SeciliObje);
                            _stand.CemberleriKontrolEt();
                            SeciliObje = null;
                            SeciliStand = null;
                        }
                        else
                        {
                            Cember.HareketEt("SoketeGeriGit");
                            SeciliObje = null;
                            SeciliStand = null;
                        }                        
                    }
                    else if (SeciliStand == hit.collider.gameObject)
                    {
                        Cember.HareketEt("SoketeGeriGit");
                        SeciliObje = null;
                        SeciliStand = null;
                    }
                    else
                    {
                        Stand _stand = hit.collider.GetComponent<Stand>();
                        SeciliObje = _stand.EnUsttekiCemberiVer();
                        Cember = SeciliObje.GetComponent<Cember>();
                        _hareketVar = true;

                        if (Cember._hareketEdebilirMi)
                        {
                            Cember.HareketEt("Secim", null, null, Cember.AitOlduguStand.GetComponent<Stand>().HareketPozisyonu);

                            SeciliStand = Cember.AitOlduguStand;
                        }
                    }
                }
            }
        }
    }
    public void StandTamamlandi()
    {
        _tamamlananStandSayisi++;
        if (_tamamlananStandSayisi == _hedefStandSayisi) Debug.Log("Kazandýn");
    }
}
