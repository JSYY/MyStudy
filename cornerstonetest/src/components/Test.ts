import { ref, watch, h, render, onMounted, createVNode, onUnmounted } from "vue";
import {RenderingEngine,Enums as coreEnums,Types, StackViewport,cache,imageLoader,getRenderingEngine,volumeLoader} from '@cornerstonejs/core';
import {init} from "./initCornerstone";
import { configTools } from "./tools";
import { addMouseEventListener } from "./cursor";
import cornerstoneDICOMImageLoader from '@cornerstonejs/dicom-image-loader';
import * as cornerstoneTools from '@cornerstonejs/tools';
import axios from 'axios';

export default {
  name: "HelloWorld",
  props: {},
  setup() {
    let Id='ID';
    let filePath = ref();
    let renderingEngine;
    let viewport;
    const viewportInput = {
        viewportId:Id,
        element:null,
        type: coreEnums.ViewportType.STACK,
      };
    let options:any = {
        targetBuffer: {
          type:'Float32Array',
        },
        preScale: {
          enabled: true,
          scaled:false
        },
        useRGBA: false,
      };
    let url = "wadouri:http://localhost:8088/api/services/app/WADO/GetImage?data=1.2.156.112605.172056107401694.241017093809.4.52856.12457";

    onMounted(async () => {
        await init();
        initViewport();
        configTools(Id,Id);
        var doc = document.getElementById('dicomImage');
        addMouseEventListener(doc);
    });

    onUnmounted(()=>{
        cache.purgeCache();
        cornerstoneDICOMImageLoader.wadouri.fileManager.purge();
        cornerstoneDICOMImageLoader.wadouri.dataSetCacheManager.purge();
        cornerstoneTools.ToolGroupManager.destroyToolGroup(Id);
        renderingEngine?.destroy();
        if((window as any).image){
          (window as any).image = null;
        }
    });

    function dispose(){
        viewport.removeAllActors();
    }

    function getDirectoryFiles(path){
        return axios({
            url: '/GetDirectory?data='+path,
            params: null,
            method: 'get',
            timeout: 10000,
            headers: {
                'X-Requested-With': 'XMLHttpRequest',
            },
        });
    }

    function load(number){
        switch(number){
            case 0:
                loadByWADOUri(filePath.value);
                break;
            case 1:
                loadByHttpRequest(filePath.value);
                break;
            default:
                break;
        }
    }

    function getImage(path){
        return axios({
            url: '/GetImage?data='+path,
            params: null,
            method: 'get',
            timeout: 10000,
            headers: {
                'X-Requested-With': 'XMLHttpRequest',
                'Accept':'application/octet-stream'
            },
            responseType:'arraybuffer',
        });
    }

    function loadByWADOUri(path){
        let url='wadouri:http://localhost:8888/GetImage?data='+path;
        imageLoader.loadImage(url,options).then(image=>{
            viewport.renderImageObject(image);
            viewport.render();
        });
    }

    function loadByHttpRequest(path){
        getImage(path).then(res=>{
            let uint8Array=new Uint8Array(res.data);
            let file = new File([uint8Array],'');
            let imageID = cornerstoneDICOMImageLoader.wadouri.fileManager.add(file);
            imageLoader.loadImage(imageID,options).then(image=>{
                viewport.renderImageObject(image);
                viewport.render();
            });
        });
    }
    
    function initViewport(){
        if(!getRenderingEngine(Id)){
            renderingEngine = new RenderingEngine(Id);
          }else{
            renderingEngine = getRenderingEngine(Id) as RenderingEngine;
          }
          var doc = document.getElementById('dicomImage');
          viewportInput.element=doc;
          renderingEngine.enableElement(viewportInput);
          viewport = <Types.IStackViewport>renderingEngine.getViewport(Id) as StackViewport;
    }

    return {
        filePath,load,dispose
    };
  },
};