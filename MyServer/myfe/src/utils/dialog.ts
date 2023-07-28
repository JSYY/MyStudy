import { createVNode, render } from 'vue';
import type { App } from "vue";

//todo ֮�󱳾���ĳ����������Ҫ�Ż����������ÿ�ѡ��
const Message: any = function (ins: any, DialogComponent: any, options: any) {
    const container = document.createElement('div');
    const vm = createVNode(
        DialogComponent,
        options as any,
    );
    container.style.background = 'rgba(213, 213, 213, 0.88)';
    container.style.top = '40px';
    container.style.height = '80%';
    container.className = "dialog";
    container.style.width = '100%';
    container.style.zIndex = '99999';
    container.style.position = 'absolute';

    vm.appContext = ins.appContext;
    render(vm, container);
    var node = document.querySelector('#app');
    node?.appendChild(container);
}

const install = function (app: App) {
    app.config.globalProperties.$message = Message;
    return app;
};

export { install };