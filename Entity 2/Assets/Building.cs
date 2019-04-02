using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour {

    public GameObject uninvested;
    public GameObject good;
    public GameObject bad;

    GameObject _uninvested;
    GameObject _good;
    GameObject _bad;

    public bool unit1 = false;
    public bool unit2 = false;
    public bool unit3 = false;
    public bool unit4 = false;

    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;

    public int investment = 20000;

	void Start () {
        _uninvested = Instantiate(uninvested, transform.position, Quaternion.identity);
        if (unit1)
        {
            _uninvested.gameObject.tag = "u1";
        }
        else if (unit2)
        {
            _uninvested.gameObject.tag = "u2";
        }
        else if (unit3)
        {
            _uninvested.gameObject.tag = "u3";
        }
        else if (unit4)
        {
            _uninvested.gameObject.tag = "u4";
        }
        else { }

        _good = Instantiate(good, transform.position, Quaternion.identity);
        _bad = Instantiate(bad, transform.position, Quaternion.identity);
        _uninvested.transform.localScale += new Vector3(100f, 100f, 100f);
        _good.transform.localScale += new Vector3(100f, 100f, 100f);
        _bad.transform.localScale += new Vector3(100f, 100f, 100f);
        _uninvested.SetActive(true);
        _good.SetActive(false);
        _bad.SetActive(false);
        MeshCollider c1 = _uninvested.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        MeshCollider c2 = _uninvested.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        MeshCollider c3 = _uninvested.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
    
        UI1.SetActive(false);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UI4.SetActive(false);
    }
	
	void Update () {

    }

    public int goodInvestment()
    {
        _uninvested.SetActive(false);
        _good.SetActive(true);
        _bad.SetActive(false);

        UI1.SetActive(false);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UI4.SetActive(false);

        return investment;
    }

    public int badInvestment()
    {
        _uninvested.SetActive(false);
        _good.SetActive(false);
        _bad.SetActive(true);

        UI1.SetActive(false);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UI4.SetActive(false);

        return investment;
    }
}
