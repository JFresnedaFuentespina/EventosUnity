using UnityEngine;

public class BombBehaviourEvent : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 2f;
    public delegate void BombExplote(float range, Vector3 position);
    public static event BombExplote OnBombExplote;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (OnBombExplote != null) // Si hay alguien subscrito al evento
            {
                OnBombExplote(detectionRadius, this.transform.position);
            }
        }
    }
}
