using UnityEditor;
using UnityEngine;

namespace Tools.Editor
{
    [CustomEditor(typeof(PlayerPopupHelper))]
    public sealed class PlayerPopupHelperEditor : UnityEditor.Editor
    {
        private SerializedProperty _currentLevel;
        private SerializedProperty _xpToAdd;
        private SerializedProperty _userName;
        private SerializedProperty _userDescription;
        private SerializedProperty _userIcon;
        private SerializedProperty _newStatName;
        private SerializedProperty _newStatValue;

        private void OnEnable()
        {
            _currentLevel = serializedObject.FindProperty("currentLevel");
            _xpToAdd = serializedObject.FindProperty("xpToAdd");
            _userName = serializedObject.FindProperty("userName");
            _userDescription = serializedObject.FindProperty("userDescription");
            _userIcon = serializedObject.FindProperty("userIcon");
            _newStatName = serializedObject.FindProperty("newStatName");
            _newStatValue = serializedObject.FindProperty("newStatValue");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            PlayerPopupHelper helper = (PlayerPopupHelper) target;
            
            if (GUILayout.Button("Show Popup"))
            {
                helper.ShowPopup();
            }
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            if (_currentLevel != null)
            {
                GUILayout.Label($"Current Level: {_currentLevel.intValue}");
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            }

            if (_xpToAdd != null)
            {
                EditorGUILayout.PropertyField(_xpToAdd, new GUIContent("Amount of XP to add"));
                if (GUILayout.Button($"Add {_xpToAdd.intValue} XP "))
                {
                   helper.AddXp();
                }
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            }
            
            GUILayout.Label("User Info");
            
            EditorGUILayout.PropertyField(_userName, new GUIContent("User name"));
            
            if (GUILayout.Button("Change User Name"))
            {
                helper.ChangeName();
            }
            
            EditorGUILayout.PropertyField(_userDescription, new GUIContent("Description"));
            
            if (GUILayout.Button("Change User Description"))
            {
                helper.ChangeUserDescription();
            }
            
            EditorGUILayout.PropertyField(_userIcon, new GUIContent("User Icon"));
            
            if (GUILayout.Button("Change User Icon"))
            {
                helper.ChangeUserIcon();
            }
            
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            for (var i = 0; i < helper.CharacterStats.Count; i++)
            {
                GUILayout.Label($"{helper.CharacterStats[i].Name}: {helper.CharacterStats[i].Value}");
                if (GUILayout.Button("Remove stat"))
                {
                    helper.RemoveStat(helper.CharacterStats[i]);
                }
            }
            
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            
            EditorGUILayout.PropertyField(_newStatName, new GUIContent("New stat name"));
            EditorGUILayout.PropertyField(_newStatValue, new GUIContent("New stat value"));
            
            if (GUILayout.Button("Add new stat"))
            {
                helper.AddNewStat();
            }
            
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
