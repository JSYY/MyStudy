import { App, Plugin } from 'vue';

export const getName = <T>(comp:T)=>{
  const c = comp as any;
  return c.name;
};

export const withInstall = <T>(comp: T) => {
  const c = comp as any;
  c.install = function(app: App) {
    const name = getName(c);
    app.component(name, comp);
  };
  return comp as T & Plugin;
};
