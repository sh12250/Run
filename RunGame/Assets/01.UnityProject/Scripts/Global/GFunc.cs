using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // ���� : �̹� �ִ� �Լ��� ����ϱ� ���� �������ϴ� ��
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! Gameobject �޾Ƽ� Text ������Ʈ ã�Ƽ� text �ʵ� �� �����ϴ� �Լ�
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        // GetComponent<������Ʈ ��>() : ������ �ִ� ������Ʈ�� ã�´�
        // AddComponent<������Ʈ ��>() : ������Ʈ�� �߰����ش�
        if (textComponent == null || textComponent == default)
        {
            return;
        }

        textComponent.text = text;
    }

    //! LoadScene �Լ� ����
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //! e�� ���͸� ���Ѵ�
    public static Vector2 AddVectors(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    }
}
