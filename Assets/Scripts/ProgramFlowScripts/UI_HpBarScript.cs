using UnityEngine;

public class UI_HpBarScript : MonoBehaviour
{
    public GameObject Entity = null;

    private void Start()
    {
        if (Entity == null)
        {
            Debug.Log("Sctipt has no entity given to track health!");
        }
    }

    void Update()
    {
        if (Entity != null)
        {
            var currentHpPercent = Entity.GetEntityCurrentHpPercent();
            transform.GetChild(2).gameObject.transform.localScale = new Vector3(currentHpPercent, 1, 1);
        }
    }
}
