# electronvue

## Project setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).

1.�״ΰ�װ��electron֮����Ҫ��װһ��tsloader������ᱨ��
2.��Ҫ��vue.config.js������node-polyfill-plugin,��ֹ�����Ҳ���electron
configureWebpack: {
        plugins: [new NodePolyfillPlugin()],
    },
3.����can not reslove fs path ʱ��Ҫ��vue.config.js������
pluginOptions: {
        electronBuilder: {
            nodeIntegration: true
        }
    },
