document.addEventListener(`DOMContentLoaded`, () => {
    const timeSpan = document.getElementById("eating-time");

    const timeNow = new Date();
    const hours = String(timeNow.getHours()).padStart(2, '0');
    const minutes = String(timeNow.getMinutes()).padStart(2, '0');;

    timeSpan.value = `${hours}:${minutes}`;
});

document.addEventListener(`DOMContentLoaded`, () => {
    const timeInput = document.getElementById("eating-time");
    const eatingNameInput = document.getElementById("eating-name");

    function getMealName(hours) {
        if (hours > 4 && hours <= 11) return "Завтрак";
        else if (hours > 11 && hours <= 13) return "Полдник";
        else if (hours > 13 && hours <= 16) return "Обед";
        else if (hours > 16 && hours <= 23) return "Ужин";
        return "Ночной ужин";
    }

    function updateMealName() {
        if (!timeInput.value) return;

        const hoursStr = timeInput.value.split(':');
        const hours = parseInt(hoursStr, 10);

        if (!isNaN(hours)) {
            eatingNameInput.value = getMealName(hours);
        }
    }

    const timeNow = new Date();
    const hours = String(timeNow.getHours()).padStart(2, '0');
    const minutes = String(timeNow.getMinutes()).padStart(2, '0');
    timeInput.value = `${hours}:${minutes}`;

    updateMealName();

    timeInput.addEventListener('input', updateMealName);
});