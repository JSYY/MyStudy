//引入两个模块：app 和 BrowserWindow

//app 模块，控制整个应用程序的事件生命周期。
//BrowserWindow 模块，它创建和管理程序的窗口。

const { app, BrowserWindow } = require('electron')
const path = require('path')

const createWindow = () => {
    //创建一个窗口
    const mainWindow = new BrowserWindow({
        width: 800,
        height: 600,
        show: true,
        frame: true, // 无边框
        skipTaskbar: false, // 使窗口不显示在任务栏中
        movable: false,  // 禁止窗口被用户移动
        resizable: false, // 禁止窗口手动调整窗口大小
        fullscreenable: false, // 禁止窗口可以进入全屏状态
        alwaysOnTop: false, // 窗口是否永远在别的窗口的上面
        webPreferences: {
            preload: path.join(__dirname, 'preload.js')
        }
    });

    //窗口loadURL或者加载html
    //mainWindow.loadURL('http://localhost:8080');
    mainWindow.loadFile('./src/main.html');

    mainWindow.webContents.openDevTools();
    mainWindow.setMenu(null);

}

// 这段程序将会在 Electron 结束初始化
// 和创建浏览器窗口的时候调用
// 部分 API 在 ready 事件触发后才能使用。
app.whenReady().then(() => {
    createWindow()
    app.on('activate', () => {
        // 在 macOS 系统内, 如果没有已开启的应用窗口
        // 点击托盘图标时通常会重新创建一个新窗口
        if (BrowserWindow.getAllWindows().length === 0) createWindow()
    })
})

app.on('ready', async () => {
    //解决系统通知不显示
    //此外还需要把生成的exe程序快捷方式发送到开始菜单
    //需要将windows10 的自定义通知中的 允许外部通知选项开放
    if (process.platform === "win32") {
        app.setAppUserModelId(process.execPath);
    }
})

// 除了 macOS 外，当所有窗口都被关闭的时候退出程序。 因此, 通常
// 对应用程序和它们的菜单栏来说应该时刻保持激活状态, 
// 直到用户使用 Cmd + Q 明确退出
app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit()
})