using UnityEngine;

public class GameBoardButton : MonoBehaviour
{
    [SerializeField] private int btnIndex;
    [SerializeField] private Material red, blue, normal;
    public delegate void AnalyticsHandler();
    public static event AnalyticsHandler OnMiss, OnError, OnSuccess;
    private MeshRenderer _meshRenderer;
    [SerializeField] private float animationDuration = 0.5f;
    [SerializeField] private float animationDistance = 0.18f;
    private bool isActive = false;
    private bool isRed = false;
    private bool isAnimating = false;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        Material[] materials = _meshRenderer.materials;
        materials[0] = normal;
        _meshRenderer.materials = materials;
    }

    private void OnEnable()
    {
        GameBoardManager.OnBeep += RespondToBeep;
    }

    private void OnDisable()
    {
        GameBoardManager.OnBeep -= RespondToBeep;
    }

    private void RespondToBeep(int btnId, bool isRed)
    {
        if (btnId != btnIndex)
        {
            if (isActive) OnMiss?.Invoke();
            MakeBtnNormal();
        }
        else
        {
            isActive = true;
            Debug.Log($"{gameObject.name} is beeped");
            Material[] materials = _meshRenderer.materials;
            materials[0] = isRed ? red : blue;
            this.isRed = isRed;
            _meshRenderer.materials = materials;
        }
    }

    private void MakeBtnNormal()
    {
        Material[] materials = _meshRenderer.materials;
        materials[0] = normal;
        _meshRenderer.materials = materials;
        isActive = false;
        this.isRed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimateButtonPress());
        }
        if (isActive)
        {
            if (other.CompareTag("Red") && isRed) Success();
            else if (other.CompareTag("Red") && !isRed) Failed();
           else  if (other.CompareTag("Blue") && isRed) Failed();
           else  if (other.CompareTag("Blue") && !isRed) Success();
            MakeBtnNormal();
        }
        else
        {
            AudioManager.instance.PlaySource(3);
        }
    }

    private void Success()
    {
        AudioManager.instance.PlaySource(4);
        OnSuccess?.Invoke();
        
    }

    private void Failed()
    {
        AudioManager.instance.PlaySource(5);
        OnError?.Invoke();
    }

    private System.Collections.IEnumerator AnimateButtonPress()
    {
        isAnimating = true;
        Vector3 originalPosition = transform.localPosition;
        Vector3 targetPosition = originalPosition + new Vector3(0, 0, animationDistance);

        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure button returns to its original position even if animation is interrupted
        transform.localPosition = originalPosition;
        isAnimating = false;
    }
}
