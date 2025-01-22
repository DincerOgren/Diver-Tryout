using UnityEngine;

[CreateAssetMenu(fileName = "MaterialSO1", menuName = "Scriptable Objects/MaterialSO1",order=1)]
public class MaterialSO1 : ScriptableObject
{
    public string materialName = "default";

    public Sprite materialImage = null;

    public bool isStackable = false;

    public string description = "";
}
