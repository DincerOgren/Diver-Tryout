using UnityEngine;

public class Gather : MonoBehaviour
{
    public Transform gatherCollider;
    public float gatherRadius;
    public LayerMask resourceLayer;
    public float gatherDamage = 2;

    public void GatherResources()
    {


        Collider[] hits = Physics.OverlapSphere(gatherCollider.position, gatherRadius, resourceLayer);
        if (hits.Length>=1)
        {
            print("Player Hit resource layer");

        }

        foreach (var item in hits)
        {
            if (item.TryGetComponent<Tree>(out Tree treeComp))
            {
                treeComp.TakeDamage(gatherDamage);
            }
        }
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gatherCollider.position, gatherRadius);
    }
}
