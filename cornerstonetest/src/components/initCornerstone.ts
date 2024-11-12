import cornerstoneDICOMImageLoader from '@cornerstonejs/dicom-image-loader';
import * as cornerstone from '@cornerstonejs/core';
import dicomParser from 'dicom-parser';
import { init as renderInit, isCornerstoneInitialized} from '@cornerstonejs/core';
import { init as toolsInit } from '@cornerstonejs/tools';
export  async function init(){
    if(isCornerstoneInitialized()){
        return;
    }
    await renderInit();
    await toolsInit();
    initCornerstoneDICOMImageLoader();
}

function initCornerstoneDICOMImageLoader() {
    const { preferSizeOverAccuracy, useNorm16Texture } = cornerstone.getConfiguration().rendering;
    cornerstoneDICOMImageLoader.external.cornerstone = cornerstone;
    cornerstoneDICOMImageLoader.external.dicomParser = dicomParser;
    cornerstoneDICOMImageLoader.configure({
      useWebWorkers: true,
      decodeConfig: {
        convertFloatPixelDataToInt: false,
        use16BitDataType: preferSizeOverAccuracy || useNorm16Texture,
      },
    });

    let maxWebWorkers = 4;

    if (navigator.hardwareConcurrency) {
      maxWebWorkers = Math.min(navigator.hardwareConcurrency, 7);
    }

    var config = {
      maxWebWorkers,
      startWebWorkersOnDemand: false,
      taskConfiguration: {
        decodeTask: {
          initializeCodecsOnStartup: false,
          strict: false,
        },
      },
    };

    cornerstoneDICOMImageLoader.webWorkerManager.initialize(config);
}