document.addEventListener('DOMContentLoaded', function () {
    const imagePanel = document.getElementById('imagePanel');
    const infoPanel = document.getElementById('infoPanel');
    const infoContent = document.getElementById('infoContent');

    const initialImageHeight = 40;
    const initialInfoHeight = 60;
    const minImageHeight = 10;
    const maxInfoHeight = 90;

    let isLocked = false;

    // Текущие и целевые значения для плавной анимации
    let currentImageHeight = initialImageHeight;
    let currentInfoHeight = initialInfoHeight;
    let targetImageHeight = initialImageHeight;
    let targetInfoHeight = initialInfoHeight;

    const lerpFactor = 0.1; // Коэффициент плавности (0.1 - очень плавно, 0.3 - быстрее)

    document.body.style.overflow = 'hidden';

    // Функция линейной интерполяции
    function lerp(start, end, factor) {
        return start + (end - start) * factor;
    }

    // Функция обновления целевых значений
    function updateTargets(delta) {
        const scrollSpeed = 0.1;

        let newImageHeight = targetImageHeight - (delta * scrollSpeed);
        let newInfoHeight = targetInfoHeight + (delta * scrollSpeed);

        newImageHeight = Math.max(minImageHeight, Math.min(initialImageHeight, newImageHeight));
        newInfoHeight = Math.max(initialInfoHeight, Math.min(maxInfoHeight, newInfoHeight));

        if (newImageHeight === minImageHeight && newInfoHeight === maxInfoHeight) {
            isLocked = true;
        } else if (newImageHeight === initialImageHeight && newInfoHeight === initialInfoHeight) {
            isLocked = false;
            infoContent.scrollTop = 0;
        }

        targetImageHeight = newImageHeight;
        targetInfoHeight = newInfoHeight;
    }

    // Анимационный цикл
    function animate() {
        // Плавная интерполяция текущих значений к целевым
        currentImageHeight = lerp(currentImageHeight, targetImageHeight, lerpFactor);
        currentInfoHeight = lerp(currentInfoHeight, targetInfoHeight, lerpFactor);

        // Применяем изменения
        imagePanel.style.height = currentImageHeight + 'vh';
        imagePanel.style.top = '0';

        infoPanel.style.height = currentInfoHeight + 'vh';
        infoPanel.style.top = currentImageHeight + 'vh';

        requestAnimationFrame(animate);
    }

    // Запускаем анимационный цикл
    requestAnimationFrame(animate);

    // Обработчик колеса мыши
    window.addEventListener('wheel', function (e) {
        e.preventDefault();

        if (isLocked) {
            if (infoContent.scrollTop <= 0 && e.deltaY < 0) {
                isLocked = false;
                infoContent.scrollTop = 0;
                updateTargets(e.deltaY);
                return;
            }
            infoContent.scrollTop += e.deltaY;
            return;
        }

        updateTargets(e.deltaY);

    }, { passive: false });

    // Поддержка сенсорных экранов
    let touchStartY = 0;

    window.addEventListener('touchstart', function (e) {
        touchStartY = e.touches[0].clientY;
    }, { passive: false });

    window.addEventListener('touchmove', function (e) {
        e.preventDefault();

        const touchY = e.touches[0].clientY;
        const delta = touchStartY - touchY;
        touchStartY = touchY;

        if (isLocked) {
            if (infoContent.scrollTop <= 0 && delta < 0) {
                isLocked = false;
                infoContent.scrollTop = 0;
                updateTargets(delta);
                return;
            }
            infoContent.scrollTop += delta;
            return;
        }

        updateTargets(delta);

    }, { passive: false });
});