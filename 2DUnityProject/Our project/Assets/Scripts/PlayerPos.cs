using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    public static Vector2 lastCheckpointPos = new Vector2(-5.79f, 0f);

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpointPos;
    }
}
