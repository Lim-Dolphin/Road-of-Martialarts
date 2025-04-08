using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    [SerializeField]
    private string transferSceneName;

    private Move_JS player;

    private void Start()
    {
        player = Move_JS.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(transferSceneName);
        }
    }
}
