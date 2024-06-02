using UnityEngine;

public class MarkerDescription : MonoBehaviour
{
    public string Tittle;

    public void OnPressed(Material material)
    {
        this.GetComponent<MeshRenderer>().material = material;
    }
    
}
