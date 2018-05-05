using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{

    public enum ComputerState
    {
        DESKTOP,
        EMAIL,
        BROWSER,
        GAME
    };

    [System.Serializable]
    public struct emailData
    {
        public string subject;
        public string message;
        public string reply;
        public Sprite avatar;
        public string sender;
    }

    public ComputerState activeState;
    public List<Button> desktopButtons = new List<Button>();
    public List<emailData> emails = new List<emailData>();
    public Dictionary<string, emailData> activeEmails = new Dictionary<string, emailData>();
    public List<EmailObject> emailObjects = new List<EmailObject>();
    public List<Button> emailButtons = new List<Button>();
    public List<Text> emailSubjects = new List<Text>();
    public bool positiveAction;
    public Fungus.Flowchart flowChart;
    int activeEmailIndex;

    bool emailReplyActive = false;

    public GameObject errorMessageDisplay;

    public GameObject EmailDisplay;
    public Image senderAvatar;
    public Text senderText;
    public Text subjectText;
    public Vector2 emailObjectOffset;
    public Vector2 emailSpaceBuffer;
    public Text messageTextField;
    public Text replyTextField;
    public Button replyButton;
    public Button sendButton;
    public bool canExitEmail = true;
    public int numEmails;
    public int charPerStroke;

    int replyIndex;

    public bool emailActive;
    public bool gameActive;
    public bool browserActive;





    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (activeState)
        {
            case ComputerState.EMAIL:
                if (emailReplyActive)
                {
                    if (Input.anyKeyDown)
                    {
                        for (int i = 0; i < charPerStroke; i++)
                        {
                            if (replyIndex < emailObjects[activeEmailIndex].replyText.Length)
                            {
                                replyTextField.text += emailObjects[activeEmailIndex].replyText[replyIndex];
                                replyIndex++;
                            }
                            else
                            {
                                //end message, enable reply button.
                                sendButton.interactable = true;
                                break;
                            }
                        }
                    }
                }
                break;
        }
    }

    public void ChangeState(string state)
    {
        switch (state)
        {
            case "Email":
                if (emailActive)
                {
                    activeState = ComputerState.EMAIL;
                    EmailDisplay.SetActive(true);
                    canExitEmail = !positiveAction;
                    emailObjects.Clear();
                    activeEmails.Clear();
                    for (int i = 0; i < numEmails; i++)
                    {
                        while (true)
                        {

                            int rand = Random.Range(0, emails.Count);
                            if (!activeEmails.ContainsKey(emails[rand].subject))
                            {

                                EmailObject e = new EmailObject();
                                e.Init(emails[rand].subject, emails[rand].message, emails[rand].reply, emails[rand].sender, i, emails[rand].avatar, this);
                                emailObjects.Add(e);
                                emailSubjects[i].text = emails[rand].sender +": " + emails[rand].subject;
                                emailButtons[i].gameObject.SetActive(true);
                                activeEmails.Add(emails[rand].subject, emails[rand]);
                                break;
                            }


                        }
                    }
                }
                else
                {
                    errorMessageDisplay.SetActive(true);
                    for (int i = 0; i < desktopButtons.Count; i++)
                    {
                        desktopButtons[i].interactable = false;
                    }
                }
                break;
            case "Desktop":
                if (activeState == ComputerState.EMAIL)
                {
                    if (canExitEmail)
                    {
                        activeState = ComputerState.DESKTOP;
                        EmailDisplay.SetActive(false);
                        ExitGame();
                    }
                    else
                    {
                        //trigger unfinished text.
                    }
                }
                else
                {
                    activeState = ComputerState.DESKTOP;
                }
                break;
            case "Game":
                if (gameActive)
                {
                    activeState = ComputerState.GAME;
                }
                else
                {
                    errorMessageDisplay.SetActive(true);
                    for(int i = 0; i < desktopButtons.Count; i++)
                    {
                        desktopButtons[i].interactable = false;
                    }
                }
                break;
            case "Browser":
                if (browserActive)
                {
                    activeState = ComputerState.BROWSER;
                }
                else
                {
                    errorMessageDisplay.SetActive(true);
                    for (int i = 0; i < desktopButtons.Count; i++)
                    {
                        desktopButtons[i].interactable = false;
                    }
                }
                break;
            case "Exit":
                //leave scene.
                break;
        }
    }

    public void StartReply()
    {
        emailReplyActive = true;
        replyIndex = 0;
        replyTextField.gameObject.SetActive(true);
        replyTextField.text = "";
        replyButton.interactable = false;
        replyButton.gameObject.SetActive(false);
        sendButton.gameObject.SetActive(true);
        sendButton.interactable = false;
        canExitEmail = false;

    }

    public void SetActiveMessage(int i)
    {
        if (!emailReplyActive)
        {
            activeEmailIndex = i;
            messageTextField.text = emailObjects[activeEmailIndex].message;
            senderAvatar.sprite = emailObjects[activeEmailIndex].avatar;
            replyButton.interactable = !emailObjects[activeEmailIndex].replied;
            replyButton.gameObject.SetActive(!emailObjects[activeEmailIndex].replied && positiveAction);
            replyTextField.text = emailObjects[activeEmailIndex].replied ? emailObjects[activeEmailIndex].replyText : "";
            senderText.text = "From: " + emailObjects[activeEmailIndex].sender;
            subjectText.text = "Subject: " + emailObjects[activeEmailIndex].subject;
        }
    }

    public void SendMessage()
    {
        sendButton.interactable = false;
        sendButton.gameObject.SetActive(false);
        //replyButton.gameObject.SetActive(true);
        emailObjects[activeEmailIndex].replied = true;
        emailReplyActive = false;

        for (int i = 0; i < emailObjects.Count; i++)
        {
            if (!emailObjects[i].replied)
                return;
        }

        canExitEmail = true;
    }

    public void CloseErrorMessage()
    {

        errorMessageDisplay.SetActive(false);
        for (int i = 0; i < desktopButtons.Count; i++)
        {
            desktopButtons[i].interactable = true;
        }
        
    }

    public void ExitGame()
    {
        flowChart.ExecuteIfHasBlock("EndBlock");
    }

    public void SetPositiveFlag(bool pos)
    {
        positiveAction = pos;
    }
}
