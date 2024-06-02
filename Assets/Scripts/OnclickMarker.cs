using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnclickMarker : MonoBehaviour
{
    [SerializeField] private GameObject[] markers;
    [SerializeField] private GameObject ButtonUp;
    [SerializeField] private GameObject ButtonDown;
    [SerializeField] private GameObject Model;
    [SerializeField] private Material SelectedMaterial;
    [SerializeField] private Material NormalMaterial;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var marker in markers)
            {
                if (marker == GetClickedObject(out RaycastHit hit2))
                {
                    GameObject.FindObjectOfType<UIController>().CloseLabel(NormalMaterial);
                    marker.GetComponent<MarkerDescription>().OnPressed(SelectedMaterial);
                    GameObject.FindObjectOfType<UIController>().ShowInfo(marker.GetComponent<MarkerDescription>().Tittle);
                    return;
                }
            }
            if (ButtonUp == GetClickedObject(out RaycastHit hit))
            {
                ButtonUp.GetComponent<Animator>().SetTrigger("Pressed");
                Model.GetComponent<Animator>().SetTrigger("Up");
                return;
            }
            if (ButtonDown == GetClickedObject(out RaycastHit hit1))
            {
                ButtonDown.GetComponent<Animator>().SetTrigger("Pressed");
                Model.GetComponent<Animator>().SetTrigger("Down");
                return;
            }
        }
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            if (!isPointerOverUIObject()) 
            { 
                target = hit.collider.gameObject;
            }
        }
        return target;
    }
    

    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }
}
