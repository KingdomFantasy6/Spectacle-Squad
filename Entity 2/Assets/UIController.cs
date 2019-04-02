using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Camera camera;

    public GameObject unit1;
    public GameObject unit2;
    public GameObject unit3;
    public GameObject unit4;

    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;

    public Text moneyCounter;
    public Text indication;
    public int totalMoney = 1000000;

    public float indicationTimer = 2.0f;
    float timer;

    bool unit1ChosenGood, unit2ChosenGood, unit3ChosenGood, unit4ChosenGood;
    bool unit1ChosenBad, unit2ChosenBad, unit3ChosenBad, unit4ChosenBad;

    public GameObject window;
    public Text info;

    public GameObject helpWindow;
    public Button helpReturnButton;
    public Text general;
    public Text stocks;
    public Text bonds;
    public Text mutualFunds;
    public Text etf;
    public Text stockOptions;

    void Start () {
        indication.gameObject.SetActive(false);
        moneyCounter.text = "Total Money: $" + totalMoney;
        timer = indicationTimer;
        unit1ChosenGood = false;
        unit2ChosenGood = false;
        unit3ChosenGood = false;
        unit4ChosenGood = false;
        unit1ChosenBad = false;
        unit2ChosenBad = false;
        unit3ChosenBad = false;
        unit4ChosenBad = false;
        window.SetActive(false);
        helpWindow.SetActive(false);
    }	

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.tag == "u1")
                {
                    if (UI1.activeSelf)
                    {
                        UI1.SetActive(false);
                    }
                    else
                    {
                        UI1.SetActive(true);
                    }
                    UI2.SetActive(false);
                    UI3.SetActive(false);
                    UI4.SetActive(false);
                }
                else if (hit.transform.tag == "u2")
                {
                    UI1.SetActive(false);
                    if (UI2.activeSelf)
                    {
                        UI2.SetActive(false);
                    }
                    else
                    {
                        UI2.SetActive(true);
                    }
                    UI3.SetActive(false);
                    UI4.SetActive(false);
                }
                else if (hit.transform.tag == "u3")
                {
                    UI1.SetActive(false);
                    UI2.SetActive(false);
                    if (UI3.activeSelf)
                    {
                        UI3.SetActive(false);
                    }
                    else
                    {
                        UI3.SetActive(true);
                    }
                    UI4.SetActive(false);
                }
                else if (hit.transform.tag == "u4")
                {
                    UI1.SetActive(false);
                    UI2.SetActive(false);
                    UI3.SetActive(false);
                    if (UI4.activeSelf)
                    {
                        UI4.SetActive(false);
                    }
                    else
                    {
                        UI4.SetActive(true);
                    }
                }
                //else if (hit.transform.tag == "ground")
                //{
                //    UI1.SetActive(false);
                //    UI2.SetActive(false);
                //    UI3.SetActive(false);
                //    UI4.SetActive(false);
                //}
                else { }
            }
        }

        if (indication.gameObject.activeSelf)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = indicationTimer;
                indication.gameObject.SetActive(false);
            }   
        }
    }

    void MoneyChange(GameObject unit, int i)
    {
        int investment;
        if (i == 0)
        {
            investment = unit.GetComponent<Building>().goodInvestment();
            totalMoney += investment;
            moneyCounter.text = "Total Money: $" + totalMoney;
            indication.text = "+$" + investment;
        }
        else
        {
            investment = unit.GetComponent<Building>().badInvestment();
            totalMoney += investment;
            moneyCounter.text = "Total Money: $" + totalMoney;
            indication.text = "+$" + investment;
        }
        indication.gameObject.SetActive(true);
    }

    // Button Functions
    public void Unit1Good()
    {
        unit1ChosenGood = true;
        info.text = "SUSA\n\n\nTrending Up\n\n\nPrice per share: $119.62";
        window.SetActive(true);
    }

    public void Unit1Bad()
    {
        unit1ChosenBad = true;
        info.text = "BP\n\n\nTrending up\n\n\nPrice per share: $44.09";
        window.SetActive(true);
    }

    public void Unit2Good()
    {
        unit2ChosenGood = true;
        info.text = "CRBN\n\n\nTrending up\n\n\nPrice per Share $117.90";
        window.SetActive(true);
    }

    public void Unit2Bad()
    {
        unit2ChosenBad = true;
        info.text = "BP\n\n\nTrending up\n\n\nPrice per share: $44.09";
        window.SetActive(true);
    }

    public void Unit3Good()
    {
        unit3ChosenGood = true;
        info.text = "CRBN\n\n\nTrending up\n\n\nPrice per Share $117.90";
        window.SetActive(true);
    }

    public void Unit3Bad()
    {
        unit3ChosenBad = true;
        info.text = "Philip Morris\n\n\nTrending Down\n\n\nPrice per Share $88.26";
        window.SetActive(true);
    }

    public void Unit4Good()
    {
        unit4ChosenGood = true;
        info.text = "SUSA\n\n\nTrending up\n\n\nPrice per Share: $119.62";
        window.SetActive(true);
    }

    public void Unit4Bad()
    {
        unit4ChosenBad = true;
        info.text = "Walmart\n\n\nTrending up\n\n\nPrice per Share:$97.83 ";
        window.SetActive(true);
    }

    public void Return()
    {
        unit1ChosenGood = false;
        unit2ChosenGood = false;
        unit3ChosenGood = false;
        unit4ChosenGood = false;
        unit1ChosenBad = false;
        unit2ChosenBad = false;
        unit3ChosenBad = false;
        unit4ChosenBad = false;
        window.SetActive(false);
    }

    public void Invest()
    {
        if (unit1ChosenGood)
        {
            MoneyChange(unit1, 0);
            unit1ChosenGood = false;
        }
        if (unit2ChosenGood)
        {
            MoneyChange(unit2, 0);
            unit2ChosenGood = false;
        }
        if (unit3ChosenGood)
        {
            MoneyChange(unit3, 0);
            unit3ChosenGood = false;
        }
        if (unit4ChosenGood)
        {
            MoneyChange(unit4, 0);
            unit4ChosenGood = false;
        }
        if (unit1ChosenBad)
        {
            MoneyChange(unit1, 1);
            unit1ChosenBad = false;
        }
        if (unit2ChosenBad)
        {
            MoneyChange(unit2, 1);
            unit2ChosenBad = false;
        }
        if (unit3ChosenBad)
        {
            MoneyChange(unit3, 1);
            unit3ChosenBad = false;
        }
        if (unit4ChosenBad)
        {
            MoneyChange(unit4, 1);
            unit4ChosenBad = false;
        }
        window.SetActive(false);
    }

    public void Help()
    {
        if (helpWindow.activeSelf)
        {
            helpWindow.SetActive(false);
        }
        else
        {
            helpWindow.SetActive(true);
            general.gameObject.SetActive(true);
            helpReturnButton.gameObject.SetActive(false);
            stocks.gameObject.SetActive(false);
            bonds.gameObject.SetActive(false);
            mutualFunds.gameObject.SetActive(false);
            etf.gameObject.SetActive(false);
            stockOptions.gameObject.SetActive(false);
        }
    }
    public void helpReturn()
    {
        general.gameObject.SetActive(true);
        helpReturnButton.gameObject.SetActive(false);
        stocks.gameObject.SetActive(false);
        bonds.gameObject.SetActive(false);
        mutualFunds.gameObject.SetActive(false);
        etf.gameObject.SetActive(false);
        stockOptions.gameObject.SetActive(false);
    }
    public void Stocks()
    {
        general.gameObject.SetActive(false);
        helpReturnButton.gameObject.SetActive(true);
        stocks.gameObject.SetActive(true);
        bonds.gameObject.SetActive(false);
        mutualFunds.gameObject.SetActive(false);
        etf.gameObject.SetActive(false);
        stockOptions.gameObject.SetActive(false);
    }
    public void Bonds()
    {
        general.gameObject.SetActive(false);
        helpReturnButton.gameObject.SetActive(true);
        stocks.gameObject.SetActive(false);
        bonds.gameObject.SetActive(true);
        mutualFunds.gameObject.SetActive(false);
        etf.gameObject.SetActive(false);
        stockOptions.gameObject.SetActive(false);
    }
    public void MutualFunds()
    {
        general.gameObject.SetActive(false);
        helpReturnButton.gameObject.SetActive(true);
        stocks.gameObject.SetActive(false);
        bonds.gameObject.SetActive(false);
        mutualFunds.gameObject.SetActive(true);
        etf.gameObject.SetActive(false);
        stockOptions.gameObject.SetActive(false);
    }
    public void ETF()
    {
        general.gameObject.SetActive(false);
        helpReturnButton.gameObject.SetActive(true);
        stocks.gameObject.SetActive(false);
        bonds.gameObject.SetActive(false);
        mutualFunds.gameObject.SetActive(false);
        etf.gameObject.SetActive(true);
        stockOptions.gameObject.SetActive(false);
    }
    public void StockOptions()
    {
        general.gameObject.SetActive(false);
        helpReturnButton.gameObject.SetActive(true);
        stocks.gameObject.SetActive(false);
        bonds.gameObject.SetActive(false);
        mutualFunds.gameObject.SetActive(false);
        etf.gameObject.SetActive(false);
        stockOptions.gameObject.SetActive(true);
    }
}
