using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEditor.AnimatedValues;


namespace BreadAndButter.AI
{
    [CustomEditor(typeof(Spawner))]
    public class SpawnerEditor : Editor
    {

        private Spawner spawner;

        private SerializedProperty sizeProperty;
        private SerializedProperty centerProperty;

        private SerializedProperty floorYPositionProperty;
        private SerializedProperty spawnRateProperty;

        private SerializedProperty shouldSpawnBossProperty;
        private SerializedProperty bossSpawnChanceProperty;
        private SerializedProperty bossPrefabProperty;
        private SerializedProperty enemyPrefabProperty;

        private AnimBool shouldSpawnBoss = new AnimBool();

        private BoxBoundsHandle handle;



        private void OnEnable()
        {
            spawner = target as Spawner;

            sizeProperty = serializedObject.FindProperty("size");
            centerProperty = serializedObject.FindProperty("center");

            floorYPositionProperty = serializedObject.FindProperty("floorYPosition");
            spawnRateProperty = serializedObject.FindProperty("spawnRate");

            shouldSpawnBossProperty = serializedObject.FindProperty("shouldSpawnBoss");
            bossSpawnChanceProperty = serializedObject.FindProperty("bossSpawnChance");
            bossPrefabProperty = serializedObject.FindProperty("bossPrefab");
            enemyPrefabProperty = serializedObject.FindProperty("enemyPrefab");

            shouldSpawnBoss.value = shouldSpawnBossProperty.boolValue;
            shouldSpawnBoss.valueChanged.AddListener(Repaint);
            handle = new BoxBoundsHandle();
        }

        //create a verticale layout group
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                //draw the ceter and size proeries as unity would
                EditorGUILayout.PropertyField(centerProperty);
                EditorGUILayout.PropertyField(sizeProperty);
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                EditorGUILayout.PropertyField(floorYPositionProperty);

                //cahce the original value of the spawn rate
                Vector2 spawnRate = spawnRateProperty.vector2Value;
                string label = $"Spawn Rate Bounds({spawnRate.x.ToString("0.00")}s - { spawnRate.y.ToString("0.00")}s)";

                EditorGUILayout.MinMaxSlider(label, ref spawnRate.x, ref spawnRate.y, 0, 3);
                spawnRateProperty.vector2Value = spawnRate;

                EditorGUILayout.Space();

                //render enemy prefab
                EditorGUILayout.PropertyField(enemyPrefabProperty);
                EditorGUILayout.PropertyField(shouldSpawnBossProperty);

                //attempt to fade the animbool
                shouldSpawnBoss.target = shouldSpawnBossProperty.boolValue;
                if(EditorGUILayout.BeginFadeGroup(shouldSpawnBoss.faded))
                {
                    //only visabel when the tickbox is on
                    EditorGUI.indentLevel++;

                    //draw spawn chance
                    EditorGUILayout.PropertyField(bossSpawnChanceProperty);
                    EditorGUILayout.PropertyField(bossPrefabProperty);


                    EditorGUI.indentLevel--;
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }

        private void OnSceneGUI()
        {
            //makes the handle color green
            Handles.color = Color.green;

            Matrix4x4 baseMatrix = Handles.matrix;
            Matrix4x4 rotationMatrix = spawner.transform.localToWorldMatrix;
            Handles.matrix = rotationMatrix;

            //setup the box bounds handle with the spawner values
            handle.center = spawner.center;
            handle.size = spawner.size;

            // begin listening for changes to the handle, then draw it
            EditorGUI.BeginChangeCheck();
            handle.DrawHandle();

            //check if any changes were detected
            if(EditorGUI.EndChangeCheck())
            {
                //reset the spawner values
                spawner.size = handle.size;
                spawner.center = handle.center;
            }
            //Reset the gizmos matrix back to default
            Handles.matrix = baseMatrix;

        }
    }
}