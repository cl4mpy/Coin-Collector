using UnityEngine;
using System;

public class BelajarDelegate : MonoBehaviour
{
    delegate void ContohDelegate();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ujidelegate1();
        Ujidelegate2();
        Ujidelegate3();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ujidelegate1()
    {
        ContohDelegate halo = PanggilHello;
        halo();
    }
    void Ujidelegate2()
    {
        ContohDelegate halo = PanggilHello;
        halo += PanggilNama;
        halo();
    }
    void Ujidelegate3()
    {
        Action halo = PanggilHello;
        halo += PanggilNama;
        halo();
    }

    void PanggilHello()
    {
        Debug.Log("Hello");
    }

    void PanggilNama()
    {
        Debug.Log("Nama saya adalah cepirits");
    }
}