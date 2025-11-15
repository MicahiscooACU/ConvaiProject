using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using Convai.Scripts.Runtime.UI;
using Convai.Scripts.Runtime.Core;
using Service;

public class Log : MonoBehaviour
{
    public string fileName = "ConversationLog.txt";
    private StringBuilder _builder = new StringBuilder();

    private void Start()
    {
        if (ConvaiGRPCAPI.Instance != null)
        {
            ConvaiGRPCAPI.Instance.OnResultReceived += HandleResult;
        }
        else
        {
            Debug.LogError("ConvaiGRPCAPI.Instance is null");
        }
    }

    private void OnDestroy()
    {
        if (ConvaiGRPCAPI.Instance != null)
        {
            ConvaiGRPCAPI.Instance.OnResultReceived -= HandleResult;
        }
    }

    private void HandleResult(GetResponseResponse response)
    {
        // Player text
        if (response.UserQuery != null)
        {
            string text = response.UserQuery.TextData;
            AppendLine($"Player: {text}");
        }

        // Character text
        if (response.AudioResponse != null)
        {
            string text = response.AudioResponse.TextData;
            AppendLine($"Character: {text}");
        }
    }

    private void AppendLine(string line)
    {
        _builder.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {line}");
    }

    public void SaveToFile()
    {
        try
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string baseName = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            string fileWithTime = $"{baseName}_{timestamp}{ext}";

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(desktopPath, fileWithTime);

            File.WriteAllText(fullPath, _builder.ToString());
            Debug.Log($"Conversation saved to: {fullPath}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to save conversation file: {ex}");
        }
    }
}