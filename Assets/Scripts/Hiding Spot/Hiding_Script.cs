using UnityEngine;

public class Hiding_Script : MonoBehaviour
{
    private bool claimed = false;

    public bool TryClaim()
    {
        if (claimed) return false;
        claimed = true;
        return true;
    }

    public bool IsClaimed()
    {
        return claimed;
    }

    public void Release()
    {
        claimed = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = claimed ? Color.red : Color.green;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}
