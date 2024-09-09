using UnityEngine;

public class ColiisionTest : MonoBehaviour
{
    public Timer timeManager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("GameOver");
            if(timeManager!=null)
            {
                timeManager.StopTimer();
                timeManager.ShowGameOverGroup();
            }
            else
            {
                Debug.Log("No existe el timeManager");
            }
        }
    }
}
