document.addEventListener(`DOMContentLoaded`, () => {
    const inputElement = document.getElementById("mass-food");
    if (!inputElement) return;

    const caloriesEl = document.getElementById("val-calories");
    const proteinEl = document.getElementById("val-protein");
    const fatEl = document.getElementById("val-fat");
    const carbsEl = document.getElementById("val-carbs");

    // Исходные значения на 100 грамм
    const baseCalories = Number(caloriesEl.dataset.baseVal) || 0;
    const baseProtein = Number(proteinEl.dataset.baseVal) || 0;
    const baseFat = Number(fatEl.dataset.baseVal) || 0;
    const baseCarbs = Number(carbsEl.dataset.baseVal) || 0;

    function updateValues() {
        const rawValue = inputElement.value.replace(',', '.');
        let mass = Number(rawValue);

        if (Number.isNaN(mass) || mass < 0) {
            mass = 0;
        }

        const ratio = mass / 100;

        caloriesEl.textContent = (baseCalories * ratio).toFixed(1);
        proteinEl.textContent = (baseProtein * ratio).toFixed(1);
        fatEl.textContent = (baseFat * ratio).toFixed(1);
        carbsEl.textContent = (baseCarbs * ratio).toFixed(1);
    }

    inputElement.addEventListener("input", updateValues);

    updateValues();
});