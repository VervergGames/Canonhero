﻿using UnityEditor;
using UnityEngine;
using System.Linq;

namespace Chronos
{
	[CustomEditor(typeof(Timeline)), CanEditMultipleObjects]
	public class TimelineEditor : Editor
	{
		protected SerializedProperty mode;
		protected SerializedProperty globalClockKey;
		protected SerializedProperty recordTransform;
		protected SerializedProperty recordingDuration;
		protected SerializedProperty recordingInterval;

		public void OnEnable()
		{
			mode = serializedObject.FindProperty("_mode");
			globalClockKey = serializedObject.FindProperty("_globalClockKey");
			recordTransform = serializedObject.FindProperty("_recordTransform");
			recordingDuration = serializedObject.FindProperty("_recordingDuration");
			recordingInterval = serializedObject.FindProperty("_recordingInterval");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(mode, new GUIContent("Mode"));

			if (!mode.hasMultipleDifferentValues)
			{
				if (mode.enumValueIndex == (int)TimelineMode.Local)
				{
					if (!serializedObject.isEditingMultipleObjects)
					{
						Timeline timeline = (Timeline)serializedObject.targetObject;

						LocalClock localClock = timeline.GetComponent<LocalClock>();

						if (localClock == null || !localClock.enabled)
						{
							EditorGUILayout.HelpBox("A local timeline requires a local clock.", MessageType.Error);
						}
					}
				}
				else if (mode.enumValueIndex == (int)TimelineMode.Global)
				{
					EditorGUILayout.PropertyField(globalClockKey, new GUIContent("Global Clock"));

					if (!globalClockKey.hasMultipleDifferentValues &&
						string.IsNullOrEmpty(globalClockKey.stringValue))
					{
						EditorGUILayout.HelpBox("A global timeline requires a global clock reference.", MessageType.Error);
					}
				}
				else
				{
					EditorGUILayout.HelpBox("Unsupported timeline mode.", MessageType.Error);
				}
			}

			EditorGUI.BeginDisabledGroup(Application.isPlaying);
			{
				EditorGUILayout.PropertyField(recordTransform, new GUIContent("Record Transform"));
				EditorGUILayout.PropertyField(recordingDuration, new GUIContent("Recording Duration"));
				EditorGUILayout.PropertyField(recordingInterval, new GUIContent("Recording Interval"));
			}
			EditorGUI.EndDisabledGroup();

			float estimate = serializedObject.targetObjects.OfType<Timeline>().Select(t => t.EstimateMemoryUsage()).Sum() / 1024;

			string summary;

			if (!recordingDuration.hasMultipleDifferentValues &&
				!recordingInterval.hasMultipleDifferentValues)
			{
				summary = string.Format("Rewind for up to {0:0.#} {1} at a {2:0.#} {3} per second precision.\n\nEstimated memory: {4} KiB.",
										recordingDuration.floatValue,
										recordingDuration.floatValue >= 2 ? "seconds" : "second",
										(1 / recordingInterval.floatValue),
										(1 / recordingInterval.floatValue) >= 2 ? "snapshots" : "snapshot",
										estimate);
			}
			else
			{
				summary = string.Format("Estimated memory: {0} KiB.", estimate);
			}

			EditorGUILayout.HelpBox(summary, MessageType.Info);

			if (!serializedObject.isEditingMultipleObjects &&
				Application.isPlaying)
			{
				Timeline timeline = (Timeline)serializedObject.targetObject;
				EditorGUILayout.LabelField("Computed Time Scale", timeline.timeScale.ToString("0.00"));
				EditorGUILayout.LabelField("Computed Time", timeline.time.ToString("0.00"));
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}
