using UnityEngine;
using System.Collections;

public class TriggerFixer : MonoBehaviour
{
   //just moves stuff, tried to fix the issue but didn't fix it
    public GameObject character;

   
    public float nudgeDistance = 0.001f;

    
    public float nudgeDuration = 0.05f;

    void Start()
    {
        StartCoroutine(NudgeOnce());
    }

    private IEnumerator NudgeOnce()
    {
        Transform t = character.transform;
        Vector3 originalPos = t.position;
        Vector3 targetPos = originalPos + Vector3.right * nudgeDistance;

       
        Rigidbody rb = character.GetComponent<Rigidbody>();

        float elapsed = 0f;
        
        while (elapsed < nudgeDuration)
        {
            elapsed += Time.deltaTime;
            float frac = Mathf.Clamp01(elapsed / nudgeDuration);
            Vector3 newPos = Vector3.Lerp(originalPos, targetPos, frac);

            if (rb != null && !rb.isKinematic)
                rb.MovePosition(newPos);
            else
                t.position = newPos;

            yield return null;
        }

       
        if (rb != null && !rb.isKinematic) rb.MovePosition(targetPos); else t.position = targetPos;

    }
}
