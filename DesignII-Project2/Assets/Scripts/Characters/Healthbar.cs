using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    private GenericPlayerChar _character;
    private Slider _healthSlider;
    [SerializeField] private Slider _sliderPrefab;
    [SerializeField] private bool _isEnemy = false;

    // Use this for initialization
    void Start () {
        _character = gameObject.GetComponent<GenericPlayerChar>();
        if (!_isEnemy)
        {
            _healthSlider = Instantiate(_sliderPrefab, transform.position + new Vector3(-1.4f, 2, 0), Quaternion.identity);
        }
        else
        {
            _healthSlider = Instantiate(_sliderPrefab, transform.position + new Vector3(4.4f, 2, 0), Quaternion.identity);
        }
        _healthSlider.transform.parent = GameObject.Find("Canvas").transform;
        _healthSlider.value = gameObject.GetComponent<GenericPlayerChar>().health / 100;
    }

    void Update()
    {
        float hpPercent = ((float)gameObject.GetComponent<GenericPlayerChar>().health / gameObject.GetComponent<GenericPlayerChar>().maxHealth) * 100;
        _healthSlider.value = hpPercent;
    }

    private void OnDisable()
    {
        //_healthText.text = "";
    }
}
