#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Linq;
using Skiing2;

[CustomPropertyDrawer(typeof(TitleAttribute))]
internal sealed class TitleDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        TitleAttribute titleAttribute = attribute as TitleAttribute;

        // 调整位置
        position.yMin += EditorGUIUtility.singleLineHeight * 0.5f;
        position = EditorGUI.IndentedRect(position);

        // 绘制标题
        GUI.Label(position, titleAttribute.Title, EditorStyles.boldLabel);
    }

    public override float GetHeight()
    {
        TitleAttribute titleAttribute = attribute as TitleAttribute;
        float height = EditorStyles.boldLabel.CalcHeight(new GUIContent(titleAttribute.Title), 1f);
        int lineCount = titleAttribute.Title.Count(c => c == '\n') + 1;
        return EditorGUIUtility.singleLineHeight * 1.5f + (height / lineCount) * (lineCount - 1);
    }
}
#endif