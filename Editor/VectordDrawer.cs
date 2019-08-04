using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector2d))]
[CustomPropertyDrawer(typeof(Vector3d))]
public class VectordDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Keyboard), label);
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		float labelWidth = EditorGUIUtility.singleLineHeight-3;
		float inputWidth = Mathf.Floor(position.width / 3 - labelWidth);
		var labelX = new Rect(position.x-1, position.y, labelWidth, position.height);
		var rectX = new Rect(labelX.xMax, position.y, inputWidth, position.height);
		var labelY = new Rect(rectX.xMax + 2, position.y, labelWidth, position.height);
		var rectY = new Rect(labelY.xMax, position.y, inputWidth, position.height);

		EditorGUI.LabelField(labelX, "X");
		EditorGUI.LabelField(labelY, "Y");
		EditorGUI.PropertyField(rectX, property.FindPropertyRelative("x"), GUIContent.none);
		EditorGUI.PropertyField(rectY, property.FindPropertyRelative("y"), GUIContent.none);
		SerializedProperty z = property.FindPropertyRelative("z");
		if (z != null)
		{
			var labelZ = new Rect(rectY.xMax + 2, position.y, labelWidth, position.height);
			var rectZ = new Rect(labelZ.xMax, position.y, inputWidth, position.height);
			EditorGUI.LabelField(labelZ, "Z");
			EditorGUI.PropertyField(rectZ, z, GUIContent.none);
		}

		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
	}
}
