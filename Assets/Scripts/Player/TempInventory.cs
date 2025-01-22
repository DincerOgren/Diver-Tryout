using UnityEngine;

public class TempInventory : MonoBehaviour
{
    public float woodAmount = 0;

    public void AddWood(float amount)
    {
        print("Add Wood Called");
        woodAmount += amount;
    }
}
