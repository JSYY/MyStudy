
var button = document.querySelector('#button');
button.onclick = function () {
    console.log("send notification");
    var option = {
        title: 'Test Message',
        body: 'This is a test Notification'
    };
    var myNotification = new window.Notification(option.title, option);
    // ����ʾ��ӵ���¼�
    myNotification.onclick = function () {
        console.log('click');
    }
};
const setButton = document.getElementById('btn')
const titleInput = document.getElementById('title')
setButton.addEventListener('click', () => {
    const title = titleInput.value
    window.electronAPI.setTitle(title)
})