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
}
