using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopPageManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> shopPages = new List<GameObject>();
    [SerializeField] TextMeshProUGUI pageText;
    private int activePage;


    void Start()
    {
        activePage = 0;
        ChangePage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPage()
    {
        if((activePage + 1) >= shopPages.Count)
        {
            return;
        }
        activePage++;

        ChangePage();
    }

    public void PreviousPage()
    {
        if ((activePage - 1) < 0)
        {
            return;
        }
        activePage--;

        ChangePage();
    }

    public void ChangePage()
    {
        foreach(var page in shopPages)
        {
            page.SetActive(false);
        }

        shopPages[activePage].SetActive(true);

        pageText.text = "Page " + (activePage + 1).ToString();
    }
}
