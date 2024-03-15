using UnityEngine.SceneManagement;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D) , typeof(Rigidbody2D))]
public class SceneLoader : MonoBehaviour
{
    [SerializeField] int sceneId;
    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}
