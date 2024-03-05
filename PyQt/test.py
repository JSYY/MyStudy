import sys
from PyQt5.QtWidgets import QApplication,QMainWindow,QAction,qApp,QLCDNumber, QDial
from PyQt5.QtGui import QIcon

class App(QMainWindow):

    def __init__(self):
        super().__init__()
        self.title = 'PyQt5 Test'
        self.left = 10
        self.top = 10
        self.width = 640
        self.height = 480
        self.initUI()
        
    def initUI(self):
        self.setWindowTitle(self.title)
        self.statusBar().showMessage('准备就绪')
        self.setGeometry(self.left, self.top, self.width, self.height)

        lcd = QLCDNumber(self)
        dial = QDial(self)

        lcd.setGeometry(100,50,150,60)
        dial.setGeometry(120,120,100,100)

        exitAct = QAction(QIcon(), '退出(&E)', self)
        exitAct.setShortcut('Ctrl+Q')
        exitAct.setStatusTip('退出程序')
        exitAct.triggered.connect(qApp.quit)

        menubar = self.menuBar()
        fileMenu = menubar.addMenu('文件(&F)')
        fileMenu.addAction(exitAct)

        dial.valueChanged.connect(lcd.display)
        self.show()
    
if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = App()
    sys.exit(app.exec_())
