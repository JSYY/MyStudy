#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QCamera>
#include <QMediaDevices>
#include <QMediaCaptureSession>
#include <QImageCapture>
#include <QFileDialog>
#include <QMessageBox>
#include "pch.h"

QT_BEGIN_NAMESPACE
namespace Ui {
    class MainWindow;
}
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget* parent = nullptr);
    ~MainWindow();
    int currentIndex;
    QCamera* camera;
    QMediaCaptureSession* my_captureSession;
    QImageCapture* my_imageCapture;
    QList<QCameraDevice> camera_list;
    void getAllCamera();
    bool cameraState;
    QString saveFileAddress;

private slots:
    void cameraChanged(int index);

    void openCamera();

    void closeCamera();

    void on_actionSave_Address_triggered();

    void capture();

private:
    Ui::MainWindow* ui;
};
#endif // MAINWINDOW_H
