using TMPro;
using UnityEngine;

public class ScoreBasketball : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreIU;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb.linearVelocity.y <= 0.1f)
            {
                score++;
                ScoreUpdate();
            }
            else
            {
                score--;
                ScoreUpdate();
            }
        }
    }
    void ScoreUpdate()
    {
        scoreIU.text = score.ToString();
    }
}