#include "MyQtApplicationOfCamera.h"
#include "ui_MyQtApplicationOfCamera.h"

MainWindow::MainWindow(QWidget* parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    getAllCamera();
    saveFileAddress = QDir::currentPath();
    qDebug() << saveFileAddress;
    cameraState = false;

    connect(ui->open, &QPushButton::clicked, this, &MainWindow::openCamera);
    connect(ui->close, &QPushButton::clicked, this, &MainWindow::closeCamera);
    connect(ui->comboBox, &QComboBox::currentIndexChanged, this, &MainWindow::cameraChanged);
    connect(ui->capture, &QPushButton::clicked, this, &MainWindow::capture);
}


MainWindow::~MainWindow()
{
    delete ui;
}


//拿到所有摄像头设备并存入到comboBox中
void MainWindow::getAllCamera() {
    camera_list = QMediaDevices::videoInputs();
    for (const QCameraDevice& camera : camera_list) {
        qDebug() << camera.description();
        qDebug() << camera.id();
        ui->comboBox->addItem(camera.description());
    }
    my_captureSession = new QMediaCaptureSession;
    my_imageCapture = new QImageCapture;
    my_captureSession->setImageCapture(my_imageCapture);
    currentIndex = 0;
}


void MainWindow::cameraChanged(int index)
{
    currentIndex = index;
}

void MainWindow::openCamera()
{
    if (cameraState) {
        closeCamera();
    }
    camera = new QCamera(camera_list[currentIndex]);
    my_captureSession->setCamera(camera);
    my_captureSession->setVideoOutput(ui->widget);
    camera->start();
    cameraState = true;
}


void MainWindow::closeCamera()
{
    camera->stop();
    cameraState = false;
    delete camera;
}


void MainWindow::on_actionSave_Address_triggered()
{
    saveFileAddress = QFileDialog::getExistingDirectory(this, tr("Save Address Select"), tr(""));
    qDebug() << saveFileAddress;
}


void MainWindow::capture()
{
    if (!cameraState)
    {
        QMessageBox::warning(this, "Warning", tr("Capture fail！Camera not open!"));
        return;
    }
    QDateTime dateTime(QDateTime::currentDateTime());
    QString time = dateTime.toString("yyyy-MM-dd-hh-mm-ss");
    QString filename = saveFileAddress + QString("/%1.jpg").arg(time);
    qDebug() << filename;
    my_imageCapture->captureToFile(filename);
}

