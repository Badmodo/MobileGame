using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BreadAndButter.AI
{


    public class Spawner : MonoBehaviour
    {
        public Vector3 size = Vector3.one;
        public Vector3 center = Vector3.zero;

        [SerializeField, Tooltip("Use the objects y position always when spawning an object.")]
        private bool floorYPosition = false;
        [SerializeField]
        private Vector2 spawnRate = new Vector2(0, 1);

        [SerializeField]
        private bool shouldSpawnBoss = false;
        [SerializeField]
        private float bossSpawnChance = 1;

        [SerializeField]
        private GameObject bossPrefab = null;
        [SerializeField]
        private GameObject enemyPrefab = null;

        private float time = 0;
        private float timeStop = 0;

        public void Spawn()
        {
            GameObject prefab = shouldSpawnBoss && Random.Range(0, 100) < bossSpawnChance ? bossPrefab : enemyPrefab;
            Vector3 position = transform.position + new Vector3(
                Random.Range(-size.x * 0.5f, size.x * 0.5f),
                floorYPosition ? 0 : Random.Range(-size.y * 0.5f, size.y * 0.5f),
                Random.Range(-size.z * 0.5f, size.z * 0.5f)) + center;

            position = transform.InverseTransformPoint(position);

            Instantiate(prefab, position, transform.rotation, transform);

            timeStop = Random.Range(spawnRate.x, spawnRate.y);
            timeStop = 0;
        }

        private void Start()
        {
            timeStop = Random.Range(spawnRate.x, spawnRate.y);
        }

        private void Update()
        {
            if(time < timeStop)
            {
                time += Time.deltaTime * Time.timeScale;
            }
            else
            {
                Spawn();
            }
        }


#if UNITY_EDITOR
        //implament this oOnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        private void OnDrawGizmos()
        {
            Matrix4x4 baseMatrix = Gizmos.matrix;
            Matrix4x4 rotationMatrix = transform.localToWorldMatrix;
            Gizmos.matrix = rotationMatrix;

            Gizmos.color = new Color(0, 1, 0, 0.5f);
            Gizmos.DrawCube(center, size);

            //Reset the gizmos matrix back to default
            Gizmos.matrix = baseMatrix;
        }
#endif
    }
}