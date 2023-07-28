class DialogService {
    AddDialogComponent(ins: any, component: any, options?: any) {
        if (options) {
            ins!.appContext?.config?.globalProperties.$message(ins, component, options);
        } else {
            ins!.appContext?.config?.globalProperties.$message(ins, component, null);
        }
    }

    RemoveDialogComponent() {
        let dialogs = document.body.querySelectorAll('.dialog');
        if (dialogs.length>0) {
            let dialog = dialogs[dialogs.length-1];
            let child = dialog.firstChild;
            if(child){
                dialog.removeChild(child);
            }
            dialog.parentNode?.removeChild(dialog);
        }
    }
}
let DialogServices = new DialogService();
export { DialogServices };