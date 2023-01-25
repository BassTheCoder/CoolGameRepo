using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject Player = null;

    void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        DestroyAllObjectWithTag("Player");
        DestroyAllObjectWithTag("Enemy");

        Instantiate(Player, new Vector3(-1f, -0.6f, 0.005f), Quaternion.identity);
    }

    private void DestroyAllObjectWithTag(string tag)
    {
        var objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (var obj in objects)
        {
            Destroy(obj);
        }
    }
}
