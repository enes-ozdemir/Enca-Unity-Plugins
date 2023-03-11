using UnityEditor;

namespace Enca
{
    public class PrefabScatterer : EditorWindow
    {
        [MenuItem("EncaPlugins/Tools/Prefab Scatterer")]
        public static void OpenWindow() => GetWindow<PrefabScatterer>();

        public float radius = 2f;
        public int spawnCount = 4;

        private void OnEnable() => SceneView.duringSceneGui += DuringSceneGUI;
        private void OnDisable() => SceneView.duringSceneGui -= DuringSceneGUI;

        private void DuringSceneGUI(SceneView sceneView)
        {
            
        }

        private void OnGUI()
        {
        }
    }
}