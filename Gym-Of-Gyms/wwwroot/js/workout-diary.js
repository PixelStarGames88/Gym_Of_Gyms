document.addEventListener('DOMContentLoaded', () => {
    initExerciseCards();
});

function initExerciseCards() {
    document.querySelectorAll('.exercise-card').forEach(card => {
        updateSetsCount(card);
    });
}

function toggleCard(buttonElement) {
    
    const container = buttonElement.closest('.exercise-container');
    if (!container) return;


    const card = container.querySelector('.exercise-card');
    if (!card) return;


    const isHidden = card.style.display === 'none';
    card.style.display = isHidden ? 'block' : 'none';


    buttonElement.textContent = isHidden ? '▼' : '►';
}
//*
// 2. Добавление нового подхода в таблицу
function addSet(buttonElement) {
    const card = buttonElement.closest('.exercise-card');
    const tbody = card.querySelector('#sets-list');

    // Считаем текущее количество строк для номера
    const setNumber = tbody.querySelectorAll('tr').length + 1;

    // Создаем новую строку
    const newRow = document.createElement('tr');
    newRow.innerHTML = `
        <td>${setNumber}</td>
        <td><input type="number" class="styled-input inp-reps" min="0" placeholder="0" /></td>
        <td><input type="number" class="styled-input inp-weight" min="0" step="0.5" placeholder="0" /></td>
        <td><input type="time" class="styled-input time-input inp-start" /></td>
        <td><input type="time" class="styled-input time-input inp-end" /></td>
        <td><button type="button" class="btn-custom" onclick="removeSet(this)">X</button></td>
    `;

    tbody.appendChild(newRow);
    updateSetsCount(card);
}
//*/

// 3. Удаление подхода
function removeSet(buttonElement) {
    const row = buttonElement.closest('tr');
    const card = buttonElement.closest('.exercise-card');
    const tbody = row.parentElement;

    row.remove();

    Array.from(tbody.querySelectorAll('tr')).forEach((tr, index) => {
        tr.cells[0].textContent = index + 1;
    });

    updateSetsCount(card);
    updateExerciseTime(card);
}

// 4. Вспомогательная функция обновления счетчика
function updateSetsCount(cardElement) {
    const container = cardElement.closest('.exercise-container');
    if (!container) return;

    const countSpan = container.querySelector('.sets-count');
    const totalSets = cardElement.querySelectorAll('#sets-list tr').length;

    if (countSpan) {
        countSpan.textContent = `Подходов: ${totalSets}`;
    }
}

// Функция добавления нового блока упражнения
function addExercise() {
    // Находим родительский контейнер, куда складываются все упражнения
    const mainContainer = document.querySelector('.container-main');
    const addExerciseBtn = mainContainer.querySelector('button[onclick="addExercise()"]');

    // Создаем новый контейнер упражнения
    const exerciseContainer = document.createElement('div');
    exerciseContainer.className = 'exercise-container';

    // Задаем внутреннюю HTML-структуру карточки
    exerciseContainer.innerHTML = `
        <div class="exercise-container">
            <div class="exercise-header">
                <input type="text" class="exercise-title styled-input" placeholder="Название упражнения..." />
                <div class="exercise-info">
                    <span class="exercise-time"></span>
                    <span class="sets-count">Подходов: 1</span>
                    <button type="button" class="btn-toggle" onclick="toggleCard(this)">▼</button>
                </div>
            </div>
            <div class="exercise-card">
                    <table class="form-table">
                        <colgroup>
                            <col style="width: 70px;">
                            <col style="width: 20%;">
                            <col style="width: 20%;">
                            <col style="width: 20%;">
                            <col style="width: 20%;">
                            <col style="width: 90px;">
                        </colgroup>
                        <thead>
                                <tr>
                                <th>№</th>
                                <th>Повторения</th>
                                <th>Вес (кг)</th>
                                <th>Старт</th>
                                <th>Конец</th>
                                <th></th>
                            </tr>
                        </thead>
                    <tbody id="sets-list">
                        <tr>
                            <td><label for="Number">1</label></td>
                            <td><input type="number" class="styled-input inp-reps" min="0" placeholder="0" /></td>
                            <td><input type="number" class="styled-input inp-weight" min="0" step="0.5" placeholder="0" /></td>
                            <td><input type="time" class="styled-input time-input inp-start" /></td>
                            <td><input type="time" class="styled-input time-input inp-end" /></td>
                            <td></td>
                        </tr>
                    </table>
                <button type="button" class="btn-custom" onclick="addSet(this)">Добавить подход</button>
                <button type="button" class="btn-custom btn-delete-exercise" onclick="removeExercise(this)" style="background-color: #8b0000; margin-left: 10px;">Удалить упражнение</button>
            </div>
        </div>
    `;

    mainContainer.insertBefore(exerciseContainer, addExerciseBtn);
}

function removeExercise(buttonElement) {
    const container = buttonElement.closest('.exercise-container');
    if (container) {
        container.remove();
    }
}

let currentDate = new Date();

document.addEventListener('DOMContentLoaded', () => {
    updateDateDisplay();

    const navButtons = document.querySelectorAll('.date-navigator .btn-custom');
    if (navButtons.length >= 2) {
        navButtons[0].addEventListener('click', () => changeDate(-1)); // Вчера
        navButtons[1].addEventListener('click', () => changeDate(1));  // Завтра
    }
});

function updateDateDisplay() {
    const dateHeader = document.getElementById('currentDate');
    if (!dateHeader) return;

    const options = { weekday: 'long', day: 'numeric', month: 'long', year: 'numeric' };
    let formattedDate = currentDate.toLocaleDateString('ru-RU', options);

    formattedDate = formattedDate.charAt(0).toUpperCase() + formattedDate.slice(1);

    dateHeader.textContent = formattedDate;
}

function changeDate(days) {
    currentDate.setDate(currentDate.getDate() + days);
    updateDateDisplay();
}

// 1. Функция обновления времени в шапке карточки
function updateExerciseTime(cardElement) {
    const container = cardElement.closest('.exercise-container');
    if (!container) return;

    const timeSpan = container.querySelector('.exercise-time');
    if (!timeSpan) return;


    const startInputs = Array.from(cardElement.querySelectorAll('.inp-start')).map(i => i.value).filter(Boolean);
    const endInputs = Array.from(cardElement.querySelectorAll('.inp-end')).map(i => i.value).filter(Boolean);

    if (startInputs.length === 0 && endInputs.length === 0) {
        timeSpan.textContent = '';
        timeSpan.classList.remove('visible');
        return;
    }

    const minStart = startInputs.length > 0 ? startInputs.sort()[0] : '--:--';
    const maxEnd = endInputs.length > 0 ? endInputs.sort().reverse()[0] : '--:--';

    timeSpan.textContent = `${minStart} - ${maxEnd}`;
    timeSpan.classList.add('visible');
}

document.addEventListener('input', (event) => {
    if (event.target.classList.contains('time-input')) {
        const card = event.target.closest('.exercise-card');
        if (card) {
            updateExerciseTime(card);
        }
    }
});