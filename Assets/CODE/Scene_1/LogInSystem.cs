using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PimDeWitte.UnityMainThreadDispatcher;
using UnityEngine.EventSystems;



public class LogInSystem : MonoBehaviour
{
    [SerializeField] GameObject LoginPanner;
    [SerializeField] GameObject SignInPanner;

    OpeningManager openingManager;
    Button loginBtn;
    Button signUpBtn;

    Animator signUpBtnAnim;

    [SerializeField]
    TMP_InputField emailField;
    [SerializeField]
    TMP_InputField passwardField;

    TMP_Text loginErrorText;
    TMP_Text sinUpErrorText;

    TMP_InputField signinEmailField;
    TMP_InputField signinPasswardField;

    Button createBtn;
    Button backBtn;
    Button exitBtn;


    Animator signUpCompleteAnim;

    private void Awake()
    {
      
       
        openingManager = GetComponent<OpeningManager>();

       

        signUpBtn = LoginPanner.transform.Find("SignIn/Button").GetComponent<Button>();
        signUpBtnAnim = signUpBtn.transform.parent.GetComponent<Animator>();

        emailField = LoginPanner.transform.Find("InputEmail").GetComponent<TMP_InputField>();

        passwardField = LoginPanner.transform.Find("InputPW").GetComponent<TMP_InputField>();
        loginBtn = LoginPanner.transform.Find("LoginBtn/Button").GetComponent<Button>();
        loginErrorText = LoginPanner.transform.Find("ErrorText").GetComponent<TMP_Text>();
        exitBtn = LoginPanner.transform.Find("ExitBtn/Button").GetComponent<Button>();
        exitBtn.onClick.AddListener(() => { Application.Quit(); });

        backBtn = SignInPanner.transform.Find("BackBtn/Button").GetComponent<Button>();
        

        signinEmailField = SignInPanner.transform.Find("InputField_Email").GetComponent<TMP_InputField>();
        signinPasswardField = SignInPanner.transform.Find("InputField_Passward").GetComponent<TMP_InputField>();
        createBtn = SignInPanner.transform.Find("CreateBtn/Button").GetComponent<Button>();
        sinUpErrorText = SignInPanner.transform.Find("ErrorText").GetComponent<TMP_Text>();
        signUpCompleteAnim = LoginPanner.transform.parent.Find("SignUpComplete").GetComponent<Animator>();

    }
    void Start()
    {

        signUpBtn.onClick.AddListener(() =>
        {
            SoundManager.inst.F_Get_SoundPreFabs_PlaySFX(3, 1);
            emailField.text = string.Empty;
            passwardField.text = string.Empty;
            signUpBtnAnim.SetTrigger("Off");
            LoginPanner.SetActive(false);
            SignInPanner.SetActive(true);
            signinEmailField.Select();
            signinEmailField.ActivateInputField();
        });


        backBtn.onClick.AddListener(() =>
        {
            SoundManager.inst.F_Get_SoundPreFabs_PlaySFX(3, 1);
            signinEmailField.text = string.Empty;
            signinPasswardField.text = string.Empty;

            LoginPanner.SetActive(true);
            SignInPanner.SetActive(false);
            emailField.Select();
            emailField.ActivateInputField();
        });





    }

     
}
