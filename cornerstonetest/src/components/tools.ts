import * as cornerstoneTools from '@cornerstonejs/tools';
const {WindowLevelTool,Enums,ZoomTool,PanTool,StackScrollMouseWheelTool} = cornerstoneTools;
const {MouseBindings} = Enums;
export function configTools(viewportID, renderingEngineId){
    const toolGroup = cornerstoneTools.ToolGroupManager.createToolGroup(viewportID);

    addTool(WindowLevelTool,toolGroup,MouseBindings.Auxiliary);
    addTool(ZoomTool,toolGroup,MouseBindings.Secondary);
    addTool(PanTool,toolGroup,MouseBindings.Primary_And_Secondary);
    addTool(StackScrollMouseWheelTool,toolGroup,null);
    toolGroup.addViewport(viewportID,renderingEngineId);
    toolGroup.setToolConfiguration(ZoomTool.toolName,{invert:true,zoomToCenter:true});
  }

function addTool(tool,toolGroup,mouse){
    if(!cornerstoneTools.state.tools[tool.toolName]){
        cornerstoneTools.addTool(tool);
    }
    toolGroup.addTool(tool.toolName);
    toolGroup.setToolActive(tool.toolName, {
        bindings: [
        {
            mouseButton: mouse
        },
        ],
    });
}

//ZoomTool 缩放
//PanTool 移动
//StackScrollMouseWheelTool 鼠标滚动监听
//WindowLevelTool 窗宽窗位
//LengthTool 测量两点距离
//BidirectionalTool 测量结构的宽度和长度
//RectangleRoiTool 矩形面积的测量和统计
//EllipseRoiTool 球体体积测量和统计信息
//ProbeTool 获取体素的底层值
 