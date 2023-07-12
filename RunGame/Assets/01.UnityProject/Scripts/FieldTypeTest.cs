using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldTypeTest : MonoBehaviour
{
    public Image filledTypeImg;

    private void Awake()
    {
        // 0에서 1사이의 값
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
            // 이만큼 시간이 걸린다
            yield return new WaitForSeconds(delay);

            // 시간이 지나간 다음에 처리한다
            filledTypeImg.fillAmount -= cooltimePercent;
        }
    }
}
