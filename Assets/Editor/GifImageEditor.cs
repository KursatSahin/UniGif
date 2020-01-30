using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(GifImage))]
public class GifImageEditor : RawImageEditor
{
    public override void OnInspectorGUI()
    {
        var gifImage = (GifImage) target; 
        gifImage.Url = EditorGUILayout.TextField("Url", gifImage.Url);
        
        EditorGUILayout.Separator();
        
        base.OnInspectorGUI();
    }
}
