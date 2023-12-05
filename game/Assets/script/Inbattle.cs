using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inbattle : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(sound1);
        StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(1.0f);

        //if (collision.gameObject.name == "pipo-charachip029_0")

        SceneManager.LoadScene("typing scene");

    }
}

