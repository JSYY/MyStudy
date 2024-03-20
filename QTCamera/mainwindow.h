#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QCamera>
#include <QMediaDevices>
#include <QMediaCaptureSession>
#include <QImageCapture>
#include <QFileDialog>
#include <QMessageBox>

QT_BEGIN_NAMESPACE
namespace Ui {
class MainWindow;
}
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    QCamera *my_camera;
    QMediaCaptureSession *my_captureSession;
    QImageCapture *my_imageCapture;
    QList<QCameraDevice> camera_list;
    void getAllCamera();
    bool cameraState;
    QString saveFileAddress;

private slots:
    void on_comboBox_currentIndexChanged(int index);

    void on_open_clicked();

    void on_close_clicked();

    void on_actionSave_Address_triggered();

    void on_open_2_clicked();

private:
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
