using UnityEngine;
using System.Collections;

using Assets.Scripts.RPGame.Core.Util;

namespace Assets.Scripts.RPGame.Core.UI
{
    public enum rpElemType
    {
        INVALID_TYPE = -1, LABEL, BUTTON, NUM_TYPES
    }
    public class rpUIElement : rpElement
    {
        // prefab references
        public Canvas canvas;
        Canvas _parentCanvas;
        public Canvas ParentCanvas
        {
            get { return _parentCanvas; }
            set { _parentCanvas = value; Parent = value.gameObject; }
        }

        // public variables
        public bool isEnabled = true;

        // transforfm accessors
        public RectTransform rectTransform
        {
            get { return ((RectTransform)transform); }
            set
            {
                ((RectTransform)transform).anchoredPosition = value.anchoredPosition;
                ((RectTransform)transform).anchoredPosition3D = value.anchoredPosition3D;
                ((RectTransform)transform).anchorMax = value.anchorMax;
                ((RectTransform)transform).anchorMin = value.anchorMin;
                ((RectTransform)transform).eulerAngles = value.eulerAngles;
                ((RectTransform)transform).forward = value.forward;
                ((RectTransform)transform).hasChanged = value.hasChanged;
                ((RectTransform)transform).hideFlags = value.hideFlags;
                ((RectTransform)transform).localEulerAngles = value.localEulerAngles;
                ((RectTransform)transform).localPosition = value.localPosition;
                ((RectTransform)transform).localRotation = value.localRotation;
                ((RectTransform)transform).localScale = value.localScale;
                ((RectTransform)transform).name = value.name;
                ((RectTransform)transform).offsetMax = value.offsetMax;
                ((RectTransform)transform).offsetMin = value.offsetMin;
                ((RectTransform)transform).parent = value.parent;
                ((RectTransform)transform).pivot = value.pivot;
                ((RectTransform)transform).position = value.position;
                ((RectTransform)transform).right = value.right;
                ((RectTransform)transform).rotation = value.rotation;
                ((RectTransform)transform).sizeDelta = value.sizeDelta;
                ((RectTransform)transform).tag = value.tag;
                ((RectTransform)transform).up = value.up;
            }
        }
        public Vector3 position
        {
            get { return rectTransform.position; }
            set { rectTransform.position = value; }
        }
        public Rect rect
        {
            get { return rectTransform.rect; }
            set { rectTransform.rect.Set(value.x, value.y, value.width, value.height); }
        }
        public Vector2 sizeDelta
        {
            get { return rectTransform.sizeDelta; }
            set { rectTransform.sizeDelta = new Vector2(value.x, value.y); }
        }

        public float x
        {
            get { return position.x; }
            set { position = new Vector3(value, y); }
        }
        public float y
        {
            get { return position.y; }
            set { position = new Vector3(x, value); }
        }
        public float width
        {
            get { return rect.width; }
            set { sizeDelta = new Vector2(value, height); }
        }
        public float height
        {
            get { return rect.height; }
            set { sizeDelta = new Vector2(width, value); }
        }

        public float left
        {
            get { return x - (width / 2); }
            set { x = value + (width / 2); }
        }
        public float right
        {
            get { return x + (width / 2); }
            set { x = value - (width) / 2; }
        }
        public float top
        {
            get { return y + (height / 2); }
            set { y = value - (height / 2); }
        }
        public float bottom
        {
            get { return y - (height / 2); }
            set { y = value + (height / 2); }
        }

        public Vector2 coordinates {
            get { return new Vector2(x, y); }
            set { x = value.x; y = value.y; }
        }
        public Vector2 anchor
        {
            get { return new Vector2(left, top); }
            set { left = value.x; top = value.y; }
        }
        public Vector2 size
        {
            get { return new Vector2(width, height); }
            set { width = value.x; height = value.y; }
        }

        // transform manipulators
        public void ResizeTo(float width, float height)
        {
            this.width = width;
            this.height = height;
        }
        public void ResizeTo(Vector2 size)
        {
            this.size = size;
        }
        public void ResizeTo(Vector3 size)
        {
            width = size.x; height = size.y;
        }
        public void MoveTo(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public void MoveTo(Vector2 position)
        {
            this.position = new Vector3(position.x, position.y);
        }
        public void MoveTo(Vector3 position)
        {
            this.position = position;
        }

        // class constructor
        public rpUIElement()
        {
            DBG.Log("Constructed");
        }
        
        // Class Initializers
        public override void Awake()
        {
            base.Awake();
        }
        public override void Start()
        {
            base.Start();
            Init();
        }
        void Init()
        {
            DBG.Log(this, "Initializing");
            //transform.localScale = new Vector3(1, 1, 1);
        }

        
    }
}
