using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    private GenericPlayerChar _character;
    //private Text _healthText;
    private Slider _healthSlider;
    //[SerializeField] private Text _textPrefab;
    [SerializeField] private Slider _sliderPrefab;
    [SerializeField] private bool _isEnemy = false;

    // Use this for initialization
    void Start () {
        _character = gameObject.GetComponent<GenericPlayerChar>();
        if (!_isEnemy)
        {
            //_healthText = Instantiate(_textPrefab, transform.position + new Vector3(-1.4f, 2, 0), Quaternion.identity);
            _healthSlider = Instantiate(_sliderPrefab, transform.position + new Vector3(-1.4f, 2, 0), Quaternion.identity);
        }
        else
        {
            //_healthText = Instantiate(_textPrefab, transform.position + new Vector3(1.4f, 2, 0), Quaternion.identity);
            _healthSlider = Instantiate(_sliderPrefab, transform.position + new Vector3(1.4f, 2, 0), Quaternion.identity);
        }
        //_healthText.transform.parent = GameObject.Find("Canvas").transform;
        //_healthText.text = gameObject.GetComponent<GenericPlayerChar>().health.ToString();
        _healthSlider.transform.parent = GameObject.Find("Canvas").transform;
        _healthSlider.value = gameObject.GetComponent<GenericPlayerChar>().health / 100;
    }

    // Update is called once per frame
    void Update()
    {
        //_healthText.text = gameObject.GetComponent<GenericPlayerChar>().health.ToString();
        _healthSlider.value = gameObject.GetComponent<GenericPlayerChar>().health / 100;
    }

    private void OnDisable()
    {
        //_healthText.text = "";
    }
}
