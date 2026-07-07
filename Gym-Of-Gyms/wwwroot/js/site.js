// site.js

function toggleMessage() {
    var msgBox = document.getElementById('jsMessage');

    if (msgBox.style.display === 'none' || msgBox.style.display === '') {
        var currentTime = new Date().toLocaleTimeString();
        msgBox.innerText = 'Привет из JavaScript! Текущее время: ' + currentTime;
        msgBox.style.display = 'block';
    }
    else {
        msgBox.style.display = 'none';
    }
}

document.addEventListener('DOMContentLoaded', function () {
    console.log('Страница загружена! JavaScript успешно подключен.');
});