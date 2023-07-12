using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldTypeTest : MonoBehaviour
{
    public Image filledTypeImg;

    private void Awake()
    {
        // 0���� 1������ ��
        filledTypeImg.fillAmount = 1f;
    }

    void Start()
    {
        StartCoroutine(PassedCooltime(1f));
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        //if (filledTypeImg.fillAmount > 0)
        //{
        //    filledTypeImg.fillAmount -= (Time.deltaTime * 0.2f);
        //}
        //else if (filledTypeImg.fillAmount < 0)
        //{
        //    filledTypeImg.fillAmount = 0;
        //}
    }

    private IEnumerator PassedCooltime(float delay)
    {
        float cooltimePercent = 1f / 300f;

        while (filledTypeImg.fillAmount > 0)
        {
            // �̸�ŭ �ð��� �ɸ���
            yield return new WaitForSeconds(delay);

            // �ð��� ������ ������ ó���Ѵ�
            filledTypeImg.fillAmount -= cooltimePercent;
        }
    }
}
