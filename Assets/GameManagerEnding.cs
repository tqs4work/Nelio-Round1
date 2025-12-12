using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerEnding : MonoBehaviour
{
    public GameObject sleep;
    public GameObject wake_up;
    public GameObject wake_up2;
    public GameObject hurry;
    public GameObject go_out;
    public GameObject clock;
    public GameObject end;

    public GameObject Title;
    public GameObject cauthoai;
    public GameObject THOAI_ENDING;


    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject hopthoai;
    [SerializeField] GameObject NextBttn;
    [SerializeField] int eventPos = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EventStarter());
        NextBttn.GetComponent<Button>().onClick.AddListener(NextButton);
    }

    // Update is called once per frame
    void Update()
    {
        textLength = TextCreator.charCount;
    }
    public void NextButton()
    {
        if (eventPos == 1)
        {
            StartCoroutine(EventOne());
        }
        else if (eventPos == 2)
        {
            StartCoroutine(EventTwo());
        }
        else if (eventPos == 3)
        {
            StartCoroutine(EventThree());
        }
        else if (eventPos == 4)
        {
            StartCoroutine(EventFour());
        }
        else if (eventPos == 5)
        {
            StartCoroutine(EventFive());
        }
        else if (eventPos == 6)
        {
            StartCoroutine(EventSix());
        }
        else if (eventPos == 7)
        {
            StartCoroutine(EventSeven());
        }
        else if (eventPos == 8)
        {
            StartCoroutine(EventEight());
        }
        else if (eventPos == 9)
        {
            StartCoroutine(EventNine());
        }
        else if (eventPos == 10)
        {
            StartCoroutine(EventTen());
        }
        else if (eventPos == 11)
        {
            StartCoroutine(EventEleven());
        }
        else if (eventPos == 12)
        {
            StartCoroutine(EventTwelve());
        }
        else if (eventPos == 13)
        {
            StartCoroutine(EventThirteen());
        }
        else if (eventPos == 14)
        {
            StartCoroutine(EventFourteen());
        }
        else if (eventPos == 15)
        {
            StartCoroutine(EventFifteen());
        }
        else if (eventPos == 16)
        {
            StartCoroutine(EventSixteen());
        }
        else if (eventPos == 17)
        {
            StartCoroutine(EventSeventeen());
        }
        else if (eventPos == 18)
        {
            StartCoroutine(EventEighteen());
        }
        else if (eventPos == 19)
        {
            StartCoroutine(EventNineteen());
        }
        else if (eventPos == 20)
        {
            StartCoroutine(EventTwenty());
        }
        else if (eventPos == 21)
        {
            StartCoroutine(EventTwenty_one());
        }
        else if (eventPos == 22)
        {
            StartCoroutine(EventTwenty_two());
        }
        else if (eventPos == 23)
        {
            StartCoroutine(EventTwenty_three());
        }
        else if (eventPos == 24)
        {
            StartCoroutine(EventTwenty_four());
        }
        else if (eventPos == 25)
        {
            StartCoroutine(EventTwenty_five());
        }
        else if (eventPos == 26)
        {
            StartCoroutine(EventTwenty_six());
        }
        else if (eventPos == 27)
        {
            StartCoroutine(EventTwenty_seven());
        }
        else if (eventPos == 28)
        {
            StartCoroutine(EventTwenty_eight());
        }
    }
    IEnumerator EventStarter()
    {
        sleep.SetActive(true);
        yield return new WaitForSeconds(1);
        cauthoai.SetActive(true);
        hopthoai.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Ánh sáng mờ buổi sớm len qua khung cửa kính.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 1;
    }
    IEnumerator EventOne()
    {
        NextBttn.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Chiếc đồng hồ cũ tích tắc trong căn phòng nhỏ, lặng lẽ như một người gác giấc mơ.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 2;
    }
    IEnumerator EventTwo()
    {
        NextBttn.SetActive(false);
        clock.SetActive(true);
        yield return new WaitForSeconds(1f);
        sleep.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Bỗng, tiếng chuông đồng hồ reo vang, đánh thức một ngày mới bắt đầu.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 3;
    }
    IEnumerator EventThree()
    {
        NextBttn.SetActive(false);
        clock.SetActive(false);
        wake_up.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "...Là... giấc mơ sao?";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 4;
    }
    IEnumerator EventFour()
    {
        NextBttn.SetActive(false);
        wake_up.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Mình đã ở một nơi... thật xa lạ.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 5;
    }
    IEnumerator EventFive()
    {
        NextBttn.SetActive(false);
        wake_up.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Đánh nhau với những quái vật... chạy trốn... rồi đứng lại...";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 6;
    }
    IEnumerator EventSix()
    {
        NextBttn.SetActive(false);
        wake_up.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Mỗi bước đi như lạc vào chính tâm trí của mình.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 7;
    }
    IEnumerator EventSeven()
    {
        NextBttn.SetActive(false);
        wake_up.SetActive(false);
        wake_up2.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Tất cả những nỗi sợ…";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 8;
    }
    IEnumerator EventEight()
    {
        NextBttn.SetActive(false);
        wake_up.SetActive(false);
        wake_up2.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Sợ không đủ giỏi.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 9;
    }
    IEnumerator EventNine()
    {
        NextBttn.SetActive(false);
        wake_up2.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Sợ không kiếm đủ tiền.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 10;
    }
    IEnumerator EventTen()
    {
        NextBttn.SetActive(false);
        wake_up.SetActive(false);
        wake_up2.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Sợ sẽ bị bỏ lại bởi công nghệ, bởi xã hội, bởi chính những người thân yêu…";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 11;
    }
    IEnumerator EventEleven()
    {
        NextBttn.SetActive(false);
        wake_up.SetActive(false);
        wake_up2.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Chúng chẳng đến từ đâu cả.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 12;
    }
    IEnumerator EventTwelve()
    {
        NextBttn.SetActive(false);
        wake_up.SetActive(false);
        wake_up2.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Chúng là... những câu chuyện do chính mình kể ra – rồi tin là thật.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 13;
    }
    IEnumerator EventThirteen()
    {
        NextBttn.SetActive(false);
        wake_up2.SetActive(false);
        hurry.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Mình đã chạy trốn đủ rồi.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 14;
    }
    IEnumerator EventFourteen()
    {
        NextBttn.SetActive(false);
        hurry.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Đã lo lắng đủ rồi.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 15;
    }
    IEnumerator EventFifteen()
    {
        NextBttn.SetActive(false);
        hurry.SetActive(false);
        go_out.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Giờ thì… đã đến lúc bước tiếp.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 16;
    }
    IEnumerator EventSixteen()
    {
        NextBttn.SetActive(false);
        go_out.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Không phải vì không còn sợ.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 17;
    }
    IEnumerator EventSeventeen()
    {
        NextBttn.SetActive(false);
        go_out.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Mà vì mình biết – sợ cũng chẳng giúp mình tiến lên.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 18;
    }
    IEnumerator EventEighteen()
    {
        NextBttn.SetActive(false);
        go_out.SetActive(false);
        cauthoai.SetActive(false);
        hopthoai.SetActive(false);
        Title.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Bạn đã đi qua...\n\nBóng tối của cô đơn.\n\nVực sâu của thất bại.\n\nCạm bẫy của thoải mái giả tạo\n\nVà áp lực của một tương lai không chắc chắn.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 19;
    }
    IEnumerator EventNineteen()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Bạn từng sợ bị bỏ lại.\n\nTừng nghĩ mình không đủ tốt, không đủ nhanh, không đủ mạnh.\n\nTừng để những giấc mơ của người khác định nghĩa con đường của mình.\n\nTừng chạy mải miết để không tụt lại – mà chẳng biết đang chạy về đâu.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 20;
    }
    IEnumerator EventTwenty()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);        
        textToSpeak = "Nhưng giờ đây, bạn hiểu:\n\nKhông ai có thể sống cuộc đời thay bạn.\n\nVà cũng chẳng có ai... thực sự đòi hỏi bạn phải là “hoàn hảo”.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 21;
    }
    IEnumerator EventTwenty_one()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Chuyến phiêu lưu đó, chỉ là một giấc mơ.\n\nNhưng bài học thì thật.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 22;
    }
    IEnumerator EventTwenty_two()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Nỗi sợ – không đến từ tương lai.\n\nNó đến từ chính tâm trí luôn lo lắng về tương lai.\n\nTừ ham muốn được công nhận, được an toàn, được yêu thương.\n\nVà càng cố vươn tới, ta càng dễ đánh mất chính mình.\n\n";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 23;
    }
    IEnumerator EventTwenty_three()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Nhưng nếu dám dừng lại, nhìn thẳng vào nỗi sợ…\n\nBạn sẽ thấy:\n\nBạn không cần phải đủ hết mọi thứ.\n\nBạn chỉ cần đủ can đảm để tiếp tục.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 24;
    }
    IEnumerator EventTwenty_four()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Bạn đứng dậy, đeo cặp lên vai.\n\nMột ngày mới đang chờ phía trước.\n\nKhông còn là chú mèo. Không còn là trò chơi.\n\nLà bạn – thật sự.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 25;
    }
    IEnumerator EventTwenty_five()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Vì cuối cùng, trưởng thành không phải là bỏ lại nỗi sợ.\n\nMà là học cách bước đi… dù vẫn còn sợ.\r\n";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 26;
    }
    IEnumerator EventTwenty_six()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Thế giới này không cần bạn là ai khác.\n\nChỉ cần bạn là chính mình – và tiếp tục bước tiếp";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 27;
    }
    IEnumerator EventTwenty_seven()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Cảm ơn bạn đã chơi game của tụi mình đến cuối cùng.\n\nMong là game mang đến cho bạn phút giây giải trí và những trải nghiệm thú vị.\n\nMột lần nữa cảm ơn bạn rất nhiều.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 28;
    }
    IEnumerator EventTwenty_eight()
    {
        NextBttn.SetActive(false);
        end.SetActive(true);
        THOAI_ENDING.SetActive(true);
        textToSpeak = "Lumora Rising Include:\n\nThái Quốc Sơn\n\nDương Thị Tuyết Trang\n\nLại Quang Huy";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        //NextBttn.SetActive(true);
        //eventPos = 28;
    }
}
