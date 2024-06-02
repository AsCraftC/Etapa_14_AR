using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text TittleLabel;
    [SerializeField] private Transform Center;
    //[SerializeField] private Transform Up;
    //[SerializeField] private Transform Down;
    //[SerializeField] private Transform Left;
    //[SerializeField] private Transform Right;

    [SerializeField] private GameObject Label;
    
    public void ShowInfo(String tittle)
    {
        TittleLabel.SetText(tittle);
        this.transform.Find("InfoLabel").gameObject.SetActive(true);
    }

    public void CloseLabel(Material material)
    {
        this.transform.Find("InfoLabel").gameObject.SetActive(false);
        GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");
        foreach (var marker in markers)
        {
            marker.GetComponent<MeshRenderer>().material = material;
        }
    }

    private void Update()
    {
        var modelCenter = Camera.main.WorldToScreenPoint(Center.position);
    //    var modelUpper = Camera.main.WorldToScreenPoint(Up.position);
    //    var modelBottom = Camera.main.WorldToScreenPoint(Down.position);
    //    var modelLeft = Camera.main.WorldToScreenPoint(Left.position);
    //    var modelRight = Camera.main.WorldToScreenPoint(Right.position);

        bool isLandscape = Camera.main.pixelWidth > Camera.main.pixelHeight;

        if (isLandscape)
        {   
            bool isModelOnRight = modelCenter.x > (Camera.main.pixelWidth/2.0f);
            if (isModelOnRight)
            {
                Label.GetComponent<RectTransform>().position = modelCenter - new Vector3(300,0);
            } 
            else
            {
                Label.GetComponent<RectTransform>().position = modelCenter + new Vector3(900,0);
            }
        }
        else
        {
            bool isModelOnTop = modelCenter.y > (Camera.main.pixelHeight/2.0f);
            if (isModelOnTop)
            {
                Label.GetComponent<RectTransform>().position = modelCenter - new Vector3(-300,800);
            } 
            else
            {
                Label.GetComponent<RectTransform>().position = modelCenter + new Vector3(300,800);
            }
        }
    }
}
