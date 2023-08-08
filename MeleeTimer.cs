using Gear;
using TMPro;
using UnityEngine;

namespace MeleeTimer
{
    public class MeleeTimer : MonoBehaviour
    {
        public MeleeTimer() { }

        private CrosshairGuiLayer crosshairLayer = GuiManager.CrosshairLayer;

        public void Awake()
        {
            MeleeTimer.Instance = this;

            GameObject rootObject = new GameObject("MeleeTimer")
            {
                layer = 5,
                active = true
            };
            rootObject.transform.SetParent(crosshairLayer.m_circleCrosshair.transform, false);
            rootObject.transform.localPosition -= new Vector3 (0, 60, 0);

            GameObject textObject = new GameObject("Text")
            {
                layer = 5,
                active = true
            };
            textObject.transform.SetParent(rootObject.transform, false);

            this.TextMesh = null;
            this.TextMesh = textObject.AddComponent<TextMeshProUGUI>();
            this.TextMesh.alignment = TextAlignmentOptions.Center;
            this.TextMesh.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 50);
            this.TextMesh.text = string.Empty;
            this.TextMesh.fontSize = 20;
            this.TextMesh.font = GuiManager.PlayerLayer.m_playerStatus.m_healthText.font;
            this.TextMesh.color = new Color(0.7451f, 0.7451f, 0.7451f, 0.6784f);
        }

        public void Update()
        {
            if(ChargingFlag)
            {
                float duration = CU_Instance.m_weapon.MeleeAnimationData.AutoAttackTime - CU_Instance.m_elapsed;

                string text = $"{string.Format("{0:0.00}", duration)}s";
                this.TextMesh.text = text;
            }
        }

        public void OnExit()
        {
            this.TextMesh.text = string.Empty;
            ChargingFlag = false;
        }

        public void OnEnter()
        {
            this.TextMesh.text = string.Empty;
            ChargingFlag = true;
        }

        public static MeleeTimer Instance { get; set; }
        public TextMeshProUGUI TextMesh { get; set; }
        public MWS_ChargeUp CU_Instance { get; set; }
        public bool ChargingFlag { get; set; } 
    }
}