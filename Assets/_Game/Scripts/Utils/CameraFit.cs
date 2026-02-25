using System.Collections;
using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(Camera))]
    public class CameraFit : MonoBehaviour
    {
        [Tooltip("Желаемая ширина в пикселях (например, 1080)")]
        public float targetWidth = 1080f;

        [Tooltip("Желаемая высота в пикселях (например, 1920)")]
        public float targetHeight = 1920f;

        public Color barsColor = Color.black; // Цвет полей

        private Camera cam;
        private CameraClearFlags originalClearFlags;

        void Start()
        {
            cam = GetComponent<Camera>();
            // Запоминаем исходные флаги, чтобы восстановить, если потребуется
            originalClearFlags = cam.clearFlags;

            StartCoroutine(AdjustViewport());
        }

        private IEnumerator AdjustViewport()
        {
/*            while (true)
            {*/
                yield return null;

                // Текущее соотношение сторон экрана (ширина / высота)
                float currentAspect = (float)Screen.width / Screen.height;
                // Целевое соотношение сторон нашей игры
                float targetAspect = targetWidth / targetHeight;

                // Если соотношения совпадают, растягиваем камеру на весь экран
                if (Mathf.Approximately(currentAspect, targetAspect))
                {
                    cam.rect = new Rect(0, 0, 1, 1);
                    cam.clearFlags = originalClearFlags;
                    yield break;
                }

                // Меняем режим очистки, чтобы фон камеры заливался цветом (поля)
                cam.clearFlags = CameraClearFlags.SolidColor;
                cam.backgroundColor = barsColor;

                // Вычисляем новый размер вьюпорта камеры
                if (currentAspect > targetAspect)
                {
                    // Экран шире, чем нужно -> поля будут слева и справа
                    float width = targetAspect / currentAspect;
                    cam.rect = new Rect((1f - width) / 2f, 0f, width, 1f);
                }
                else
                {
                    // Экран уже, чем нужно (или выше) -> поля будут сверху и снизу
                    float height = currentAspect / targetAspect;
                    cam.rect = new Rect(0f, (1f - height) / 2f, 1f, height);
                }
            //}
        }
    }
}