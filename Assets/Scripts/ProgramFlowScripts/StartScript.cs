using UnityEngine;


[DefaultExecutionOrder(-1000)]
public class StartScript : MonoBehaviour
{
    public bool IsMenu = false;
    public GameObject Player = null;
    public Vector3 PlayerSpawnLocation = Vector3.zero;

    void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        //DestroyAllObjectWithTag("Player");
        //DestroyAllObjectWithTag("Enemy");

        if (!IsMenu)
        {
            SpawnPlayer();
        }
    }

    private void DestroyAllObjectWithTag(string tag)
    {
        var objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (var obj in objects)
        {
            Destroy(obj);
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(Player, PlayerSpawnLocation, Quaternion.identity);
    }
}
