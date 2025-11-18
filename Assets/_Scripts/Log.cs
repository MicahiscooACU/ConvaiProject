using Convai.Scripts.Runtime.Core;
using Service;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public class Log : MonoBehaviour
{
    public string fileName = "ConversationLog.txt";
    private StringBuilder _builder = new StringBuilder();

    private void OnEnable()
    {
        if (ConvaiGRPCAPI.Instance != null)
        {
            ConvaiGRPCAPI.Instance.OnResultReceived += HandleResult;
        }
        else
        {
            Debug.LogError("ConvaiGRPCAPI.Instance is null in OnEnable.");
        }
    }

    private void OnDisable()
    {
        if (ConvaiGRPCAPI.Instance != null)
        {
            ConvaiGRPCAPI.Instance.OnResultReceived -= HandleResult;
        }
    }

    private void HandleResult(GetResponseResponse response)
    {
        // Log finalized user query (speech input)
        if (response.UserQuery != null && response.UserQuery.IsFinal)
        {
            string playerText = response.UserQuery.TextData;
            AppendLine($"Player: {playerText}");
        }

        // Log character response
        if (response.AudioResponse != null && !string.IsNullOrEmpty(response.AudioResponse.TextData))
        {
            string characterText = response.AudioResponse.TextData;
            AppendLine($"Character: {characterText}");
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
