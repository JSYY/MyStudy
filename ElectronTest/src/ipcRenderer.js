
var button = document.querySelector('#button');
button.onclick = function () {
    console.log("send notification");
    var option = {
        title: 'Test Message',
        body: 'This is a test Notification'
    };
    var myNotification = new window.Notification(option.title, option);
    // 给提示添加点击事件
    myNotification.onclick = function () {
        console.log('click');
    }
};