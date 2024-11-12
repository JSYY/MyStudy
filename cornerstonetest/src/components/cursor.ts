import {setCursorForElement} from '@cornerstonejs/tools/dist/esm/cursors/index'
import {setElementCursor} from '@cornerstonejs/tools/dist/esm/cursors/elementCursor'
import SVGMouseCursor from '@cornerstonejs/tools/dist/esm/cursors/SVGMouseCursor'
export function addMouseEventListener(element){
    element.addEventListener('mousedown',(e)=>{
        var cursorName = 'Default';
        switch(e.buttons){
          case MouseActionDefine.Left:
            break;
          case MouseActionDefine.Right:
            cursorName = 'Zoom';
            break;
          case MouseActionDefine.Middle:
            cursorName = 'WindowLevel';
            break;
          case MouseActionDefine.LR:
            cursorName = 'Pan';
            break;
        }
        var cursor = SVGMouseCursor.getDefinedCursor(cursorName,true,'white');
        setElementCursor(element,cursor);
    });
    element.addEventListener('mouseup',(e)=>{
        setCursorForElement(element,'Default');
    });
}

enum MouseActionDefine{
  Left = 1,
  Right = 2,
  Middle = 4,
  LR = 3,
}