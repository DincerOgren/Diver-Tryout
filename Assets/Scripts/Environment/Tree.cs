using System;
using UnityEngine;

public class Tree : MonoBehaviour
{
    TempInventory playerInventory;
    public float maxHealth = 10;
    public float currentHealth;

    private float[] numbers = { 2f, 4f, 10f };
    private float[] weights = { 50f, 40f, 10f }; // Probabilities in percentages
    private void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<TempInventory>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        print("Tree Take Damagge;");
        currentHealth -= damageAmount;
        GiveResources(GetRandomWeightedNumber());
    }

    private void GiveResources(float amount)
    {
        playerInventory.AddWood(amount);
    }

   
    float GetRandomWeightedNumber()
    {
        // Calculate the total weight
        float totalWeight = 0;
        foreach (int weight in weights)
        {
            totalWeight += weight;
        }

        // Generate a random number between 0 and totalWeight
        float randomValue = UnityEngine.Random.Range(0, totalWeight);

        // Determine the chosen number based on the random value
        float cumulativeWeight = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            cumulativeWeight += weights[i];
            if (randomValue < cumulativeWeight)
            {
                return numbers[i];
            }
        }

        // Fallback (should never reach here if weights are set correctly)
        return numbers[0];
    }
}
