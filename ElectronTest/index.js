//��������ģ�飺app �� BrowserWindow

//app ģ�飬��������Ӧ�ó�����¼��������ڡ�
//BrowserWindow ģ�飬�������͹������Ĵ��ڡ�

const { app, BrowserWindow } = require('electron')
const path = require('path')

const createWindow = () => {
    //����һ������
    const mainWindow = new BrowserWindow({
        width: 800,
        height: 600,
        show: true,
        frame: true, // �ޱ߿�
        skipTaskbar: false, // ʹ���ڲ���ʾ����������
        movable: false,  // ��ֹ���ڱ��û��ƶ�
        resizable: false, // ��ֹ�����ֶ��������ڴ�С
        fullscreenable: false, // ��ֹ���ڿ��Խ���ȫ��״̬
        alwaysOnTop: false, // �����Ƿ���Զ�ڱ�Ĵ��ڵ�����
        webPreferences: {
            preload: path.join(__dirname, 'preload.js')
        }
    });

    //����loadURL���߼���html
    //mainWindow.loadURL('http://localhost:8080');
    mainWindow.loadFile('./src/main.html');

    mainWindow.webContents.openDevTools();
    mainWindow.setMenu(null);

}

// ��γ��򽫻��� Electron ������ʼ��
// �ʹ�����������ڵ�ʱ�����
// ���� API �� ready �¼����������ʹ�á�
app.whenReady().then(() => {
    createWindow()
    app.on('activate', () => {
        // �� macOS ϵͳ��, ���û���ѿ�����Ӧ�ô���
        // �������ͼ��ʱͨ�������´���һ���´���
        if (BrowserWindow.getAllWindows().length === 0) createWindow()
    })
})

app.on('ready', async () => {
    //���ϵͳ֪ͨ����ʾ
    //���⻹��Ҫ�����ɵ�exe�����ݷ�ʽ���͵���ʼ�˵�
    //��Ҫ��windows10 ���Զ���֪ͨ�е� �����ⲿ֪ͨѡ���
    if (process.platform === "win32") {
        app.setAppUserModelId(process.execPath);
    }
})

// ���� macOS �⣬�����д��ڶ����رյ�ʱ���˳����� ���, ͨ��
// ��Ӧ�ó�������ǵĲ˵�����˵Ӧ��ʱ�̱��ּ���״̬, 
// ֱ���û�ʹ�� Cmd + Q ��ȷ�˳�
app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit()
})