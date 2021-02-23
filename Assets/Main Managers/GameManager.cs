using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }
    [BoxGroup("Gem Generation")]

    public GameObject gemPrefab;
    [BoxGroup("Gem Generation")]
    public CodeGem gemSO;
    [Button("Spawn New Gem")]
    void SpawnNewGame()
    {
        GameObject go = Instantiate(gemPrefab, Vector3.zero, Quaternion.identity);
        GemPickup gp = go.GetComponent<GemPickup>();
        gp.gemSO = gemSO;
        go.GetComponent<SpriteRenderer>().sprite = gemSO.image;

    }
    public GameObject particles;
}
