using UnityEngine;

public class AlwaysKeepRightOrientation : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.localScale = transform.parent.transform.localScale;
    }
}
