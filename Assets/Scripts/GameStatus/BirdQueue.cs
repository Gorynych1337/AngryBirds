using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static BirdEnum;

public class BirdQueue : MonoBehaviour
{
    [SerializeField] private List<Birds> birds;
    [SerializeField] private Transform slingshotTransform;
    [SerializeField] private Transform queueTransform;
    [SerializeField] private BirdEnum birdEnum;
    private Queue<GameObject> birdsQueue;

    public delegate void QueueEnded();
    public static event QueueEnded OnQueueEnded;

    private void Start()
    {
        birdsQueue = new Queue<GameObject>();

        float shift = 0;
        birds.ForEach(b =>
        {
            var bird = Instantiate(birdEnum.GetBirdPrefab(b), queueTransform.position, queueTransform.rotation);
            bird.GetComponent<Bird>().enabled = false;
            bird.transform.position -= new Vector3(shift, 0);
            shift += bird.transform.lossyScale.x + 0.1f;
            birdsQueue.Enqueue(bird);
        });
        SpawnBirdToShoot();

        Bird.OnBirdDestroyed += SpawnBirdToShoot;
    }

    private void OnDisable()
    {
        Bird.OnBirdDestroyed -= SpawnBirdToShoot;
    }

    private void SpawnBirdToShoot()
    {
        if (birdsQueue.Count == 0)
        {
            OnQueueEnded?.Invoke();
            return;
        }

        var bird = birdsQueue.Dequeue();
        bird.GetComponent<Bird>().enabled = true;
        bird.transform.position = slingshotTransform.position;
    }

    private void MoveQueue(float shift)
    {
        var list = birdsQueue.ToList();
        list.ForEach(b => b.transform.position += new Vector3(shift, 0));
    }
}
